using Stenography.Encryption;
using System;
using System.Windows.Forms;
using System.Text;
using Stenography.Storage;
using Stenography.Forms;

namespace Stenography
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
            Application.Run(new StartupForm());
        }
    }
}
