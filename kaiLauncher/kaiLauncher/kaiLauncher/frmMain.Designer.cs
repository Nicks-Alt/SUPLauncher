
namespace kaiLauncher
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.topBar = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.chkAFK = new System.Windows.Forms.CheckBox();
            this.t = new System.Windows.Forms.Timer(this.components);
            this.topBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // topBar
            // 
            this.topBar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(149)))), ((int)(((byte)(209)))));
            this.topBar.Controls.Add(this.label2);
            this.topBar.Controls.Add(this.button2);
            this.topBar.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.topBar.Location = new System.Drawing.Point(-2, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(802, 30);
            this.topBar.TabIndex = 0;
            this.topBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseDown);
            this.topBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseMove);
            this.topBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(335, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kai.PR Launcher";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseMove);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseUp);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.LightCoral;
            this.button2.Location = new System.Drawing.Point(765, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 30);
            this.button2.TabIndex = 0;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(300, 125);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConnect.Location = new System.Drawing.Point(337, 369);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(126, 44);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "CONNECT";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(335, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "STATUS: ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.ForeColor = System.Drawing.Color.LightCoral;
            this.lblStatus.Location = new System.Drawing.Point(401, 339);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(69, 20);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "OFFLINE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(331, 420);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Players:";
            // 
            // lblPlayers
            // 
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPlayers.Location = new System.Drawing.Point(398, 420);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(71, 21);
            this.lblPlayers.TabIndex = 6;
            this.lblPlayers.Text = "000/000";
            // 
            // chkAFK
            // 
            this.chkAFK.AutoSize = true;
            this.chkAFK.Location = new System.Drawing.Point(469, 385);
            this.chkAFK.Name = "chkAFK";
            this.chkAFK.Size = new System.Drawing.Size(81, 19);
            this.chkAFK.TabIndex = 7;
            this.chkAFK.Text = "AFK Mode";
            this.chkAFK.UseVisualStyleBackColor = true;
            this.chkAFK.CheckedChanged += new System.EventHandler(this.chkAFK_CheckedChanged);
            // 
            // t
            // 
            this.t.Enabled = true;
            this.t.Interval = 10000;
            this.t.Tick += new System.EventHandler(this.t_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.chkAFK);
            this.Controls.Add(this.lblPlayers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.topBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(802, 452);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(802, 452);
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.topBar.ResumeLayout(false);
            this.topBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAFK;
        private System.Windows.Forms.Timer t;
    }
}

