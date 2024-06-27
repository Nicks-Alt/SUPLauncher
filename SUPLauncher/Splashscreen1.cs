using System.Drawing.Text;

using Timer = System.Windows.Forms.Timer;

namespace SUPLauncher
{
    public partial class Splashscreen1 : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
               IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font myFont;
        Timer t1 = new Timer();
        public Splashscreen1()
        {
            InitializeComponent();

            byte[] fontData = Properties.Resources.PrototypeFont;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, fontData.Length);
            AddFontMemResourceEx(fontPtr, (uint)fontData.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            label1.Font = new Font(fonts.Families[0], 27.75F);
            label1.Font = new Font(fonts.Families[0], 27.75F);

            var closeTimer = new Timer();
            closeTimer.Interval = (int)TimeSpan.FromSeconds(1).TotalMilliseconds;
            closeTimer.Tick += delegate {
                if (Program.StartupComplete)
                {
                    Close();
                }
                else
                {
                    closeTimer.Start();
                }
            };
            closeTimer.Start();
        }

        #region Fade
        



        void fadeIn(object sender, EventArgs e)
        {
            if (Opacity >= 1)
                t1.Stop();   //this stops the timer if the form is completely displayed
            else
                Opacity += 0.05;
        }

        void fadeOut(object sender, EventArgs e)
        {
            if (Opacity <= 0)     //check if opacity is 0
            {
                t1.Stop();    //if it is, we stop the timer
                Close();   //and we try to close the form
            }
            else
                Opacity -= 0.05;
        }
        #endregion

        private void Splashscreen1_Activated(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(1000);
            //t1.Tick += new EventHandler(fadeOut);  //this calls the fade out function
            //t1.Start();
        }

        private void Splashscreen1_Load(object sender, EventArgs e)
        {
            t1 = new Timer();
            Opacity = 0;      //first the opacity is 0

            t1.Interval = 10;  //we'll increase the opacity every 10ms
            t1.Tick += new EventHandler(fadeIn);  //this calls the function that changes opacity 
            t1.Start();
        }
    }
}
