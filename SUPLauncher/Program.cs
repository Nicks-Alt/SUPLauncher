using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SUPLauncher
{
    static class Program
    {
#if DEBUG
        [DllImport("kernel32")]
        static extern bool AllocConsole();
#endif

        public static string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static bool StartupComplete => Startup_DiscordReady;
        public static volatile bool Startup_DiscordReady = false;

        public static void OpenURL(string url) => Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if DEBUG
            AllocConsole();
#endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLauncher());
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
        }
        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("MyHandler caught : " + e.Message);
            Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
        }
    }
}
