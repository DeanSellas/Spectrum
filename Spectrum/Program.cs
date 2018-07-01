using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Spectrum
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
            // only allows 1 instance of spectrum to run at a time
            if(Process.GetProcessesByName("Spectrum").Length > 1) MessageBox.Show("Specturm Is Already Running.", "Spectrum Is Running", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else Application.Run(new SpectrumFormMain());
        }
    }
}
