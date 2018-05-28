using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            if(Process.GetProcessesByName("Spectrum").Length > 1) MessageBox.Show("Specturm Is Already Running");
            else Application.Run(new SpectrumFormMain());
        }
    }
}
