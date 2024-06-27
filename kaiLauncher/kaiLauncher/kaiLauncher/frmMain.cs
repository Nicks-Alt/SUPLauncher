using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Okolni.Source.Query;

namespace kaiLauncher
{
    public partial class frmMain : Form
    {
        bool isTopPanelDragged = false;
        Size _normalWindowSize;
        Point _normalWindowLocation = Point.Empty;
        Point offset;
        DiscordRPC.DiscordRpcClient discord = new DiscordRPC.DiscordRpcClient("872151070929993759");
        ulong steamID = new SteamBridge().GetSteamId();
        IQueryConnection conn = new QueryConnection();
        bool isAlreadyConnected;
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                discord.Initialize();
                discord.SetPresence(new DiscordRPC.RichPresence()
                {
                    Details = "Idle",
                    State = "",
                    Timestamps = DiscordRPC.Timestamps.Now,
                    Assets = new DiscordRPC.Assets()
                    {
                        LargeImageKey = "kai",
                        LargeImageText = "Kai.PR"
                    },
                    Buttons = new DiscordRPC.Button[]
                    {
                        new DiscordRPC.Button() { Label = "Connect", Url = "steam://connect/95.216.30.3:27414"}
                    }
                });
                

                conn.Host = "95.216.30.3";
                conn.Port = 27414;

                conn.Connect();

                lblStatus.Text = "ONLINE";
                lblStatus.ForeColor = Color.LightGreen;
                lblPlayers.Text = conn.GetPlayers().Players.Count.ToString() + "/128";
            }
            catch (Exception)
            {
                lblStatus.Text = "OFFLINE";
                lblStatus.ForeColor = Color.LightCoral;
                lblPlayers.Text = "0/128";
            }
        }

        private void topBar_MouseUp(object sender, MouseEventArgs e)
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
        private void topBar_MouseMove(object sender, MouseEventArgs e)
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
        private void topBar_MouseDown(object sender, MouseEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var programFilesDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            var someExeLocation = Path.Combine(programFilesDir, "Steam", "steam.exe");
            string args = "";
            if (!chkAFK.Checked)
                Process.Start("explorer.exe", "steam://connect/95.216.30.3:27414");
            else
            {
                Process.Start("explorer.exe", "steam://run/4000//-64bit -textmode -single_core -nojoy -low -nosound -sw -noshader -nopix -novid -nopreload -nopreloadmodels -multirun +connect 95.216.30.3:27414");
                Process.Start("explorer.exe", "steam://run/4000//-64bit -textmode -single_core -nojoy -low -nosound -sw -noshader -nopix -novid -nopreload -nopreloadmodels -multirun +connect 95.216.30.3:27414");
            }
        }

        private void chkAFK_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Process.GetProcessesByName("hl2")[0].Kill();
            }
            catch (Exception) {
                try{ Process.GetProcessesByName("gmod")[0].Kill(); }
                catch (Exception) { }
            }
            
        }

        private void t_Tick(object sender, EventArgs e)
        {
            try
            {
                WebRequest wr = WebRequest.Create("https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=7875E26FC3C740C9901DDA4C6E74EB4E&steamids=" + steamID);
                dynamic steamName = ((dynamic)Newtonsoft.Json.JsonConvert.DeserializeObject(new StreamReader(wr.GetResponse().GetResponseStream()).ReadToEnd())).response.players[0].personaname;
                bool isConnected = false;
                foreach (var pl in conn.GetPlayers().Players)
                {
                    if (steamName.ToString().Contains(pl.Name))
                    {
                        isConnected = true;
                        break;
                    }
                }
                if (isConnected)
                {
                    if (!isAlreadyConnected)
                        isAlreadyConnected = true;
                    btnConnect.Enabled = false;
                    btnConnect.Text = "CONNECTED";
                    discord.SetPresence(new DiscordRPC.RichPresence()
                    {

                        Details = "Playing on Danktown",
                        State = "",
                        Assets = new DiscordRPC.Assets()
                        {
                            LargeImageKey = "kai",
                            LargeImageText = "Kai.PR"
                        },
                        Buttons = new DiscordRPC.Button[]
                        {
                            new DiscordRPC.Button() { Label = "Connect", Url = "steam://connect/95.216.30.3:27414"}
                        }
                    });


                }
                else
                {
                    btnConnect.Enabled = true;
                    btnConnect.Text = "CONNECT";
                    discord.SetPresence(new DiscordRPC.RichPresence()
                    {
                        Details = "Idle",
                        State = "",
                        //Timestamps = DiscordRPC.Timestamps.Now,
                        Assets = new DiscordRPC.Assets()
                        {
                            LargeImageKey = "kai",
                            LargeImageText = "Kai.PR"
                        },
                        Buttons = new DiscordRPC.Button[]
                        {
                        new DiscordRPC.Button() { Label = "Connect", Url = "steam://connect/95.216.30.3:27414"}
                        }
                    });
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
