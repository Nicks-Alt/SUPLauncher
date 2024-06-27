using System.Runtime.InteropServices;

using Timer = System.Windows.Forms.Timer;

namespace SUPLauncher
{
    public partial class Notification : Form
    {
        public struct RECT
        {
            public int left, top, right, bottom;
        }
        bool focusGmod;
        RECT rect;
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT ipRect);
        /// <summary>
        /// Shows a noffication attached to a process in the top right corner
        /// </summary>
        /// <param name="Title">The title showed at the top.</param>
        /// <param name="Text">The text to display in the noffication</param>
        /// 
        public Notification(string Text, string Title = "NOTIFICATION", bool FocusGMOD = true, int height = 94)
        {
            InitializeComponent();
            this.Size = new Size(387, height);
            title.Text = Title;
            this.TopMost = true;
            text.Text = Text;
            focusGmod = FocusGMOD;
        }

        private void closeOn_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Noffication_Load(object sender, EventArgs e)
        {
            if (focusGmod)
            {
                IntPtr handle = frmLauncher.getGmodHandle();
                if (handle == IntPtr.Zero)
                {
                    this.Size = new Size(this.Width, this.Height);
                    this.Top = Screen.PrimaryScreen.Bounds.Top;
                    this.Left = Screen.PrimaryScreen.Bounds.Right - this.Bounds.Width;
                    Opacity = 0;      //first the opacity is 0

                    t1.Interval = 10;  //we'll increase the opacity every 10ms
                    t1.Tick += new EventHandler(fadeIn);  //this calls the function that changes opacity 
                    t1.Start();
                    return;
                }

                GetWindowRect(handle, out rect);
                this.Size = new Size(this.Width, this.Height);
                this.Top = rect.top;
                this.Left = rect.right - this.Bounds.Width;
            }
            else
            {
                this.Size = new Size(this.Width, this.Height);
                this.Top = Screen.PrimaryScreen.Bounds.Top;
                this.Left = Screen.PrimaryScreen.Bounds.Right - this.Bounds.Width;
            }
            Opacity = 0;      //first the opacity is 0

            t1.Interval = 10;  //we'll increase the opacity every 10ms
            t1.Tick += new EventHandler(fadeIn);  //this calls the function that changes opacity 
            t1.Start();
        }

        Timer t1 = new Timer();



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

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;    //cancel the event so the form won't be closed

            t1.Tick += new EventHandler(fadeOut);  //this calls the fade out function
            t1.Start();

            if (Opacity == 0)  //if the form is completly transparent
                e.Cancel = false;   //resume the event - the program can be closed

        }

    }
}
