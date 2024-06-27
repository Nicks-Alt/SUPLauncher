using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SUPLauncher
{
    class WindowFocus
    {
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uflags);

        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_SHOWWINDOW = 0x0040;
        /// <summary>
        /// Activates a Process's main window handle via PID
        /// </summary>
        /// <param name="PID"></param>
        public static void ActivateProcess(int PID)
        {
            try
            {
                Process proc = Process.GetProcessById(PID);
                IntPtr mainWindow = proc.MainWindowHandle;

                IntPtr newPos = new IntPtr(0);  // 0 puts it on top of Z order.   You can do new IntPtr(-1) to force it to a topmost window, instead.
                SetWindowPos(mainWindow, newPos, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_SHOWWINDOW);
            }
            catch (Exception) { };
        }
    }
}
