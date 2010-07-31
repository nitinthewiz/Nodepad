namespace Nodepad
{
    partial class EditorWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorWindow));
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("No Document");
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.editorBox = new System.Windows.Forms.RichTextBox();
            this.editorToolstrip = new System.Windows.Forms.ToolStrip();
            this.createNodeButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.styleListBox = new System.Windows.Forms.ToolStripComboBox();
            this.editStyleButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.boldButton = new System.Windows.Forms.ToolStripButton();
            this.italicButton = new System.Windows.Forms.ToolStripButton();
            this.highlightButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.listButton = new System.Windows.Forms.ToolStripButton();
            this.editorSplitter = new System.Windows.Forms.SplitContainer();
            this.nodeTreeView = new System.Windows.Forms.TreeView();
            this.treeImages = new System.Windows.Forms.ImageList(this.components);
            this.editorMenu = new System.Windows.Forms.MenuStrip();
            this.documentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFromSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.launcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setLaunchTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLaunchTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rerootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rerootHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rerootInParentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.sortByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lengthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostchildrenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentlyupdatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostEditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.styleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editStylesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchTargetSelectorBox = new System.Windows.Forms.OpenFileDialog();
            this.exportFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.editorToolstrip.SuspendLayout();
            this.editorSplitter.Panel1.SuspendLayout();
            this.editorSplitter.Panel2.SuspendLayout();
            this.editorSplitter.SuspendLayout();
            this.editorMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.editorBox);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(520, 378);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(520, 403);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.editorToolstrip);
            // 
            // editorBox
            // 
            this.editorBox.AcceptsTab = true;
            this.editorBox.BulletIndent = 24;
            this.editorBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorBox.EnableAutoDragDrop = true;
            this.editorBox.Enabled = false;
            this.editorBox.HideSelection = false;
            this.editorBox.Location = new System.Drawing.Point(0, 0);
            this.editorBox.Name = "editorBox";
            this.editorBox.ShowSelectionMargin = true;
            this.editorBox.Size = new System.Drawing.Size(520, 378);
            this.editorBox.TabIndex = 0;
            this.editorBox.Text = "";
            this.editorBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.editorBox_LinkClicked);
            this.editorBox.SelectionChanged += new System.EventHandler(this.editorBox_SelectionChanged);
            this.editorBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editorBox_KeyDown);
            this.editorBox.TextChanged += new System.EventHandler(this.editorBox_TextChanged);
            // 
            // editorToolstrip
            // 
            this.editorToolstrip.Dock = System.Windows.Forms.DockStyle.None;
            this.editorToolstrip.Enabled = false;
            this.editorToolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNodeButton,
            this.toolStripSeparator3,
            this.styleListBox,
            this.editStyleButton,
            this.toolStripSeparator1,
            this.boldButton,
            this.italicButton,
            this.highlightButton,
            this.toolStripSeparator2,
            this.listButton});
            this.editorToolstrip.Location = new System.Drawing.Point(0, 0);
            this.editorToolstrip.Name = "editorToolstrip";
            this.editorToolstrip.Size = new System.Drawing.Size(520, 25);
            this.editorToolstrip.Stretch = true;
            this.editorToolstrip.TabIndex = 0;
            // 
            // createNodeButton
            // 
            this.createNodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.createNodeButton.Image = ((System.Drawing.Image)(resources.GetObject("createNodeButton.Image")));
            this.createNodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.createNodeButton.Name = "createNodeButton";
            this.createNodeButton.Size = new System.Drawing.Size(23, 22);
            this.createNodeButton.Text = "N";
            this.createNodeButton.ToolTipText = "Create Node from Selection";
            this.createNodeButton.Click += new System.EventHandler(this.createNodeButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // styleListBox
            // 
            this.styleListBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.styleListBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.styleListBox.Name = "styleListBox";
            this.styleListBox.Size = new System.Drawing.Size(121, 25);
            this.styleListBox.SelectedIndexChanged += new System.EventHandler(this.styleListBox_SelectedIndexChanged);
            // 
            // editStyleButton
            // 
            this.editStyleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editStyleButton.Image = ((System.Drawing.Image)(resources.GetObject("editStyleButton.Image")));
            this.editStyleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editStyleButton.Name = "editStyleButton";
            this.editStyleButton.Size = new System.Drawing.Size(23, 22);
            this.editStyleButton.Text = "Edit";
            this.editStyleButton.ToolTipText = "Edit Style";
            this.editStyleButton.Click += new System.EventHandler(this.editStyleButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // boldButton
            // 
            this.boldButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.boldButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.boldButton.Image = ((System.Drawing.Image)(resources.GetObject("boldButton.Image")));
            this.boldButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.boldButton.Name = "boldButton";
            this.boldButton.Size = new System.Drawing.Size(23, 22);
            this.boldButton.Text = "B";
            this.boldButton.ToolTipText = "Toggle Bold";
            this.boldButton.Click += new System.EventHandler(this.boldButton_Click);
            // 
            // italicButton
            // 
            this.italicButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.italicButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.italicButton.Image = ((System.Drawing.Image)(resources.GetObject("italicButton.Image")));
            this.italicButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.italicButton.Name = "italicButton";
            this.italicButton.Size = new System.Drawing.Size(23, 22);
            this.italicButton.Text = "I";
            this.italicButton.ToolTipText = "Toggle Italics";
            this.italicButton.Click += new System.EventHandler(this.italicButton_Click);
            // 
            // highlightButton
            // 
            this.highlightButton.BackColor = System.Drawing.Color.Yellow;
            this.highlightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.highlightButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.highlightButton.Image = ((System.Drawing.Image)(resources.GetObject("highlightButton.Image")));
            this.highlightButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.highlightButton.Name = "highlightButton";
            this.highlightButton.Size = new System.Drawing.Size(23, 22);
            this.highlightButton.Text = "Hi";
            this.highlightButton.ToolTipText = "Toggle Highlight";
            this.highlightButton.Click += new System.EventHandler(this.highlightButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // listButton
            // 
            this.listButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.listButton.Image = ((System.Drawing.Image)(resources.GetObject("listButton.Image")));
            this.listButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.listButton.Name = "listButton";
            this.listButton.Size = new System.Drawing.Size(23, 22);
            this.listButton.Text = "L";
            this.listButton.ToolTipText = "Toggle List";
            this.listButton.Click += new System.EventHandler(this.listButton_Click);
            // 
            // editorSplitter
            // 
            this.editorSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorSplitter.Location = new System.Drawing.Point(0, 24);
            this.editorSplitter.Name = "editorSplitter";
            // 
            // editorSplitter.Panel1
            // 
            this.editorSplitter.Panel1.Controls.Add(this.nodeTreeView);
            // 
            // editorSplitter.Panel2
            // 
            this.editorSplitter.Panel2.Controls.Add(this.toolStripContainer1);
            this.editorSplitter.Size = new System.Drawing.Size(687, 403);
            this.editorSplitter.SplitterDistance = 163;
            this.editorSplitter.TabIndex = 1;
            this.editorSplitter.TabStop = false;
            // 
            // nodeTreeView
            // 
            this.nodeTreeView.AllowDrop = true;
            this.nodeTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeTreeView.HideSelection = false;
            this.nodeTreeView.ImageIndex = 0;
            this.nodeTreeView.ImageList = this.treeImages;
            this.nodeTreeView.Location = new System.Drawing.Point(0, 0);
            this.nodeTreeView.Name = "nodeTreeView";
            treeNode2.Name = "root";
            treeNode2.Text = "No Document";
            this.nodeTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.nodeTreeView.PathSeparator = "/";
            this.nodeTreeView.SelectedImageIndex = 1;
            this.nodeTreeView.Size = new System.Drawing.Size(163, 403);
            this.nodeTreeView.TabIndex = 2;
            this.nodeTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.nodeTreeView_DragDrop);
            this.nodeTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.nodeTreeView_BeforeExpand);
            this.nodeTreeView.DragOver += new System.Windows.Forms.DragEventHandler(this.nodeTreeView_DragOver);
            this.nodeTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.nodeTreeView_AfterLabelEdit);
            this.nodeTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.nodeTreeView_AfterSelect);
            this.nodeTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.nodeTreeView_DragEnter);
            this.nodeTreeView.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.nodeTreeView_BeforeLabelEdit);
            this.nodeTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nodeTreeView_KeyDown);
            this.nodeTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.nodeTreeView_ItemDrag);
            // 
            // treeImages
            // 
            this.treeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImages.ImageStream")));
            this.treeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.treeImages.Images.SetKeyName(0, "");
            this.treeImages.Images.SetKeyName(1, "");
            this.treeImages.Images.SetKeyName(2, "white.sphere.flat.png");
            this.treeImages.Images.SetKeyName(3, "white.shiny.sphere.flat.png");
            this.treeImages.Images.SetKeyName(4, "red.sphere.png");
            this.treeImages.Images.SetKeyName(5, "orange.sphere.png");
            // 
            // editorMenu
            // 
            this.editorMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentToolStripMenuItem,
            this.nodeToolStripMenuItem,
            this.styleToolStripMenuItem});
            this.editorMenu.Location = new System.Drawing.Point(0, 0);
            this.editorMenu.Name = "editorMenu";
            this.editorMenu.Size = new System.Drawing.Size(687, 24);
            this.editorMenu.TabIndex = 2;
            // 
            // documentToolStripMenuItem
            // 
            this.documentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator4,
            this.reloadToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.documentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("documentToolStripMenuItem.Image")));
            this.documentToolStripMenuItem.Name = "documentToolStripMenuItem";
            this.documentToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.documentToolStripMenuItem.Text = "&Document";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(153, 6);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reloadToolStripMenuItem.Image")));
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.reloadToolStripMenuItem.Text = "&Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportToolStripMenuItem.Image")));
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.exportToolStripMenuItem.Text = "&Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.exitToolStripMenuItem.Text = "&Quit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // nodeToolStripMenuItem
            // 
            this.nodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createFromSelectionToolStripMenuItem,
            this.toolStripSeparator5,
            this.launcherToolStripMenuItem,
            this.exploreToolStripMenuItem,
            this.shellToolStripMenuItem,
            this.rerootToolStripMenuItem,
            this.toolStripSeparator6,
            this.sortByToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.nodeToolStripMenuItem.Enabled = false;
            this.nodeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nodeToolStripMenuItem.Image")));
            this.nodeToolStripMenuItem.Name = "nodeToolStripMenuItem";
            this.nodeToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.nodeToolStripMenuItem.Text = "&Node";
            // 
            // createFromSelectionToolStripMenuItem
            // 
            this.createFromSelectionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("createFromSelectionToolStripMenuItem.Image")));
            this.createFromSelectionToolStripMenuItem.Name = "createFromSelectionToolStripMenuItem";
            this.createFromSelectionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.createFromSelectionToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.createFromSelectionToolStripMenuItem.Text = "&Create from Selection";
            this.createFromSelectionToolStripMenuItem.Click += new System.EventHandler(this.createFromSelectionToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(214, 6);
            // 
            // launcherToolStripMenuItem
            // 
            this.launcherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchToolStripMenuItem,
            this.setLaunchTargetToolStripMenuItem,
            this.removeLaunchTargetToolStripMenuItem});
            this.launcherToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("launcherToolStripMenuItem.Image")));
            this.launcherToolStripMenuItem.Name = "launcherToolStripMenuItem";
            this.launcherToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.launcherToolStripMenuItem.Text = "&Launcher";
            // 
            // launchToolStripMenuItem
            // 
            this.launchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("launchToolStripMenuItem.Image")));
            this.launchToolStripMenuItem.Name = "launchToolStripMenuItem";
            this.launchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.launchToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.launchToolStripMenuItem.Text = "&Launch";
            this.launchToolStripMenuItem.Click += new System.EventHandler(this.launchToolStripMenuItem_Click);
            // 
            // setLaunchTargetToolStripMenuItem
            // 
            this.setLaunchTargetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("setLaunchTargetToolStripMenuItem.Image")));
            this.setLaunchTargetToolStripMenuItem.Name = "setLaunchTargetToolStripMenuItem";
            this.setLaunchTargetToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.setLaunchTargetToolStripMenuItem.Text = "&Set Launch target...";
            this.setLaunchTargetToolStripMenuItem.Click += new System.EventHandler(this.setLaunchTargetToolStripMenuItem_Click);
            // 
            // removeLaunchTargetToolStripMenuItem
            // 
            this.removeLaunchTargetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeLaunchTargetToolStripMenuItem.Image")));
            this.removeLaunchTargetToolStripMenuItem.Name = "removeLaunchTargetToolStripMenuItem";
            this.removeLaunchTargetToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.removeLaunchTargetToolStripMenuItem.Text = "&Remove Launch target";
            this.removeLaunchTargetToolStripMenuItem.Click += new System.EventHandler(this.removeLaunchTargetToolStripMenuItem_Click);
            // 
            // exploreToolStripMenuItem
            // 
            this.exploreToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exploreToolStripMenuItem.Image")));
            this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
            this.exploreToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exploreToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.exploreToolStripMenuItem.Text = "&Explore";
            this.exploreToolStripMenuItem.Click += new System.EventHandler(this.exploreToolStripMenuItem_Click);
            // 
            // shellToolStripMenuItem
            // 
            this.shellToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("shellToolStripMenuItem.Image")));
            this.shellToolStripMenuItem.Name = "shellToolStripMenuItem";
            this.shellToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.shellToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.shellToolStripMenuItem.Text = "&Shell";
            this.shellToolStripMenuItem.Click += new System.EventHandler(this.shellToolStripMenuItem_Click);
            // 
            // rerootToolStripMenuItem
            // 
            this.rerootToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rerootHereToolStripMenuItem,
            this.rerootInParentToolStripMenuItem});
            this.rerootToolStripMenuItem.Name = "rerootToolStripMenuItem";
            this.rerootToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.rerootToolStripMenuItem.Text = "Rer&oot...";
            // 
            // rerootHereToolStripMenuItem
            // 
            this.rerootHereToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rerootHereToolStripMenuItem.Image")));
            this.rerootHereToolStripMenuItem.Name = "rerootHereToolStripMenuItem";
            this.rerootHereToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Down)));
            this.rerootHereToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.rerootHereToolStripMenuItem.Text = "&Here";
            this.rerootHereToolStripMenuItem.Click += new System.EventHandler(this.rerootHereToolStripMenuItem_Click);
            // 
            // rerootInParentToolStripMenuItem
            // 
            this.rerootInParentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rerootInParentToolStripMenuItem.Image")));
            this.rerootInParentToolStripMenuItem.Name = "rerootInParentToolStripMenuItem";
            this.rerootInParentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Up)));
            this.rerootInParentToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.rerootInParentToolStripMenuItem.Text = "in &Parent";
            this.rerootInParentToolStripMenuItem.Click += new System.EventHandler(this.rerootInParentToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(214, 6);
            // 
            // sortByToolStripMenuItem
            // 
            this.sortByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameToolStripMenuItem,
            this.lengthToolStripMenuItem,
            this.newestToolStripMenuItem,
            this.mostchildrenToolStripMenuItem,
            this.recentlyupdatedToolStripMenuItem,
            this.mostEditsToolStripMenuItem});
            this.sortByToolStripMenuItem.Name = "sortByToolStripMenuItem";
            this.sortByToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.sortByToolStripMenuItem.Text = "Sort &children by...";
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nameToolStripMenuItem.Image")));
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.nameToolStripMenuItem.Tag = "name";
            this.nameToolStripMenuItem.Text = "&Name";
            this.nameToolStripMenuItem.Click += new System.EventHandler(this.sortOptionToolStripMenuItem_Click);
            // 
            // lengthToolStripMenuItem
            // 
            this.lengthToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("lengthToolStripMenuItem.Image")));
            this.lengthToolStripMenuItem.Name = "lengthToolStripMenuItem";
            this.lengthToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.lengthToolStripMenuItem.Tag = "length";
            this.lengthToolStripMenuItem.Text = "&Length";
            this.lengthToolStripMenuItem.Click += new System.EventHandler(this.sortOptionToolStripMenuItem_Click);
            // 
            // newestToolStripMenuItem
            // 
            this.newestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newestToolStripMenuItem.Image")));
            this.newestToolStripMenuItem.Name = "newestToolStripMenuItem";
            this.newestToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.newestToolStripMenuItem.Tag = "ctime";
            this.newestToolStripMenuItem.Text = "&Age";
            this.newestToolStripMenuItem.Click += new System.EventHandler(this.sortOptionToolStripMenuItem_Click);
            // 
            // mostchildrenToolStripMenuItem
            // 
            this.mostchildrenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mostchildrenToolStripMenuItem.Image")));
            this.mostchildrenToolStripMenuItem.Name = "mostchildrenToolStripMenuItem";
            this.mostchildrenToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.mostchildrenToolStripMenuItem.Tag = "children";
            this.mostchildrenToolStripMenuItem.Text = "Most &children";
            this.mostchildrenToolStripMenuItem.Click += new System.EventHandler(this.sortOptionToolStripMenuItem_Click);
            // 
            // recentlyupdatedToolStripMenuItem
            // 
            this.recentlyupdatedToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("recentlyupdatedToolStripMenuItem.Image")));
            this.recentlyupdatedToolStripMenuItem.Name = "recentlyupdatedToolStripMenuItem";
            this.recentlyupdatedToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.recentlyupdatedToolStripMenuItem.Tag = "mtime";
            this.recentlyupdatedToolStripMenuItem.Text = "Recently &edited";
            this.recentlyupdatedToolStripMenuItem.Click += new System.EventHandler(this.sortOptionToolStripMenuItem_Click);
            // 
            // mostEditsToolStripMenuItem
            // 
            this.mostEditsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mostEditsToolStripMenuItem.Image")));
            this.mostEditsToolStripMenuItem.Name = "mostEditsToolStripMenuItem";
            this.mostEditsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.mostEditsToolStripMenuItem.Tag = "version";
            this.mostEditsToolStripMenuItem.Text = "Most e&dits";
            this.mostEditsToolStripMenuItem.Click += new System.EventHandler(this.sortOptionToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("renameToolStripMenuItem.Image")));
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.renameToolStripMenuItem.Text = "&Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // styleToolStripMenuItem
            // 
            this.styleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editStylesToolStripMenuItem});
            this.styleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("styleToolStripMenuItem.Image")));
            this.styleToolStripMenuItem.Name = "styleToolStripMenuItem";
            this.styleToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.styleToolStripMenuItem.Text = "&Style";
            // 
            // editStylesToolStripMenuItem
            // 
            this.editStylesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editStylesToolStripMenuItem.Image")));
            this.editStylesToolStripMenuItem.Name = "editStylesToolStripMenuItem";
            this.editStylesToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.editStylesToolStripMenuItem.Text = "&Edit Styles";
            this.editStylesToolStripMenuItem.Click += new System.EventHandler(this.editStylesToolStripMenuItem_Click);
            // 
            // launchTargetSelectorBox
            // 
            this.launchTargetSelectorBox.Filter = "All files|*.*";
            // 
            // exportFileDialog
            // 
            this.exportFileDialog.DefaultExt = "html";
            this.exportFileDialog.Filter = "HTML documents|*.htm;*.html;*.xhtml|All files|*.*";
            // 
            // EditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 427);
            this.Controls.Add(this.editorSplitter);
            this.Controls.Add(this.editorMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.editorMenu;
            this.Name = "EditorWindow";
            this.Text = "Nodepad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorWindow_FormClosing);
            this.Load += new System.EventHandler(this.EditorWindow_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.editorToolstrip.ResumeLayout(false);
            this.editorToolstrip.PerformLayout();
            this.editorSplitter.Panel1.ResumeLayout(false);
            this.editorSplitter.Panel2.ResumeLayout(false);
            this.editorSplitter.ResumeLayout(false);
            this.editorMenu.ResumeLayout(false);
            this.editorMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip editorToolstrip;
        private System.Windows.Forms.ToolStripButton createNodeButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox styleListBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton boldButton;
        private System.Windows.Forms.ToolStripButton italicButton;
        private System.Windows.Forms.ToolStripButton highlightButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton listButton;
        private System.Windows.Forms.RichTextBox editorBox;
        private System.Windows.Forms.ToolStripButton editStyleButton;
        private System.Windows.Forms.SplitContainer editorSplitter;
        private System.Windows.Forms.ImageList treeImages;
        private System.Windows.Forms.TreeView nodeTreeView;
        private System.Windows.Forms.MenuStrip editorMenu;
        private System.Windows.Forms.ToolStripMenuItem documentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFromSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem styleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editStylesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem shellToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem sortByToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentlyupdatedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostchildrenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lengthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostEditsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rerootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rerootHereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rerootInParentToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog launchTargetSelectorBox;
        private System.Windows.Forms.ToolStripMenuItem launcherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setLaunchTargetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeLaunchTargetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog exportFileDialog;
    }
}

