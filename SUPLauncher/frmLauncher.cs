using System.Diagnostics;
using System.Net;
using Microsoft.VisualBasic;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using DiscordRPC;
using System.Text.Json;
using CefSharp;
using Microsoft.Win32;
using Gameloop.Vdf.Linq;
using Gameloop.Vdf;

namespace SUPLauncher
{



    public partial class frmLauncher : Form
    {
        int refresh = 0;
        bool appStarted = false;
        public static string dupePath = "";
        string playerServer;
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
        private string rp1 = Dns.GetHostEntry("rp.superiorservers.co").AddressList[0].ToString();
        private string rp2 = Dns.GetHostEntry("rp2.superiorservers.co").AddressList[0].ToString();
        private string milrp = Dns.GetHostEntry("milrp.superiorservers.co").AddressList[0].ToString();
        private string cwrp1 = Dns.GetHostEntry("cwrp.superiorservers.co").AddressList[0].ToString();
        private string cwrp2 = Dns.GetHostEntry("cwrp2.superiorservers.co").AddressList[0].ToString();

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


        public frmLauncher()
        {
            if (Process.GetProcessesByName("steam").Length == 0) // Check if steam is running (Thanks Red Means Recording)
            {
                MessageBox.Show("An error occurred. Please restart the program when steam is running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Interaction.Shell("taskkill /pid " + Process.GetCurrentProcess().Id.ToString() + " /f");
            }
            Thread trd = new Thread(new ThreadStart(Run));
            trd.Start();
            InitializeComponent();
            discord.Initialize();
            discord.OnReady += (sender, msg) =>
            {
                Program.Startup_DiscordReady = true;
                Console.WriteLine("Presence is ready");
            };
            GetCurrentServer(steam.GetSteamId().ToString(), true);

            trd.Join();
            refresh_img = imgrefresh.Image;
            original_refreshimg = imgrefresh.Image;

            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(Keyboard);

            hook.RegisterKeybind(Settings.OverlayModifierKey, (int)Settings.OverlayKey);

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
            Opacity = 0;      //first the opacity is 0

            t1.Interval = 10;  //we'll increase the opacity every 10ms
            t1.Tick += new EventHandler(fadeIn);  //this calls the function that changes opacity 
            t1.Start();
        }
        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
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

        bool altdown = false;
        bool sdown = false;
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        private void Keyboard(object sender, KeyPressedEventArgs e)
        {


            if (chkOverlay.Checked)
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

        public void Run()
        {
            Application.Run(new Splashscreen1());
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

        private DiscordRpcClient discord = new DiscordRpcClient("594668399653814335") { Logger = new DiscordRPC.Logging.ConsoleLogger(DiscordRPC.Logging.LogLevel.Info, true) };

        private void FrmLauncher_Load(object sender, EventArgs e)
        {
            //if (ClientUpdater.checkForUpdates())
            //{
            //    versionWarn.Visible = true;
            //    toolTip1.SetToolTip(versionWarn, "You are using an\noutdated version\nof SUPLauncher.\n\nClick to install the\nlatest version");
            //    toolTip1.SetToolTip(lblVersion, "You are using an\noutdated version\nof SUPLauncher.\n\nClick to install the\nlatest version");
            //}

            //// If a update is avaliable ask
            //if (Settings.updatePopup == false) // Check if user has already had a update popup
            //{
            //    ClientUpdater.Update();
            //}

            imgrefresh.SizeMode = PictureBoxSizeMode.StretchImage;
            imgrefresh.Refresh();


            GetUsername();
            //GetDiscordCheckStatus();
            chkDiscord.Checked = Settings.DiscordStatus;
            GetCurrentServer(steam.GetSteamId().ToString(), true);
            GetDupes();
            picImage.Visible = true;
            try
            {
                if (chkDiscord.Checked)
                {
                    LblServer_TextChanged(this, new EventArgs());
                }
                lblVersion.Text = Program.Version;
                var client = new WebClient();
                client.Headers.Add("user-agent", "SUP Launcher"); // penguin is a fucking bitch for blocking the sup api
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=7875E26FC3C740C9901DDA4C6E74EB4E&steamids=" + steam.GetSteamId().ToString());
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string streamData = sr.ReadToEnd();
                var json = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(streamData);
                string avatarURL = json.response.players[0].avatarfull;
                byte[] avatardata = client.DownloadData(new Uri(avatarURL));
                using (var ms = new MemoryStream(avatardata))
                {
                    picImage.Image = Image.FromStream(ms);
                    client.Dispose();
                    ms.Close();
                }
                GetPlayerCountAllServers(true);
                Activate();
                tmrSteamQuery.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, ex.ToString(), "REPORT THIS TO NICK YOU DUMB FUCK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //FrmLauncher_FormClosing(this, new FormClosingEventArgs(CloseReason.ApplicationExitCall, false));
            }

            chkOverlay.Checked = Settings.OverlayEnabled;

            loadOverlay();

            string keybind = "";
            if (Settings.OverlayModifierKey != 0)
            {
                keybind = getModiferKey(Settings.OverlayModifierKey) + " + " + Settings.OverlayKey;
            }
            else
            {
                keybind = Settings.OverlayKey.ToString();
            }
            lblALTS.Text = "(" + keybind + ")";
        }
        // "Program.OpenURL("steam:");" is for focusing steam
        private void BtnDanktown_Click(object sender, EventArgs e)
        {
            AppStartCheck();
            if (chkAFK.Checked && appStarted == false)
            {
                Program.OpenURL("steam://open/main");
                WindowFocus.ActivateProcess(Process.GetProcessesByName("steam")[0].Id);
                ProcessStartInfo startInfo = new ProcessStartInfo("steam");
                Program.OpenURL("steam://run/4000//-64bit -textmode -single_core -nojoy -low -nosound -sw -noshader -nopix -novid -nopreload -nopreloadmodels -multirun +connect rp.superiorservers.co");
                startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            }
            else
            {
                Program.OpenURL($"steam://connect/{rp1}:27015");
            }
            appStarted = true;
        }

        //private void btnSundown_Click(object sender, EventArgs e)
        //{
        //    if (chkAFK.Checked && appStarted == false)
        //    {
        //        Program.OpenURL("steam:");
        //        Program.OpenURL("steam://run/4000//-64bit -textmode -single_core -nojoy -low -nosound -sw -noshader -nopix -novid -nopreload -nopreloadmodels -multirun +connect rp2.superiorservers.co");
        //    }
        //    else
        //    {
        //        Program.OpenURL("steam://connect/rp2.superiorservers.co:27015");
        //    }
        //    appStarted = true;
        //}
        private void BtnC18_Click(object sender, EventArgs e)
        {
            AppStartCheck();
            if (chkAFK.Checked && appStarted == false)
            {
                Program.OpenURL("steam://open/main");
                WindowFocus.ActivateProcess(Process.GetProcessesByName("steam")[0].Id);
                Program.OpenURL("steam://run/4000//-64bit -textmode -single_core -nojoy -low -nosound -sw -noshader -nopix -novid -nopreload -nopreloadmodels -multirun +connect rp2.superiorservers.co");
            }
            else
            {
                Program.OpenURL($"steam://connect/{rp2}:27015");
            }
            appStarted = true;
        }
        private void BtnZombies_Click(object sender, EventArgs e)
        {
            AppStartCheck();
            if (chkAFK.Checked && appStarted == false)
            {
                Program.OpenURL("steam://open/main");
                WindowFocus.ActivateProcess(Process.GetProcessesByName("steam")[0].Id);
                Program.OpenURL("steam://run/4000//-64bit -textmode -single_core -nojoy -low -nosound -sw -noshader -nopix -novid -nopreload -nopreloadmodels -multirun +connect zrp.superiorservers.co");
            }
            else
            {
                Program.OpenURL($"steam://connect/zrp.superiorservers.co:27015");
            }
            appStarted = true;
        }
        private void BtnMilRP_Click(object sender, EventArgs e)
        {
            AppStartCheck();
            if (chkAFK.Checked && appStarted == false)
            {
                Program.OpenURL("steam://open/main");
                WindowFocus.ActivateProcess(Process.GetProcessesByName("steam")[0].Id);
                Program.OpenURL("steam://run/4000//-64bit -textmode -single_core -nojoy -low -nosound -sw -noshader -nopix -novid -nopreload -nopreloadmodels -multirun +connect milrp.superiorservers.co");
            }
            else
            {
                Program.OpenURL($"steam://connect/{milrp}:27015");
            }
            appStarted = true;
        }
        private void BtnCW1_Click(object sender, EventArgs e)
        {
            AppStartCheck();
            if (chkAFK.Checked && appStarted == false)
            {
                Program.OpenURL("steam://open/main");
                WindowFocus.ActivateProcess(Process.GetProcessesByName("steam")[0].Id);
                Program.OpenURL("steam://run/4000//-64bit -textmode -single_core -nojoy -low -nosound -sw -noshader -nopix -novid -nopreload -nopreloadmodels -multirun +connect cwrp.superiorservers.co");
            }
            else
            {
                Program.OpenURL($"steam://connect/{cwrp1}:27015");
            }
            appStarted = true;
        }
        private void BtnCW2_Click(object sender, EventArgs e)
        {
            AppStartCheck();
            if (chkAFK.Checked && appStarted == false)
            {
                Program.OpenURL("steam://open/main");
                WindowFocus.ActivateProcess(Process.GetProcessesByName("steam")[0].Id);
                Program.OpenURL("steam://run/4000//-64bit -textmode -single_core -nojoy -low -nosound -sw -noshader -nopix -novid -nopreload -nopreloadmodels -multirun +connect cwrp2.superiorservers.co");
            }
            else
            {
                Program.OpenURL($"steam://connect/{cwrp2}:27015");
            }
            appStarted = true;
        }
        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Keep in mind that this program is still being worked on and is not an official release of the SUP Launcher. In order to use this program, you must just simply click on a button and watch the magic happen. The credit for this idea goes to aStonedPenguin, and all new releases will available on the github (nickiscool1022/SUPLauncher). Thanks for using this nice little program I made, and have a fun time playing SuperiorServers." + Environment.NewLine + Environment.NewLine + "-Nick", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


                if (chkDiscord.Checked && File.Exists("1") == false)
                {
                    File.Create("1");
                    File.SetAttributes("1", FileAttributes.Hidden);
                }
                else
                    File.Delete("1");
                Cef.Shutdown();
                if (this.Opacity == 0)
                    e.Cancel = false;
                Interaction.Shell("taskkill /pid " + Process.GetCurrentProcess().Id.ToString() + " /f /t"); // Whoops
            }
            catch (Exception)
            {
                Interaction.Shell("taskkill /pid " + Process.GetCurrentProcess().Id.ToString() + " /f /t");
            }

        }
        private void ChkAFK_CheckedChanged(object sender, EventArgs e)
        {
            //notifyIcon1.Visible = true;
            if (chkAFK.Checked)
            {
                //notifyIcon1.ShowBalloonTip(5000, "AFK Mode", "You are now in AFK Mode.\n Press on a server from the list on the menu\n and confirm it in steam to begin AFKing on SUP!", ToolTipIcon.Info);
                Notification notif = new Notification("You are now in AFK Mode. \nPress on a server from the list on the menu \nand confirm it in steam to begin AFKing \non SUP!", "AFK MODE", false, 115);
                notif.Show();
            }
            else
            {
                //notifyIcon1.ShowBalloonTip(5000, "AFK Mode", "You are no longer in AFK Mode.\n Pressing on a server will launch the game normally through steam with regular graphics (not in command", ToolTipIcon.Info);
                Notification notif = new Notification("You are no longer in AFK Mode. \nPressing on a server will launch the game normally through steam with regular graphics.", "AFK MODE", false, 115);
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
            appStarted = false;
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
        void GetUsername()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // Secure security protocol for querying the steam API
            HttpWebRequest request = WebRequest.CreateHttp("http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=7875E26FC3C740C9901DDA4C6E74EB4E&steamids=" + steam.GetSteamId());
            request.UserAgent = new Random().NextDouble().ToString();
            WebResponse response = null;
            try
            {
                response = request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream()); // Create stream to access web data
                string data = sr.ReadToEnd(); // Read data from response stream
                var json = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(data);

                // old: //string raw = currentRecord.Substring(currentRecord.IndexOf("personaname") + "personaname".Length + 3, (currentRecord.IndexOf("lastlogoff") - (currentRecord.IndexOf("personaname") + "personaname".Length + 6)));
                /* new: */
                lblUsername.Text = "SUP Launcher (" + json.response.players[0].personaname + ")";
            }
            catch (Exception)
            {
                lblUsername.Text = "SUP Launcher";
            }
        }
        //void GetDiscordCheckStatus()
        //{
        //    if (File.Exists("1"))
        //        chkDiscord.Checked = true;
        //    else
        //        chkDiscord.Checked = false;
        //}
        void AppStartCheck()
        {
            Process proc = getGmodProcess();

            if (proc == null || proc.Container == null)
                appStarted = false;
            else
                appStarted = true;
        }
        void GetDupes()
        {
            string SteamInstallPathDir = FindGmodFolder();
            if (Directory.Exists($"{SteamInstallPathDir}\\steamapps\\common\\GarrysMod\\garrysmod\\data\\advdupe2") == false)
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
            /*
             * DT: 104.152.143.244
             * C18: 104.152.143.245
             * ZRP: 199.231.233.143
             * MilRP: 208.103.169.18
             * CWRP1: 199.231.233.148
             * CWRP2: 199.231.233.149
             * CWRP3: 199.231.233.150
             * 
             * fuck all that^
             *
             */
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

        private void TmrSteamQuery_Tick(object sender, EventArgs e)
        {
            GetCurrentServer(steam.GetSteamId().ToString(), true);
            if (lblServer.Text == "" && chkAFK.Checked)
            {
                BtnDanktown_Click(this, new EventArgs());
            }
        }

        private void ChkDiscord_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiscord.Checked)
            {
                LblServer_TextChanged(this, new EventArgs());
            }
        }

        private void LblServer_TextChanged(object sender, EventArgs e)
        {
            if (discord.IsInitialized && chkDiscord.Checked)
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
        private int danktownPlayerCount;
        private int c18PlayerCount;
        private int cwrpPlayerCount;
        private int cwrp2PlayerCount;
        private int milrpPlayerCount;
        private void GetPlayerCountAllServers(bool startup)
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

        private void BtnDupes_Click(object sender, EventArgs e)
        {
            new DupeManager().ShowDialog();
        }

        private void LblSERVERLookup_Click(object sender, EventArgs e)
        {
            bool IDAquired = false;
            bool dirty = false;
            string rawID = Interaction.InputBox("Enter steamid.", "Enter info.", " ");
            string refinedID = "";
            if (rawID == "")
                return;
            if (rawID.StartsWith("7") && rawID.Length == 76561197960265728.ToString().Length)
                IDAquired = true;
            if (IDAquired == false && (rawID.Contains("STEAM_0:0:") || rawID.Contains("STEAM_0:1:")))
            {
                try
                {
                    if (rawID.StartsWith("STEAM_0:0"))
                    {
                        refinedID = ((Convert.ToInt32(rawID.Substring(10, rawID.Length - 10)) * 2) + 76561197960265728).ToString();
                    }
                    else if (rawID.StartsWith("STEAM_0:1"))
                    {
                        refinedID = ((Convert.ToInt32(rawID.Substring(10, rawID.Length - 10)) * 2) + 76561197960265729).ToString();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid STEAMID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dirty = true;
                }
            }
            if (dirty == false)
            {
                if (IDAquired)
                {
                    //GetCurrentServer(rawID, false);
                }
                else
                {
                    // GetCurrentServer(refinedID, false);
                }
                MessageBox.Show(playerServer, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid STEAMID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblFORUMLookup_Click(object sender, EventArgs e)
        {
            string steamid = Interaction.InputBox("Enter steamid.", "Enter info.", " ");
            if ((steamid.Contains("STEAM_0:0:") || steamid.Contains("STEAM_0:1:")) || (steamid.StartsWith("7") && steamid.Length == 76561197960265728.ToString().Length))
            {
                Program.OpenURL("https://superiorservers.co/profile/" + steamid);
                forumSteamIDLookup = steamid;
                //wbForumbrowser.Url = new Uri("https://superiorservers.co/profile/" + steamid);
                //wbForumbrowser.Size = new Size(1280, 720);
                //wbForumbrowser.Visible = true;
            }
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
            Settings.DiscordStatus = chkDiscord.Checked;
            this.Close();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            ClientUpdater.Update();
        }

        private void ToolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
        }

        private void ToolTip1_Popup(object sender, PopupEventArgs e)
        {
            if ((e.AssociatedControl.Name != lblVersion.Name) && (e.AssociatedControl.Name != versionWarn.Name))
            {
                toolTip1.ToolTipIcon = ToolTipIcon.Info;
            }
            else
            {
                toolTip1.ToolTipIcon = ToolTipIcon.Warning;
            }
            if (e.AssociatedControl == lblALTS)
                toolTip1.ToolTipTitle = "Overlay";
            else if (e.AssociatedControl == versionWarn)
                toolTip1.ToolTipTitle = lblVersion.Text;
            else if (e.AssociatedControl == picImage)
                toolTip1.ToolTipTitle = "Your avatar";
            else
                toolTip1.ToolTipTitle = e.AssociatedControl.Text;
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

        private void chkOverlay_CheckedChanged(object sender, EventArgs e)
        {
            Settings.OverlayEnabled = chkOverlay.Checked;
            Notification notif;
            if (!chkOverlay.Checked)
            {
                notif = new Notification("SUPLauncher overlay is disabled.", "NOTIFICATION", true);
                notif.Show();
            }
            else
            {
                string keybind = "";
                if (Settings.OverlayModifierKey != 0)
                {
                    keybind = getModiferKey(Settings.OverlayModifierKey) + " + " + Settings.OverlayKey;
                }
                else
                {
                    keybind = Settings.OverlayKey.ToString();
                }
                notif = new Notification("SUPLauncher overlay is enabled.\n(" + keybind + ")", "NOTIFICATION", true);
                notif.Show();
                loadOverlay();
            }
        }

        public void loadOverlay()
        {
            if (getGmodProcess() != null)
            {
                if (chkOverlay.Checked)
                {
                    if (overlay.IsDisposed)
                    {
                        overlay = new Overlay();
                    }
                    overlay.Visible = false;
                    //string keybind = "";
                    //if (Settings.OverlayModifierKey != 0)
                    //{
                    //    keybind = getModiferKey(Settings.OverlayModifierKey) + " + " + ((Keys)Settings.OverlayKey).ToString();
                    //}
                    //else
                    //{
                    //    keybind = ((Keys)Settings.OverlayKey).ToString();
                    //}
                    //Notification notification = new Notification("SUPLauncher overlay is enabled.\n(" + keybind + ")", "NOTIFICATION" , true);
                    //notification.Show();
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

        private void lblALTS_Click(object sender, EventArgs e)
        {
            
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
    }



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
}
