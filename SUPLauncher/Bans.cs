using CefSharp;
using CefSharp.WinForms;

namespace SUPLauncher
{
    public partial class Bans : Form
    {
        bool isTopPanelDragged = false;
        bool isWindowMaximized = false;
        Point offset;
        Size _normalWindowSize;
        Point _normalWindowLocation = Point.Empty;
        string steamid = "";
        ChromiumWebBrowser chrome = new ChromiumWebBrowser();
        bool opened = false;
        
        //bool opened = false;
        /// <summary>
        /// Open up a profile of the specified steamid.
        /// </summary>
        /// <param name="steamID">The steamid of the profile to display. Can be 32 or 64</param>
        public Bans(string steamID)
        {
            InitializeComponent();
            InitializeChromium(steamID);
            steamid = steamID;
            Width = Screen.PrimaryScreen.WorkingArea.Width / 2;
            Height = Screen.PrimaryScreen.WorkingArea.Height / 2 + 100;

            Opacity = 0;      //first the opacity is 0

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
        private void hide()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(hide), new object[] {  });

            }

            panel2.Visible = false;
            panel2.Dispose();

        }

        private void InitializeChromium(string steamID)
        {
            chrome.Load("https://superiorservers.co/profile/" + steamID);
            this.panel1.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
            chrome.LoadingStateChanged += (sender, args) =>
            {
                //Wait for the Page to finish loading
                if (args.IsLoading == false)
                {
                    
                    chrome.EvaluateScriptAsync("document.getElementsByClassName(\"navbar\")[0].remove();"); // Use javascript magic to remove the navbar from the page.
                    hide();
                }
            };
        }
        private void TopBar_MouseUp(object sender, MouseEventArgs e)
        {
            isTopPanelDragged = false;
            if (this.Location.Y <= 5)
            {
                if (!isWindowMaximized)
                {
                    _normalWindowSize = this.Size;
                    _normalWindowLocation = this.Location;

                    Rectangle rect = Screen.PrimaryScreen.WorkingArea;
                    this.Location = new Point(0, 0);
                    this.Size = new System.Drawing.Size(rect.Width, rect.Height);

                    isWindowMaximized = true;
                }
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
                        isWindowMaximized = false;
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bans_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            t1 = new System.Windows.Forms.Timer();
            t1.Interval = 10;  //we'll increase the opacity every 10ms
            t1.Tick += new EventHandler(fadeOut);  //this calls the function that changes opacity 
            
            t1.Start();
            if (this.Opacity == 0)
                e.Cancel = false;
        }

        private void Bans_Load(object sender, EventArgs e)
        {
            InitializeChromium(steamid);
        }
    }
}