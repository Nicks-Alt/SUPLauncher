using CefSharp;
using CefSharp.WinForms;

using System.Net;
using System.Runtime.InteropServices;

using System.Text.Json;

using Timer = System.Windows.Forms.Timer;

namespace SUPLauncher
{
    public partial class profile : Form
    {
        public profile()
        {
            InitializeComponent();
            
        }
        #region Fade
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
        #endregion
        public struct RECT
        {
            public int left, top, right, bottom;
        }
        public string steam { get; set; }
        RECT rect;
        

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT ipRect);

        private void profile_Load(object sender, EventArgs e)
        {
            this.Size = new Size(479, 193);
            IntPtr handle = frmLauncher.getGmodHandle();
            GetWindowRect(handle, out rect);
            this.Top = rect.top + 30;
            this.Left = 0;
            t1.Interval = 10;
            t1.Tick += new EventHandler(fadeIn);
            t1.Start();
        }
        ChromiumWebBrowser chrome = new ChromiumWebBrowser();
        private void InitializeChromium(string steamID)
        {            
            chrome.Load("https://superiorservers.co/profile/" + steamID);
            this.Controls.Add(chrome);
            chrome.Dock = DockStyle.Left;
            chrome.BringToFront();   
            chrome.Dock = DockStyle.Fill;
            chrome.LoadingStateChanged += (sender, args) =>
            {
                //Wait for the Page to finish loading
                if (args.IsLoading == false)
                {
                    chrome.EvaluateScriptAsync("document.getElementsByClassName('navbar')[0].remove(); document.getElementsByClassName('col-lg-12')[0].remove(); document.getElementsByClassName('col-lg-6')[0].remove(); document.getElementsByClassName('col-lg-6')[0].remove(); document.getElementsByClassName('panel-heading')[0].remove(); document.getElementsByTagName('div')[0].remove();"); // Use javascript magic to remove everything apart from the PO's.
                }
            };
        }

        
        public void initProfile(string steamid)
        {
            InitializeChromium(steamid);
            HttpWebRequest request = WebRequest.CreateHttp("https://superiorservers.co/api/profile/" + steamid);
            request.UserAgent = "Browser";
            WebResponse response = null;
            response = request.GetResponse(); // Get Response from webrequest
            StreamReader sr = new StreamReader(response.GetResponseStream()); // Create stream to access web data
            try
            {
                var result = JsonSerializer.Deserialize<dynamic>(sr.ReadToEnd());
                if (result.Badmin.Name == "Unknown")
                {
                    MessageBox.Show("Invalid SteamID"); // Debug Messages. Remove before commiting
                    this.Close();
                }
                player_name.Text = result.Badmin.Name.ToString();
                steamid32.Text = result.SteamID32.ToString();
                steamid64.Text = result.SteamID64.ToString();
                TimeSpan t = TimeSpan.FromSeconds(long.Parse(result.Badmin.PlayTime.ToString()));
                var hours = Math.Floor(t.TotalHours);
                playtime.Text = string.Format("{0:D}", Convert.ToInt64(hours)) + " hours of playtime";
                var client = new WebClient();
                client.Headers.Add("user-agent", "SUP Launcher: v" + Program.Version); // Set a header for the SUP Avatar API web request so it doesn't get blocked :)
                byte[] avatardata = client.DownloadData(new Uri("https://superiorservers.co/api/avatar/" + result.SteamID64));
                using (var ms = new MemoryStream(avatardata))
                {
                    ovalPictureBox1.Image = Image.FromStream(ms);
                    client.Dispose();
                    ms.Close();
                }

                po.Text = result.Badmin.Bans.Count + "\nPO(s)";
                if (result.Badmin.Bans.Count < 1)
                {
                    this.Size = new Size(479, 193);
                    label3.Visible = false;
                    button1.Visible = false;
                } else
                {
                    label3.Visible = true;
                    button1.Visible = true;
                }
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(long.Parse(result.Badmin.FirstJoin.ToString())).ToLocalTime();
                first_join.Text = dtDateTime.ToString("dd/MM/yyyy hh:mm tt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Size == new Size(479, 193))
            {
                this.Size = new Size(1600, 193);
                label3.Text = "<";
            } else
            {
                this.Size = new Size(479, 193);
                label3.Text = ">";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            t1.Interval = 10;
            t1.Tick += new EventHandler(fadeOut);
            t1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(steamid64.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(steamid32.Text);
        }
    }

}
