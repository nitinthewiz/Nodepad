using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Nodepad
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Node.RefreshChildSorts();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EditorWindow(args));
        }
    }
}