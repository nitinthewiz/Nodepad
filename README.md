Nodepad is a document editor developed in **C#**, which was designed around the [Snowflake Method](http://www.advancedfictionwriting.com/art/snowflake.php) workflow for fiction writing. Nodepad works with a hierarchical structure of named text blocks, called *nodes*. Users start with a *root node*—an empty document—and then write in the Content Editor pane (which is auto-saved) until they feel that whatever they have written has grown too large, and needs to be broken down. They then select the part of their text which has a repetitive structure, and *node* it; the structure is automatically detected, and each item is extracted into a new node, which appears as a child of the current node in the Node Explorer pane. The user can then repeat the workflow on each child node, recursively, until the document is complete.

Nodepad was built to obey the [Unix philosophy](http://www.faqs.org/docs/artu/ch01s06.html). There is no complex document format for storing nodes; instead, Nodepad relies entirely on the filesystem for data serialization and storage. Each "node" is a folder—and, conversely, any folder can be opened as a node—and the content of each node is simply the content of an **RTF** *content* file in the folder. Thus, any tool that understands the filesystem—such as **Git**, **Dropbox**, or **Windows Search**—can treat a Nodepad node tree as if it were any other hierarchy of files and folders, enabling simple support for search, remote mirroring, and revision-control, which would otherwise have to be built-in. Each node has an optional **XML** *hooks* file, allowing individual nodes to react to events upon them, or their children, by triggering scripts written in the [Boo language](http://boo.codehaus.org/). Premade **Boo** scripts are provided for integration with the **SVN** and **Git** revision-control systems. Nodepad also natively understands **NTFS** features such as *reparse points* and *aliases*, so, with a few simple drag-and-drop movements, nodes may be made to "live" in multiple sections of the tree at once (with Nodepad at the ready to prevent directory-graph cycles).