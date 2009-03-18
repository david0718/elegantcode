using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RoboDojo.Combat;
using RoboDojo.WinFormRunner.Presenter;
using RoboDojo.WinFormRunner.View;

namespace RoboDojo.WinFormRunner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm form = new MainForm();

            Application.Run(form);
        }
    }
}
