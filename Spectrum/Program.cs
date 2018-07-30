using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Spectrum.Classes;

namespace Spectrum {
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{94c9e38c-1478-43aa-9e66-a7f2f833c173}");
        [STAThread]
        static void Main() {

            // only allows 1 instance of spectrum to run at a time
            if (mutex.WaitOne(TimeSpan.Zero, true)) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SpectrumFormMain());
                mutex.ReleaseMutex();
            }
            else {
                NativeMethods.PostMessage((IntPtr)NativeMethods.HWND_BROADCAST, NativeMethods.WM_SHOWME, IntPtr.Zero, IntPtr.Zero);
            }
        }
    }
}
