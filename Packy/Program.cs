using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Packy
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var projectName = args.FirstOrDefault(p => p.ToLower().StartsWith("-proj="));

            var doPublish = args.FirstOrDefault(p => p.ToLower() == "-pub");
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm() { DoPublish = !string.IsNullOrEmpty(doPublish) };

            if (!string.IsNullOrEmpty(projectName))
            {
                mainForm.TargetedProject = projectName.Substring("-proj=".Length);
            }

            Application.Run(mainForm);
        }
    }
}
