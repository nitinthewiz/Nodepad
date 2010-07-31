using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nodepad
{
    public partial class EditorWindow : Form
    {
        public Node DocumentRoot;
        public Node CurrentNode;
        public IList<Style> Styles;
        public String preload_document = null;

        public EditorWindow(String[] args)
        {
            if (args.Length == 1)
                preload_document = args[0];

            this.Styles = load_styles();

            InitializeComponent();
        }

        public void load_document(Node root)
        {
            this.DocumentRoot = root;
            this.DocumentRoot.RealRenameDisabled = true;
            this.nodeTreeView.Nodes[0].Text = this.DocumentRoot.Name;
            build_node_tree(this.DocumentRoot, this.nodeTreeView.Nodes[0]);

            this.nodeTreeView.SelectedNode = this.nodeTreeView.Nodes[0];
            load_node(this.DocumentRoot);

            refresh_enabled_states();
        }

        public void unload_document()
        {
            this.DocumentRoot = null;
            this.CurrentNode = null;
            this.nodeTreeView.Nodes.Clear();
            this.nodeTreeView.Nodes.Add("No Document");
            this.nodeTreeView.SelectedNode = this.nodeTreeView.Nodes[0];
            this.editorBox.Text = "";
            refresh_enabled_states();
        }

        void nodeTreeView_BeforeLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
        {
            if (this.CurrentNode == null)
                e.CancelEdit = true;
        }

        void nodeTreeView_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
        {
            Node sn = (Node)e.Node.Tag;

            if (e.Label == null || e.Label == String.Empty || sn[e.Label] != null || e.Label == e.Node.Text)
                return;

            sn.Name = e.Label;
            this.nodeTreeView.SelectedNode = this.nodeTreeView.Nodes[0];
            build_node_tree(sn, e.Node);
            this.nodeTreeView.SelectedNode = e.Node;
            
            refresh_enabled_states();
        }

        private MouseButtons _dragging_with_buttons = MouseButtons.None;
        void nodeTreeView_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            this._dragging_with_buttons = e.Button;
            this.DoDragDrop(e.Item, DragDropEffects.All | DragDropEffects.Link);
        }

        void nodeTreeView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop, false))
            {
                e.Effect = System.Windows.Forms.DragDropEffects.All;
            }
            else if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                e.Effect = this.effect_by_mod_state;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        void nodeTreeView_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop, false))
                return;

            if (!e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            TreeView stv = (TreeView)sender;
            TreeNode dest_node = stv.GetNodeAt(stv.PointToClient(new Point(e.X, e.Y)));
            TreeNode drag_node = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode", false);
            
            if (dest_node.Equals(drag_node) || dest_node.Equals(drag_node.Parent))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            
            if (has_parent_node(dest_node, drag_node))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            e.Effect = this.effect_by_mod_state;
        }

        private bool has_parent_node(TreeNode child, TreeNode possible_parent)
        {
            TreeNode cursor = child;
            while (cursor.Parent != null)
            {
                cursor = cursor.Parent;
                if (cursor.Equals(possible_parent))
                    return true;
            }
            return false;
        }


        void nodeTreeView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop, false))
            {
                String[] accepted_paths = (String[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop, false);
                if (accepted_paths.Length == 1 && System.IO.Directory.Exists(accepted_paths[0]))
                {
                    load_document(new Node(accepted_paths[0]));
                }
            }
            else if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                TreeView stv = (TreeView)sender;
                TreeNode dest_tn = stv.GetNodeAt(stv.PointToClient(new Point(e.X, e.Y)));
                TreeNode drag_tn = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode", false);
                String drag_name = drag_tn.Text;
                Node drag_node = (Node)drag_tn.Tag;
                Node dest_node = (Node)dest_tn.Tag;

                switch (e.Effect)
                {
                    case (DragDropEffects.Copy | DragDropEffects.Link):
                        drag_node.AliasTo(dest_node);
                        break;
                    case DragDropEffects.Move:
                        drag_node.MoveTo(dest_node);
                        ((Node)drag_tn.Parent.Tag).RefreshChildCache();
                        break;
                    case DragDropEffects.Copy:
                        drag_node.CopyTo(dest_node);
                        break;
                    case DragDropEffects.Link:
                        drag_node.LinkTo(dest_node);
                        break;
                }

                rebuild_node_tree(dest_tn);
                foreach (TreeNode new_tn in dest_tn.Nodes)
                {
                    if (new_tn.Text.Contains(drag_name))
                    {
                        this.nodeTreeView.SelectedNode = new_tn;
                        break;
                    }
                }

                if(drag_node.Destroyed)
                    drag_tn.Remove();
            }
        }

        public void build_node_tree(Node parent, TreeNode insert_point)
        {
            refresh_treenode(parent, insert_point);
            refresh_treenode_children(parent, insert_point);
        }

        public void refresh_treenode(Node parent, TreeNode insert_point)
        {
            insert_point.Tag = parent;
            refresh_node_icons(insert_point, parent.HasContent, parent.IsBadLink);

            insert_point.NodeFont = new Font(this.nodeTreeView.Font, (parent.IsLink && !parent.IsAliased) ? FontStyle.Italic : FontStyle.Regular);
        }

        public void refresh_treenode_children(Node parent, TreeNode insert_point)
        {
            List<String> opened_nodes = new List<String>();
            foreach (TreeNode tn in insert_point.Nodes)
            {
                if (tn.IsExpanded)
                    opened_nodes.Add(tn.Text);
            }

            insert_point.Nodes.Clear();
            parent.RefreshChildCache();
            foreach (Node child in parent.Children)
            {
                TreeNode child_tn = new TreeNode(child.Name);
                insert_point.Nodes.Add(child_tn);
                refresh_treenode(child, child_tn);
                if (opened_nodes.Contains(child_tn.Text))
                {
                    child_tn.Expand();
                    refresh_treenode_children(child, child_tn);
                }
                else
                {
                    preview_treenode_child_state(child, child_tn);
                }
            }
        }

        public void preview_treenode_child_state(Node parent, TreeNode insert_point)
        {
            insert_point.Nodes.Clear();
            if (parent.HasChildren)
                insert_point.Nodes.Add("__Dummy");
        }

        void nodeTreeView_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            if (!this.nodeTreeView.SelectedNode.Equals(e.Node))
                rebuild_node_tree(e.Node);
        }

        public void rebuild_node_tree(TreeNode insert_point)
        {
            if (insert_point.Tag == null)
                return;

            build_node_tree((Node)insert_point.Tag, insert_point);
        }

        void refresh_node_icons(TreeNode tn, bool has_content, bool is_bad_link)
        {
            if (has_content)
            {
                tn.ImageIndex = 0;
                tn.SelectedImageIndex = 1;
            }
            else if (is_bad_link)
            {
                tn.ImageIndex = 4;
                tn.SelectedImageIndex = 5;
            }
            else
            {
                tn.ImageIndex = 2;
                tn.SelectedImageIndex = 3;
            }
        }

        void refresh_node_icons(TreeNode tn, bool has_content)
        {
            refresh_node_icons(tn, has_content, false);
        }

        private String StyleConfigPath
        {
            get { return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Nodepad.styles.txt"); }
        }

        public IList<Style> load_styles()
        {
            List<Style> ss = new List<Style>();

            if (System.IO.File.Exists(this.StyleConfigPath))
            {
                String[] style_tokens;
                foreach (String style_str in System.IO.File.ReadAllLines(this.StyleConfigPath))
                {
                    style_tokens = style_str.Split(',');
                    ss.Add(new Style(style_tokens[0], new Font(style_tokens[1], float.Parse(style_tokens[2])), Color.FromArgb(int.Parse(style_tokens[3]), int.Parse(style_tokens[4]), int.Parse(style_tokens[5])), (HorizontalAlignment)Enum.Parse(typeof(HorizontalAlignment), style_tokens[6])));
                }
            }

            if (ss.Count == 0)
            {
                ss.Add(new Style("Plain", new Font("Georgia", (float)14.0), Color.Black, HorizontalAlignment.Left));
                ss.Add(new Style("Note", new Font("Arial", (float)10.0), Color.Black, HorizontalAlignment.Left));
                ss.Add(new Style("Header", new Font("Verdana", (float)18.0), Color.FromArgb(64, 64, 64), HorizontalAlignment.Left));
                ss.Add(new Style("Aside", new Font("Trebuchet MS", (float)9.0), Color.Gray, HorizontalAlignment.Left));
                ss.Add(new Style("Code", new Font("Lucida Console", (float)8.0), Color.Black, HorizontalAlignment.Left));
            }

            return ss;
        }

        public void save_styles()
        {
            List<String> style_strs = new List<string>();
            foreach (Style s in this.Styles)
                style_strs.Add(s.Name + "," + s.Font.FontFamily.Name + "," + s.Font.Size.ToString() + "," + s.Color.R + "," + s.Color.G + "," + s.Color.B + "," + s.Alignment.ToString());
            System.IO.File.WriteAllLines(this.StyleConfigPath, style_strs.ToArray());
        }

        private void editStyleButton_Click(object sender, EventArgs e)
        {
            edit_styles();
        }

        private void edit_styles()
        {
            StyleEditor se = new StyleEditor(Styles);

            if (styleListBox.Text != String.Empty)
            {
                se.SelectStyle((Style)styleListBox.SelectedItem);
            }

            se.ShowDialog();

            this.Styles = se.Styles;
            refresh_style_list();
        }

        private void refresh_style_list()
        {
            styleListBox.Items.Clear();
            styleListBox.Items.Add(Style.Empty());
            foreach (Style s in Styles)
                styleListBox.Items.Add(s);

            ToolStripItemCollection ddi = styleToolStripMenuItem.DropDownItems;
            ToolStripItem ddi_header = ddi[0];
            ddi.Clear();
            ddi.Add(ddi_header);
            ToolStripMenuItem mi = null;
            ddi.Add(new ToolStripSeparator());
            for (int i = 0; i < Math.Min(Styles.Count, 11); i++)
            {
                mi = new ToolStripMenuItem(Styles[i].Name);
                mi.Name = Styles[i].Name;
                mi.Tag = Styles[i];
                mi.ShortcutKeys = Keys.Alt | (Keys.D1 + i);
                mi.Click += new EventHandler(styleMenuItem_Click);
                ddi.Add(mi);
            }
        }

        void styleMenuItem_Click(object sender, EventArgs e)
        {
            styleListBox.SelectedItem = ((ToolStripMenuItem)sender).Tag;
        }

        private void EditorWindow_Load(object sender, EventArgs e)
        {
            refresh_style_list();
            styleListBox.SelectedIndex = 1;
            ((Style)styleListBox.SelectedItem).ApplyAsDefault(editorBox);

            refresh_enabled_states();

            if (preload_document != null)
            {
                Timer delayed_load = new Timer();
                delayed_load.Interval = 1;
                delayed_load.Tick += new EventHandler(delayed_load_Tick);
                delayed_load.Start();
            }
        }

        private void delayed_load_Tick(object sender, EventArgs e)
        {
            load_document(new Node(preload_document));
            ((Timer)sender).Stop();
        }
        
        private void load_node(Node n)
        {
            if (n.Destroyed)
            {
                if (nodeTreeView.SelectedNode.Level > 0)
                    nodeTreeView.SelectedNode = nodeTreeView.SelectedNode.Parent;
                else
                    unload_document();

                return;
            }

            this.CurrentNode = n;
            this.editorBox.Rtf = (this.CurrentNode != null) ? this.CurrentNode.Content : "";

            refresh_enabled_states();
        }

        void editorBox_TextChanged(object sender, System.EventArgs e)
        {
            if (this.editorBox.Focused && (this.nodeTreeView.SelectedNode != null) && (this.CurrentNode != null))
            {
                refresh_node_icons(this.nodeTreeView.SelectedNode, this.editorBox.TextLength > 0, this.CurrentNode.IsBadLink);
                this.CurrentNode.UpdateContentTime();
                refresh_enabled_states();
            }
        }

        private void styleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (styleListBox.SelectedIndex != 0)
                ((Style)styleListBox.SelectedItem).Apply(editorBox);

            editorBox.Focus();
        }

        void editorBox_SelectionChanged(object sender, System.EventArgs e)
        {
            refresh_enabled_states();

            Style sel_style = new Style(editorBox);

            foreach (Style s in styleListBox.Items)
            {
                if (s.Equivalent(sel_style))
                {
                    styleListBox.SelectedItem = s;
                    return;
                }
            }
        }

        private void boldButton_Click(object sender, EventArgs e)
        {
            editor_toggle_bold();
        }

        private void editor_toggle_bold()
        {
            if (editorBox.SelectionFont == null)
                return;

            editorBox.SelectionFont = new Font(editorBox.SelectionFont, editorBox.SelectionFont.Style ^ FontStyle.Bold);
        }

        private void italicButton_Click(object sender, EventArgs e)
        {
            editor_toggle_italics();
        }

        private void editor_toggle_italics()
        {
            if (editorBox.SelectionFont == null)
                return;

            editorBox.SelectionFont = new Font(editorBox.SelectionFont, editorBox.SelectionFont.Style ^ FontStyle.Italic);
        }

        private void highlightButton_Click(object sender, EventArgs e)
        {
            editor_toggle_highlight();
        }

        private void editor_toggle_highlight()
        {
            editorBox.SelectionBackColor = (editorBox.SelectionBackColor.Equals(Color.Yellow)) ? editorBox.BackColor : Color.Yellow;
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            editorBox.SelectionBullet ^= true;
        }

        private void editStylesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit_styles();
        }

        private void createFromSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            create_node();
        }

        private void createNodeButton_Click(object sender, EventArgs e)
        {
            create_node();
        }

        private void create_node()
        {
            if (this.CurrentNode == null || this.editorBox.SelectionLength == 0)
                return;

            Node last_n = create_node_from_chunk_text(this.CurrentNode, this.editorBox.SelectedText);

            this.editorBox.SelectedText = "";

            build_node_tree(this.CurrentNode, this.nodeTreeView.SelectedNode);
            if (last_n.HasContent)
                foreach (TreeNode tn in this.nodeTreeView.SelectedNode.Nodes)
                if((Node)tn.Tag == last_n)
                {
                    this.nodeTreeView.SelectedNode = tn;
                    break;
                }

            if(this.CurrentNode.Name.Equals(this.default_child_name))
                rename_node();
        }

        private char[] sentence_separators = new char[]{ '.', '!', '?' };
        private String[] paragraph_separators = new String[] { "\n\n" };
        private char[] line_separators = new char[] { '\n' };
        private String default_child_name = "New node";

        private Node create_node_from_chunk_text(Node parent, String chunk_text)
        {

            String[] paragraphs = chunk_text.Split(paragraph_separators, StringSplitOptions.RemoveEmptyEntries);
            if (paragraphs.Length > 1)
                return create_nodes_from_paragraphs(parent, paragraphs);

            String[] lines = chunk_text.Split(line_separators, StringSplitOptions.RemoveEmptyEntries);
            return create_nodes_from_lines(parent, lines);
        }

        private Node create_nodes_from_paragraphs(Node parent, String[] paragraphs)
        {
            List<List<String>> par_groups = new List<List<String>>();

            List<String> last_pargroup = new List<String>();
            par_groups.Add(last_pargroup);

            foreach(String par in paragraphs)
            {
                if(!(is_multisentence(par)) && par.Trim().Length > 0 && last_pargroup.Count > 0)
                {
                    last_pargroup = new List<String>();
                    par_groups.Add(last_pargroup);
                }
                last_pargroup.Add(par);
            }

            String name;
            Node last_node = null;
            Node recent_node;
            foreach(List<String> par_group in par_groups)
            {
                if(par_group.Count == 0)
                    continue;

                name = par_group[0].Trim();

                if (!(is_multisentence(name)))
                {
                    par_group.RemoveAt(0);
                    recent_node = create_node_from_name_and_par_group(parent, name, par_group);
                }
                else
                {
                    recent_node = create_nodes_from_lines(parent, par_group.ToArray());
                }

                if(recent_node != null)
                    last_node = recent_node;
            }

            return last_node;
        }

        private Node create_nodes_from_lines(Node parent, String[] lines)
        {
            Node last_n = null;
            Node n = null;
            foreach (String line in lines)
            {
                n = create_node_from_line(parent, line);
                if (n != null)
                    last_n = n;
            }
            return last_n;
        }

        private bool is_multisentence(String text)
        {
            // I can't decide whether to remove empty entries. Is a single sentence a paragraph? I think so. Can it be used as a title? Yes!
            return (text.Split(sentence_separators, StringSplitOptions.RemoveEmptyEntries).Length > 1);
        }

        private char[] line_specifier_separator = new char[] { ':' };
        private Node create_node_from_line(Node parent, String line)
        {
            if (line.Trim().Length == 0)
                return null;

            String[] kv = line.Split(line_specifier_separator, StringSplitOptions.RemoveEmptyEntries);
            if(kv.Length == 2 && !is_multisentence(kv[0]))
                return create_node_from_name_and_content(parent, kv[0].Trim(), kv[1].Trim());

            if(is_multisentence(line))
                return create_node_from_name_and_content(parent, this.default_child_name, line.Trim());

            return create_node_from_name_and_content(parent, line.Trim(), "");
        }

        private Node create_node_from_name_and_content(Node parent, String name, String content)
        {
            if (name.Length == 0)
                return null;

            if (content.Length > 0)
                content = map_text_to_rtf(content);

            return parent.CreateChild(name, content);
        }

        private Node create_node_from_name_and_par_group(Node parent, String name, List<String> par_group)
        {
            if (name.Length == 0)
                return null;

            RichTextBox virt_box = new RichTextBox();
            foreach (String par in par_group)
            {
                virt_box.Select(Math.Max(virt_box.Text.Length - 1, 0), 0);
                virt_box.SelectedText = "\n\n";
                virt_box.Select(Math.Max(virt_box.Text.Length - 1, 0), 0);
                virt_box.SelectedRtf = map_text_to_rtf(par.Trim());
            }

            return parent.CreateChild(name, virt_box.Rtf);
        }


        private String map_text_to_rtf(String content)
        {
            int old_start = this.editorBox.SelectionStart;
            int old_len = this.editorBox.SelectionLength;

            this.editorBox.SelectionStart = this.editorBox.Text.IndexOf(content);
            this.editorBox.SelectionLength = content.Length;

            content = this.editorBox.SelectedRtf;

            this.editorBox.SelectionStart = old_start;
            this.editorBox.SelectionLength = old_len;

            return content;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "Select a folder to be the root of your document.";
            if(fb.ShowDialog() == DialogResult.OK)
                load_document(new Node(fb.SelectedPath));
        }

        private void editorBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (!this.editorBox.Enabled || !e.Control || e.Shift || e.Alt)
                return;

            e.SuppressKeyPress = true;
            switch (e.KeyCode)
            {
                case Keys.H:
                    editor_toggle_highlight();
                    break;
                case Keys.I:
                    editor_toggle_italics();
                    break;
                case Keys.B:
                    editor_toggle_bold();
                    break;

                // Don't let the user re-align paragraphs
                case Keys.L:
                    break;
                case Keys.E:
                    break;
                case Keys.R:
                    break;

                default:
                    e.SuppressKeyPress = false;
                    break;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        void EditorWindow_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            save_content();
            save_styles();
        }

        private void save_content()
        {
            if (this.CurrentNode == null || this.CurrentNode.Destroyed)
                return;

            this.CurrentNode.Content = (this.editorBox.TextLength != 0) ? this.editorBox.Rtf : String.Empty;
        }

        private void refresh_enabled_states()
        {
            bool en = !((this.DocumentRoot == null) || (this.CurrentNode == null) || this.CurrentNode.IsBadLink || (this.CurrentNode.HasBeenUpdatedElsewhere));
            this.editorBox.Enabled = en;
            this.editorBox.ReadOnly = !(en);
            this.editorToolstrip.Enabled = en;
            this.nodeToolStripMenuItem.Enabled = en;
            this.nodeTreeView.LabelEdit = en;
            this.reloadToolStripMenuItem.Enabled = (this.DocumentRoot != null);
            this.exportToolStripMenuItem.Enabled = (this.DocumentRoot != null);
            this.sortByToolStripMenuItem.Enabled = (this.CurrentNode != null);
            this.createFromSelectionToolStripMenuItem.Enabled = this.createNodeButton.Enabled = (this.CurrentNode != null) && (this.editorBox.SelectionLength > 0);
            this.rerootToolStripMenuItem.Enabled = (this.CurrentNode != null);

            if (en)
            {
                String sort_method = Node.InverseChildrenSort[this.CurrentNode.SortChildren];
                foreach (ToolStripMenuItem mi in this.sortByToolStripMenuItem.DropDownItems)
                    mi.Checked = sort_method.Equals((String)mi.Tag);
            }

            if(this.CurrentNode != null)
                this.Text = this.DocumentRoot.Name + (this.DocumentRoot.Equals(this.CurrentNode) ? "" : (": " + this.CurrentNode.Name)) + " - Nodepad";
            this.launchToolStripMenuItem.Enabled = (this.CurrentNode != null) && this.CurrentNode.HasLauncher;
            this.removeLaunchTargetToolStripMenuItem.Enabled = (this.CurrentNode != null) && this.CurrentNode.HasLauncher;
        }

        private void nodeTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            save_content();

            if (e.Node == null || e.Node.Tag == null)
                return;

            rebuild_node_tree(e.Node);

            load_node((Node)e.Node.Tag);
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rename_node();
        }

        private void rename_node()
        {
            if (this.nodeTreeView.LabelEdit)
                this.nodeTreeView.SelectedNode.BeginEdit();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String old_pos = this.nodeTreeView.SelectedNode.FullPath;
            load_document(new Node(this.DocumentRoot.Path));
        }

        private void launchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.CurrentNode.HasLauncher)
                return;

            String launch_path = this.CurrentNode.LaunchItem;
            if (!System.IO.File.Exists(launch_path))
            {
                this.CurrentNode.LaunchItem = "";
                MessageBox.Show("The launch target for this node has been moved or deleted.", "Launch Target Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                refresh_enabled_states();
                return;
            }

            String cur_cd = System.IO.Directory.GetCurrentDirectory();
            System.IO.Directory.SetCurrentDirectory(this.CurrentNode.Path);
            System.Diagnostics.Process.Start(this.CurrentNode.LaunchItem);
            System.IO.Directory.SetCurrentDirectory(cur_cd);
        }

        private void exploreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CurrentNode == null)
                return;

            System.Diagnostics.Process.Start(((Node)this.nodeTreeView.SelectedNode.Tag).Path);
        }

        private void shellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd.exe", "/k cd \"" + ((Node)this.nodeTreeView.SelectedNode.Tag).Path + "\"");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.nodeTreeView.SelectedNode.Level == 0)
                return;

            delete_node();
        }

        void nodeTreeView_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (!this.nodeTreeView.Enabled)
                return;

            if(this.nodeTreeView.SelectedNode != null && e.KeyCode == Keys.Delete)
            {
                delete_node();
                e.Handled = true;
            }
        }

        private DragDropEffects effect_by_mod_state
        {
            get
            {
                if ((this._dragging_with_buttons & MouseButtons.Right) > 0)
                    return DragDropEffects.Link | DragDropEffects.Copy;
                if ((Control.ModifierKeys & Keys.Shift) > 0)
                    return DragDropEffects.Copy;
                if ((Control.ModifierKeys & Keys.Control) > 0)
                    return DragDropEffects.Link;
                return DragDropEffects.Move;
            }
        }

        private void delete_node()
        {
            TreeNode sn = this.nodeTreeView.SelectedNode;

            if (sn == null || sn.Level == 0)
                return;

            TreeNode pn = sn.Parent;

            Node n = (Node)sn.Tag;

            if (!(n.IsLink || n.IsAliased) && MessageBox.Show("Remove this node, all its children, and any resources it may have?", "Delete node?", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            n.Destroy();
            sn.Remove();

            ((Node)pn.Tag).RefreshChildCache();
        }

        private void sortOptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CurrentNode.SortChildren = Node.ChildrenSort[((String)((ToolStripMenuItem)sender).Tag)];
            rebuild_node_tree(this.nodeTreeView.SelectedNode);
            refresh_enabled_states();
        }

        private void rerootHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_document(this.CurrentNode);
        }

        private void rerootInParentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.nodeTreeView.SelectedNode.Parent != null)
            {
                load_document((Node)this.nodeTreeView.SelectedNode.Parent.Tag);
            }
            else
            {
                load_document(new Node(System.IO.Path.GetDirectoryName(this.CurrentNode.Path)));
            }

        }

        private void setLaunchTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (launchTargetSelectorBox.ShowDialog() == DialogResult.OK)
            {
                this.CurrentNode.LaunchItem = launchTargetSelectorBox.FileName;
                refresh_enabled_states();
            }
        }

        private void removeLaunchTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CurrentNode.LaunchItem = "";
            refresh_enabled_states();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.exportFileDialog.ShowDialog() == DialogResult.OK)
            {
                save_content();
                String output_doc = this.DocumentRoot.GenerateHtml();
                System.IO.File.WriteAllText(this.exportFileDialog.FileName, output_doc);
            }
        }

        void editorBox_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

    }
}