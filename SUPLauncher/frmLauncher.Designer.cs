namespace SUPLauncher
{
    partial class frmLauncher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLauncher));
            btnForums = new Button();
            btnTS = new Button();
            lblDT = new Label();
            tmrRefresh = new System.Windows.Forms.Timer(components);
            lblSD = new Label();
            lblC18 = new Label();
            lblZRP = new Label();
            lblMRP = new Label();
            lblCW1 = new Label();
            lblCW2 = new Label();
            lblVersion = new Label();
            toolStripMenuItem1 = new ToolStripMenuItem();
            tmrSteamQuery = new System.Windows.Forms.Timer(components);
            btnDRPRules = new Button();
            btnMilRPRules = new Button();
            btnCWRPRules = new Button();
            lblServer = new Label();
            btnCW2 = new Button();
            btnCW1 = new Button();
            btnMilRP = new Button();
            btnZombies = new Button();
            btnC18 = new Button();
            btnSundown = new Button();
            btnDupes = new Button();
            btnDanktown = new Button();
            label2 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            picImage = new PictureBox();
            picRank = new PictureBox();
            versionWarn = new PictureBox();
            lblUsername = new Label();
            imgrefresh = new PictureBox();
            label4 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panCW2 = new Panel();
            chkAFK = new CheckBox();
            panCW1 = new Panel();
            panMilRP = new Panel();
            panZombies = new Panel();
            panC18 = new Panel();
            panSD = new Panel();
            panDanktown = new Panel();
            topBar = new Panel();
            label7 = new Label();
            btnMinimize = new Button();
            btnSettings = new Button();
            picRepoLink = new PictureBox();
            button1 = new Button();
            textBox1 = new TextBox();
            toolTip1 = new ToolTip(components);
            tmrAFK = new System.Windows.Forms.Timer(components);
            mnuSettingsDrop = new ContextMenuStrip(components);
            customizationToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            missingTexturesToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            discordStatusToggleToolStripMenuItem = new ToolStripMenuItem();
            overlayToggleALTSToolStripMenuItem = new ToolStripMenuItem();
            ofdSetBackgroundImage = new OpenFileDialog();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picRank).BeginInit();
            ((System.ComponentModel.ISupportInitialize)versionWarn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgrefresh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            topBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picRepoLink).BeginInit();
            mnuSettingsDrop.SuspendLayout();
            SuspendLayout();
            // 
            // btnForums
            // 
            btnForums.BackColor = Color.FromArgb(14, 14, 14);
            btnForums.FlatAppearance.BorderSize = 0;
            btnForums.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnForums.FlatStyle = FlatStyle.Flat;
            btnForums.Font = new Font("Microsoft Sans Serif", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnForums.ForeColor = Color.White;
            btnForums.Location = new Point(345, 213);
            btnForums.Margin = new Padding(4, 3, 4, 3);
            btnForums.Name = "btnForums";
            btnForums.Size = new Size(94, 38);
            btnForums.TabIndex = 11;
            btnForums.Text = "Forums";
            toolTip1.SetToolTip(btnForums, "Opens your default web browser\r\nand automatically opens the\r\nSuperiorServers website!");
            btnForums.UseVisualStyleBackColor = false;
            btnForums.Click += BtnForums_Click;
            // 
            // btnTS
            // 
            btnTS.BackColor = Color.FromArgb(14, 14, 14);
            btnTS.FlatAppearance.BorderSize = 0;
            btnTS.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnTS.FlatStyle = FlatStyle.Flat;
            btnTS.Font = new Font("Microsoft Sans Serif", 10F);
            btnTS.ForeColor = Color.White;
            btnTS.Location = new Point(454, 213);
            btnTS.Margin = new Padding(4, 3, 4, 3);
            btnTS.Name = "btnTS";
            btnTS.Size = new Size(94, 38);
            btnTS.TabIndex = 12;
            btnTS.Text = "TS";
            toolTip1.SetToolTip(btnTS, "Connects to the TeamSpeak server\r\n(ts.superiorservers.co)");
            btnTS.UseVisualStyleBackColor = false;
            btnTS.Click += BtnTS_Click;
            // 
            // lblDT
            // 
            lblDT.AutoSize = true;
            lblDT.BackColor = Color.FromArgb(64, 64, 64);
            lblDT.FlatStyle = FlatStyle.Flat;
            lblDT.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDT.ForeColor = Color.Gray;
            lblDT.Location = new Point(229, 95);
            lblDT.Margin = new Padding(4, 0, 4, 0);
            lblDT.Name = "lblDT";
            lblDT.Size = new Size(53, 16);
            lblDT.TabIndex = 15;
            lblDT.Text = "000/000";
            // 
            // tmrRefresh
            // 
            tmrRefresh.Enabled = true;
            tmrRefresh.Interval = 1000;
            tmrRefresh.Tick += TmrRefresh_Tick;
            // 
            // lblSD
            // 
            lblSD.AutoSize = true;
            lblSD.BackColor = Color.FromArgb(64, 64, 64);
            lblSD.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSD.ForeColor = Color.Gray;
            lblSD.Location = new Point(229, 140);
            lblSD.Margin = new Padding(4, 0, 4, 0);
            lblSD.Name = "lblSD";
            lblSD.Size = new Size(53, 16);
            lblSD.TabIndex = 16;
            lblSD.Text = "000/000";
            // 
            // lblC18
            // 
            lblC18.AutoSize = true;
            lblC18.BackColor = Color.FromArgb(64, 64, 64);
            lblC18.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblC18.ForeColor = Color.Gray;
            lblC18.Location = new Point(229, 185);
            lblC18.Margin = new Padding(4, 0, 4, 0);
            lblC18.Name = "lblC18";
            lblC18.Size = new Size(53, 16);
            lblC18.TabIndex = 17;
            lblC18.Text = "000/000";
            // 
            // lblZRP
            // 
            lblZRP.AutoSize = true;
            lblZRP.BackColor = Color.FromArgb(64, 64, 64);
            lblZRP.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblZRP.ForeColor = Color.Gray;
            lblZRP.Location = new Point(229, 230);
            lblZRP.Margin = new Padding(4, 0, 4, 0);
            lblZRP.Name = "lblZRP";
            lblZRP.Size = new Size(53, 16);
            lblZRP.TabIndex = 18;
            lblZRP.Text = "000/000";
            // 
            // lblMRP
            // 
            lblMRP.AutoSize = true;
            lblMRP.BackColor = Color.FromArgb(64, 64, 64);
            lblMRP.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMRP.ForeColor = Color.Gray;
            lblMRP.Location = new Point(229, 275);
            lblMRP.Margin = new Padding(4, 0, 4, 0);
            lblMRP.Name = "lblMRP";
            lblMRP.Size = new Size(53, 16);
            lblMRP.TabIndex = 19;
            lblMRP.Text = "000/000";
            // 
            // lblCW1
            // 
            lblCW1.AutoSize = true;
            lblCW1.BackColor = Color.FromArgb(64, 64, 64);
            lblCW1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCW1.ForeColor = Color.Gray;
            lblCW1.Location = new Point(229, 320);
            lblCW1.Margin = new Padding(4, 0, 4, 0);
            lblCW1.Name = "lblCW1";
            lblCW1.Size = new Size(53, 16);
            lblCW1.TabIndex = 20;
            lblCW1.Text = "000/000";
            // 
            // lblCW2
            // 
            lblCW2.AutoSize = true;
            lblCW2.BackColor = Color.FromArgb(64, 64, 64);
            lblCW2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCW2.ForeColor = Color.Gray;
            lblCW2.Location = new Point(229, 365);
            lblCW2.Margin = new Padding(4, 0, 4, 0);
            lblCW2.Name = "lblCW2";
            lblCW2.Size = new Size(53, 16);
            lblCW2.TabIndex = 21;
            lblCW2.Text = "000/000";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.BackColor = Color.FromArgb(99, 99, 99);
            lblVersion.Cursor = Cursors.Hand;
            lblVersion.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVersion.ForeColor = SystemColors.Control;
            lblVersion.Location = new Point(422, 63);
            lblVersion.Margin = new Padding(4, 0, 4, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(57, 20);
            lblVersion.TabIndex = 27;
            lblVersion.Text = "1.1.1.1";
            toolTip1.SetToolTip(lblVersion, "Current application version.");
            lblVersion.Click += LblVersion_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(32, 19);
            // 
            // tmrSteamQuery
            // 
            tmrSteamQuery.Interval = 10000;
            tmrSteamQuery.Tick += TmrSteamQuery_Tick;
            // 
            // btnDRPRules
            // 
            btnDRPRules.BackColor = Color.FromArgb(14, 14, 14);
            btnDRPRules.FlatAppearance.BorderSize = 0;
            btnDRPRules.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnDRPRules.FlatStyle = FlatStyle.Flat;
            btnDRPRules.Font = new Font("Microsoft Sans Serif", 10F);
            btnDRPRules.ForeColor = Color.White;
            btnDRPRules.Location = new Point(326, 275);
            btnDRPRules.Margin = new Padding(0);
            btnDRPRules.Name = "btnDRPRules";
            btnDRPRules.Size = new Size(238, 27);
            btnDRPRules.TabIndex = 33;
            btnDRPRules.Text = "DarkRP Rules/FAQ";
            toolTip1.SetToolTip(btnDRPRules, "Opens the DarkRP rules via your\r\ndefault web browser.");
            btnDRPRules.UseVisualStyleBackColor = false;
            btnDRPRules.Click += BtnDRPRules_Click;
            // 
            // btnMilRPRules
            // 
            btnMilRPRules.BackColor = Color.FromArgb(14, 14, 14);
            btnMilRPRules.FlatAppearance.BorderSize = 0;
            btnMilRPRules.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnMilRPRules.FlatStyle = FlatStyle.Flat;
            btnMilRPRules.Font = new Font("Microsoft Sans Serif", 10F);
            btnMilRPRules.ForeColor = Color.White;
            btnMilRPRules.Location = new Point(326, 323);
            btnMilRPRules.Margin = new Padding(0);
            btnMilRPRules.Name = "btnMilRPRules";
            btnMilRPRules.Size = new Size(238, 27);
            btnMilRPRules.TabIndex = 34;
            btnMilRPRules.Text = "MilRP Rules/FAQ";
            toolTip1.SetToolTip(btnMilRPRules, "Opens the MilRP rules via your\r\ndefault web browser.");
            btnMilRPRules.UseVisualStyleBackColor = false;
            btnMilRPRules.Click += BtnMilRPRules_Click;
            // 
            // btnCWRPRules
            // 
            btnCWRPRules.BackColor = Color.FromArgb(14, 14, 14);
            btnCWRPRules.FlatAppearance.BorderSize = 0;
            btnCWRPRules.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnCWRPRules.FlatStyle = FlatStyle.Flat;
            btnCWRPRules.Font = new Font("Microsoft Sans Serif", 10F);
            btnCWRPRules.ForeColor = Color.White;
            btnCWRPRules.Location = new Point(326, 370);
            btnCWRPRules.Margin = new Padding(0);
            btnCWRPRules.Name = "btnCWRPRules";
            btnCWRPRules.Size = new Size(238, 27);
            btnCWRPRules.TabIndex = 35;
            btnCWRPRules.Text = "CWRP Rules/FAQ";
            toolTip1.SetToolTip(btnCWRPRules, "Opens the CWRP rules via your\r\ndefault web browser.");
            btnCWRPRules.UseVisualStyleBackColor = false;
            btnCWRPRules.Click += BtnCWRPRules_Click;
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.BackColor = Color.Transparent;
            lblServer.Cursor = Cursors.Hand;
            lblServer.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblServer.ForeColor = SystemColors.Control;
            lblServer.Location = new Point(306, 6);
            lblServer.Margin = new Padding(4, 0, 4, 0);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(57, 20);
            lblServer.TabIndex = 36;
            lblServer.Text = "1.1.1.1";
            lblServer.Visible = false;
            lblServer.TextChanged += LblServer_TextChanged;
            // 
            // btnCW2
            // 
            btnCW2.BackColor = Color.FromArgb(30, 30, 30);
            btnCW2.FlatAppearance.BorderSize = 0;
            btnCW2.FlatStyle = FlatStyle.Flat;
            btnCW2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCW2.ForeColor = Color.White;
            btnCW2.Location = new Point(0, 354);
            btnCW2.Margin = new Padding(4, 3, 4, 3);
            btnCW2.Name = "btnCW2";
            btnCW2.Size = new Size(293, 38);
            btnCW2.TabIndex = 6;
            btnCW2.Text = "Clonewars #2";
            toolTip1.SetToolTip(btnCW2, "Connects to CWRP #2\r\n(cwrp2.superiorservers.co)");
            btnCW2.UseVisualStyleBackColor = false;
            btnCW2.Click += BtnCW2_Click;
            // 
            // btnCW1
            // 
            btnCW1.BackColor = Color.FromArgb(30, 30, 30);
            btnCW1.FlatAppearance.BorderSize = 0;
            btnCW1.FlatStyle = FlatStyle.Flat;
            btnCW1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCW1.ForeColor = Color.White;
            btnCW1.ImageAlign = ContentAlignment.BottomCenter;
            btnCW1.Location = new Point(0, 309);
            btnCW1.Margin = new Padding(4, 3, 4, 3);
            btnCW1.Name = "btnCW1";
            btnCW1.Size = new Size(293, 38);
            btnCW1.TabIndex = 5;
            btnCW1.Text = "Clonewars #1";
            toolTip1.SetToolTip(btnCW1, "Connects to CWRP #1\r\n(cwrp.superiorservers.co)\r\n");
            btnCW1.UseVisualStyleBackColor = false;
            btnCW1.Click += BtnCW1_Click;
            // 
            // btnMilRP
            // 
            btnMilRP.BackColor = Color.FromArgb(30, 30, 30);
            btnMilRP.FlatAppearance.BorderSize = 0;
            btnMilRP.FlatStyle = FlatStyle.Flat;
            btnMilRP.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMilRP.ForeColor = Color.White;
            btnMilRP.Location = new Point(0, 264);
            btnMilRP.Margin = new Padding(4, 3, 4, 3);
            btnMilRP.Name = "btnMilRP";
            btnMilRP.Size = new Size(293, 38);
            btnMilRP.TabIndex = 4;
            btnMilRP.Text = "MilitaryRP";
            toolTip1.SetToolTip(btnMilRP, "Connects to MilRP\r\n(milrp.superiorservers.co)\r\n\r\n");
            btnMilRP.UseVisualStyleBackColor = false;
            btnMilRP.Click += BtnMilRP_Click;
            // 
            // btnZombies
            // 
            btnZombies.BackColor = Color.FromArgb(30, 30, 30);
            btnZombies.Enabled = false;
            btnZombies.FlatAppearance.BorderSize = 0;
            btnZombies.FlatStyle = FlatStyle.Flat;
            btnZombies.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnZombies.ForeColor = Color.Gray;
            btnZombies.Location = new Point(0, 219);
            btnZombies.Margin = new Padding(4, 3, 4, 3);
            btnZombies.Name = "btnZombies";
            btnZombies.Size = new Size(293, 38);
            btnZombies.TabIndex = 3;
            btnZombies.Text = "Zombies";
            toolTip1.SetToolTip(btnZombies, "Connects to ZombiesRP\r\n(208.103.169.14:27015)\r\n\r\n\r\n");
            btnZombies.UseVisualStyleBackColor = false;
            btnZombies.Click += BtnZombies_Click;
            // 
            // btnC18
            // 
            btnC18.BackColor = Color.FromArgb(30, 30, 30);
            btnC18.FlatAppearance.BorderSize = 0;
            btnC18.FlatStyle = FlatStyle.Flat;
            btnC18.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnC18.ForeColor = Color.White;
            btnC18.Location = new Point(0, 174);
            btnC18.Margin = new Padding(4, 3, 4, 3);
            btnC18.Name = "btnC18";
            btnC18.Size = new Size(293, 38);
            btnC18.TabIndex = 2;
            btnC18.Text = "C18";
            toolTip1.SetToolTip(btnC18, "Connects to C18\r\n(rp2.superiorservers.co)\r\n\r\n\r\n");
            btnC18.UseVisualStyleBackColor = false;
            btnC18.Click += BtnC18_Click;
            // 
            // btnSundown
            // 
            btnSundown.BackColor = Color.FromArgb(30, 30, 30);
            btnSundown.Enabled = false;
            btnSundown.FlatAppearance.BorderSize = 0;
            btnSundown.FlatStyle = FlatStyle.Flat;
            btnSundown.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSundown.ForeColor = Color.Gray;
            btnSundown.Location = new Point(0, 129);
            btnSundown.Margin = new Padding(4, 3, 4, 3);
            btnSundown.Name = "btnSundown";
            btnSundown.Size = new Size(293, 38);
            btnSundown.TabIndex = 1;
            btnSundown.Text = "Sundown";
            btnSundown.UseVisualStyleBackColor = false;
            // 
            // btnDupes
            // 
            btnDupes.BackColor = Color.FromArgb(14, 14, 14);
            btnDupes.FlatAppearance.BorderSize = 0;
            btnDupes.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnDupes.FlatStyle = FlatStyle.Flat;
            btnDupes.Font = new Font("Microsoft Sans Serif", 9F);
            btnDupes.ForeColor = Color.White;
            btnDupes.Location = new Point(326, 0);
            btnDupes.Margin = new Padding(4, 3, 4, 3);
            btnDupes.Name = "btnDupes";
            btnDupes.Size = new Size(249, 40);
            btnDupes.TabIndex = 38;
            btnDupes.Text = "Open Dupe Manager";
            toolTip1.SetToolTip(btnDupes, "Opens the Dupe Manager window.");
            btnDupes.UseVisualStyleBackColor = false;
            btnDupes.Click += BtnDupes_Click;
            // 
            // btnDanktown
            // 
            btnDanktown.BackColor = Color.FromArgb(30, 30, 30);
            btnDanktown.FlatAppearance.BorderSize = 0;
            btnDanktown.FlatStyle = FlatStyle.Flat;
            btnDanktown.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDanktown.ForeColor = Color.White;
            btnDanktown.Location = new Point(4, 84);
            btnDanktown.Margin = new Padding(4, 3, 4, 3);
            btnDanktown.Name = "btnDanktown";
            btnDanktown.Size = new Size(289, 38);
            btnDanktown.TabIndex = 0;
            btnDanktown.Text = "Danktown";
            toolTip1.SetToolTip(btnDanktown, "Connects to Danktown\r\n(rp.superiorservers.co)\r\n\r\n\r\n");
            btnDanktown.UseVisualStyleBackColor = false;
            btnDanktown.Click += BtnDanktown_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(102, 42);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(93, 25);
            label2.TabIndex = 8;
            label2.Text = "Servers";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = Properties.Resources.background2;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnCWRPRules);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnMilRPRules);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnDRPRules);
            panel1.Controls.Add(btnTS);
            panel1.Controls.Add(panCW2);
            panel1.Controls.Add(btnForums);
            panel1.Controls.Add(chkAFK);
            panel1.Controls.Add(panCW1);
            panel1.Controls.Add(panMilRP);
            panel1.Controls.Add(panZombies);
            panel1.Controls.Add(panC18);
            panel1.Controls.Add(panSD);
            panel1.Controls.Add(panDanktown);
            panel1.Controls.Add(lblCW2);
            panel1.Controls.Add(lblCW1);
            panel1.Controls.Add(lblMRP);
            panel1.Controls.Add(lblZRP);
            panel1.Controls.Add(btnMilRP);
            panel1.Controls.Add(lblC18);
            panel1.Controls.Add(btnCW1);
            panel1.Controls.Add(lblSD);
            panel1.Controls.Add(btnCW2);
            panel1.Controls.Add(lblDT);
            panel1.Controls.Add(btnDanktown);
            panel1.Controls.Add(btnSundown);
            panel1.Controls.Add(btnC18);
            panel1.Controls.Add(btnZombies);
            panel1.Location = new Point(0, -1);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(576, 537);
            panel1.TabIndex = 39;
            panel1.Click += FrmLauncher_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(30, 30, 30);
            panel2.Controls.Add(btnDupes);
            panel2.Controls.Add(picImage);
            panel2.Controls.Add(picRank);
            panel2.Controls.Add(versionWarn);
            panel2.Controls.Add(lblUsername);
            panel2.Controls.Add(lblVersion);
            panel2.Controls.Add(imgrefresh);
            panel2.Location = new Point(0, 418);
            panel2.Name = "panel2";
            panel2.Size = new Size(575, 119);
            panel2.TabIndex = 58;
            // 
            // picImage
            // 
            picImage.BackColor = Color.Transparent;
            picImage.Cursor = Cursors.Hand;
            picImage.Image = Properties.Resources.suplogo;
            picImage.Location = new Point(12, 16);
            picImage.Name = "picImage";
            picImage.Size = new Size(88, 88);
            picImage.SizeMode = PictureBoxSizeMode.StretchImage;
            picImage.TabIndex = 50;
            picImage.TabStop = false;
            toolTip1.SetToolTip(picImage, "Your avatar. Click to open your SUP Profile.");
            picImage.Visible = false;
            picImage.VisibleChanged += picImage_Resize;
            picImage.Click += PicImage_Click;
            picImage.Resize += picImage_Resize;
            // 
            // picRank
            // 
            picRank.Anchor = AnchorStyles.None;
            picRank.BackgroundImage = Properties.Resources.co_blue;
            picRank.BackgroundImageLayout = ImageLayout.Stretch;
            picRank.ErrorImage = Properties.Resources.MEMBER;
            picRank.InitialImage = null;
            picRank.Location = new Point(107, 48);
            picRank.Margin = new Padding(0);
            picRank.Name = "picRank";
            picRank.Size = new Size(166, 76);
            picRank.TabIndex = 51;
            picRank.TabStop = false;
            // 
            // versionWarn
            // 
            versionWarn.BackColor = Color.Transparent;
            versionWarn.Image = (Image)resources.GetObject("versionWarn.Image");
            versionWarn.Location = new Point(377, 63);
            versionWarn.Margin = new Padding(4, 3, 4, 3);
            versionWarn.Name = "versionWarn";
            versionWarn.Size = new Size(37, 20);
            versionWarn.SizeMode = PictureBoxSizeMode.Zoom;
            versionWarn.TabIndex = 49;
            versionWarn.TabStop = false;
            versionWarn.Visible = false;
            versionWarn.Click += LblVersion_Click;
            // 
            // lblUsername
            // 
            lblUsername.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = SystemColors.Control;
            lblUsername.Location = new Point(107, 8);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(167, 40);
            lblUsername.TabIndex = 46;
            lblUsername.Text = "USERNAME\r\n(STEAM:0:0:0000000)";
            lblUsername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // imgrefresh
            // 
            imgrefresh.Cursor = Cursors.Hand;
            imgrefresh.Image = (Image)resources.GetObject("imgrefresh.Image");
            imgrefresh.Location = new Point(294, 8);
            imgrefresh.Margin = new Padding(4, 3, 4, 3);
            imgrefresh.Name = "imgrefresh";
            imgrefresh.Size = new Size(24, 23);
            imgrefresh.SizeMode = PictureBoxSizeMode.Zoom;
            imgrefresh.TabIndex = 48;
            imgrefresh.TabStop = false;
            imgrefresh.Click += LblRefresh_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Cursor = Cursors.Hand;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(229, 50);
            label4.Name = "label4";
            label4.Size = new Size(69, 17);
            label4.TabIndex = 55;
            label4.Text = "AFK Mode";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(423, 185);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(50, 18);
            label3.TabIndex = 54;
            label3.Text = "Other";
            label3.Click += label3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(306, 87);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(258, 94);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 52;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 8.65F);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(406, 42);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 51;
            label1.Text = "Player Lookup";
            // 
            // panCW2
            // 
            panCW2.BackColor = Color.RoyalBlue;
            panCW2.Location = new Point(0, 354);
            panCW2.Margin = new Padding(4, 3, 4, 3);
            panCW2.Name = "panCW2";
            panCW2.Size = new Size(5, 38);
            panCW2.TabIndex = 47;
            // 
            // chkAFK
            // 
            chkAFK.BackColor = Color.Transparent;
            chkAFK.BackgroundImage = (Image)resources.GetObject("chkAFK.BackgroundImage");
            chkAFK.BackgroundImageLayout = ImageLayout.None;
            chkAFK.Cursor = Cursors.Hand;
            chkAFK.FlatAppearance.BorderSize = 0;
            chkAFK.FlatStyle = FlatStyle.System;
            chkAFK.Font = new Font("Microsoft Sans Serif", 9.75F);
            chkAFK.ForeColor = SystemColors.Control;
            chkAFK.Location = new Point(214, 52);
            chkAFK.Margin = new Padding(4, 3, 4, 3);
            chkAFK.Name = "chkAFK";
            chkAFK.Size = new Size(15, 15);
            chkAFK.TabIndex = 22;
            toolTip1.SetToolTip(chkAFK, "Pressing this will forcefully restart your game\r\nand put you in AFK Mode, which will launch\r\nthe game in a command prompt window,\r\nusing less system resources.");
            chkAFK.UseVisualStyleBackColor = false;
            chkAFK.CheckedChanged += ChkAFK_CheckedChanged;
            chkAFK.Click += ChkAFK_CheckedChanged;
            // 
            // panCW1
            // 
            panCW1.BackColor = Color.RoyalBlue;
            panCW1.Location = new Point(0, 309);
            panCW1.Margin = new Padding(4, 3, 4, 3);
            panCW1.Name = "panCW1";
            panCW1.Size = new Size(5, 38);
            panCW1.TabIndex = 46;
            // 
            // panMilRP
            // 
            panMilRP.BackColor = Color.RoyalBlue;
            panMilRP.Location = new Point(0, 264);
            panMilRP.Margin = new Padding(4, 3, 4, 3);
            panMilRP.Name = "panMilRP";
            panMilRP.Size = new Size(5, 38);
            panMilRP.TabIndex = 45;
            // 
            // panZombies
            // 
            panZombies.BackColor = Color.LightCoral;
            panZombies.Location = new Point(0, 219);
            panZombies.Margin = new Padding(4, 3, 4, 3);
            panZombies.Name = "panZombies";
            panZombies.Size = new Size(5, 38);
            panZombies.TabIndex = 44;
            // 
            // panC18
            // 
            panC18.BackColor = Color.RoyalBlue;
            panC18.Location = new Point(0, 174);
            panC18.Margin = new Padding(4, 3, 4, 3);
            panC18.Name = "panC18";
            panC18.Size = new Size(5, 38);
            panC18.TabIndex = 43;
            // 
            // panSD
            // 
            panSD.BackColor = Color.LightCoral;
            panSD.Location = new Point(0, 129);
            panSD.Margin = new Padding(4, 3, 4, 3);
            panSD.Name = "panSD";
            panSD.Size = new Size(5, 38);
            panSD.TabIndex = 42;
            // 
            // panDanktown
            // 
            panDanktown.BackColor = Color.RoyalBlue;
            panDanktown.Location = new Point(0, 84);
            panDanktown.Margin = new Padding(4, 3, 4, 3);
            panDanktown.Name = "panDanktown";
            panDanktown.Size = new Size(5, 38);
            panDanktown.TabIndex = 41;
            // 
            // topBar
            // 
            topBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            topBar.BackColor = Color.FromArgb(17, 17, 17);
            topBar.Controls.Add(label7);
            topBar.Controls.Add(btnMinimize);
            topBar.Controls.Add(btnSettings);
            topBar.Controls.Add(lblServer);
            topBar.Controls.Add(picRepoLink);
            topBar.Controls.Add(button1);
            topBar.Cursor = Cursors.SizeAll;
            topBar.Location = new Point(0, 0);
            topBar.Margin = new Padding(4, 3, 4, 3);
            topBar.Name = "topBar";
            topBar.Size = new Size(575, 35);
            topBar.TabIndex = 44;
            topBar.MouseDown += TopBar_MouseDown;
            topBar.MouseMove += TopBar_MouseMove;
            topBar.MouseUp += TopBar_MouseUp;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(42, 4);
            label7.Name = "label7";
            label7.Size = new Size(124, 25);
            label7.TabIndex = 54;
            label7.Text = "SUPLauncher";
            label7.MouseDown += TopBar_MouseDown;
            label7.MouseMove += TopBar_MouseMove;
            label7.MouseUp += TopBar_MouseUp;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.BackColor = Color.Transparent;
            btnMinimize.BackgroundImage = (Image)resources.GetObject("btnMinimize.BackgroundImage");
            btnMinimize.BackgroundImageLayout = ImageLayout.Stretch;
            btnMinimize.Cursor = Cursors.Hand;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(509, 1);
            btnMinimize.Margin = new Padding(4, 3, 4, 3);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(32, 32);
            btnMinimize.TabIndex = 53;
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnSettings
            // 
            btnSettings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSettings.BackColor = Color.Transparent;
            btnSettings.BackgroundImage = (Image)resources.GetObject("btnSettings.BackgroundImage");
            btnSettings.BackgroundImageLayout = ImageLayout.Stretch;
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(477, 1);
            btnSettings.Margin = new Padding(4, 3, 4, 3);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(32, 32);
            btnSettings.TabIndex = 52;
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // picRepoLink
            // 
            picRepoLink.Cursor = Cursors.Hand;
            picRepoLink.Image = Properties.Resources.suplogo;
            picRepoLink.Location = new Point(5, 0);
            picRepoLink.Name = "picRepoLink";
            picRepoLink.Size = new Size(31, 32);
            picRepoLink.SizeMode = PictureBoxSizeMode.StretchImage;
            picRepoLink.TabIndex = 51;
            picRepoLink.TabStop = false;
            toolTip1.SetToolTip(picRepoLink, "Opens SUP Launcher repository on Github");
            picRepoLink.Click += picRepoLink_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.Gray;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(544, -1);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(31, 36);
            button1.TabIndex = 50;
            button1.UseVisualStyleBackColor = false;
            button1.Click += Button1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(24, 31, 40);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.ForeColor = Color.Gray;
            textBox1.Location = new Point(334, 62);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(225, 16);
            textBox1.TabIndex = 45;
            textBox1.Text = "STEAM_0:X:XXXXXXXXX";
            textBox1.TextAlign = HorizontalAlignment.Center;
            toolTip1.SetToolTip(textBox1, "Search up a player's information\r\non SuperiorServers by pasting \r\ntheir SteamID32 or 64 in the search box.");
            textBox1.Enter += TextBox1_Enter;
            textBox1.KeyDown += TextBox1_KeyDown;
            textBox1.Leave += TextBox1_Leave;
            // 
            // toolTip1
            // 
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.Popup += ToolTip1_Popup;
            // 
            // tmrAFK
            // 
            tmrAFK.Enabled = true;
            tmrAFK.Interval = 11000;
            tmrAFK.Tick += tmrAFK_Tick;
            // 
            // mnuSettingsDrop
            // 
            mnuSettingsDrop.BackColor = Color.Black;
            mnuSettingsDrop.DropShadowEnabled = false;
            mnuSettingsDrop.Items.AddRange(new ToolStripItem[] { customizationToolStripMenuItem, missingTexturesToolStripMenuItem, discordStatusToggleToolStripMenuItem, overlayToggleALTSToolStripMenuItem });
            mnuSettingsDrop.Name = "mnuSettingsDrop";
            mnuSettingsDrop.ShowCheckMargin = true;
            mnuSettingsDrop.ShowImageMargin = false;
            mnuSettingsDrop.Size = new Size(203, 92);
            mnuSettingsDrop.Text = "Settings";
            // 
            // customizationToolStripMenuItem
            // 
            customizationToolStripMenuItem.BackColor = Color.FromArgb(32, 32, 32);
            customizationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3 });
            customizationToolStripMenuItem.ForeColor = Color.White;
            customizationToolStripMenuItem.Name = "customizationToolStripMenuItem";
            customizationToolStripMenuItem.Size = new Size(202, 22);
            customizationToolStripMenuItem.Text = "Customization";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.BackColor = Color.FromArgb(32, 32, 32);
            toolStripMenuItem2.DoubleClickEnabled = true;
            toolStripMenuItem2.ForeColor = Color.White;
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.ShowShortcutKeys = false;
            toolStripMenuItem2.Size = new Size(195, 22);
            toolStripMenuItem2.Text = "Set Custom Background";
            toolStripMenuItem2.ToolTipText = "Allows you to set the background image of the Launcher";
            toolStripMenuItem2.Click += setBackgroundImageToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.BackColor = Color.FromArgb(32, 32, 32);
            toolStripMenuItem3.ForeColor = Color.White;
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.ShowShortcutKeys = false;
            toolStripMenuItem3.Size = new Size(195, 22);
            toolStripMenuItem3.Text = "Set Default Background";
            toolStripMenuItem3.Click += setDefaultBackgroundImageToolStripMenuItem_Click;
            // 
            // missingTexturesToolStripMenuItem
            // 
            missingTexturesToolStripMenuItem.BackColor = Color.FromArgb(30, 30, 30);
            missingTexturesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem4 });
            missingTexturesToolStripMenuItem.ForeColor = Color.White;
            missingTexturesToolStripMenuItem.Name = "missingTexturesToolStripMenuItem";
            missingTexturesToolStripMenuItem.Size = new Size(202, 22);
            missingTexturesToolStripMenuItem.Text = "Missing Textures?";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.BackColor = Color.FromArgb(32, 32, 32);
            toolStripMenuItem4.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripMenuItem4.ForeColor = Color.White;
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(197, 22);
            toolStripMenuItem4.Text = "Download CSS Textures";
            // 
            // discordStatusToggleToolStripMenuItem
            // 
            discordStatusToggleToolStripMenuItem.BackColor = Color.FromArgb(32, 32, 32);
            discordStatusToggleToolStripMenuItem.CheckOnClick = true;
            discordStatusToggleToolStripMenuItem.ForeColor = Color.White;
            discordStatusToggleToolStripMenuItem.Name = "discordStatusToggleToolStripMenuItem";
            discordStatusToggleToolStripMenuItem.Size = new Size(202, 22);
            discordStatusToggleToolStripMenuItem.Text = "Discord Status Toggle";
            discordStatusToggleToolStripMenuItem.Click += discordStatusToggleToolStripMenuItem_CheckedChanged;
            // 
            // overlayToggleALTSToolStripMenuItem
            // 
            overlayToggleALTSToolStripMenuItem.BackColor = Color.FromArgb(32, 32, 32);
            overlayToggleALTSToolStripMenuItem.CheckOnClick = true;
            overlayToggleALTSToolStripMenuItem.ForeColor = Color.White;
            overlayToggleALTSToolStripMenuItem.Name = "overlayToggleALTSToolStripMenuItem";
            overlayToggleALTSToolStripMenuItem.Size = new Size(202, 22);
            overlayToggleALTSToolStripMenuItem.Text = "Overlay Toggle (ALT + S)";
            overlayToggleALTSToolStripMenuItem.Click += overlayToggleALTSToolStripMenuItem_CheckedChanged;
            // 
            // ofdSetBackgroundImage
            // 
            ofdSetBackgroundImage.Filter = "Image Files (*png, *jpg, *bmp)|*.png;*.jpg;*bmp";
            ofdSetBackgroundImage.Title = "Select Background Image";
            // 
            // frmLauncher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(74, 99, 145);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(575, 535);
            ControlBox = false;
            Controls.Add(textBox1);
            Controls.Add(topBar);
            Controls.Add(panel1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MaximumSize = new Size(575, 535);
            MinimizeBox = false;
            Name = "frmLauncher";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SUP Launcher";
            TransparencyKey = Color.FromArgb(74, 99, 145);
            FormClosing += FrmLauncher_FormClosing;
            Click += FrmLauncher_Click;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)picRank).EndInit();
            ((System.ComponentModel.ISupportInitialize)versionWarn).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgrefresh).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            topBar.ResumeLayout(false);
            topBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picRepoLink).EndInit();
            mnuSettingsDrop.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button btnForums;
        private System.Windows.Forms.Button btnTS;
        private System.Windows.Forms.Label lblDT;
        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.Label lblSD;
        private System.Windows.Forms.Label lblC18;
        private System.Windows.Forms.Label lblZRP;
        private System.Windows.Forms.Label lblMRP;
        private System.Windows.Forms.Label lblCW1;
        private System.Windows.Forms.Label lblCW2;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Timer tmrSteamQuery;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button btnDRPRules;
        private System.Windows.Forms.Button btnMilRPRules;
        private System.Windows.Forms.Button btnCWRPRules;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Button btnCW2;
        private System.Windows.Forms.Button btnCW1;
        private System.Windows.Forms.Button btnMilRP;
        private System.Windows.Forms.Button btnZombies;
        private System.Windows.Forms.Button btnC18;
        private System.Windows.Forms.Button btnSundown;
        private System.Windows.Forms.Button btnDupes;
        private System.Windows.Forms.Button btnDanktown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panCW2;
        private System.Windows.Forms.Panel panCW1;
        private System.Windows.Forms.Panel panMilRP;
        private System.Windows.Forms.Panel panZombies;
        private System.Windows.Forms.Panel panC18;
        private System.Windows.Forms.Panel panSD;
        private System.Windows.Forms.Panel panDanktown;
        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.PictureBox imgrefresh;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox versionWarn;
        private System.Windows.Forms.ToolTip toolTip1;
        private PictureBox picRepoLink;
        private PictureBox pictureBox1;
        private Label label1;
        private CheckBox chkAFK;
        private Label label3;
        public PictureBox picImage;
        private System.Windows.Forms.Timer tmrAFK;
        private Button btnSettings;
        private ContextMenuStrip mnuSettingsDrop;
        private OpenFileDialog ofdSetBackgroundImage;
        private Label label4;
        private Button btnMinimize;
        private Panel panel2;
        private PictureBox picRank;
        private Label label7;
        private ToolStripMenuItem discordStatusToggleToolStripMenuItem;
        private ToolStripMenuItem overlayToggleALTSToolStripMenuItem;
        private ToolStripMenuItem customizationToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem missingTexturesToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem4;
    }
}

