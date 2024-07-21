using System.Diagnostics;
using System.Net;
using Microsoft.VisualBasic;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using DiscordRPC;
using System.Text.Json;
using Microsoft.Win32;
using Gameloop.Vdf.Linq;
using Gameloop.Vdf;
using System.Resources;
using System.Reflection.Metadata.Ecma335;
using SUPLauncher.Properties;
using System.Xml.Linq;
using System.Text;
using System.IO.Compression;
using System.Drawing.Imaging;

namespace SUPLauncher
{

    /*TODO:
     * 
     * - Group all subroutines with #region --DONE
     * - Group all event handlers to hide their cancer --DONE
     * - Give KoB a smooch --NEEDS DONE ASAP
    */
    public partial class frmLauncher : Form
    {
        #region Globals
        int refresh = 0;
        public static string dupePath = "";
        string playerServer = "";
        public static readonly SteamBridge steam = new SteamBridge();
        public static string forumSteamIDLookup = "";
        bool isTopPanelDragged = false;
        Point offset;
        Size _normalWindowSize;
        Point _normalWindowLocation = Point.Empty;
        private Image refresh_img;
        Image original_refreshimg;
        KeyboardHook hook = new KeyboardHook();
        public static Overlay overlay = new Overlay();
        public PrivateFontCollection fonts = new PrivateFontCollection();
        public static string rp1 = Dns.GetHostEntry("rp.superiorservers.co").AddressList[0].ToString();
        public static string rp2 = Dns.GetHostEntry("rp2.superiorservers.co").AddressList[0].ToString();
        public static string milrp = Dns.GetHostEntry("milrp.superiorservers.co").AddressList[0].ToString();
        public static string cwrp1 = Dns.GetHostEntry("cwrp.superiorservers.co").AddressList[0].ToString();
        public static string cwrp2 = Dns.GetHostEntry("cwrp2.superiorservers.co").AddressList[0].ToString();
        bool altdown = false;
        bool sdown = false;
        public static Image? avatarImage;
        private DiscordRpcClient discord = new DiscordRpcClient("594668399653814335") { Logger = new DiscordRPC.Logging.ConsoleLogger(DiscordRPC.Logging.LogLevel.Info, true) };
        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
        private int danktownPlayerCount;
        private int c18PlayerCount;
        private int cwrpPlayerCount;
        private int cwrp2PlayerCount;
        private int milrpPlayerCount;

        #endregion

        public frmLauncher()
        {
            if (Process.GetProcessesByName("steam").Length == 0) // Check if steam is running (Thanks Red Means Recording)
            {
                MessageBox.Show("An error occurred. Please restart the program when steam is running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Interaction.Shell("taskkill /pid " + Process.GetCurrentProcess().Id.ToString() + " /f");
            }

            Thread trd = new Thread(new ThreadStart(Run));

            InitializeComponent();
            discord.Initialize();
            discord.OnReady += (sender, msg) =>
            {
                Program.Startup_DiscordReady = true;
                Console.WriteLine("Presence is ready");
            };

            GetCurrentServer(steam.GetSteamId().ToString(), true);

            refresh_img = imgrefresh.Image;
            original_refreshimg = imgrefresh.Image;

            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(Keyboard);
            hook.RegisterKeybind(83); // Alt+S

            //chkAFK.Paint += (sender, e) =>
            //{
            //    e.Graphics.Clear(Color.Transparent);
            //};
            //chkAFK.BackColor = Color.Transparent;
            //chkAFK.FlatStyle = FlatStyle.Flat;
            //chkAFK.FlatAppearance.BorderSize = 0;
            InitControlFonts();
            InitUser();
            InitUserRank();
            InitValvecmd();
            GetCurrentServer(steam.GetSteamId().ToString(), true);
            GetDupes();
            discordStatusToggleToolStripMenuItem.Checked = Settings.DiscordStatus;
            overlayToggleALTSToolStripMenuItem.Checked = Settings.OverlayEnabled;
            chkAFK.Checked = Settings.AFKStatus;
            picImage.Visible = true;
            Opacity = 0;      //first the opacity is 0
            t1.Interval = 10;  //we'll increase the opacity every 10ms
            t1.Tick += new EventHandler(fadeIn);  //this calls the function that changes opacity 
            t1.Start();
            imgrefresh.SizeMode = PictureBoxSizeMode.StretchImage;
            imgrefresh.Refresh();
            try
            {
                if (discordStatusToggleToolStripMenuItem.Checked)
                {
                    LblServer_TextChanged(this, new EventArgs());
                }
                lblVersion.Text = Program.Version;
                GetPlayerCountAllServers(true);
                Activate();
                tmrSteamQuery.Start();
                if (ClientUpdater.checkForUpdates())
                {
                    versionWarn.Visible = true;
                    lblVersion.ForeColor = Color.Salmon;
                    toolTip1.ToolTipIcon = ToolTipIcon.Warning;
                    toolTip1.SetToolTip(lblVersion, $"This version of the SUPLauncher ({lblVersion.Text}) is out of date! Click on the version number to update! (HIGHLY RECOMMENDED)");
                }
                else
                {
                    toolTip1.ToolTipIcon = ToolTipIcon.Info;
                    toolTip1.SetToolTip(lblVersion, "SUP Launcher is currently up to date.");
                }
                ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, ex.ToString(), "REPORT THIS TO NICK YOU DUMB FUCK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //FrmLauncher_FormClosing(this, new FormClosingEventArgs(CloseReason.ApplicationExitCall, false));
            }
            loadOverlay();
            //trd.Join();
        }

        #region Helpers

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

        private void InitValvecmd()
        {
            if (!File.Exists("valvecmd.exe"))
                using (FileStream fsDst = new FileStream("valvecmd.exe", FileMode.CreateNew, FileAccess.Write))
                {
                    byte[] bytes = Properties.Resources.valvecmd;
                    fsDst.Write(bytes, 0, bytes.Length);
                    fsDst.Close();
                    fsDst.Dispose();
                }
        }
        private void SendAFKCommand(string cmd)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "valvecmd.exe";
            startInfo.Arguments = cmd;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            Process processTemp = new Process();
            processTemp.StartInfo = startInfo;
            processTemp.EnableRaisingEvents = true;
            processTemp.Start();
        }
        private void rotateInThread(Bitmap bm, float angle)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<Bitmap, float>(rotateInThread), new object[] { bm, angle });

            }
            refresh_img = RotateBitmap(bm, angle);
        }


        private void GetPointBounds(PointF[] points, out float xmin, out float xmax, out float ymin, out float ymax)
        {
            xmin = points[0].X;
            xmax = xmin;
            ymin = points[0].Y;
            ymax = ymin;
            foreach (PointF point in points)
            {
                if (xmin > point.X) xmin = point.X;
                if (xmax < point.X) xmax = point.X;
                if (ymin > point.Y) ymin = point.Y;
                if (ymax < point.Y) ymax = point.Y;
            }
        }

        private Bitmap RotateBitmap(Bitmap bm, float angle)
        {
            // Make a Matrix to represent rotation
            // by this angle.
            Matrix rotate_at_origin = new Matrix();
            rotate_at_origin.Rotate(angle);

            // Rotate the image's corners to see how big
            // it will be after rotation.
            PointF[] points =
            {
                new PointF(0, 0),
                new PointF(bm.Width, 0),
                new PointF(bm.Width, bm.Height),
                new PointF(0, bm.Height),
            };
            rotate_at_origin.TransformPoints(points);
            float xmin, xmax, ymin, ymax;
            GetPointBounds(points, out xmin, out xmax,
                out ymin, out ymax);

            // Make a bitmap to hold the rotated result.
            int wid = (int)Math.Round(xmax - xmin);
            int hgt = (int)Math.Round(ymax - ymin);
            Bitmap result = new Bitmap(wid, hgt);

            // Create the real rotation transformation.
            Matrix rotate_at_center = new Matrix();
            rotate_at_center.RotateAt(angle,
                new PointF(wid / 2f, hgt / 2f));

            // Draw the image onto the new bitmap rotated.
            using (Graphics gr = Graphics.FromImage(result))
            {
                // Use smooth image interpolation.
                gr.InterpolationMode = InterpolationMode.High;

                // Clear with the color in the image's upper left corner.
                gr.Clear(bm.GetPixel(0, 0));

                //// For debugging. (It's easier to see the background.)
                //gr.Clear(Color.LightBlue);

                // Set up the transformation to rotate.
                gr.Transform = rotate_at_center;

                // Draw the image centered on the bitmap.
                int x = (wid - bm.Width) / 2;
                int y = (hgt - bm.Height) / 2;
                gr.DrawImage(bm, x, y);
            }

            // Return the result bitmap.
            return result;
        }

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string ipClassName, string ipWindowName);


        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
               IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        private void Keyboard(object sender, KeyPressedEventArgs e)
        {


            if (overlayToggleALTSToolStripMenuItem.Checked)
            {

                try
                {
                    if (overlay.Visible)
                    {

                        overlay.Visible = false;
                        SetForegroundWindow(getGmodHandle());
                    }
                    else
                    {
                        SetForegroundWindow(getGmodHandle());
                        overlay.Visible = true;

                        SetForegroundWindow(getGmodHandle());
                    }
                }
                catch
                {
                    overlay.Visible = false;
                }
            }

        }

        /// <summary>
        /// Opens the splashscreen
        /// </summary>
        public void Run()
        {
            Application.Run(new Splashscreen1());
        }

        /// <summary>
        /// Sets all controls' fonts on the main form
        /// </summary>
        private void InitControlFonts()
        {
            byte[] fontData = Properties.Resources.PrototypeFont;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, fontData.Length);
            AddFontMemResourceEx(fontPtr, (uint)fontData.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
            lblUsername.Font = new Font(fonts.Families[0], lblUsername.Font.Size);
            btnForums.Font = new Font(fonts.Families[0], btnForums.Font.Size);
            btnTS.Font = new Font(fonts.Families[0], btnTS.Font.Size);
            btnDRPRules.Font = new Font(fonts.Families[0], btnDRPRules.Font.Size);
            btnMilRPRules.Font = new Font(fonts.Families[0], btnMilRPRules.Font.Size);
            btnCWRPRules.Font = new Font(fonts.Families[0], btnCWRPRules.Font.Size);
            btnDupes.Font = new Font(fonts.Families[0], btnDupes.Font.Size);
            btnDanktown.Font = new Font(fonts.Families[0], btnDanktown.Font.Size);
            btnSundown.Font = new Font(fonts.Families[0], btnSundown.Font.Size);
            btnC18.Font = new Font(fonts.Families[0], btnC18.Font.Size);
            btnZombies.Font = new Font(fonts.Families[0], btnZombies.Font.Size);
            btnMilRP.Font = new Font(fonts.Families[0], btnMilRP.Font.Size);
            btnCW1.Font = new Font(fonts.Families[0], btnCW1.Font.Size);
            btnCW2.Font = new Font(fonts.Families[0], btnCW2.Font.Size);
            btnSettings.Font = new(fonts.Families[0], btnSettings.Font.Size);
            lblDT.Font = new(fonts.Families[0], lblDT.Font.Size);
            lblC18.Font = new(fonts.Families[0], lblC18.Font.Size);
            lblZRP.Font = new(fonts.Families[0], lblZRP.Font.Size);
            lblSD.Font = new(fonts.Families[0], lblSD.Font.Size);
            lblMRP.Font = new(fonts.Families[0], lblMRP.Font.Size);
            lblCW1.Font = new(fonts.Families[0], lblCW1.Font.Size);
            lblCW2.Font = new(fonts.Families[0], lblCW2.Font.Size);
            label7.Font = new(fonts.Families[0], label7.Font.Size);
            label2.Font = new(fonts.Families[0], label2.Font.Size);
        }

        /// <summary>
        /// Gets the gmod window name
        /// </summary>
        public static IntPtr getGmodHandle()
        {
            try
            {
                if (getGmodProcess() == null) return IntPtr.Zero; else if (getGmodProcess().ProcessName == "hl2") { return FindWindow(null, "Garry's Mod"); } else { return FindWindow(null, "Garry's Mod (x64)"); }
            }
            catch (Exception)
            {
                return IntPtr.Zero;
            }

        }

        /// <summary>
        /// Gets the gmod process, this works even if gmod is on another branch.
        /// </summary>

        public static Process getGmodProcess()
        {
            Process[] hl2 = Process.GetProcessesByName("hl2");
            Process[] gmod = Process.GetProcessesByName("gmod");
            if (hl2.Length > 0)
            {
                return hl2[0];
            }
            else if (gmod.Length > 0)
            {
                return gmod[0];
            }
            else
            {
                return null;
            }

        }
        void InitUser()
        {
            try
            {
                var client = new WebClient();
                string Url = $"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=7875E26FC3C740C9901DDA4C6E74EB4E&steamids={steam.GetSteamId()}";
                CookieContainer cookieJar = new CookieContainer();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.CookieContainer = cookieJar;
                request.Accept = @"text/html, application/xhtml+xml, */*";
                request.Referer = @"https://superiorservers.co/api";
                request.Headers.Add("Accept-Language", "en-GB");
                request.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    JsonDocument json = JsonDocument.Parse(sr.ReadToEnd());
                    lblUsername.Text = $"{json.RootElement.GetProperty("response").GetProperty("players")[0].GetProperty("personaname").GetString()}\n[{SteamIDFrom64Bit(steam.GetSteamId())}]";
                    byte[] avatarData = client.DownloadData(json.RootElement.GetProperty("response").GetProperty("players")[0].GetProperty("avatarfull").GetString());
                    using (var ms = new MemoryStream(avatarData))
                    {
                        picImage.Image = Image.FromStream(ms); client.Dispose(); ms.Close();
                        avatarImage = picImage.Image;
                    }
                }
                if (Settings.BackgroundImagePath != "")
                    panel1.BackgroundImage = Image.FromFile(Settings.BackgroundImagePath);


            }
            catch (Exception)
            {
                picImage.Image = Properties.Resources.suplogo;
                avatarImage = picImage.Image;
            }

        }
        void InitUserRank()
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://superiorservers.co/api/profile/" + frmLauncher.steam.GetSteamId());
            request.UserAgent = "Browser";
            WebResponse response = null;
            response = request.GetResponse(); // Get Response from webrequest
            StreamReader sr = new StreamReader(response.GetResponseStream()); // Create stream to access web data
            JsonElement ranksFromResult = JsonDocument.Parse(sr.ReadToEnd()).RootElement.GetProperty("Badmin").GetProperty("Ranks");
            switch (ranksFromResult.GetProperty("DarkRP").GetString())
            {
                case "VIP":
                    {
                        picRank.BackgroundImage = Properties.Resources.VIP;
                        break;
                    }
                case "Moderator":
                    {
                        picRank.BackgroundImage = Properties.Resources.MOD;
                        break;
                    }
                case "Admin":
                    {
                        picRank.BackgroundImage = Properties.Resources.ADMIN;
                        break;
                    }
                case "Double Admin":
                    {
                        picRank.BackgroundImage = Properties.Resources.DOUBLE;
                        break;
                    }
                case "Super Admin":
                    {
                        picRank.BackgroundImage = Properties.Resources.SUPER;
                        break;
                    }
                case "Council":
                    {
                        picRank.BackgroundImage = Properties.Resources.co_blue;
                        break;
                    }
                case "Root":
                    {
                        picRank.BackgroundImage = Properties.Resources.ROOT;
                        break;
                    }
                case "Content Creator":
                    {
                        picRank.BackgroundImage = Properties.Resources.cc_forumbar;
                        break;
                    }
                default:
                    {
                        picRank.BackgroundImage = Properties.Resources.MEMBER;
                        break;
                    }
            }
        }
        public static string SteamIDFrom64Bit(ulong steamid_64)
        {
            ulong universe = steamid_64 & 0x80000000;
            ulong account_id = steamid_64 & 0xFFFFFFFF;

            if (universe == 0)
            {
                return string.Format("STEAM_0:{0}:{1}", account_id % 2, account_id / 2);
            }
            else
            {
                universe >>= 31;
                return string.Format("STEAM_{0}:{1}:{2}", universe, account_id % 2, account_id / 2);
            }
        }
        private bool AppStartCheck()
        {
            Process proc = getGmodProcess();

            if (proc == null)
                return false;
            else
                return true;
        }
        void GetDupes()
        {
            string SteamInstallPathDir = FindGmodFolder();
            if (Directory.Exists($"{SteamInstallPathDir}\\garrysmod\\data\\advdupe2") == false)
            {
                dupePath = $"{SteamInstallPathDir}\\garrysmod\\data\\advdupe2";
            }
            else
                dupePath = $"{SteamInstallPathDir}\\garrysmod\\data\\advdupe2";
        }
        /// <summary>
        /// Finds the Garry's Mod install via the Windows Registry
        /// </summary>
        private static string FindGmodFolder()
        {
            if (Registry.GetValue(Environment.Is64BitOperatingSystem ? @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam" : @"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath", null) is string steamInstallPath)
            {
                Console.WriteLine($"Found steam install: {steamInstallPath}");

                string steamLibraryVdf = Path.Combine(steamInstallPath, "steamapps", "libraryfolders.vdf");

                if (File.Exists(steamLibraryVdf))
                {
                    Console.WriteLine($"Found steamlibrary vdf: {steamLibraryVdf}");
                    VProperty libraries = VdfConvert.Deserialize(File.ReadAllText(steamLibraryVdf));

                    foreach (VProperty library in libraries.Value.Children<VProperty>())
                    {
                        foreach (VProperty path in library.Value.Children<VProperty>().Where((v) => v.Key == "path"))
                        {
                            string gmodFolder = Path.Combine(path.Value.ToString(), "steamapps", "common", "GarrysMod");

                            if (Directory.Exists(gmodFolder) && File.Exists(Path.Combine(gmodFolder, "garrysmod", "cfg", "mount.cfg")))
                            {
                                Console.WriteLine($"Found gmod folder: {gmodFolder}");
                                return gmodFolder;
                            }
                        }
                    }
                }
            }
            return "";
        }
        /// <summary>
        /// Gets the server name and IP the provided steam user is on
        /// </summary>
        /// <param name="steamID">The steamid to use</param>
        /// <param name="normalState">Whether or not it is normally called via timer or not.</param>
        void GetCurrentServer(string steamID, bool normalState)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // Secure security protocol for querying the steam API
                HttpWebRequest request = WebRequest.CreateHttp("http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=7875E26FC3C740C9901DDA4C6E74EB4E&steamids=" + steamID);
                request.UserAgent = "Nick";
                WebResponse response = null;
                response = request.GetResponse(); // Get Response from webrequest
                StreamReader sr = new StreamReader(response.GetResponseStream()); // Create stream to access web data
                var rawResults = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(sr.ReadToEnd());
                string ip = rawResults.response.players.First.gameserverip.ToString();
                string playerName = rawResults.response.players.First.personaname.ToString();
                if (ip == $"{rp1}:27015")
                {
                    if (normalState)
                    {
                        panDanktown.BackColor = Color.SpringGreen;
                        panC18.BackColor = Color.RoyalBlue;
                        //panZombies.BackColor = Color.LightCoral;
                        panMilRP.BackColor = Color.RoyalBlue;
                        panCW1.BackColor = Color.RoyalBlue;
                        panCW2.BackColor = Color.RoyalBlue;
                        lblServer.Text = "Danktown";
                    }
                    else
                    {
                        playerServer = playerName + "(" + steamID + ") is on Danktown(rp.superiorservers.co)";
                    }
                }
                else if (ip == $"{rp2}:27015")
                {
                    if (normalState)
                    {
                        panDanktown.BackColor = Color.RoyalBlue;
                        panC18.BackColor = Color.SpringGreen;
                        //panZombies.BackColor = Color.RoyalBlue;
                        panMilRP.BackColor = Color.RoyalBlue;
                        panCW1.BackColor = Color.RoyalBlue;
                        panCW2.BackColor = Color.RoyalBlue;
                        lblServer.Text = "C18";
                    }
                    else
                    {
                        playerServer = playerName + "(" + steamID + ") is on C18(rp2.superiorservers.co)";
                    }
                }
                else if (ip == $"{milrp}:27015")
                {
                    if (normalState)
                    {
                        panDanktown.BackColor = Color.RoyalBlue;
                        panC18.BackColor = Color.RoyalBlue;
                        //panZombies.BackColor = Color.RoyalBlue;
                        panMilRP.BackColor = Color.SpringGreen;
                        panCW1.BackColor = Color.RoyalBlue;
                        panCW2.BackColor = Color.RoyalBlue;
                        lblServer.Text = "MilRP";
                    }
                    else
                    {
                        playerServer = playerName + "(" + steamID + ") is on MilRP(milrp.superiorservers.co)";
                    }
                }
                else if (ip == $"{cwrp1}:27015")
                {
                    if (normalState)
                    {
                        panDanktown.BackColor = Color.RoyalBlue;
                        panC18.BackColor = Color.RoyalBlue;
                        //panZombies.BackColor = Color.RoyalBlue;
                        panMilRP.BackColor = Color.RoyalBlue;
                        panCW1.BackColor = Color.SpringGreen;
                        panCW2.BackColor = Color.RoyalBlue;
                        lblServer.Text = "CWRP #1";
                    }
                    else
                    {
                        playerServer = playerName + "(" + steamID + ") is on CWRP #1(cwrp.superiorservers.co)";
                    }
                }
                else if (ip == $"{cwrp2}:27015")
                {
                    if (normalState)
                    {
                        panDanktown.BackColor = Color.RoyalBlue;
                        panC18.BackColor = Color.RoyalBlue;
                        //panZombies.BackColor = Color.RoyalBlue;
                        panMilRP.BackColor = Color.RoyalBlue;
                        panCW1.BackColor = Color.RoyalBlue;
                        panCW2.BackColor = Color.SpringGreen;
                        lblServer.Text = "CWRP #2";
                    }
                    else
                    {
                        playerServer = playerName + "(" + steamID + ") is on CWRP #2(cwrp2.superiorservers.co)";
                    }
                }
            }
            catch (Exception)
            {
                if (normalState)
                {
                    panDanktown.BackColor = Color.RoyalBlue;
                    panC18.BackColor = Color.RoyalBlue;
                    //panZombies.BackColor = Color.RoyalBlue;
                    panMilRP.BackColor = Color.RoyalBlue;
                    panCW1.BackColor = Color.RoyalBlue;
                    panCW2.BackColor = Color.RoyalBlue;
                    lblServer.Text = "";
                }
                else
                {
                    playerServer = "This player is not playing on a server or has their steam profile private.";
                }
            }
        }
        private void GetPlayerCountAllServers(bool startup)
        {
            try
            {


                string Url = "https://superiorservers.co/api/servers";
                CookieContainer cookieJar = new CookieContainer();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.CookieContainer = cookieJar;
                request.Accept = @"text/html, application/xhtml+xml, */*";
                request.Referer = @"https://superiorservers.co/api";
                request.Headers.Add("Accept-Language", "en-GB");
                request.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
                //request.Host = @"https://superiorservers.co/api";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string htmlString;
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    htmlString = reader.ReadToEnd();
                }

                var jsonRoot = JsonDocument.Parse(htmlString).RootElement.GetProperty("response").GetProperty("Servers");


                danktownPlayerCount = jsonRoot[2].GetProperty("Players").GetInt32();
                c18PlayerCount = jsonRoot[3].GetProperty("Players").GetInt32();
                cwrpPlayerCount = jsonRoot[4].GetProperty("Players").GetInt32();
                cwrp2PlayerCount = jsonRoot[5].GetProperty("Players").GetInt32();
                milrpPlayerCount = jsonRoot[7].GetProperty("Players").GetInt32();

                /*
                 * DT: 199.231.233.142
                 * ZRP: 199.231.233.143
                 * MilRP: 208.103.169.18
                 * CWRP1: 199.231.233.148
                 * CWRP2: 199.231.233.149
                 * CWRP3: 199.231.233.150
                 */

                if (refresh == 0 || startup)
                {

                    ThreadHelperClass.SetText(this, lblDT, danktownPlayerCount.ToString() + "/128");
                    ThreadHelperClass.SetText(this, lblC18, c18PlayerCount.ToString() + "/128");
                    //ThreadHelperClass.SetText(this, lblC18, GetPlayerCount("rp2.superiorservers.co").ToString() + "/128"); rip c18
                    ThreadHelperClass.SetText(this, lblMRP, milrpPlayerCount.ToString() + "/128");
                    ThreadHelperClass.SetText(this, lblCW1, cwrpPlayerCount.ToString() + "/128");
                    ThreadHelperClass.SetText(this, lblCW2, cwrp2PlayerCount.ToString() + "/128");
                    refresh++;
                    tmrRefresh.Start();
                }
            }
            catch (Exception)
            {
            }

        }
        private string getModiferKey(uint key)
        {
            return key switch
            {
                (uint)SUPLauncher.ModifierKeys.Control => "CTRL",
                (uint)SUPLauncher.ModifierKeys.Alt => "ALT",
                (uint)SUPLauncher.ModifierKeys.Shift => "SHIFT",
                _ => string.Empty
            };
        }
        public void loadOverlay()
        {
            if (getGmodProcess() != null)
            {
                if (overlayToggleALTSToolStripMenuItem.Checked)
                {
                    if (overlay.IsDisposed)
                    {
                        overlay = new Overlay();
                    }
                    overlay.Visible = true;
                    overlay.Visible = false;
                    SetForegroundWindow(getGmodHandle());
                }
                else
                {
                    if (overlay != null)
                    {
                        if (!overlay.IsDisposed)
                        {
                            overlay.Close();
                        }
                    }
                }
            }
        }
        static void DownloadFile(string url, string downloadPath)
        {
            try
            {
                // Create a web request to the URL
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                CookieContainer cookieJar = new CookieContainer();
                request.CookieContainer = cookieJar;
                request.Accept = @"text/html, application/xhtml+xml, */*";
                request.Referer = @"https://superiorservers.co/api";
                request.Headers.Add("Accept-Language", "en-GB");
                request.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
                // Get the web response
                using (var response = request.GetResponse())
                {
                    // Get the stream containing content returned by the server
                    using (var stream = response.GetResponseStream())
                    {
                        // Create a FileStream to write the downloaded file
                        using (var fileStream = new FileStream(downloadPath, FileMode.Create))
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead;
                            long totalBytesRead = 0;
                            long totalBytes = response.ContentLength; // Total size of the file

                            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                fileStream.Write(buffer, 0, bytesRead);
                                totalBytesRead += bytesRead;

                                // Calculate the progress percentage
                                int progress = (int)(((double)totalBytesRead / totalBytes) * 100);

                                // Display progress in console
                                Console.Write($"\rDownloading... {progress}%");
                            }
                        }
                    }
                }

                Console.WriteLine(); // Move to next line after download completes
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading file: {ex.Message}");
            }
        }
        static void ExtractZip(string zipFilePath, string extractPath)
        {
            try
            {
                ZipFile.ExtractToDirectory(zipFilePath, extractPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting zip file: {ex.Message}");
            }
        }
        #endregion

        #region Event Handlers
        private void TopBar_MouseUp(object sender, MouseEventArgs e)
        {
            isTopPanelDragged = false;
            if (this.Location.Y <= 5)
            {

                _normalWindowSize = this.Size;
                _normalWindowLocation = this.Location;

                Rectangle rect = Screen.PrimaryScreen.WorkingArea;
                this.Location = new Point(0, 0);
                this.Size = new System.Drawing.Size(rect.Width, rect.Height);


            }
        }

        private void TopBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isTopPanelDragged)
            {
                Point newPoint = topBar.PointToScreen(new Point(e.X, e.Y));
                newPoint.Offset(offset);
                this.Location = newPoint;

                if (this.Location.X > 2 || this.Location.Y > 2)
                {
                    if (this.WindowState == FormWindowState.Maximized)
                    {
                        this.Location = _normalWindowLocation;
                        this.Size = _normalWindowSize;
                    }
                }
            }
        }

        private void TopBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isTopPanelDragged = true;
                Point pointStartPosition = this.PointToScreen(new Point(e.X, e.Y));
                offset = new Point
                {
                    X = this.Location.X - pointStartPosition.X,
                    Y = this.Location.Y - pointStartPosition.Y
                };
            }
            else
            {
                isTopPanelDragged = false;
            }
            if (e.Clicks == 2)
            {
                isTopPanelDragged = false;

            }
        }
        private void TmrSteamQuery_Tick(object sender, EventArgs e)
        {
            GetCurrentServer(steam.GetSteamId().ToString(), true);
        }

        private void discordStatusToggleToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (discordStatusToggleToolStripMenuItem.Checked)
            {
                LblServer_TextChanged(this, new EventArgs());
            }
        }

        private void LblServer_TextChanged(object sender, EventArgs e)
        {
            if (discord.IsInitialized && discordStatusToggleToolStripMenuItem.Checked)
            {
                GetPlayerCountAllServers(false);
                discord.RegisterUriScheme("4000", executable: "explorer steam://rungameid/4000");
                switch (lblServer.Text)
                {
                    case "Danktown":

                        discord.SetPresence(new RichPresence()
                        {
                            Buttons = new DiscordRPC.Button[]
                            {
                                new DiscordRPC.Button() { Label = "Join", Url = $"steam://connect/{rp1}:27015" },
                                new DiscordRPC.Button(){ Label = "Forums", Url = "https://superiorservers.co/" },
                            },
                            Details = "Playing on Danktown",
                            State = "SuperiorServers.co",
                            Timestamps = Timestamps.Now,
                            Party = new Party()
                            {
                                ID = "balls",
                                Size = danktownPlayerCount,
                                Max = 128,
                                Privacy = Party.PrivacySetting.Public
                            },
                            Assets = new Assets()
                            {
                                LargeImageKey = "suplogo",
                                LargeImageText = "SuperiorServers.co",
                            },

                        });
                        break;
                    case "C18":
                        discord.SetPresence(new RichPresence()
                        {
                            Buttons = new DiscordRPC.Button[]
                            {
                                new DiscordRPC.Button() { Label = "Join", Url = $"steam://connect/{rp2}:27015" },
                                new DiscordRPC.Button(){ Label = "Forums", Url = "https://superiorservers.co/" },
                            },
                            Details = "Playing on C18",
                            State = "SuperiorServers.co",
                            Timestamps = Timestamps.Now,
                            Party = new Party()
                            {
                                ID = "balls2",
                                Size = c18PlayerCount,
                                Max = 128,
                                Privacy = Party.PrivacySetting.Public
                            },
                            Assets = new Assets()
                            {
                                LargeImageKey = "suplogo",
                                LargeImageText = "SuperiorServers.co"
                            }
                        });
                        break;
                    //case "ZRP":
                    //    discord.SetPresence(new RichPresence()
                    //    {
                    //        Details = "Playing on ZRP",
                    //        State = "",
                    //        Timestamps = Timestamps.Now,
                    //        Assets = new Assets()
                    //        {
                    //            LargeImageKey = "suplogo",
                    //            LargeImageText = "SuperiorServers.co"
                    //        }
                    //    });
                    //    break;
                    case "MilRP":
                        discord.SetPresence(new RichPresence()
                        {
                            Buttons = new DiscordRPC.Button[]
                            {
                                new DiscordRPC.Button() { Label = "Join", Url = $"steam://connect/{milrp}:27015" },
                                new DiscordRPC.Button(){ Label = "Forums", Url = "https://superiorservers.co/" },
                            },
                            Details = "Playing on MilRP",
                            State = "SuperiorServers.co",
                            Timestamps = Timestamps.Now,
                            Party = new Party()
                            {
                                ID = "balls3",
                                Size = milrpPlayerCount,
                                Max = 128,
                                Privacy = Party.PrivacySetting.Public
                            },
                            Assets = new Assets()
                            {
                                LargeImageKey = "suplogo",
                                LargeImageText = "SuperiorServers.co"
                            }
                        });
                        break;
                    case "CWRP #1":
                        discord.SetPresence(new RichPresence()
                        {
                            Buttons = new DiscordRPC.Button[]
                            {
                                new DiscordRPC.Button() { Label = "Join", Url = $"steam://connect/{cwrp1}:27015" },
                                new DiscordRPC.Button(){ Label = "Forums", Url = "https://superiorservers.co/" },
                            },
                            Details = "Playing on CWRP #1",
                            State = "SuperiorServers.co",
                            Timestamps = Timestamps.Now,
                            Party = new Party()
                            {
                                ID = "balls4",
                                Size = cwrpPlayerCount,
                                Max = 128,
                                Privacy = Party.PrivacySetting.Public
                            },
                            Assets = new Assets()
                            {
                                LargeImageKey = "suplogo",
                                LargeImageText = "SuperiorServers.co"
                            }
                        });
                        break;
                    case "CWRP #2":
                        discord.SetPresence(new RichPresence()
                        {
                            Buttons = new DiscordRPC.Button[]
                            {
                                new DiscordRPC.Button() { Label = "Join", Url = $"steam://connect/{cwrp2}:27015" },
                                new DiscordRPC.Button(){ Label = "Forums", Url = "https://superiorservers.co/" },
                            },
                            Details = "Playing on CWRP #2",
                            State = "SuperiorServers.co",
                            Timestamps = Timestamps.Now,
                            Party = new Party()
                            {
                                ID = "balls5",
                                Size = cwrp2PlayerCount,
                                Max = 128,
                                Privacy = Party.PrivacySetting.Public
                            },
                            Assets = new Assets()
                            {
                                LargeImageKey = "suplogo",
                                LargeImageText = "SuperiorServers.co"
                            }
                        });
                        break;
                    case "":
                        discord.Logger.Level = DiscordRPC.Logging.LogLevel.Info;
                        discord.SetPresence(new RichPresence()
                        {
                            Details = "Waiting to join a server...",
                            State = "SuperiorServers.co",
                            Timestamps = Timestamps.Now,
                            Buttons = new DiscordRPC.Button[]
                            {
                                new DiscordRPC.Button(){ Label = "Forums", Url = "https://superiorservers.co/" },
                                new DiscordRPC.Button(){ Label = "Bans", Url = "https://superiorservers.co/bans" }
                            },
                            Assets = new Assets()
                            {
                                LargeImageKey = "suplogo",
                                LargeImageText = "SuperiorServers.co"
                            }
                        });
                        break;
                }

            }
        }
        private void BtnDupes_Click(object sender, EventArgs e)
        {
            new DupeManager().ShowDialog();
        }

        private void LblRefresh_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                int i = 0;
                while (i != 10)
                {
                    i = i + 1;
                    Thread.Sleep(70);
                    rotateInThread(new Bitmap(refresh_img), 90);
                    imgrefresh.Image = refresh_img;
                }
                imgrefresh.Image = original_refreshimg;
                return;

            }).Start();
            GetPlayerCountAllServers(false);
        }

        private void TmrRefresh_Tick(object sender, EventArgs e)
        {
            if (refresh > 0 && refresh < 60)
            {
                refresh++;
            }
            else
            {
                refresh = 0;
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text.Contains("STEAM_0:0:") || textBox1.Text.Contains("STEAM_0:1:") || (textBox1.Text.StartsWith("7") && textBox1.Text.Length == 76561197960265728.ToString().Length))
                {
                    Program.OpenURL("https://superiorservers.co/profile/" + textBox1.Text);
                    forumSteamIDLookup = textBox1.Text;
                    //wbForumbrowser.Url = new Uri("https://superiorservers.co/profile/" + steamid);
                    //wbForumbrowser.Size = new Size(1280, 720);
                    //wbForumbrowser.Visible = true;
                }
                else
                {
                    MessageBox.Show("Invalid SteamID. Make sure you have the correct SteamID", "Error");
                }
            }

        }
        private void TextBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = "STEAM_0:X:XXXXXXXXX";
        }
        private void TextBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void FrmLauncher_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            ClientUpdater.Update();
        }


        private void ToolTip1_Popup(object sender, PopupEventArgs e)
        {
            if ((e.AssociatedControl.Name != lblVersion.Name) && (e.AssociatedControl.Name != versionWarn.Name))
            {
                toolTip1.ToolTipIcon = ToolTipIcon.Info;
            }
            if (e.AssociatedControl == versionWarn)
                toolTip1.ToolTipTitle = lblVersion.Text;
            else if (e.AssociatedControl == picImage)
                toolTip1.ToolTipTitle = "Your avatar";
            else if (e.AssociatedControl == picRepoLink)
                toolTip1.ToolTipTitle = "SUP Launcher Github";
            else
                toolTip1.ToolTipTitle = e.AssociatedControl.Text;
        }



        private void overlayToggleALTSToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Notification notif;
            if (!overlayToggleALTSToolStripMenuItem.Checked)
            {
                notif = new Notification("SUPLauncher overlay is disabled.", "NOTIFICATION", true);
                notif.Show();
            }
            else
            {
                string keybind = $"ALT + {Settings.OverlayKey}";
                notif = new Notification("SUPLauncher overlay is enabled.\n(" + keybind + ")", "NOTIFICATION", true);
                notif.Show();
                loadOverlay();
            }
        }

        private void frmLauncher_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("test");
        }

        private void picImage_Resize(object sender, EventArgs e)
        {
            base.OnResize(e);
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(new Rectangle(0, 0, picImage.Width - 1, picImage.Height - 1));
                picImage.Region = new Region(gp);
            }
        }
        private void BtnDanktown_Click(object sender, EventArgs e)
        {
            if (chkAFK.Checked)
            {
                Program.OpenURL("steam://open/main");
                WindowFocus.ActivateProcess(Process.GetProcessesByName("steam")[0].Id);
                //UpdateGmodConfig(0);
                Program.OpenURL("steam://run/4000//-64bit -textmode -single_core -nojoy -low -nosound -sw -noshader -nopix -novid -nopreload -nopreloadmodels -multirun +cl_mouselook 0 +connect rp.superiorservers.co");
            }
            else // if not afk mode then
            {
                Program.OpenURL($"steam://run/4000//+cl_mouselook 1 +connect {rp1}");
            }

        }

        //private void btnSundown_Click(object sender, EventArgs e)
        //{
        //    if (chkAFK.Checked && AppStartCheck() == false)
        //    {
        //        Program.OpenURL("steam:");
        //        Program.OpenURL("steam://run/4000//-64bit -textmode -single_core -nojoy -low -nosound -sw -noshader -nopix -novid -nopreload -nopreloadmodels -multirun +connect rp2.superiorservers.co");
        //    }
        //    else
        //    {
        //        Program.OpenURL("steam://connect/rp2.superiorservers.co:27015");
        //    }
        //    
        //}
        private void BtnC18_Click(object sender, EventArgs e)
        {

            if (chkAFK.Checked && AppStartCheck() == false)
            {
                Program.OpenURL("steam://open/main");
                WindowFocus.ActivateProcess(Process.GetProcessesByName("steam")[0].Id);
                Program.OpenURL("steam://run/4000//-64bit -textmode -single_core -nojoy -low -nosound -sw -noshader -nopix -novid -nopreload -nopreloadmodels -multirun +cl_mouselook 0 +connect rp2.superiorservers.co");
                SendAFKCommand("\"cl_mouselook 0\""); // Set cl_mouselook to 0
            }
            else // if not afk mode then
            {
                Program.OpenURL($"steam://run/4000//+cl_mouselook 1 +connect {rp2}");
            }
        }
        private void BtnZombies_Click(object sender, EventArgs e)
        {

            if (chkAFK.Checked && AppStartCheck() == false)
            {
                Program.OpenURL("steam://open/main");
                WindowFocus.ActivateProcess(Process.GetProcessesByName("steam")[0].Id);
                Program.OpenURL("steam://run/4000//-64bit -textmode -single_core -nojoy -low -nosound -sw -noshader -nopix -novid -nopreload -nopreloadmodels -multirun +connect zrp.superiorservers.co");
                SendAFKCommand("\"cl_mouselook 0\""); // Set cl_mouselook to 0
            }
            else // if not afk mode then
            {

            }
        }
        private void BtnMilRP_Click(object sender, EventArgs e)
        {

            if (chkAFK.Checked && AppStartCheck() == false)
            {
                Program.OpenURL("steam://open/main");
                WindowFocus.ActivateProcess(Process.GetProcessesByName("steam")[0].Id);
                Program.OpenURL("steam://run/4000//-64bit -textmode -single_core -nojoy -low -nosound -sw -noshader -nopix -novid -nopreload -nopreloadmodels -multirun +connect milrp.superiorservers.co");
                SendAFKCommand("\"cl_mouselook 0\""); // Set cl_mouselook to 0
            }
            else // if not afk mode then
            {
                Program.OpenURL($"steam://run/4000//+cl_mouselook 1 +connect {milrp}");
            }
        }
        private void BtnCW1_Click(object sender, EventArgs e)
        {

            if (chkAFK.Checked && AppStartCheck() == false)
            {
                Program.OpenURL("steam://open/main");
                WindowFocus.ActivateProcess(Process.GetProcessesByName("steam")[0].Id);
                Program.OpenURL("steam://run/4000//-64bit -textmode -single_core -nojoy -low -nosound -sw -noshader -nopix -novid -nopreload -nopreloadmodels -multirun +connect cwrp.superiorservers.co");
                SendAFKCommand("\"cl_mouselook 0\""); // Set cl_mouselook to 0
            }
            else // if not afk mode then
            {
                Program.OpenURL($"steam://run/4000//+cl_mouselook 1 +connect {cwrp1}");
            }
        }
        private void BtnCW2_Click(object sender, EventArgs e)
        {

            if (chkAFK.Checked && AppStartCheck() == false)
            {
                Program.OpenURL("steam://open/main");
                WindowFocus.ActivateProcess(Process.GetProcessesByName("steam")[0].Id);
                Program.OpenURL("steam://run/4000//-64bit -textmode -single_core -nojoy -low -nosound -sw -noshader -nopix -novid -nopreload -nopreloadmodels -multirun +connect cwrp2.superiorservers.co");
                SendAFKCommand("\"cl_mouselook 0\""); // Set cl_mouselook to 0
            }
            else // if not afk mode then
            {
                Program.OpenURL($"steam://run/4000//+cl_mouselook 1 +connect {cwrp2}");
            }

        }
        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Keep in mind that this program is still being worked on and is not an official release of the SUP Launcher. In order to use this program, you must just simply click on a button and watch the magic happen. The credit for this idea goes to aStonedPenguin, and all new releases will available on the github (Nicks-Alt/SUPLauncher). Thanks for using this nice little program I made, and have a fun time playing SuperiorServers." + Environment.NewLine + Environment.NewLine + "-Nick", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BtnForums_Click(object sender, EventArgs e)
        {
            Program.OpenURL("https://forum.superiorservers.co");
        }
        private void BtnTS_Click(object sender, EventArgs e)
        {
            Program.OpenURL("ts3server://TS.SuperiorServers.co:9987");
        }
        private void FrmLauncher_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            try
            {
                t1 = new System.Windows.Forms.Timer();
                t1.Interval = 10;  //we'll increase the opacity every 10ms
                t1.Tick += new EventHandler(fadeOut);  //this calls the function that changes opacity 
                t1.Start();

                if (this.Opacity == 0)
                {
                    e.Cancel = false;
                    Settings.AFKStatus = chkAFK.Checked;
                    Settings.DiscordStatus = discordStatusToggleToolStripMenuItem.Checked;
                    Settings.OverlayEnabled = overlayToggleALTSToolStripMenuItem.Checked;
                }
                Interaction.Shell("taskkill /pid " + Process.GetCurrentProcess().Id.ToString() + " /f /t"); // Whoops
            }
            catch (Exception)
            {
                Interaction.Shell("taskkill /pid " + Process.GetCurrentProcess().Id.ToString() + " /f /t");
            }

        }
        private void ChkAFK_CheckedChanged(object sender, EventArgs e)
        {
            //Settings.AFKStatus = chkAFK.Checked;
            //notifyIcon1.Visible = true;
            if (chkAFK.Checked)
            {
                tmrAFK.Enabled = true;
                tmrAFK.Start();
                Notification notif = new Notification("You are now in AFK Mode. \nPress on a server from the list on the menu \nand confirm it in steam to begin AFKing \non SUP!", "AFK MODE", false, 115);
                notif.Show();
            }
            else
            {
                tmrAFK.Enabled = false;
                tmrAFK.Stop();
                Notification notif = new Notification("You are no longer in AFK Mode. \nPressing on a server will launch the game \n normally through steam with \n regular graphics.", "AFK MODE", false, 115);
                notif.Show();
            }
            try
            {
                Process.GetProcessesByName("hl2")[0].Kill();
            }
            catch (Exception)
            {
                // Does nothing if permission is denied...
                // As doing something may bring up usless errors
                // Even though gmod is already closed
            }
            try
            {
                Process.GetProcessesByName("gmod")[0].Kill();
            }
            catch (Exception)
            {
                // Do nothing if process does not exist
            }
        }

        private void PicImage_Click(object sender, EventArgs e)
        {
            Program.OpenURL($"https://superiorservers.co/profile/{steam.GetSteamId()}");
        }
        private void BtnDRPRules_Click(object sender, EventArgs e)
        {
            Program.OpenURL("https://superiorservers.co/darkrp/rules");
        }
        private void BtnMilRPRules_Click(object sender, EventArgs e)
        {
            Program.OpenURL("https://superiorservers.co/ssrp/milrp/rules");
        }

        private void BtnCWRPRules_Click(object sender, EventArgs e)
        {
            Program.OpenURL("https://superiorservers.co/ssrp/cwrp/rules");
        }
        private void LblVersion_Click(object sender, EventArgs e)
        {
            ClientUpdater.Update();
        }

        private void picRepoLink_Click(object sender, EventArgs e)
        {
            Program.OpenURL("https://github.com/Nicks-Alt/SUPLauncher");
        }

        private void tmrAFK_Tick(object sender, EventArgs e)
        {
            try
            {
                if (chkAFK.Checked && AppStartCheck())
                {
                    Task.Factory.StartNew(() => // Do Task Factory because no hanging! // Thank you to Jaiden/Particles for helping with this!
                    {
                        #region AFK Macro
                        SendAFKCommand("\"rp spawn; echo [SUPLauncher] Attempting to spawn...\"");
                        Thread.Sleep(500);
                        SendAFKCommand("\"rp selectweapon pocket; echo [SUPLauncher] Selected pocket\"");
                        Thread.Sleep(500);
                        SendAFKCommand("\"+lookdown; echo [SUPLauncher] Ran lookdown\"");
                        Thread.Sleep(500);
                        SendAFKCommand("\"rp poop; echo [SUPLauncher] Ran /poop\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("+moveright");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveright");
                        SendAFKCommand("+moveleft");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveleft");
                        SendAFKCommand("+moveright");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveright");
                        SendAFKCommand("+moveleft");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveleft");
                        SendAFKCommand("+moveright");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveright");
                        SendAFKCommand("+moveleft");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveleft");
                        SendAFKCommand("+moveright");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveright");
                        SendAFKCommand("+moveleft");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveleft");
                        SendAFKCommand("+moveright");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveright");
                        SendAFKCommand("+moveleft");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveleft");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("+moveright");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveright");
                        SendAFKCommand("+moveleft");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveleft");
                        SendAFKCommand("+moveright");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveright");
                        SendAFKCommand("+moveleft");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveleft");
                        SendAFKCommand("+moveright");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveright");
                        SendAFKCommand("+moveleft");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveleft");
                        SendAFKCommand("+moveright");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveright");
                        SendAFKCommand("+moveleft");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveleft");
                        SendAFKCommand("+moveright");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveright");
                        SendAFKCommand("+moveleft");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveleft");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("+moveright");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveright");
                        SendAFKCommand("+moveleft");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveleft");
                        SendAFKCommand("+moveright");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveright");
                        SendAFKCommand("+moveleft");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveleft");
                        SendAFKCommand("+moveright");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveright");
                        SendAFKCommand("+moveleft");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveleft");
                        SendAFKCommand("+moveright");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveright");
                        SendAFKCommand("+moveleft");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveleft");
                        SendAFKCommand("+moveright");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveright");
                        SendAFKCommand("+moveleft");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        Thread.Sleep(200);
                        SendAFKCommand("-moveleft");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"+attack\""); Thread.Sleep(10);
                        Thread.Sleep(10);
                        SendAFKCommand("\"-attack\"");
                        SendAFKCommand("\"echo [SUPLauncher] Thank you for AFKing on SUP!\"");
                        #endregion
                    });
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion

        private void btnSettings_Click(object sender, EventArgs e)
        {
            mnuSettingsDrop.Show(btnSettings, new Point(0, btnSettings.Height));
        }

        private void setBackgroundImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(ofdSetBackgroundImage.ShowDialog() == DialogResult.Cancel))
            {
                panel1.BackgroundImage = Image.FromFile(ofdSetBackgroundImage.FileName);
                Settings.BackgroundImagePath = ofdSetBackgroundImage.FileName;
            }
        }


        private void setDefaultBackgroundImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.BackgroundImage = Properties.Resources.background2;
            picRepoLink.Image = Properties.Resources.suplogo;
            picImage.Image = avatarImage;
            Settings.BackgroundImagePath = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (chkAFK.Checked)
                chkAFK.Checked = false;
            else
                chkAFK.Checked = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (discordStatusToggleToolStripMenuItem.Checked)
                discordStatusToggleToolStripMenuItem.Checked = false;
            else
                discordStatusToggleToolStripMenuItem.Checked = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (overlayToggleALTSToolStripMenuItem.Checked)
                overlayToggleALTSToolStripMenuItem.Checked = false;
            else
                overlayToggleALTSToolStripMenuItem.Checked = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                panel1.BackgroundImage = Properties.Resources.MONKEY;
                picRepoLink.Image = Properties.Resources.MONKEY;
                picImage.Image = Properties.Resources.MONKEY;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        [DllImport("kernel32.dll", EntryPoint = "GetStdHandle", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int AllocConsole();

        private const int STD_OUTPUT_HANDLE = -11;
        private const int MY_CODE_PAGE = 437;
        private void downloadCSSTexturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to download the CSS textures for Garry's Mod?\n\n WARNING: THIS WILL TAKE SOME TIME!", "Download CSS Textures", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!(Directory.Exists($"{FindGmodFolder()}\\garrysmod\\addons\\css-content-gmodcontent")))
                {
                    AllocConsole();
                    IntPtr stdHandle = GetStdHandle(STD_OUTPUT_HANDLE);
                    Microsoft.Win32.SafeHandles.SafeFileHandle safeFileHandle = new Microsoft.Win32.SafeHandles.SafeFileHandle(stdHandle, true);
                    FileStream fileStream = new FileStream(safeFileHandle, FileAccess.Write);
                    StreamWriter standardOutput = new StreamWriter(fileStream);
                    standardOutput.AutoFlush = true;
                    Console.SetOut(standardOutput);
                    Console.WriteLine("DOWNLOADING CSS CONTENT. DO NOT CLOSE THIS WINDOW UNTIL PROCESS IS FINISHED!");
                    string url = "https://suplauncher.s3.us-east-2.amazonaws.com/css-content-gmodcontent.zip"; // Replace with your download URL
                    string downloadPath = "downloaded.zip";      // Temporarily downloaded file
                    string extractPath = $"{FindGmodFolder()}\\garrysmod\\addons";    // Directory to extract contents
                    Console.WriteLine("Downloading file...");
                    DownloadFile(url, downloadPath);

                    Console.WriteLine("Extracting contents...");
                    ExtractZip(downloadPath, extractPath);

                    Console.WriteLine("Cleaning up...");
                    File.Delete(downloadPath); // Delete the downloaded zip file

                    Console.WriteLine("Process completed successfully. Press any key to close the launcher...");
                    Console.ReadKey();
                    this.Close();
                }
                else
                    MessageBox.Show("CSS Textures already installed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    #region Classes
    public static class MemoryStreamExtensions
    {
        
        public static string ReadTerminatedString(this MemoryStream ms)
        {
            List<byte> res = new List<byte>();

            byte last;
            while ((last = (byte)ms.ReadByte()) != 0x00)
            {
                res.Add(last);
            }

            return System.Text.Encoding.ASCII.GetString(res.ToArray());
        }
    }
    public static class ThreadHelperClass // Because fuck threads and me not allowing to just set text on a label like a normal person
    {
        delegate void SetTextCallback(Form f, Control ctrl, string text);
        /// <summary>
        /// Set text property of various controls
        /// </summary>
        /// <param name="form">The calling form</param>
        /// <param name="ctrl">The control being modified</param>
        /// <param name="text">The text to set</param>
        public static void SetText(Form form, Control ctrl, string text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (ctrl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                form.Invoke(d, new object[] { form, ctrl, text });
            }
            else
            {
                ctrl.Text = text;
            }
        }
    }
#endregion

}
