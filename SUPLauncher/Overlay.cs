using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace SUPLauncher
{
    public partial class Overlay : Form
    {
        public Overlay()
        {
            InitializeComponent();
        }
        public static DupeManager dupemanager;
        public static profile profile = new profile();
        private void Button1_Click(object sender, EventArgs e)
        {
            Program.OpenURL("https://forum.superiorservers.co");
        }
        public struct RECT
        {
            public int left, top, right, bottom;
        }
        RECT rect;
        
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string ipClassName, string ipWindowName);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT ipRect);

        IntPtr ClipboardViewerNext;

        private void Overlay_Load(object sender, EventArgs e)
        {
            // test 64 bit shit u retard @Best of all
            
            
            IntPtr handle = frmLauncher.getGmodHandle();
            pictureBox1.Focus();
            GetWindowRect(handle, out rect);
            this.Size = new Size(this.Width, rect.bottom - rect.top);
            this.Top = rect.top;
            this.Left = rect.right - this.Bounds.Width;
            this.Focus();
            frmLauncher.overlay.Visible = true;
            
            // Set Clipboard listener    
            if (ClipboardViewerNext.ToInt32() == 0)
            {
                ClipboardViewerNext = SetClipboardViewer(this.Handle);
                
            }

            HttpWebRequest request = WebRequest.CreateHttp("https://superiorservers.co/api/profile/" + frmLauncher.steam.GetSteamId());
            request.UserAgent = "Browser";
            WebResponse response = null;
            response = request.GetResponse(); // Get Response from webrequest
            StreamReader sr = new StreamReader(response.GetResponseStream()); // Create stream to access web data
            var result = JsonSerializer.Deserialize<dynamic>(sr.ReadToEnd());
            string[] staffRanks = { "Moderator", "Admin", "Double Admin", "Super Admin", "Council", "Root" };

            foreach (string x in staffRanks)
            {

                if (result.Badmin.Ranks.GetValue("DarkRP & Zombies") == x)
                {
                    staffTools.Visible = true;
                }

                if (result.Badmin.Ranks.GetValue("CWRP") == x)
                {
                    staffTools.Visible = true;
                }

                if (result.Badmin.Ranks.GetValue("MilRP") == x)
                {
                    staffTools.Visible = true;
                }
            }

            checkBox1.Checked = Settings.ProfileOverlayEnabled;
            t1 = new System.Windows.Forms.Timer();
            t1.Interval = 10;  //we'll increase the opacity every 10ms
            t1.Tick += new EventHandler(fadeIn);  //this calls the function that changes opacity 
            t1.Start();
        }

        #region Fade
        /*
            Opacity = 0;      //first the opacity is 0

            t1.Interval = 10;  //we'll increase the opacity every 10ms
            t1.Tick += new EventHandler(fadeIn);  //this calls the function that changes opacity 
            t1.Start(); 
         */
        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
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


        private void Button14_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("https://superiorservers.co/darkrp/rules");
        }
        private void Button11_Click(object sender, EventArgs e)
        {
            Program.OpenURL("https://superiorservers.co/darkrp/rules");
        }
        private void Button12_Click(object sender, EventArgs e)
        {
            Program.OpenURL("https://superiorservers.co/ssrp/milrp/rules");
        }
        private void Button15_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("https://superiorservers.co/ssrp/milrp/rules");
        }
        private void Button13_Click(object sender, EventArgs e)
        {
            Program.OpenURL("https://superiorservers.co/ssrp/cwrp/rules");
        }
        private void Button16_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("https://superiorservers.co/ssrp/cwrp/rules");
        }
        private void Overlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            frmLauncher.overlay.Visible = false;
            t1 = new System.Windows.Forms.Timer();
            t1.Interval = 10;  //we'll increase the opacity every 10ms
            t1.Tick += new EventHandler(fadeOut);  //this calls the function that changes opacity 
            t1.Start();
            //if (this.Opacity == 0)
                //e.Cancel = false;
        }
        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((textBox1.Text.Contains("STEAM_0:0:") || textBox1.Text.Contains("STEAM_0:1:")) || (textBox1.Text.StartsWith("7") && textBox1.Text.Length == 76561197960265728.ToString().Length))
                {
                    Bans ban;
                    ban = new Bans(textBox1.Text);
                    ban.Show();
                    ban.TopMost = true;
                   //Bans ban = new Bans(textBox1.Text);
                    
                }
                else
                {
                    MessageBox.Show("Invalid SteamID. Make sure you have the correct SteamID", "Error");
                }

            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Program.OpenURL("ts3server://TS.SuperiorServers.co:9987");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Program.OpenURL("steam://connect/rp.superiorservers.co:27015");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Program.OpenURL("steam://connect/rp2.superiorservers.co:27015");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Program.OpenURL("steam://connect/zrp.superiorservers.co:27015");
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Program.OpenURL("steam://connect/milrp.superiorservers.co:27015");
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Program.OpenURL("steam://connect/cwrp.superiorservers.co:27015");
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Program.OpenURL("steam://connect/cwrp2.superiorservers.co:27015");
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Program.OpenURL("https://superiorservers.co/bans");
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            Program.OpenURL("https://superiorservers.co/staff");
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = "STEAM_0:X:XXXXXXXXX";
        }

        private void OverlayPanel_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

        private void Overlay_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

        private void Overlay_VisibleChanged(object sender, EventArgs e)
        {
            if (dupemanager != null && dupemanager.IsDisposed == false) { dupemanager.Visible = this.Visible; }

            if (this.Visible)
            {
                //throw new Exception("visible");
                Overlay_Load(this, new EventArgs());
            }
            else
            {
                //throw new Exception("not visible");
                Overlay_FormClosing(this, new FormClosingEventArgs(CloseReason.FormOwnerClosing, true));
            }
        }


        public static event EventHandler ClipboardUpdate;

        private static void OnClipboardUpdate(EventArgs e)
        {
            var handler = ClipboardUpdate;
            if (handler != null)
            {
                handler(null, e);
            }
        }
        protected override void WndProc(ref Message m)
        {

            // Listen for operating system Hot Key messages    

            base.WndProc(ref m);
            // Listen for operating system Clipboard changes    

            if (m.Msg == 0x308)
            {
                if (checkBox1.Checked) // Check if the user has profile overlays enabled first.
                {
                    bool steamid = false;
                    long s = 0;

                    string text = Clipboard.GetText(); // Get text from clipboard

                    if (text.StartsWith("STEAM_") && text.Length > 17)
                    {
                        steamid = true;
                    } else if (long.TryParse(text, out s) && text.Length == 17)
                    {
                        steamid = true;
                    }

                    if (steamid)
                    {
                        if (profile == null || profile.IsDisposed)
                        {
                            profile = new profile();
                            profile.TopMost = true;
                        }

                        profile.steam = text;
                        profile.initProfile(profile.steam);
                        profile.Visible = true;
                        SetForegroundWindow(frmLauncher.getGmodHandle());
                    }
                }
            }
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {



            this.Visible = false;
            if (!checkBox1.Checked)
            {
                Notification noffication = new Notification("Profile overlays have now been disabled.", "STAFF TOOLS");
                noffication.Show();
            } else
            {
                Notification noffication = new Notification("Profile overlays have now been enabled.\n(Opens whenever you copy SteamID's)", "STAFF TOOLS");
                noffication.Show();
            }
            Settings.ProfileOverlayEnabled = checkBox1.Checked;
            SetForegroundWindow(frmLauncher.getGmodProcess().MainWindowHandle);
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }
    }
}


