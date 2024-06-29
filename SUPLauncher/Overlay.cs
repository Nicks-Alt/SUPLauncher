using Microsoft.Win32;
using System.Diagnostics;
using System.Drawing.Drawing2D;
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
        #region Main
        private void Overlay_Load(object sender, EventArgs e)
        {
            IntPtr handle = frmLauncher.getGmodHandle();
            pictureBox1.Focus();
            pictureBox1.Image = frmLauncher.avatarImage;
            GetWindowRect(handle, out rect);
            this.Size = new Size(this.Width, rect.bottom - rect.top);
            this.Top = rect.top;
            this.Left = rect.right - this.Bounds.Width;
            this.Focus();
            frmLauncher.overlay.Visible = true;

            if (ClipboardViewerNext.ToInt32() == 0) // Set Clipboard listener    
            {
                ClipboardViewerNext = SetClipboardViewer(this.Handle);

            }
            HttpWebRequest request = WebRequest.CreateHttp("https://superiorservers.co/api/profile/" + frmLauncher.steam.GetSteamId());
            request.UserAgent = "Browser";
            WebResponse response = null;
            response = request.GetResponse(); // Get Response from webrequest
            StreamReader sr = new StreamReader(response.GetResponseStream()); // Create stream to access web data
            JsonElement ranksFromResult = JsonDocument.Parse(sr.ReadToEnd()).RootElement.GetProperty("Badmin").GetProperty("Ranks");
            string[] staffRanks = { "Moderator", "Admin", "Double Admin", "Super Admin", "Council", "Root", "Content Creator" };
            foreach (string x in staffRanks)
            {

                if (ranksFromResult.GetProperty("DarkRP").GetString() == x)
                {
                    staffTools.Visible = true;
                }
                if (ranksFromResult.GetProperty("CWRP").GetString() == x)
                {
                    staffTools.Visible = true;
                }
                if (ranksFromResult.GetProperty("MilRP").GetString() == x)
                {
                    staffTools.Visible = true;
                }
                SetRankBanner(ranksFromResult.GetProperty("DarkRP").GetString());
            }
            checkBox1.Checked = Settings.ProfileOverlayEnabled;
        }
#endregion

        #region Handlers
        private void Button1_Click(object sender, EventArgs e)
        {
            Program.OpenURL("https://forum.superiorservers.co");
        }
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
        }
        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((textBox1.Text.Contains("STEAM_0:0:") || textBox1.Text.Contains("STEAM_0:1:")) || (textBox1.Text.StartsWith("7") && textBox1.Text.Length == 76561197960265728.ToString().Length))
                {
                    Program.OpenURL($"https://superiorservers.co/profile/{textBox1.Text}");
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
            Program.OpenURL($"steam://connect/{frmLauncher.rp1}:27015");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Program.OpenURL($"steam://connect/{frmLauncher.rp2}:27015");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Program.OpenURL($"steam://connect/zrp.superiorservers.co:27015");
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Program.OpenURL($"steam://connect/{frmLauncher.milrp}:27015");
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Program.OpenURL($"steam://connect/{frmLauncher.cwrp1}:27015");
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Program.OpenURL($"steam://connect/{frmLauncher.cwrp2}:27015");
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Notification noffication = new Notification("Profile overlays have now been disabled.", "STAFF TOOLS");
                noffication.Show();
            }
            else
            {
                Notification noffication = new Notification("Profile overlays have now been enabled.\n(Opens whenever you copy SteamID's)", "STAFF TOOLS");
                noffication.Show();
            }
            Settings.ProfileOverlayEnabled = checkBox1.Checked;
        }
        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            base.OnResize(e);
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1));
                pictureBox1.Region = new Region(gp);
            }
        }
        #endregion

        #region Helpers

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
                int wparam = m.WParam.ToInt32();

                if (checkBox1.Checked) // Check if the user has profile overlays enabled first.
                {
                    bool steamid = false;
                    long s = 0;

                    string text = Clipboard.GetText(); // Get text from clipboard

                    if (text.StartsWith("STEAM_") && text.Length > 17)
                    {
                        steamid = true;
                    }
                    else if (long.TryParse(text, out s) && text.Length == 17)
                    {
                        steamid = true;
                    }

                    if (steamid)
                    {
                        SetForegroundWindow(getBrowserProcess());
                        Program.OpenURL($"https://superiorservers.co/bans/{text}");
                    }
                    
                }
            }
        }

        void SetRankBanner(string Rank)
        {
            switch (Rank)
            {
                case "VIP":
                    {
                        picRank.Image = Properties.Resources.VIP;
                        break;
                    }
                case "Moderator":
                    {
                        picRank.Image = Properties.Resources.MOD;
                        break;
                    }
                case "Admin":
                    {
                        picRank.Image = Properties.Resources.ADMIN;
                        break;
                    }
                case "Double Admin":
                    {
                        picRank.Image = Properties.Resources.DOUBLE;
                        break;
                    }
                case "Super Admin":
                    {
                        picRank.Image = Properties.Resources.SUPER;
                        break;
                    }
                case "Council":
                    {
                        picRank.Image = Properties.Resources.co_blue;
                        break;
                    }
                case "Root":
                    {
                        picRank.Image = Properties.Resources.ROOT;
                        break;
                    }
                case "Content Creator":
                    {
                        picRank.Image = Properties.Resources.cc_forumbar;
                        break;
                    }
                default:
                    {
                        picRank.Image = Properties.Resources.MEMBER;
                        break;
                    }
                
            }
        }

        public static IntPtr getBrowserProcess()
        {
            Process[] chrome = Process.GetProcessesByName("chrome");
            Process[] edge = Process.GetProcessesByName("msedge");
            Process[] firefox = Process.GetProcessesByName("firefox");
            Process[] opera /*yes. even opera*/ = Process.GetProcessesByName("opera");
            Process[] safari /*lol why not*/ = Process.GetProcessesByName("safari");

            if (chrome.Length > 0)
            {
                foreach (Process pr in chrome)
                {
                    if (!(pr.MainWindowHandle == 0))
                    {
                        return pr.MainWindowHandle; // basically get all of the 8132731723 processes that chrome makes and find the first one that isnt a 0
                    }
                    Console.WriteLine(pr.MainWindowHandle);
                }
                return 0;
            }
            else if (edge.Length > 0)
            {
                return edge[0].MainWindowHandle;
            }
            else if (firefox.Length > 0)
            {
                return firefox[0].MainWindowHandle;
            }
            else if (opera.Length > 0)
            {
                return opera[0].MainWindowHandle;
            }
            else if (safari.Length > 0)
            {
                return safari[0].MainWindowHandle;
            }
            else
            {
                return 0;
            }
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        #endregion


    }
}


