namespace SUPLauncher
{
    partial class Overlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Overlay));
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            overlayPanel = new Panel();
            lblStaffTools = new Label();
            lblHoverForInfo = new Label();
            picRank = new PictureBox();
            chkProfileOverlay = new CheckBox();
            lblUseF3 = new Label();
            label1 = new Label();
            staffTools = new Panel();
            textBox1 = new TextBox();
            label2 = new Label();
            btnCWRPRulesCopy = new Button();
            btnMilRPRulesCopy = new Button();
            btnDarkRPRulesCopy = new Button();
            btnCWRPRules = new Button();
            btnMilRPRules = new Button();
            btnDarkRPRules = new Button();
            button10 = new Button();
            button9 = new Button();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            overlayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picRank).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.suplogo;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(65, 8);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 125);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Resize += pictureBox1_Resize;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(14, 14, 14);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 10F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(13, 513);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(57, 31);
            button1.TabIndex = 1;
            button1.Text = "Forums";
            toolTip1.SetToolTip(button1, "Opens link in your default browser");
            button1.UseVisualStyleBackColor = false;
            button1.Click += Button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(14, 14, 14);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft Sans Serif", 10F);
            button2.ForeColor = Color.White;
            button2.Location = new Point(14, 206);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(231, 31);
            button2.TabIndex = 2;
            button2.Text = "TeamSpeak";
            toolTip1.SetToolTip(button2, "Opens teamspeak and connects to the superiorservers teamspeak.");
            button2.UseVisualStyleBackColor = false;
            button2.Click += Button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(14, 14, 14);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Microsoft Sans Serif", 10F);
            button3.ForeColor = Color.White;
            button3.Location = new Point(14, 244);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(230, 31);
            button3.TabIndex = 3;
            button3.Text = "Danktown";
            toolTip1.SetToolTip(button3, "Connects you to this server.");
            button3.UseVisualStyleBackColor = false;
            button3.Click += Button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(14, 14, 14);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Microsoft Sans Serif", 10F);
            button4.ForeColor = Color.White;
            button4.Location = new Point(14, 283);
            button4.Margin = new Padding(4, 3, 4, 3);
            button4.Name = "button4";
            button4.Size = new Size(230, 31);
            button4.TabIndex = 4;
            button4.Text = "C18";
            toolTip1.SetToolTip(button4, "Connects you to this server.");
            button4.UseVisualStyleBackColor = false;
            button4.Click += Button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(14, 14, 14);
            button5.Enabled = false;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Microsoft Sans Serif", 10F);
            button5.ForeColor = Color.White;
            button5.Location = new Point(14, 321);
            button5.Margin = new Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new Size(230, 31);
            button5.TabIndex = 5;
            button5.Text = "Zombies";
            toolTip1.SetToolTip(button5, "Connects you to this server.");
            button5.UseVisualStyleBackColor = false;
            button5.Click += Button5_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(14, 14, 14);
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Microsoft Sans Serif", 10F);
            button6.ForeColor = Color.White;
            button6.Location = new Point(14, 359);
            button6.Margin = new Padding(4, 3, 4, 3);
            button6.Name = "button6";
            button6.Size = new Size(230, 31);
            button6.TabIndex = 6;
            button6.Text = "MilRP";
            toolTip1.SetToolTip(button6, "Connects you to this server.");
            button6.UseVisualStyleBackColor = false;
            button6.Click += Button6_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(14, 14, 14);
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Microsoft Sans Serif", 10F);
            button7.ForeColor = Color.White;
            button7.Location = new Point(14, 397);
            button7.Margin = new Padding(4, 3, 4, 3);
            button7.Name = "button7";
            button7.Size = new Size(230, 31);
            button7.TabIndex = 7;
            button7.Text = "CWRP";
            toolTip1.SetToolTip(button7, "Connects you to this server.");
            button7.UseVisualStyleBackColor = false;
            button7.Click += Button7_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(14, 14, 14);
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Microsoft Sans Serif", 10F);
            button8.ForeColor = Color.White;
            button8.Location = new Point(14, 435);
            button8.Margin = new Padding(4, 3, 4, 3);
            button8.Name = "button8";
            button8.Size = new Size(230, 31);
            button8.TabIndex = 8;
            button8.Text = "CWRP 2";
            toolTip1.SetToolTip(button8, "Connects you to this server.");
            button8.UseVisualStyleBackColor = false;
            button8.Click += Button8_Click;
            // 
            // overlayPanel
            // 
            overlayPanel.AutoScroll = true;
            overlayPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            overlayPanel.BackColor = Color.FromArgb(225, 14, 14, 14);
            overlayPanel.Controls.Add(lblStaffTools);
            overlayPanel.Controls.Add(lblHoverForInfo);
            overlayPanel.Controls.Add(picRank);
            overlayPanel.Controls.Add(chkProfileOverlay);
            overlayPanel.Controls.Add(lblUseF3);
            overlayPanel.Controls.Add(label1);
            overlayPanel.Controls.Add(staffTools);
            overlayPanel.Controls.Add(textBox1);
            overlayPanel.Controls.Add(label2);
            overlayPanel.Controls.Add(btnCWRPRulesCopy);
            overlayPanel.Controls.Add(btnMilRPRulesCopy);
            overlayPanel.Controls.Add(btnDarkRPRulesCopy);
            overlayPanel.Controls.Add(btnCWRPRules);
            overlayPanel.Controls.Add(btnMilRPRules);
            overlayPanel.Controls.Add(btnDarkRPRules);
            overlayPanel.Controls.Add(button10);
            overlayPanel.Controls.Add(button9);
            overlayPanel.Controls.Add(button8);
            overlayPanel.Controls.Add(pictureBox1);
            overlayPanel.Controls.Add(button7);
            overlayPanel.Controls.Add(button1);
            overlayPanel.Controls.Add(button6);
            overlayPanel.Controls.Add(button2);
            overlayPanel.Controls.Add(button5);
            overlayPanel.Controls.Add(button3);
            overlayPanel.Controls.Add(button4);
            overlayPanel.Location = new Point(0, 0);
            overlayPanel.Margin = new Padding(4, 3, 4, 3);
            overlayPanel.Name = "overlayPanel";
            overlayPanel.Size = new Size(255, 1034);
            overlayPanel.TabIndex = 9;
            overlayPanel.Click += OverlayPanel_Click;
            // 
            // lblStaffTools
            // 
            lblStaffTools.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblStaffTools.BackColor = Color.Transparent;
            lblStaffTools.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStaffTools.ForeColor = Color.White;
            lblStaffTools.Location = new Point(2, 822);
            lblStaffTools.Margin = new Padding(4, 0, 4, 0);
            lblStaffTools.Name = "lblStaffTools";
            lblStaffTools.Size = new Size(251, 33);
            lblStaffTools.TabIndex = 0;
            lblStaffTools.Text = "STAFF TOOLS";
            lblStaffTools.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHoverForInfo
            // 
            lblHoverForInfo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblHoverForInfo.BackColor = Color.Transparent;
            lblHoverForInfo.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHoverForInfo.ForeColor = Color.White;
            lblHoverForInfo.Location = new Point(2, 913);
            lblHoverForInfo.Margin = new Padding(4, 0, 4, 0);
            lblHoverForInfo.Name = "lblHoverForInfo";
            lblHoverForInfo.Size = new Size(251, 46);
            lblHoverForInfo.TabIndex = 2;
            lblHoverForInfo.Text = "Hover over for more info";
            lblHoverForInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picRank
            // 
            picRank.Anchor = AnchorStyles.Top;
            picRank.BackColor = Color.Transparent;
            picRank.Location = new Point(0, 143);
            picRank.Name = "picRank";
            picRank.Size = new Size(255, 56);
            picRank.SizeMode = PictureBoxSizeMode.CenterImage;
            picRank.TabIndex = 48;
            picRank.TabStop = false;
            // 
            // chkProfileOverlay
            // 
            chkProfileOverlay.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            chkProfileOverlay.BackColor = Color.Transparent;
            chkProfileOverlay.ForeColor = Color.White;
            chkProfileOverlay.Location = new Point(61, 882);
            chkProfileOverlay.Margin = new Padding(4, 3, 4, 3);
            chkProfileOverlay.Name = "chkProfileOverlay";
            chkProfileOverlay.Size = new Size(132, 28);
            chkProfileOverlay.TabIndex = 1;
            chkProfileOverlay.Text = "SUP Profile Overlay";
            toolTip1.SetToolTip(chkProfileOverlay, "Automatically display sup profiles from clipboard or click button below to ask for input.");
            chkProfileOverlay.UseVisualStyleBackColor = false;
            chkProfileOverlay.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // lblUseF3
            // 
            lblUseF3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblUseF3.BackColor = Color.Transparent;
            lblUseF3.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUseF3.ForeColor = Color.White;
            lblUseF3.Location = new Point(2, 985);
            lblUseF3.Margin = new Padding(4, 0, 4, 0);
            lblUseF3.Name = "lblUseF3";
            lblUseF3.Size = new Size(251, 46);
            lblUseF3.TabIndex = 3;
            lblUseF3.Text = "Use F3 To Interact";
            lblUseF3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(-5, 551);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 37);
            label1.TabIndex = 20;
            label1.Text = "LINKS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // staffTools
            // 
            staffTools.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            staffTools.BackColor = Color.Transparent;
            staffTools.Location = new Point(0, 832);
            staffTools.Margin = new Padding(4, 3, 4, 3);
            staffTools.Name = "staffTools";
            staffTools.Size = new Size(0, 163);
            staffTools.TabIndex = 10;
            staffTools.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = Color.FromArgb(35, 37, 39);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(10, 521);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(0, 23);
            textBox1.TabIndex = 46;
            textBox1.Text = "STEAM_0:X:XXXXXXXXX";
            textBox1.Enter += TextBox1_Enter;
            textBox1.KeyDown += TextBox1_KeyDown;
            textBox1.Leave += TextBox1_Leave;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(-5, 471);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(0, 47);
            label2.TabIndex = 19;
            label2.Text = "SUP LOOKUP";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCWRPRulesCopy
            // 
            btnCWRPRulesCopy.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnCWRPRulesCopy.BackColor = Color.FromArgb(14, 50, 50);
            btnCWRPRulesCopy.FlatAppearance.BorderSize = 0;
            btnCWRPRulesCopy.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 50, 50);
            btnCWRPRulesCopy.FlatStyle = FlatStyle.Flat;
            btnCWRPRulesCopy.Font = new Font("Microsoft Sans Serif", 10F);
            btnCWRPRulesCopy.ForeColor = Color.White;
            btnCWRPRulesCopy.Location = new Point(165, 728);
            btnCWRPRulesCopy.Margin = new Padding(4, 3, 4, 3);
            btnCWRPRulesCopy.Name = "btnCWRPRulesCopy";
            btnCWRPRulesCopy.Size = new Size(67, 31);
            btnCWRPRulesCopy.TabIndex = 17;
            btnCWRPRulesCopy.Text = "Copy";
            toolTip1.SetToolTip(btnCWRPRulesCopy, "Copies link to your clipboard");
            btnCWRPRulesCopy.UseVisualStyleBackColor = false;
            btnCWRPRulesCopy.Click += Button16_Click;
            // 
            // btnMilRPRulesCopy
            // 
            btnMilRPRulesCopy.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnMilRPRulesCopy.BackColor = Color.FromArgb(14, 50, 50);
            btnMilRPRulesCopy.FlatAppearance.BorderSize = 0;
            btnMilRPRulesCopy.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 50, 50);
            btnMilRPRulesCopy.FlatStyle = FlatStyle.Flat;
            btnMilRPRulesCopy.Font = new Font("Microsoft Sans Serif", 10F);
            btnMilRPRulesCopy.ForeColor = Color.White;
            btnMilRPRulesCopy.Location = new Point(165, 691);
            btnMilRPRulesCopy.Margin = new Padding(4, 3, 4, 3);
            btnMilRPRulesCopy.Name = "btnMilRPRulesCopy";
            btnMilRPRulesCopy.Size = new Size(67, 31);
            btnMilRPRulesCopy.TabIndex = 16;
            btnMilRPRulesCopy.Text = "Copy";
            toolTip1.SetToolTip(btnMilRPRulesCopy, "Copies link to your clipboard");
            btnMilRPRulesCopy.UseVisualStyleBackColor = false;
            btnMilRPRulesCopy.Click += Button15_Click;
            // 
            // btnDarkRPRulesCopy
            // 
            btnDarkRPRulesCopy.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnDarkRPRulesCopy.BackColor = Color.FromArgb(14, 50, 50);
            btnDarkRPRulesCopy.FlatAppearance.BorderSize = 0;
            btnDarkRPRulesCopy.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 50, 50);
            btnDarkRPRulesCopy.FlatStyle = FlatStyle.Flat;
            btnDarkRPRulesCopy.Font = new Font("Microsoft Sans Serif", 10F);
            btnDarkRPRulesCopy.ForeColor = Color.White;
            btnDarkRPRulesCopy.Location = new Point(165, 653);
            btnDarkRPRulesCopy.Margin = new Padding(4, 3, 4, 3);
            btnDarkRPRulesCopy.Name = "btnDarkRPRulesCopy";
            btnDarkRPRulesCopy.Size = new Size(67, 31);
            btnDarkRPRulesCopy.TabIndex = 15;
            btnDarkRPRulesCopy.Text = "Copy";
            toolTip1.SetToolTip(btnDarkRPRulesCopy, "Copies link to your clipboard");
            btnDarkRPRulesCopy.UseVisualStyleBackColor = false;
            btnDarkRPRulesCopy.Click += Button14_Click;
            // 
            // btnCWRPRules
            // 
            btnCWRPRules.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnCWRPRules.BackColor = Color.FromArgb(14, 14, 14);
            btnCWRPRules.FlatAppearance.BorderSize = 0;
            btnCWRPRules.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            btnCWRPRules.FlatStyle = FlatStyle.Flat;
            btnCWRPRules.Font = new Font("Microsoft Sans Serif", 10F);
            btnCWRPRules.ForeColor = Color.White;
            btnCWRPRules.Location = new Point(20, 728);
            btnCWRPRules.Margin = new Padding(4, 3, 4, 3);
            btnCWRPRules.Name = "btnCWRPRules";
            btnCWRPRules.Size = new Size(154, 31);
            btnCWRPRules.TabIndex = 14;
            btnCWRPRules.Text = "CWRP Rules";
            toolTip1.SetToolTip(btnCWRPRules, "Opens link in your default browser");
            btnCWRPRules.UseVisualStyleBackColor = false;
            btnCWRPRules.Click += Button13_Click;
            // 
            // btnMilRPRules
            // 
            btnMilRPRules.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnMilRPRules.BackColor = Color.FromArgb(14, 14, 14);
            btnMilRPRules.FlatAppearance.BorderSize = 0;
            btnMilRPRules.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            btnMilRPRules.FlatStyle = FlatStyle.Flat;
            btnMilRPRules.Font = new Font("Microsoft Sans Serif", 10F);
            btnMilRPRules.ForeColor = Color.White;
            btnMilRPRules.Location = new Point(20, 691);
            btnMilRPRules.Margin = new Padding(4, 3, 4, 3);
            btnMilRPRules.Name = "btnMilRPRules";
            btnMilRPRules.Size = new Size(148, 31);
            btnMilRPRules.TabIndex = 13;
            btnMilRPRules.Text = "MilRP Rules";
            toolTip1.SetToolTip(btnMilRPRules, "Opens link in your default browser");
            btnMilRPRules.UseVisualStyleBackColor = false;
            btnMilRPRules.Click += Button12_Click;
            // 
            // btnDarkRPRules
            // 
            btnDarkRPRules.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnDarkRPRules.BackColor = Color.FromArgb(14, 14, 14);
            btnDarkRPRules.FlatAppearance.BorderSize = 0;
            btnDarkRPRules.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            btnDarkRPRules.FlatStyle = FlatStyle.Flat;
            btnDarkRPRules.Font = new Font("Microsoft Sans Serif", 10F);
            btnDarkRPRules.ForeColor = Color.White;
            btnDarkRPRules.Location = new Point(20, 654);
            btnDarkRPRules.Margin = new Padding(4, 3, 4, 3);
            btnDarkRPRules.Name = "btnDarkRPRules";
            btnDarkRPRules.Size = new Size(148, 31);
            btnDarkRPRules.TabIndex = 12;
            btnDarkRPRules.Text = "DarkRP Rules";
            toolTip1.SetToolTip(btnDarkRPRules, "Opens link in your default browser");
            btnDarkRPRules.UseVisualStyleBackColor = false;
            btnDarkRPRules.Click += Button11_Click;
            // 
            // button10
            // 
            button10.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button10.BackColor = Color.FromArgb(14, 14, 14);
            button10.FlatAppearance.BorderSize = 0;
            button10.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            button10.FlatStyle = FlatStyle.Flat;
            button10.Font = new Font("Microsoft Sans Serif", 10F);
            button10.ForeColor = Color.White;
            button10.Location = new Point(186, 513);
            button10.Margin = new Padding(4, 3, 4, 3);
            button10.Name = "button10";
            button10.Size = new Size(57, 31);
            button10.TabIndex = 11;
            button10.Text = "Staff";
            toolTip1.SetToolTip(button10, "Opens link in your default browser");
            button10.UseVisualStyleBackColor = false;
            button10.Click += Button10_Click;
            // 
            // button9
            // 
            button9.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button9.BackColor = Color.FromArgb(14, 14, 14);
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Microsoft Sans Serif", 10F);
            button9.ForeColor = Color.White;
            button9.Location = new Point(100, 513);
            button9.Margin = new Padding(4, 3, 4, 3);
            button9.Name = "button9";
            button9.Size = new Size(56, 31);
            button9.TabIndex = 10;
            button9.Text = "Bans";
            toolTip1.SetToolTip(button9, "Opens link in your default browser");
            button9.UseVisualStyleBackColor = false;
            button9.Click += Button9_Click;
            // 
            // Overlay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(255, 255, 249);
            ClientSize = new Size(255, 1033);
            Controls.Add(overlayPanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Overlay";
            Opacity = 0.92D;
            Text = "Overlay";
            TopMost = true;
            TransparencyKey = Color.FromArgb(255, 255, 249);
            FormClosing += Overlay_FormClosing;
            Load += Overlay_Load;
            VisibleChanged += Overlay_VisibleChanged;
            Click += Overlay_Click;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            overlayPanel.ResumeLayout(false);
            overlayPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picRank).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btnCWRPRulesCopy;
        private System.Windows.Forms.Button btnMilRPRulesCopy;
        private System.Windows.Forms.Button btnDarkRPRulesCopy;
        private System.Windows.Forms.Button btnCWRPRules;
        private System.Windows.Forms.Button btnMilRPRules;
        private System.Windows.Forms.Button btnDarkRPRules;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel staffTools;
        private System.Windows.Forms.CheckBox chkProfileOverlay;
        private System.Windows.Forms.Label lblStaffTools;
        private System.Windows.Forms.Label lblHoverForInfo;
        private System.Windows.Forms.Label lblUseF3;
        private PictureBox picRank;
        public Panel overlayPanel;
    }
}