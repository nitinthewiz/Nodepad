using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Nodepad
{
    public class Node
    {
        public String Path;
        private DateTime last_write;

        public Node(String path)
        {
            this.Path = System.IO.Path.GetFullPath(path);
            update_last_write();
        }

        public bool RealRenameDisabled = false;

        public String Name
        {
            get
            {
                if (System.IO.File.Exists(this.LabelFilePath))
                    return System.IO.File.ReadAllText(this.LabelFilePath);
                return System.IO.Path.GetFileNameWithoutExtension(this.Path);
            }

            set
            {
                String name = value;

                if (this.RealRenameDisabled || this.IsAliased)
                {
                    System.IO.File.WriteAllText(this.LabelFilePath, value);
                    return;
                }

                if (value.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) != -1)
                {
                    name = sanitize_name(name);

                    if (name.Trim().Length == 0)
                        return;

                    System.IO.File.WriteAllText(this.LabelFilePath, value);
                }
                else
                {
                    if(System.IO.File.Exists(this.LabelFilePath))
                        System.IO.File.Delete(this.LabelFilePath);
                }

                String new_path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(this.Path), name + ".node");

                if (System.IO.Directory.Exists(new_path))
                    return;

                System.IO.Directory.Move(this.Path, new_path);
                this.Path = new_path;
            }
        }

        public bool LinkTo(Node new_parent)
        {
            String new_path = System.IO.Path.Combine(new_parent.Path, System.IO.Path.GetFileName(this.Path));
            if (System.IO.Directory.Exists(new_path))
                return false;

            Monitor.Core.Utilities.JunctionPoint.Create(new_path, this.Path, false);
            return true;
        }

        public bool AliasTo(Node new_parent)
        {
            Node canon_node = this.CanonicalAlias;
            if (!canon_node.LinkTo(new_parent))
                return false;
            canon_node.AddAlias(System.IO.Path.Combine(new_parent.Path, System.IO.Path.GetFileName(this.Path)));
            return true;
        }
            

        public bool IsLink
        {
            get { return Monitor.Core.Utilities.JunctionPoint.Exists(this.Path); }
        }

        public bool IsBadLink
        {
            get { return (this.IsLink && !(System.IO.Directory.Exists(Monitor.Core.Utilities.JunctionPoint.GetTarget(this.Path)))); }
        }

        private String AliasPath
        {
            get { return System.IO.Path.Combine(this.Path, "node.aliases.txt"); }
        }


        private List<String> _aliases = null;
        private List<String> Aliases
        {
            get
            {
                if(!this.IsAliased)
                    return null;

                if (this._aliases != null)
                    return this._aliases;

                String old_cd = System.IO.Directory.GetCurrentDirectory();
                System.IO.Directory.SetCurrentDirectory(this.Path);
                this._aliases = new List<String>(System.IO.File.ReadAllLines(this.AliasPath)).ConvertAll(new Converter<String, String>(System.IO.Path.GetFullPath));
                System.IO.Directory.SetCurrentDirectory(old_cd);
                return this._aliases;
            }
        }

        private List<String> RefreshAliases()
        {
            this._aliases = null;
            return this.Aliases;
        }

        private string relative_path(string FullPath, string BasePath)
        {
            //FullPath = FullPath.ToLower();
            //BasePath = BasePath.ToLower();

            if (BasePath.EndsWith("\\"))
                BasePath = BasePath.Substring(0,BasePath.Length-1);

            if (FullPath.EndsWith("\\"))
                FullPath = FullPath.Substring(0,FullPath.Length-1);

            if (FullPath.IndexOf(BasePath) > -1)
                return FullPath.Replace(BasePath,".");

            string BackDirs = "";
            string PartialPath = BasePath;
            int Index = PartialPath.LastIndexOf("\\");

            while (Index > 0)
            {
                PartialPath = PartialPath.Substring(0, Index);
                BackDirs = BackDirs + "..\\";
                if (FullPath.IndexOf(PartialPath) > -1)
                {
                    if (FullPath == PartialPath)
                        return FullPath.Replace(PartialPath, BackDirs.Substring(0, BackDirs.Length - 1));
                    else
                        return FullPath.Replace(PartialPath + (FullPath == PartialPath ?  "" : "\\"), BackDirs);
                }

                Index = PartialPath.LastIndexOf("\\",PartialPath.Length-1);
            }

            return FullPath;
        }

        private void AddAlias(String alias)
        {
            if (this._aliases != null)
                this._aliases.Add(alias);

            System.IO.File.AppendAllText(this.AliasPath, relative_path(alias, this.Path) + "\n");
        }

        private void RemoveAlias(String bad_alias)
        {
            Monitor.Core.Utilities.JunctionPoint.Delete(bad_alias);
            this.Aliases.Remove(bad_alias);
            List<String> relative_aliases = new List<String>();
            foreach (String alias in this._aliases)
                relative_aliases.Add(relative_path(alias, this.Path));
            if (relative_aliases.Count > 0)
            {
                System.IO.File.WriteAllLines(this.AliasPath, relative_aliases.ToArray());
            }
            else
            {
                System.IO.File.Delete(this.AliasPath);
            }
        }

        private void RemapAliases(String new_base_path)
        {
            List<String> relative_aliases = new List<string>();
            foreach (String alias in this.Aliases)
            {
                Monitor.Core.Utilities.JunctionPoint.Delete(alias);
                Monitor.Core.Utilities.JunctionPoint.Create(alias, new_base_path, false);
                relative_aliases.Add(relative_path(alias, new_base_path));
            }

            if (relative_aliases.Count > 0)
            {
                System.IO.File.WriteAllLines(this.AliasPath, relative_aliases.ToArray());
            }
            else
            {
                System.IO.File.Delete(this.AliasPath);
            }
        }

        private String LauncherPath
        {
            get { return System.IO.Path.Combine(this.Path, "node.launcher.txt"); }
        }

        public bool HasLauncher
        {
            get { return System.IO.File.Exists(this.LauncherPath); }
        }

        public String LaunchItem
        {
            get { return System.IO.File.ReadAllText(this.LauncherPath); }
            set
            {
                if (!(value.Trim().Equals(String.Empty)))
                    System.IO.File.WriteAllText(this.LauncherPath, value);
                else if (this.HasLauncher)
                    System.IO.File.Delete(this.LauncherPath);
            }
        }

        private Node CanonicalAlias
        {
            get{ return (this.IsLink) ? new Node(Monitor.Core.Utilities.JunctionPoint.GetTarget(this.Path)) : this; }
        }

        public bool IsAliased
        {
            get { return System.IO.File.Exists(this.AliasPath); }
        }

        public bool CopyTo(Node new_parent)
        {
            String new_path = System.IO.Path.Combine(new_parent.Path, System.IO.Path.GetFileName(this.Path));
            if (System.IO.Directory.Exists(new_path))
                return false;

            rec_copy_dir(this.Path, new_parent.Path);
            return true;
        }

        public bool MoveTo(Node new_parent)
        {
            if (this.IsAliased && this.IsLink)
                return this.CanonicalAlias.MoveTo(new_parent);

            String new_path = System.IO.Path.Combine(new_parent.Path, System.IO.Path.GetFileName(this.Path));
            if (System.IO.Directory.Exists(new_path))
                return false;

            if (this.IsAliased)
                RemapAliases(new_path);

            System.IO.Directory.Move(this.Path, new_path);
            return true;
        }

        public bool Destroyed
        {
            get { return !(System.IO.Directory.Exists(this.Path)); }
        }

        private void rec_copy_dir(String old_dir, String new_dir)
        {
            String old_name = System.IO.Path.GetFileName(old_dir);
            String new_path = System.IO.Path.Combine(new_dir, old_name);
            System.IO.Directory.CreateDirectory(new_path);

            // Copy files
            foreach(String old_path in System.IO.Directory.GetFiles(old_dir))
            {
                if(old_path.Equals(this.AliasPath))
                    continue;

                System.IO.File.Copy(old_path, System.IO.Path.Combine(new_path, System.IO.Path.GetFileName(old_path)));
            }

            // Copy subdirs
            foreach(String old_path in System.IO.Directory.GetDirectories(old_dir, "*", System.IO.SearchOption.TopDirectoryOnly))
                rec_copy_dir(old_path, new_path);
        }

        private String LabelFilePath
        {
            get { return System.IO.Path.Combine(this.Path, "node.label.txt"); }
        }

        private void update_last_write()
        {
            this.last_write = this.HasStoredContent ? System.IO.File.GetLastWriteTime(this.ContentFilePath) : System.IO.Directory.GetLastWriteTime(this.Path);
        }

        private String ContentFilePath
        {
            get { return System.IO.Path.Combine(this.Path, "node.rtf"); }
        }

        public bool HasCachedContent
        {
            get { return !(this._content.Equals(String.Empty)); }
        }

        public bool HasStoredContent
        {
            get { return System.IO.File.Exists(this.ContentFilePath); }
        }

        public bool HasContent
        {
            get { return this.HasCachedContent || this.HasStoredContent; }
        }

        public bool HasBeenUpdatedElsewhere
        {
            get { return this.HasStoredContent && (this.last_write < System.IO.File.GetLastWriteTime(this.ContentFilePath)); }
        }

        public bool HasStoredContentBeenRemoved
        {
            get { return this.HasCachedContent && !(this.HasStoredContent); }
        }

        public void UpdateContentTime()
        {
            DateTime n = DateTime.Now;
            if (this.HasStoredContent && this.last_write < n)
                System.IO.File.SetLastWriteTime(this.ContentFilePath, n);
            this.last_write = n;
        }

        private String _content = "";

        public String Content
        {
            get
            {
                if (this.HasStoredContent && (!this.HasCachedContent || (this.HasCachedContent && this.HasBeenUpdatedElsewhere)))
                {
                    this._content = System.IO.File.ReadAllText(this.ContentFilePath);
                    update_last_write();
                }
                else if (this.HasStoredContentBeenRemoved)
                {
                    this.Content = "";
                    update_last_write();
                }
                return this._content;
            }

            set
            {
                if (value == null || value.Equals(String.Empty))
                {
                    this._content = String.Empty;
                    if (this.HasStoredContent)
                    {
                        System.IO.File.Delete(this.ContentFilePath);
                        increment_version();
                    }
                    return;
                }

                if (this.HasContent && (value.Equals(this.Content) || this.HasBeenUpdatedElsewhere))
                    return;

                this._content = value;
                System.IO.File.WriteAllText(this.ContentFilePath, value);
                update_last_write();
                increment_version();
            }
        }

        public Node Parent
        {
            get { return new Node(System.IO.Path.GetDirectoryName(this.Path)); }
        }

        public DateTime CreationTime
        {
            get { return System.IO.Directory.GetCreationTime(this.Path); }
        }

        public DateTime ModificationTime
        {
            get { return this.last_write; }
        }

        private String VersionFilePath
        {
            get { return System.IO.Path.Combine(this.Path, "node.version.txt"); }
        }

        private int _version = -1;

        public int Version
        {
            get
            {
                if (this._version != -1 || !System.IO.File.Exists(this.VersionFilePath))
                    return this._version;

                String rev_str = System.IO.File.ReadAllText(this.VersionFilePath);
                int try_rev;

                if (int.TryParse(rev_str, out try_rev))
                    this._version = try_rev;

                return this._version;
            }
        }

        public void increment_version()
        {
            int new_v = this.Version + 1;

            this._version = new_v;

            System.IO.File.WriteAllText(this.VersionFilePath, new_v.ToString());
        }

        struct ChildSortClasses
        {
            public class ByName : IComparer<Node>
            {
                public int Compare(Node a, Node b)
                {
                    return String.Compare(a.Name, b.Name);
                }
            }

            public class ByCreationTime : IComparer<Node>
            {
                public int Compare(Node a, Node b)
                {
                    return DateTime.Compare(a.CreationTime, b.CreationTime);
                }
            }

            public class ByModificationTime : IComparer<Node>
            {
                public int Compare(Node a, Node b)
                {
                    return DateTime.Compare(b.ModificationTime, a.ModificationTime);
                }
            }

            public class ByMostChildren : IComparer<Node>
            {
                public int Compare(Node a, Node b)
                {
                    int m = (b.Children.Count - a.Children.Count);
                    return (m == 0) ? String.Compare(a.Name, b.Name) : m;
                }
            }

            public class ByContentLength : IComparer<Node>
            {
                public int Compare(Node a, Node b)
                {
                    int m = b.Content.Length - a.Content.Length;
                    return (m == 0) ? String.Compare(a.Name, b.Name) : m;
                }
            }

            public class ByVersion : IComparer<Node>
            {
                public int Compare(Node a, Node b)
                {
                    int m = b.Version - a.Version;
                    return (m == 0) ? String.Compare(a.Name, b.Name) : m;
                }
            }
        }

        public static Dictionary<string, IComparer<Node>> ChildrenSort = new Dictionary<string,IComparer<Node>>();
        public static Dictionary<IComparer<Node>, string> InverseChildrenSort = new Dictionary<IComparer<Node>, string>();

        public static void RefreshChildSorts()
        {
            ChildrenSort.Clear();
            ChildrenSort.Add("name", new ChildSortClasses.ByName());
            ChildrenSort.Add("ctime", new ChildSortClasses.ByCreationTime());
            ChildrenSort.Add("mtime", new ChildSortClasses.ByModificationTime());
            ChildrenSort.Add("children", new ChildSortClasses.ByMostChildren());
            ChildrenSort.Add("length", new ChildSortClasses.ByContentLength());
            ChildrenSort.Add("version", new ChildSortClasses.ByVersion());

            ChildrenSort.Add("default", ChildrenSort["name"]);

            foreach (KeyValuePair<String, IComparer<Node>> kp in ChildrenSort)
                if(!InverseChildrenSort.ContainsKey(kp.Value))
                    InverseChildrenSort.Add(kp.Value, kp.Key);
        }

        private String SortFilePath
        {
            get { return System.IO.Path.Combine(this.Path, "node.sort.txt"); }
        }
        
        private IComparer<Node> _sort_children;

        public IComparer<Node> SortChildren
        {
            get
            {
                if (_sort_children != null)
                    return _sort_children;

                if (!System.IO.File.Exists(this.SortFilePath))
                    return ChildrenSort["default"];

                String method = System.IO.File.ReadAllText(this.SortFilePath).Trim().ToLower();

                IComparer<Node> sorter;
                if (Node.ChildrenSort.TryGetValue(method, out sorter))
                {
                    _sort_children = sorter;
                }
                else
                {
                    _sort_children = ChildrenSort["default"];
                }

                return _sort_children;
            }

            set
            {
                if (value == null)
                    return;

                String method_name = null;
                if(Node.InverseChildrenSort.TryGetValue(value, out method_name))
                {
                    _sort_children = value;
                    System.IO.File.WriteAllText(this.SortFilePath, method_name);
                }
            }
        }

        private List<Node> _children;
        private IComparer<Node> child_cache_sort;

        public List<Node> Children
        {
            get
            {
                if (this._children == null)
                {
                    this._children = new List<Node>();

                    if (this.Destroyed || this.IsBadLink)
                        return this._children;

                    String real_path;
                    foreach (String path in System.IO.Directory.GetDirectories(this.Path, "*.node", System.IO.SearchOption.TopDirectoryOnly))
                    {
                        real_path = path;
                        //if(Monitor.Core.Utilities.JunctionPoint.Exists(path))
                        //    real_path = Monitor.Core.Utilities.JunctionPoint.GetTarget(path);

                        this._children.Add(new Node(real_path));
                    }
                }
                return ResortChildCache();
            }
        }

        public bool HasChildren
        {
            get { this.RefreshChildCache(); return this.Children.Count > 0; }
        }

        public void RefreshChildCache()
        {
            this._children = null;
            List<Node> unused = this.Children;
        }

        public List<Node> ResortChildCache()
        {
            if (this._children == null)
            {
                return this.Children;
            }

            this.child_cache_sort = this.SortChildren;
            this._children.Sort(this.child_cache_sort);

            return this._children;
        }

        public Node CreateChild(String name, String content)
        {
            String path = System.IO.Path.Combine(this.Path, Guid.NewGuid().ToString() + ".node");
            System.IO.Directory.CreateDirectory(path);

            Node child = new Node(path);
            child.Name = name;
            child.Content = content;
            _children.Add(child);

            return child;
        }

        private String sanitize_name(String name)
        {
            StringBuilder new_name = new StringBuilder();
            char[] invalids = System.IO.Path.GetInvalidFileNameChars();

            bool add_ch;
            foreach (char ch in name.ToCharArray())
            {
                add_ch = true;
                foreach (char inv in invalids)
                    if (ch.Equals(inv))
                    {
                        add_ch = false;
                        break;
                    }
                if (add_ch)
                {
                    new_name.Append(ch);
                }
                else
                {
                    new_name.Append('.');
                }
            }

            return new_name.ToString();
        }

        public Node this[String path]
        {
            get
            {
                if (path == null)
                    return null;

                if (path.IndexOf('/') != -1)
                {
                    String[] paths = path.Split('/');
                    Node cursor = this;
                    foreach (String child_name in paths)
                    {
                        cursor = cursor[child_name];
                        if (cursor == null)
                            return null;
                    }
                    return cursor;
                }
                else
                {
                    foreach (Node child in this.Children)
                        if (child.Name.Equals(path))
                            return child;
                    return null;
                }
            }
        }

        public void Destroy()
        {
            if (this.IsAliased)
            {
                if (this.IsLink)
                {
                    this.CanonicalAlias.RemoveAlias(this.Path);
                }
                else
                {
                    String new_path = this.Aliases[0];
                    this._aliases = this._aliases.GetRange(1, this._aliases.Count - 1);
                    RemapAliases(new_path);
                    Monitor.Core.Utilities.JunctionPoint.Delete(new_path);
                    System.IO.Directory.Move(this.Path, new_path);
                }
            }
            else
            {
                if (this.IsLink)
                {
                    Monitor.Core.Utilities.JunctionPoint.Delete(this.Path);
                }
                else
                {
                    System.IO.Directory.Delete(this.Path, true);
                }
            }
        }


        public String GenerateHtml()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">");
            sb.AppendLine("<html>");
            sb.AppendLine("  <head>");
            sb.Append("    <title>");
            sb.Append(this.Name);
            sb.AppendLine("</title>");
            sb.AppendLine("    <link rel=\"stylesheet\" type=\"text/css\" href=\"http://derefr.googlepages.com/nodepad.css\" />");
            sb.AppendLine("  </head>");
            sb.AppendLine("  <body>");
            this.GenerateHtml(sb, 0);
            sb.AppendLine("  </body>");
            sb.AppendLine("</html>");
            return Regex.Replace(Regex.Replace(sb.ToString(), @"(<\w+>\s*</\w+>\s*)+</(\w+)>", "</$2>"), @"(<\w+ />\s*)+</(\w+)>", "</$2>");
        }

        public class HtmlNodeDumper : Net.Sgoliver.NRtfTree.Core.SarParser
        {
            private StringBuilder sb;

            private bool inText = false;
            private bool inList = false;
            private bool inSize = false;
            private const int DefaultSize = 28;
            private int Size = DefaultSize;
            private System.Drawing.FontStyle fs = System.Drawing.FontStyle.Regular;

            public HtmlNodeDumper(StringBuilder s_b)
            {
                this.sb = s_b;
            }

            public override void EndRtfDocument()
            {
                if (this.inSize)
                    sb.Append("</span>");

                if (this.inList)
                    sb.Append("</ul>");

                if (this.inText)
                    sb.AppendLine("</p>");

                EndRtfGroup();
            }

            public override void StartRtfDocument() { ; }
            public override void StartRtfGroup() { ; }
            public override void RtfControl(string key, bool hasParameter, int parameter) { ; }

            public override void EndRtfGroup()
            {
                if ((this.fs & System.Drawing.FontStyle.Bold) > 0)
                    this.sb.Append("</strong>");

                if ((this.fs & System.Drawing.FontStyle.Italic) > 0)
                    this.sb.Append("</em>");

                this.fs = System.Drawing.FontStyle.Regular;
            }

            private void font_open_tag()
            {
                sb.Append("<span style=\"font-size: ");
                sb.AppendFormat(Convert.ToInt32(Math.Floor((double)this.Size * 0.5)).ToString());
                sb.Append("pt;\">");
                this.inSize = true;
            }

            public override void RtfKeyword(string key, bool hasParameter, int parameter)
            {
                if (key.Equals("pard"))
                {
                    if (this.inList)
                        sb.Append("</ul>");
                    this.inList = false;
                    if (this.inText)
                        sb.AppendLine("</p>");
                    this.inText = true;
                    sb.Append("<p>");
                    if (this.Size != DefaultSize)
                        font_open_tag();
                }

                if(!this.inText)
                    return;

                switch (key)
                {
                    case "b":
                        if (!hasParameter || (hasParameter && parameter == 1))
                        {
                            this.fs |= System.Drawing.FontStyle.Bold;
                            sb.Append("<strong>");
                        }
                        else
                        {
                            this.fs &= ~System.Drawing.FontStyle.Bold;
                            sb.Append("</strong>");
                        }
                        break;
                    case "i":
                        if (!hasParameter || (hasParameter && parameter == 1))
                        {
                            this.fs |= System.Drawing.FontStyle.Italic;
                            sb.Append("<em>");
                        }
                        else
                        {
                            this.fs &= ~System.Drawing.FontStyle.Italic;
                            sb.Append("</em>");
                        }
                        break;
                    case "par":
                        if (this.inList)
                        {
                            if (this.inSize)
                            {
                                sb.Append("</span>");
                                this.inSize = false;
                            }
                            sb.AppendLine("</li>");
                        }
                        else
                            sb.Append("<br />");
                        break;
                    case "pntext":
                        if (!this.inList)
                            sb.Append("<ul>");
                        this.inList = true;
                        sb.Append("<li>");
                        if (!this.inSize && this.Size != DefaultSize)
                            font_open_tag();
                        break;
                    case "fs":
                        if (parameter == DefaultSize)
                        {
                            sb.Append("</span>");
                            this.inSize = false;
                        }
                        else if (parameter != this.Size)
                        {
                            this.Size = parameter;
                            if (this.inSize)
                                sb.Append("</span>");
                            this.inSize = true;
                            font_open_tag();
                        }
                        break;
                    default:
                        //System.Windows.Forms.MessageBox.Show(key);
                        break;
                }
            }

            public override void RtfText(string text)
            {
                if(inText)
                    sb.Append(System.Text.RegularExpressions.Regex.Replace(text, @"(http\:\/(\/[\.\-_A-Za-z0-9\%\=\&\?]*[A-Za-z0-9])+)", "<a href=\"$1\">$1</a>"));
            }
        }

        public void GenerateHtml(StringBuilder sb, int Level)
        {
            int indent = 4 + (Level * 2);
            String spaces = "".PadLeft(indent, ' ');
            if (Level != 0)
                sb.AppendLine(spaces + "<div class=\"node\">");

            String h_number = ((int)Math.Min(Level + 1, 6)).ToString();
            sb.AppendLine(spaces + "<h" + h_number + ">" + this.Name + "</h" + h_number + ">");

            if (this.HasContent)
            {
                sb.AppendLine(spaces + "<div class=\"content\">");
                Net.Sgoliver.NRtfTree.Core.RtfReader nd = new Net.Sgoliver.NRtfTree.Core.RtfReader(new HtmlNodeDumper(sb));
                nd.LoadRtfText(System.Text.RegularExpressions.Regex.Replace(this.Content, @"\\par\s*((\\[A-Za-z0-9]+)*)\s*\\par", @"$1\pard"));
                nd.Parse();
                sb.AppendLine(spaces + "</div>");
            }

            foreach (Node child in this.Children)
                child.GenerateHtml(sb, Level + 1);

            if (Level != 0)
                sb.AppendLine(spaces + "</div>");

            sb.AppendLine();
        }
    }
}
