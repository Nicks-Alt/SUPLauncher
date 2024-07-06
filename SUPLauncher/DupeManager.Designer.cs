namespace SUPLauncher
{
    partial class DupeManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DupeManager));
            FolderMenu = new ContextMenuStrip(components);
            newFolderToolStripMenuItem = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            deleteFolderToolStripMenuItem = new ToolStripMenuItem();
            renameToolStripMenuItem = new ToolStripMenuItem();
            Import = new OpenFileDialog();
            TopBar = new Panel();
            lblTitle = new Label();
            pictureBox2 = new PictureBox();
            button3 = new Button();
            button2 = new Button();
            Drop = new Panel();
            label1 = new Label();
            imgrefresh = new PictureBox();
            Dupes = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            iconList = new ImageList(components);
            path = new TextBox();
            panel1 = new Panel();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            FolderMenu.SuspendLayout();
            TopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            Drop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgrefresh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // FolderMenu
            // 
            FolderMenu.Items.AddRange(new ToolStripItem[] { newFolderToolStripMenuItem, importToolStripMenuItem, toolStripSeparator1, deleteFolderToolStripMenuItem, renameToolStripMenuItem });
            FolderMenu.Name = "FolderMenu";
            FolderMenu.Size = new Size(142, 98);
            FolderMenu.Opening += FolderMenu_Opening;
            // 
            // newFolderToolStripMenuItem
            // 
            newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            newFolderToolStripMenuItem.Size = new Size(141, 22);
            newFolderToolStripMenuItem.Text = "New Folder";
            newFolderToolStripMenuItem.Click += NewFolderToolStripMenuItem_Click;
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(141, 22);
            importToolStripMenuItem.Text = "Import Dupe";
            importToolStripMenuItem.Click += importToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(138, 6);
            // 
            // deleteFolderToolStripMenuItem
            // 
            deleteFolderToolStripMenuItem.Name = "deleteFolderToolStripMenuItem";
            deleteFolderToolStripMenuItem.Size = new Size(141, 22);
            deleteFolderToolStripMenuItem.Text = "Delete";
            deleteFolderToolStripMenuItem.Click += deleteFolderToolStripMenuItem_Click;
            // 
            // renameToolStripMenuItem
            // 
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.Size = new Size(141, 22);
            renameToolStripMenuItem.Text = "Rename";
            renameToolStripMenuItem.Click += renameToolStripMenuItem_Click;
            // 
            // Import
            // 
            Import.Filter = "Text Files|*.txt";
            Import.Multiselect = true;
            Import.Title = "Select a dupe to import...";
            // 
            // TopBar
            // 
            TopBar.BackColor = Color.FromArgb(17, 17, 17);
            TopBar.Controls.Add(lblTitle);
            TopBar.Controls.Add(pictureBox2);
            TopBar.Controls.Add(button3);
            TopBar.Controls.Add(button2);
            TopBar.Cursor = Cursors.SizeAll;
            TopBar.Dock = DockStyle.Top;
            TopBar.Location = new Point(0, 0);
            TopBar.Margin = new Padding(4, 3, 4, 3);
            TopBar.Name = "TopBar";
            TopBar.Size = new Size(650, 32);
            TopBar.TabIndex = 32;
            TopBar.MouseDown += TopBar_MouseDown;
            TopBar.MouseMove += TopBar_MouseMove;
            TopBar.MouseUp += TopBar_MouseUp;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(60, 4);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(113, 21);
            lblTitle.TabIndex = 57;
            lblTitle.Text = "Dupe Manager";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.suplogo;
            pictureBox2.Location = new Point(6, 3);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(47, 25);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 56;
            pictureBox2.TabStop = false;
            // 
            // button3
            // 
            button3.Cursor = Cursors.Hand;
            button3.Dock = DockStyle.Right;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(17, 17, 17);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe MDL2 Assets", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(598, 0);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(52, 32);
            button3.TabIndex = 55;
            button3.Text = "";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.Gray;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(884, 0);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(43, 25);
            button2.TabIndex = 52;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = false;
            button2.Click += BtnExit_Click;
            // 
            // Drop
            // 
            Drop.BackColor = Color.FromArgb(200, 16, 22, 29);
            Drop.Controls.Add(label1);
            Drop.Dock = DockStyle.Bottom;
            Drop.Location = new Point(0, 657);
            Drop.Margin = new Padding(4, 3, 4, 3);
            Drop.Name = "Drop";
            Drop.Size = new Size(650, 62);
            Drop.TabIndex = 33;
            Drop.Visible = false;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Microsoft YaHei UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(650, 62);
            label1.TabIndex = 0;
            label1.Text = "DROP TO IMPORT";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // imgrefresh
            // 
            imgrefresh.BackColor = Color.Transparent;
            imgrefresh.Cursor = Cursors.Hand;
            imgrefresh.Image = (Image)resources.GetObject("imgrefresh.Image");
            imgrefresh.Location = new Point(854, 51);
            imgrefresh.Margin = new Padding(4, 3, 4, 3);
            imgrefresh.Name = "imgrefresh";
            imgrefresh.Size = new Size(20, 23);
            imgrefresh.SizeMode = PictureBoxSizeMode.Zoom;
            imgrefresh.TabIndex = 49;
            imgrefresh.TabStop = false;
            imgrefresh.Click += Imgrefresh_Click;
            // 
            // Dupes
            // 
            Dupes.Activation = ItemActivation.OneClick;
            Dupes.BackColor = Color.FromArgb(25, 25, 25);
            Dupes.BorderStyle = BorderStyle.None;
            Dupes.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            Dupes.ContextMenuStrip = FolderMenu;
            Dupes.ForeColor = Color.White;
            Dupes.LargeImageList = iconList;
            Dupes.Location = new Point(14, 76);
            Dupes.Margin = new Padding(4, 3, 4, 3);
            Dupes.Name = "Dupes";
            Dupes.Size = new Size(622, 577);
            Dupes.TabIndex = 50;
            Dupes.UseCompatibleStateImageBehavior = false;
            Dupes.SelectedIndexChanged += Dupes_SelectedIndexChanged;
            Dupes.MouseDoubleClick += Dupes_MouseDoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Dupe Name";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "File Size";
            // 
            // iconList
            // 
            iconList.ColorDepth = ColorDepth.Depth32Bit;
            iconList.ImageStream = (ImageListStreamer)resources.GetObject("iconList.ImageStream");
            iconList.TransparentColor = Color.White;
            iconList.Images.SetKeyName(0, "folder");
            iconList.Images.SetKeyName(1, "txt.png");
            // 
            // path
            // 
            path.BackColor = Color.FromArgb(17, 17, 17);
            path.BorderStyle = BorderStyle.None;
            path.Font = new Font("Microsoft YaHei UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            path.ForeColor = Color.White;
            path.Location = new Point(88, 50);
            path.Margin = new Padding(4, 3, 4, 3);
            path.Multiline = true;
            path.Name = "path";
            path.ReadOnly = true;
            path.Size = new Size(548, 27);
            path.TabIndex = 51;
            path.Text = "\\";
            path.WordWrap = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(17, 17, 17);
            panel1.Location = new Point(74, 50);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(90, 27);
            panel1.TabIndex = 52;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 14, 14, 14);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(15, 47);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(31, 27);
            button1.TabIndex = 53;
            button1.Text = "<";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(47, 53);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(19, 18);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 54;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;
            pictureBox1.MouseLeave += pictureBox1_MouseLeave;
            // 
            // DupeManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(650, 719);
            ControlBox = false;
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(path);
            Controls.Add(Dupes);
            Controls.Add(imgrefresh);
            Controls.Add(Drop);
            Controls.Add(panel1);
            Controls.Add(TopBar);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "DupeManager";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += DupeManager_FormClosing;
            Load += DupeManager_Load;
            DragDrop += DupeManager_DragDrop;
            DragLeave += DupeManager_DragLeave;
            FolderMenu.ResumeLayout(false);
            TopBar.ResumeLayout(false);
            TopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            Drop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imgrefresh).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip FolderMenu;
        private System.Windows.Forms.ToolStripMenuItem newFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFolderToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog Import;
        private System.Windows.Forms.Panel TopBar;
        private System.Windows.Forms.Panel Drop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox imgrefresh;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView Dupes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.ImageList iconList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button3;
        private Label lblTitle;
    }
}