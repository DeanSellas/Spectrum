using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Spectrum.Classes {

    // Makes Sure only 1 instance of Spectrum is running at any given time.

    // this class just wraps some Win32 stuff that we're going to use
    internal class NativeMethods {

        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessage("SpectrumShowMe");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);

        // Brings Spectrum To Front
        public static void BringToFront(SpectrumFormMain spectrum) {
            if (!spectrum.Visible)
                spectrum.Show();
            if (spectrum.WindowState == FormWindowState.Minimized)
                spectrum.WindowState = FormWindowState.Normal;
            // get our current "TopMost" value (ours will always be false though)
            bool top = spectrum.TopMost;
            // make our form jump to the top of everything
            spectrum.TopMost = true;
            // set it back to whatever it was
            spectrum.TopMost = top;
        }
    }
}
