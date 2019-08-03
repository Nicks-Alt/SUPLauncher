﻿namespace SUPLauncher
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLauncher));
            this.btnForums = new System.Windows.Forms.Button();
            this.btnTS = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDT = new System.Windows.Forms.Label();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.lblSD = new System.Windows.Forms.Label();
            this.lblC18 = new System.Windows.Forms.Label();
            this.lblZRP = new System.Windows.Forms.Label();
            this.lblMRP = new System.Windows.Forms.Label();
            this.lblCW1 = new System.Windows.Forms.Label();
            this.lblCW2 = new System.Windows.Forms.Label();
            this.chkAFK = new System.Windows.Forms.CheckBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrSteamQuery = new System.Windows.Forms.Timer(this.components);
            this.chkDiscord = new System.Windows.Forms.CheckBox();
            this.btnDRPRules = new System.Windows.Forms.Button();
            this.btnMilRPRules = new System.Windows.Forms.Button();
            this.btnCWRPRules = new System.Windows.Forms.Button();
            this.lblServer = new System.Windows.Forms.Label();
            this.btnCW2 = new System.Windows.Forms.Button();
            this.btnCW1 = new System.Windows.Forms.Button();
            this.btnMilRP = new System.Windows.Forms.Button();
            this.btnZombies = new System.Windows.Forms.Button();
            this.btnC18 = new System.Windows.Forms.Button();
            this.btnSundown = new System.Windows.Forms.Button();
            this.btnDupes = new System.Windows.Forms.Button();
            this.btnDanktown = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panCW2 = new System.Windows.Forms.Panel();
            this.panCW1 = new System.Windows.Forms.Panel();
            this.panMilRP = new System.Windows.Forms.Panel();
            this.panZombies = new System.Windows.Forms.Panel();
            this.panC18 = new System.Windows.Forms.Panel();
            this.panSD = new System.Windows.Forms.Panel();
            this.panDanktown = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSERVERLookup = new System.Windows.Forms.Label();
            this.lblFORUMLookup = new System.Windows.Forms.Label();
            this.picImage = new OvalPictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnForums
            // 
            this.btnForums.BackColor = System.Drawing.Color.White;
            this.btnForums.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForums.Location = new System.Drawing.Point(291, 201);
            this.btnForums.Name = "btnForums";
            this.btnForums.Size = new System.Drawing.Size(81, 33);
            this.btnForums.TabIndex = 11;
            this.btnForums.Text = "Forums";
            this.btnForums.UseVisualStyleBackColor = false;
            this.btnForums.Click += new System.EventHandler(this.btnForums_Click);
            // 
            // btnTS
            // 
            this.btnTS.BackColor = System.Drawing.Color.White;
            this.btnTS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTS.Location = new System.Drawing.Point(384, 201);
            this.btnTS.Name = "btnTS";
            this.btnTS.Size = new System.Drawing.Size(81, 33);
            this.btnTS.TabIndex = 12;
            this.btnTS.Text = "TS";
            this.btnTS.UseVisualStyleBackColor = false;
            this.btnTS.Click += new System.EventHandler(this.btnTS_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(355, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "Other";
            // 
            // lblDT
            // 
            this.lblDT.AutoSize = true;
            this.lblDT.BackColor = System.Drawing.Color.Transparent;
            this.lblDT.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDT.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDT.Location = new System.Drawing.Point(206, 43);
            this.lblDT.Name = "lblDT";
            this.lblDT.Size = new System.Drawing.Size(48, 15);
            this.lblDT.TabIndex = 15;
            this.lblDT.Text = "000/000";
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Enabled = true;
            this.tmrRefresh.Interval = 5000;
            // 
            // lblSD
            // 
            this.lblSD.AutoSize = true;
            this.lblSD.BackColor = System.Drawing.Color.Transparent;
            this.lblSD.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSD.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSD.Location = new System.Drawing.Point(206, 82);
            this.lblSD.Name = "lblSD";
            this.lblSD.Size = new System.Drawing.Size(48, 15);
            this.lblSD.TabIndex = 16;
            this.lblSD.Text = "000/000";
            // 
            // lblC18
            // 
            this.lblC18.AutoSize = true;
            this.lblC18.BackColor = System.Drawing.Color.Transparent;
            this.lblC18.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblC18.ForeColor = System.Drawing.SystemColors.Control;
            this.lblC18.Location = new System.Drawing.Point(206, 121);
            this.lblC18.Name = "lblC18";
            this.lblC18.Size = new System.Drawing.Size(48, 15);
            this.lblC18.TabIndex = 17;
            this.lblC18.Text = "000/000";
            // 
            // lblZRP
            // 
            this.lblZRP.AutoSize = true;
            this.lblZRP.BackColor = System.Drawing.Color.Transparent;
            this.lblZRP.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZRP.ForeColor = System.Drawing.SystemColors.Control;
            this.lblZRP.Location = new System.Drawing.Point(206, 160);
            this.lblZRP.Name = "lblZRP";
            this.lblZRP.Size = new System.Drawing.Size(48, 15);
            this.lblZRP.TabIndex = 18;
            this.lblZRP.Text = "000/000";
            // 
            // lblMRP
            // 
            this.lblMRP.AutoSize = true;
            this.lblMRP.BackColor = System.Drawing.Color.Transparent;
            this.lblMRP.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMRP.ForeColor = System.Drawing.SystemColors.Control;
            this.lblMRP.Location = new System.Drawing.Point(206, 199);
            this.lblMRP.Name = "lblMRP";
            this.lblMRP.Size = new System.Drawing.Size(48, 15);
            this.lblMRP.TabIndex = 19;
            this.lblMRP.Text = "000/000";
            // 
            // lblCW1
            // 
            this.lblCW1.AutoSize = true;
            this.lblCW1.BackColor = System.Drawing.Color.Transparent;
            this.lblCW1.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCW1.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCW1.Location = new System.Drawing.Point(206, 238);
            this.lblCW1.Name = "lblCW1";
            this.lblCW1.Size = new System.Drawing.Size(48, 15);
            this.lblCW1.TabIndex = 20;
            this.lblCW1.Text = "000/000";
            // 
            // lblCW2
            // 
            this.lblCW2.AutoSize = true;
            this.lblCW2.BackColor = System.Drawing.Color.Transparent;
            this.lblCW2.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCW2.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCW2.Location = new System.Drawing.Point(206, 277);
            this.lblCW2.Name = "lblCW2";
            this.lblCW2.Size = new System.Drawing.Size(48, 15);
            this.lblCW2.TabIndex = 21;
            this.lblCW2.Text = "000/000";
            // 
            // chkAFK
            // 
            this.chkAFK.AutoSize = true;
            this.chkAFK.BackColor = System.Drawing.Color.Transparent;
            this.chkAFK.Font = new System.Drawing.Font("Roboto Condensed", 9.75F);
            this.chkAFK.ForeColor = System.Drawing.SystemColors.Control;
            this.chkAFK.Location = new System.Drawing.Point(294, 381);
            this.chkAFK.Name = "chkAFK";
            this.chkAFK.Size = new System.Drawing.Size(78, 19);
            this.chkAFK.TabIndex = 22;
            this.chkAFK.Text = "AFK Mode";
            this.chkAFK.UseVisualStyleBackColor = false;
            this.chkAFK.CheckedChanged += new System.EventHandler(this.chkAFK_CheckedChanged);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVersion.Font = new System.Drawing.Font("Prototype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.SystemColors.Control;
            this.lblVersion.Location = new System.Drawing.Point(164, 386);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(34, 20);
            this.lblVersion.TabIndex = 27;
            this.lblVersion.Text = "1.1.1.1";
            this.lblVersion.Click += new System.EventHandler(this.lblVersion_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // tmrSteamQuery
            // 
            this.tmrSteamQuery.Interval = 5000;
            this.tmrSteamQuery.Tick += new System.EventHandler(this.tmrSteamQuery_Tick);
            // 
            // chkDiscord
            // 
            this.chkDiscord.AutoSize = true;
            this.chkDiscord.BackColor = System.Drawing.Color.Transparent;
            this.chkDiscord.Font = new System.Drawing.Font("Roboto Condensed", 9.75F);
            this.chkDiscord.ForeColor = System.Drawing.SystemColors.Control;
            this.chkDiscord.Location = new System.Drawing.Point(400, 381);
            this.chkDiscord.Name = "chkDiscord";
            this.chkDiscord.Size = new System.Drawing.Size(65, 19);
            this.chkDiscord.TabIndex = 32;
            this.chkDiscord.Text = "Discord";
            this.chkDiscord.UseVisualStyleBackColor = false;
            this.chkDiscord.CheckedChanged += new System.EventHandler(this.chkDiscord_CheckedChanged);
            // 
            // btnDRPRules
            // 
            this.btnDRPRules.BackColor = System.Drawing.Color.White;
            this.btnDRPRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDRPRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDRPRules.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDRPRules.Location = new System.Drawing.Point(274, 255);
            this.btnDRPRules.Margin = new System.Windows.Forms.Padding(0);
            this.btnDRPRules.Name = "btnDRPRules";
            this.btnDRPRules.Size = new System.Drawing.Size(204, 23);
            this.btnDRPRules.TabIndex = 33;
            this.btnDRPRules.Text = "DarkRP Rules/FAQ";
            this.btnDRPRules.UseVisualStyleBackColor = false;
            this.btnDRPRules.Click += new System.EventHandler(this.btnDRPRules_Click);
            // 
            // btnMilRPRules
            // 
            this.btnMilRPRules.BackColor = System.Drawing.Color.White;
            this.btnMilRPRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMilRPRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMilRPRules.Location = new System.Drawing.Point(274, 296);
            this.btnMilRPRules.Margin = new System.Windows.Forms.Padding(0);
            this.btnMilRPRules.Name = "btnMilRPRules";
            this.btnMilRPRules.Size = new System.Drawing.Size(204, 23);
            this.btnMilRPRules.TabIndex = 34;
            this.btnMilRPRules.Text = "MilRP Rules/FAQ";
            this.btnMilRPRules.UseVisualStyleBackColor = false;
            this.btnMilRPRules.Click += new System.EventHandler(this.btnMilRPRules_Click);
            // 
            // btnCWRPRules
            // 
            this.btnCWRPRules.BackColor = System.Drawing.Color.White;
            this.btnCWRPRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCWRPRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCWRPRules.Location = new System.Drawing.Point(274, 337);
            this.btnCWRPRules.Margin = new System.Windows.Forms.Padding(0);
            this.btnCWRPRules.Name = "btnCWRPRules";
            this.btnCWRPRules.Size = new System.Drawing.Size(204, 23);
            this.btnCWRPRules.TabIndex = 35;
            this.btnCWRPRules.Text = "CWRP Rules/FAQ";
            this.btnCWRPRules.UseVisualStyleBackColor = false;
            this.btnCWRPRules.Click += new System.EventHandler(this.btnCWRPRules_Click);
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.BackColor = System.Drawing.Color.Transparent;
            this.lblServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblServer.Font = new System.Drawing.Font("Prototype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServer.ForeColor = System.Drawing.SystemColors.Control;
            this.lblServer.Location = new System.Drawing.Point(290, 442);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(34, 20);
            this.lblServer.TabIndex = 36;
            this.lblServer.Text = "1.1.1.1";
            this.lblServer.Visible = false;
            this.lblServer.TextChanged += new System.EventHandler(this.lblServer_TextChanged);
            // 
            // btnCW2
            // 
            this.btnCW2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCW2.FlatAppearance.BorderSize = 0;
            this.btnCW2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCW2.ForeColor = System.Drawing.Color.White;
            this.btnCW2.Location = new System.Drawing.Point(0, 268);
            this.btnCW2.Name = "btnCW2";
            this.btnCW2.Size = new System.Drawing.Size(200, 33);
            this.btnCW2.TabIndex = 6;
            this.btnCW2.Text = "Clonewars #2";
            this.btnCW2.UseVisualStyleBackColor = false;
            this.btnCW2.Click += new System.EventHandler(this.btnCW2_Click);
            // 
            // btnCW1
            // 
            this.btnCW1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCW1.FlatAppearance.BorderSize = 0;
            this.btnCW1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCW1.ForeColor = System.Drawing.Color.White;
            this.btnCW1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCW1.Location = new System.Drawing.Point(0, 229);
            this.btnCW1.Name = "btnCW1";
            this.btnCW1.Size = new System.Drawing.Size(200, 33);
            this.btnCW1.TabIndex = 5;
            this.btnCW1.Text = "Clonewars #1";
            this.btnCW1.UseVisualStyleBackColor = false;
            this.btnCW1.Click += new System.EventHandler(this.btnCW1_Click);
            // 
            // btnMilRP
            // 
            this.btnMilRP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMilRP.FlatAppearance.BorderSize = 0;
            this.btnMilRP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMilRP.ForeColor = System.Drawing.Color.White;
            this.btnMilRP.Location = new System.Drawing.Point(0, 190);
            this.btnMilRP.Name = "btnMilRP";
            this.btnMilRP.Size = new System.Drawing.Size(200, 33);
            this.btnMilRP.TabIndex = 4;
            this.btnMilRP.Text = "MilitaryRP";
            this.btnMilRP.UseVisualStyleBackColor = false;
            this.btnMilRP.Click += new System.EventHandler(this.btnMilRP_Click);
            // 
            // btnZombies
            // 
            this.btnZombies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnZombies.FlatAppearance.BorderSize = 0;
            this.btnZombies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZombies.ForeColor = System.Drawing.Color.White;
            this.btnZombies.Location = new System.Drawing.Point(0, 151);
            this.btnZombies.Name = "btnZombies";
            this.btnZombies.Size = new System.Drawing.Size(200, 33);
            this.btnZombies.TabIndex = 3;
            this.btnZombies.Text = "Zombies";
            this.btnZombies.UseVisualStyleBackColor = false;
            this.btnZombies.Click += new System.EventHandler(this.btnZombies_Click);
            // 
            // btnC18
            // 
            this.btnC18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnC18.FlatAppearance.BorderSize = 0;
            this.btnC18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnC18.ForeColor = System.Drawing.Color.White;
            this.btnC18.Location = new System.Drawing.Point(0, 112);
            this.btnC18.Name = "btnC18";
            this.btnC18.Size = new System.Drawing.Size(200, 33);
            this.btnC18.TabIndex = 2;
            this.btnC18.Text = "C18";
            this.btnC18.UseVisualStyleBackColor = false;
            this.btnC18.Click += new System.EventHandler(this.btnC18_Click);
            // 
            // btnSundown
            // 
            this.btnSundown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSundown.Enabled = false;
            this.btnSundown.FlatAppearance.BorderSize = 0;
            this.btnSundown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSundown.ForeColor = System.Drawing.Color.White;
            this.btnSundown.Location = new System.Drawing.Point(0, 73);
            this.btnSundown.Name = "btnSundown";
            this.btnSundown.Size = new System.Drawing.Size(200, 33);
            this.btnSundown.TabIndex = 1;
            this.btnSundown.Text = "Sundown";
            this.btnSundown.UseVisualStyleBackColor = false;
            // 
            // btnDupes
            // 
            this.btnDupes.BackColor = System.Drawing.Color.White;
            this.btnDupes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDupes.Location = new System.Drawing.Point(142, 329);
            this.btnDupes.Name = "btnDupes";
            this.btnDupes.Size = new System.Drawing.Size(91, 41);
            this.btnDupes.TabIndex = 38;
            this.btnDupes.Text = "Open Dupe Manager";
            this.btnDupes.UseVisualStyleBackColor = false;
            this.btnDupes.Click += new System.EventHandler(this.BtnDupes_Click);
            // 
            // btnDanktown
            // 
            this.btnDanktown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDanktown.FlatAppearance.BorderSize = 0;
            this.btnDanktown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanktown.ForeColor = System.Drawing.Color.White;
            this.btnDanktown.Location = new System.Drawing.Point(3, 34);
            this.btnDanktown.Name = "btnDanktown";
            this.btnDanktown.Size = new System.Drawing.Size(197, 33);
            this.btnDanktown.TabIndex = 0;
            this.btnDanktown.Text = "Danktown";
            this.btnDanktown.UseVisualStyleBackColor = false;
            this.btnDanktown.Click += new System.EventHandler(this.btnDanktown_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Prototype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(89, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Servers";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnDupes);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panCW2);
            this.panel1.Controls.Add(this.panCW1);
            this.panel1.Controls.Add(this.panMilRP);
            this.panel1.Controls.Add(this.panZombies);
            this.panel1.Controls.Add(this.panC18);
            this.panel1.Controls.Add(this.panSD);
            this.panel1.Controls.Add(this.panDanktown);
            this.panel1.Controls.Add(this.btnDanktown);
            this.panel1.Controls.Add(this.lblVersion);
            this.panel1.Controls.Add(this.btnSundown);
            this.panel1.Controls.Add(this.lblCW2);
            this.panel1.Controls.Add(this.btnC18);
            this.panel1.Controls.Add(this.lblCW1);
            this.panel1.Controls.Add(this.picImage);
            this.panel1.Controls.Add(this.lblMRP);
            this.panel1.Controls.Add(this.btnZombies);
            this.panel1.Controls.Add(this.lblZRP);
            this.panel1.Controls.Add(this.btnMilRP);
            this.panel1.Controls.Add(this.lblC18);
            this.panel1.Controls.Add(this.btnCW1);
            this.panel1.Controls.Add(this.lblSD);
            this.panel1.Controls.Add(this.btnCW2);
            this.panel1.Controls.Add(this.lblDT);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 424);
            this.panel1.TabIndex = 39;
            // 
            // panCW2
            // 
            this.panCW2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panCW2.Location = new System.Drawing.Point(0, 268);
            this.panCW2.Name = "panCW2";
            this.panCW2.Size = new System.Drawing.Size(10, 33);
            this.panCW2.TabIndex = 47;
            // 
            // panCW1
            // 
            this.panCW1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panCW1.Location = new System.Drawing.Point(0, 229);
            this.panCW1.Name = "panCW1";
            this.panCW1.Size = new System.Drawing.Size(10, 33);
            this.panCW1.TabIndex = 46;
            // 
            // panMilRP
            // 
            this.panMilRP.BackColor = System.Drawing.Color.RoyalBlue;
            this.panMilRP.Location = new System.Drawing.Point(0, 190);
            this.panMilRP.Name = "panMilRP";
            this.panMilRP.Size = new System.Drawing.Size(10, 33);
            this.panMilRP.TabIndex = 45;
            // 
            // panZombies
            // 
            this.panZombies.BackColor = System.Drawing.Color.RoyalBlue;
            this.panZombies.Location = new System.Drawing.Point(0, 151);
            this.panZombies.Name = "panZombies";
            this.panZombies.Size = new System.Drawing.Size(10, 33);
            this.panZombies.TabIndex = 44;
            // 
            // panC18
            // 
            this.panC18.BackColor = System.Drawing.Color.RoyalBlue;
            this.panC18.Location = new System.Drawing.Point(0, 112);
            this.panC18.Name = "panC18";
            this.panC18.Size = new System.Drawing.Size(10, 33);
            this.panC18.TabIndex = 43;
            // 
            // panSD
            // 
            this.panSD.BackColor = System.Drawing.Color.RoyalBlue;
            this.panSD.Location = new System.Drawing.Point(0, 73);
            this.panSD.Name = "panSD";
            this.panSD.Size = new System.Drawing.Size(10, 33);
            this.panSD.TabIndex = 42;
            // 
            // panDanktown
            // 
            this.panDanktown.BackColor = System.Drawing.Color.RoyalBlue;
            this.panDanktown.Location = new System.Drawing.Point(0, 34);
            this.panDanktown.Name = "panDanktown";
            this.panDanktown.Size = new System.Drawing.Size(10, 33);
            this.panDanktown.TabIndex = 41;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(267, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(222, 93);
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // lblSERVERLookup
            // 
            this.lblSERVERLookup.AutoSize = true;
            this.lblSERVERLookup.BackColor = System.Drawing.Color.Transparent;
            this.lblSERVERLookup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSERVERLookup.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSERVERLookup.Location = new System.Drawing.Point(288, 11);
            this.lblSERVERLookup.Name = "lblSERVERLookup";
            this.lblSERVERLookup.Size = new System.Drawing.Size(38, 13);
            this.lblSERVERLookup.TabIndex = 41;
            this.lblSERVERLookup.Text = "Server";
            this.lblSERVERLookup.Click += new System.EventHandler(this.LblSERVERLookup_Click);
            // 
            // lblFORUMLookup
            // 
            this.lblFORUMLookup.AutoSize = true;
            this.lblFORUMLookup.BackColor = System.Drawing.Color.Transparent;
            this.lblFORUMLookup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFORUMLookup.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblFORUMLookup.Location = new System.Drawing.Point(429, 11);
            this.lblFORUMLookup.Name = "lblFORUMLookup";
            this.lblFORUMLookup.Size = new System.Drawing.Size(36, 13);
            this.lblFORUMLookup.TabIndex = 42;
            this.lblFORUMLookup.Text = "Forum";
            this.lblFORUMLookup.Click += new System.EventHandler(this.LblFORUMLookup_Click);
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.Transparent;
            this.picImage.BackgroundImage = global::SUPLauncher.Properties.Resources.suplogo;
            this.picImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picImage.ErrorImage = global::SUPLauncher.Properties.Resources.suplogo;
            this.picImage.Location = new System.Drawing.Point(12, 313);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(100, 100);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 25;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            // 
            // frmLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(99)))), ((int)(((byte)(145)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(493, 421);
            this.Controls.Add(this.lblFORUMLookup);
            this.Controls.Add(this.lblSERVERLookup);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.btnCWRPRules);
            this.Controls.Add(this.btnMilRPRules);
            this.Controls.Add(this.btnDRPRules);
            this.Controls.Add(this.chkDiscord);
            this.Controls.Add(this.chkAFK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnTS);
            this.Controls.Add(this.btnForums);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLauncher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SUP Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLauncher_FormClosing);
            this.Load += new System.EventHandler(this.frmLauncher_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnForums;
        private System.Windows.Forms.Button btnTS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDT;
        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.Label lblSD;
        private System.Windows.Forms.Label lblC18;
        private System.Windows.Forms.Label lblZRP;
        private System.Windows.Forms.Label lblMRP;
        private System.Windows.Forms.Label lblCW1;
        private System.Windows.Forms.Label lblCW2;
        private System.Windows.Forms.CheckBox chkAFK;
        private OvalPictureBox picImage;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Timer tmrSteamQuery;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.CheckBox chkDiscord;
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSERVERLookup;
        private System.Windows.Forms.Label lblFORUMLookup;
    }
}

