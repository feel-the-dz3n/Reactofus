using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Reactofus
{
    public class Worker
    {
        private static void WorkerStart(DefaultWorker worker)
        {
            Program.MainWnd.Working = true;

            var methods = GetMethods(worker).ToArray();
            bool errorHappened = false;

            Prepare();

            for (int i = 0; i < methods.Length; i++)
            {
                Program.MainWnd.SetProgressFromValues(i + 1, methods.Length);
                Program.MainWnd.SetStatus(GetFriendlyName(methods[i].Name));

                try
                {
                    Check();

                    methods[i].Invoke(worker, new object[] { });
                }
                catch (TargetInvocationException ex)
                {
                    ErrorHandler(ex.InnerException);
                    errorHappened = true;
                }
            }

            if (!errorHappened)
                Done();

            Program.MainWnd.SetProgress(0);
            Program.MainWnd.SetStatus("Ready!");

            Program.MainWnd.Working = false;
        }

        private static List<MethodInfo> GetMethods(DefaultWorker worker)
        {
            List<MethodInfo> result = new List<MethodInfo>();

            var methods = worker.GetType().GetMethods();

            foreach (var method in methods)
                if (method.ReturnType == worker.GetType())
                    result.Add(method);

            return result;
        }

        public static string GetFriendlyName(string source)
        {
            StringBuilder a = new StringBuilder();

            bool IgnoreUpper = false;

            for (int i = 0; i < source.Length; i++)
            {
                var c = source[i];

                if (!IgnoreUpper && i != 0 && char.IsUpper(c))
                    a.Append(' ');

                if (c == '_')
                {
                    c = ' ';

                    if (i == 0)
                    {
                        IgnoreUpper = true;
                        continue;
                    }
                }

                a.Append(c);
            }

            return a.ToString();
        }

        public static void RamDiskISOWorkerStart() => new Thread(() => WorkerStart(new RamDiskISOWorker())).Start();

        private static void Prepare(string driveLabel = "ReactOS")
        {
            if (Program.MainWnd.ForceFormatDrive)
            {
                object drive = null;
                DialogResult answer = DialogResult.No;

                Program.MainWnd.Invoke(new Action(() =>
                {
                    drive = Program.MainWnd.SelectedDrive;

                    answer = MessageBox.Show(
                        $"WARNING!!!\r\nAll data on {drive.ToString()} will be removed!\r\n\r\nWould you like to continue?",
                        "Reactofus - Format Drive",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                }));

                if (answer == DialogResult.No)
                    throw new Exception("User cancelled formatting.");
                else if (answer == DialogResult.Yes)
                {
                    Program.MainWnd.SetStatus("Formatting drive " + drive + "...");

                    //if (!FomratManager.FormatDrive(drive.Name[0], "FAT32"))
                    //    throw new Exception("Drive formatting error.");
                }
            }

            //Program.MainWnd.Invoke(new Action(() =>
            //{
            //    Program.MainWnd.SelectedDrive.VolumeLabel = driveLabel;
            //}));
        }

        private static void Check()
        {
            if(Program.MainWnd.ProgressPaused)
            {
                while (Program.MainWnd.ProgressPaused)
                    Thread.Sleep(500);
            }

            if (Program.MainWnd.Aborted)
                throw new Exception("Aborted.");
        }

        private static void Done()
        {
            Program.MainWnd.Invoke(new Action(() =>
            {
                MessageBox.Show("Completed!", "Reactofus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }));
        }

        private static void ErrorHandler(Exception ex)
        {
            Program.MainWnd.Invoke(new Action(() =>
            {
                MessageBox.Show(ex.Message, "Reactofus Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Program.MainWnd.SetProgress(0);
                Program.MainWnd.SetStatus("Error.");
            }));
        }
    }
}
