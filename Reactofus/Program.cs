using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Reactofus
{
    static class Program
    {
        public static Form1 MainWnd;

        public static object SelectedDrive => MainWnd.SelectedDrive;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void WriteResourceToFile(string resourceName, string fileName)
        {
            if (File.Exists(fileName)) File.Delete(fileName);

            using (var resource = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    resource.CopyTo(file);
                }
            }
        }
    }
}
