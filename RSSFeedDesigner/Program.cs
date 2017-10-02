using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RSSFeedDesigner
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RSSFeedMaker.WindowMain New = new RSSFeedMaker.WindowMain();
            if (args.Length > 0)
            {
                New.LoadProject(new System.IO.FileInfo(args[0]));
            }
            Application.Run(New);

        }
    }
}
