namespace RandomSongTournamentAssistant
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtTitle = new System.Windows.Forms.Label();
            this.txtMapID = new System.Windows.Forms.TextBox();
            this.btnRandomKey = new System.Windows.Forms.Button();
            this.txtBeatsaverFolder = new System.Windows.Forms.TextBox();
            this.btnGetDifficulties = new System.Windows.Forms.Button();
            this.btnCopyLink = new System.Windows.Forms.Button();
            this.btnCopyMapInfo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDifficulties = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnInstallMap = new System.Windows.Forms.Button();
            this.btnAnalyzeMap = new System.Windows.Forms.Button();
            this.btnRandomDiff = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cmbDifficulty = new RandomSongTournamentAssistant.CustomComboBox();
            this.customComboBox1 = new RandomSongTournamentAssistant.CustomComboBox();
            this.cmbCharacteristics = new RandomSongTournamentAssistant.CustomComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.AutoSize = true;
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(71)))), ((int)(((byte)(73)))));
            this.txtTitle.Location = new System.Drawing.Point(12, 20);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(57, 26);
            this.txtTitle.TabIndex = 3;
            this.txtTitle.Text = "Title";
            this.txtTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InitializeMoveForm);
            this.txtTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMoveFormWindow);
            this.txtTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DisableMoveForm);
            // 
            // txtMapID
            // 
            this.txtMapID.BackColor = System.Drawing.Color.White;
            this.txtMapID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMapID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMapID.ForeColor = System.Drawing.Color.Black;
            this.txtMapID.Location = new System.Drawing.Point(27, 267);
            this.txtMapID.Name = "txtMapID";
            this.txtMapID.Size = new System.Drawing.Size(435, 25);
            this.txtMapID.TabIndex = 1;
            // 
            // btnRandomKey
            // 
            this.btnRandomKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.btnRandomKey.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRandomKey.FlatAppearance.BorderSize = 2;
            this.btnRandomKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRandomKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandomKey.ForeColor = System.Drawing.Color.Black;
            this.btnRandomKey.Location = new System.Drawing.Point(468, 259);
            this.btnRandomKey.Name = "btnRandomKey";
            this.btnRandomKey.Size = new System.Drawing.Size(157, 46);
            this.btnRandomKey.TabIndex = 11;
            this.btnRandomKey.Text = "Generate random key";
            this.btnRandomKey.UseVisualStyleBackColor = false;
            this.btnRandomKey.Click += new System.EventHandler(this.btnRandomKey_Click);
            // 
            // txtBeatsaverFolder
            // 
            this.txtBeatsaverFolder.BackColor = System.Drawing.Color.White;
            this.txtBeatsaverFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBeatsaverFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBeatsaverFolder.ForeColor = System.Drawing.Color.Silver;
            this.txtBeatsaverFolder.Location = new System.Drawing.Point(27, 547);
            this.txtBeatsaverFolder.Name = "txtBeatsaverFolder";
            this.txtBeatsaverFolder.Size = new System.Drawing.Size(412, 25);
            this.txtBeatsaverFolder.TabIndex = 13;
            this.txtBeatsaverFolder.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChooseCustomLevelsFolder);
            // 
            // btnGetDifficulties
            // 
            this.btnGetDifficulties.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.btnGetDifficulties.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGetDifficulties.FlatAppearance.BorderSize = 2;
            this.btnGetDifficulties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetDifficulties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetDifficulties.ForeColor = System.Drawing.Color.Black;
            this.btnGetDifficulties.Location = new System.Drawing.Point(468, 189);
            this.btnGetDifficulties.Name = "btnGetDifficulties";
            this.btnGetDifficulties.Size = new System.Drawing.Size(157, 46);
            this.btnGetDifficulties.TabIndex = 20;
            this.btnGetDifficulties.Text = "Get difficulties";
            this.btnGetDifficulties.UseVisualStyleBackColor = false;
            this.btnGetDifficulties.Click += new System.EventHandler(this.btnGetDifficulties_Click);
            // 
            // btnCopyLink
            // 
            this.btnCopyLink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.btnCopyLink.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCopyLink.FlatAppearance.BorderSize = 2;
            this.btnCopyLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyLink.ForeColor = System.Drawing.Color.Black;
            this.btnCopyLink.Location = new System.Drawing.Point(465, 97);
            this.btnCopyLink.Name = "btnCopyLink";
            this.btnCopyLink.Size = new System.Drawing.Size(157, 46);
            this.btnCopyLink.TabIndex = 21;
            this.btnCopyLink.Text = "Copy Beatsaver link";
            this.btnCopyLink.UseVisualStyleBackColor = false;
            this.btnCopyLink.Click += new System.EventHandler(this.btnCopyLink_Click);
            // 
            // btnCopyMapInfo
            // 
            this.btnCopyMapInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.btnCopyMapInfo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCopyMapInfo.FlatAppearance.BorderSize = 2;
            this.btnCopyMapInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyMapInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyMapInfo.ForeColor = System.Drawing.Color.Black;
            this.btnCopyMapInfo.Location = new System.Drawing.Point(240, 97);
            this.btnCopyMapInfo.Name = "btnCopyMapInfo";
            this.btnCopyMapInfo.Size = new System.Drawing.Size(157, 46);
            this.btnCopyMapInfo.TabIndex = 22;
            this.btnCopyMapInfo.Text = "Copy Map Info";
            this.btnCopyMapInfo.UseVisualStyleBackColor = false;
            this.btnCopyMapInfo.Click += new System.EventHandler(this.btnCopyMapInfo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(17, 537);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(422, 46);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChooseCustomLevelsFolder);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(17, 259);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(445, 46);
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Difficulty";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Characteristics";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Map Key";
            // 
            // lblDifficulties
            // 
            this.lblDifficulties.AutoSize = true;
            this.lblDifficulties.BackColor = System.Drawing.Color.Transparent;
            this.lblDifficulties.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifficulties.ForeColor = System.Drawing.Color.White;
            this.lblDifficulties.Location = new System.Drawing.Point(137, 204);
            this.lblDifficulties.Name = "lblDifficulties";
            this.lblDifficulties.Size = new System.Drawing.Size(238, 17);
            this.lblDifficulties.TabIndex = 15;
            this.lblDifficulties.Text = "ExpertPlus Expert Normal Hard Easy";
            this.lblDifficulties.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(14, 520);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "CustomLevels folder";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(14, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Difficulties";
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.AutoSize = true;
            this.lblClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.Gray;
            this.lblClose.Location = new System.Drawing.Point(595, 9);
            this.lblClose.Margin = new System.Windows.Forms.Padding(0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(33, 37);
            this.lblClose.TabIndex = 29;
            this.lblClose.Text = "x";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.lblClose_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            // 
            // lblVersion
            // 
            this.lblVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Gray;
            this.lblVersion.Location = new System.Drawing.Point(468, 65);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblVersion.Size = new System.Drawing.Size(160, 26);
            this.lblVersion.TabIndex = 34;
            this.lblVersion.Text = "Version";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVersion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InitializeMoveForm);
            this.lblVersion.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMoveFormWindow);
            this.lblVersion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DisableMoveForm);
            // 
            // btnInstallMap
            // 
            this.btnInstallMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.btnInstallMap.FlatAppearance.BorderSize = 2;
            this.btnInstallMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstallMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstallMap.ForeColor = System.Drawing.Color.Black;
            this.btnInstallMap.Location = new System.Drawing.Point(445, 538);
            this.btnInstallMap.Name = "btnInstallMap";
            this.btnInstallMap.Size = new System.Drawing.Size(180, 46);
            this.btnInstallMap.TabIndex = 12;
            this.btnInstallMap.Text = "Download and install map";
            this.btnInstallMap.UseVisualStyleBackColor = false;
            this.btnInstallMap.Click += new System.EventHandler(this.btnInstallMap_Click);
            // 
            // btnAnalyzeMap
            // 
            this.btnAnalyzeMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.btnAnalyzeMap.FlatAppearance.BorderSize = 2;
            this.btnAnalyzeMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalyzeMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalyzeMap.ForeColor = System.Drawing.Color.Black;
            this.btnAnalyzeMap.Location = new System.Drawing.Point(12, 463);
            this.btnAnalyzeMap.Name = "btnAnalyzeMap";
            this.btnAnalyzeMap.Size = new System.Drawing.Size(613, 46);
            this.btnAnalyzeMap.TabIndex = 4;
            this.btnAnalyzeMap.Text = "Analyze map";
            this.btnAnalyzeMap.UseVisualStyleBackColor = false;
            this.btnAnalyzeMap.Click += new System.EventHandler(this.btnAnalyzeMap_Click);
            // 
            // btnRandomDiff
            // 
            this.btnRandomDiff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.btnRandomDiff.FlatAppearance.BorderSize = 2;
            this.btnRandomDiff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRandomDiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandomDiff.ForeColor = System.Drawing.Color.Black;
            this.btnRandomDiff.Location = new System.Drawing.Point(468, 406);
            this.btnRandomDiff.Name = "btnRandomDiff";
            this.btnRandomDiff.Size = new System.Drawing.Size(157, 46);
            this.btnRandomDiff.TabIndex = 1;
            this.btnRandomDiff.Text = "Set random Difficulty";
            this.btnRandomDiff.UseVisualStyleBackColor = false;
            this.btnRandomDiff.Click += new System.EventHandler(this.btnRandomDiff_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox4.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(639, 91);
            this.pictureBox4.TabIndex = 33;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InitializeMoveForm);
            this.pictureBox4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMoveFormWindow);
            this.pictureBox4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DisableMoveForm);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnFilter.FlatAppearance.BorderSize = 2;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.Black;
            this.btnFilter.Location = new System.Drawing.Point(15, 97);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(157, 46);
            this.btnFilter.TabIndex = 35;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cmbDifficulty
            // 
            this.cmbDifficulty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.cmbDifficulty.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.cmbDifficulty.ItemHeight = 20;
            this.cmbDifficulty.Items.Add("ExpertPlus");
            this.cmbDifficulty.Items.Add("Expert");
            this.cmbDifficulty.Items.Add("Hard");
            this.cmbDifficulty.Items.Add("Normal");
            this.cmbDifficulty.Items.Add("Easy");
            this.cmbDifficulty.Location = new System.Drawing.Point(12, 406);
            this.cmbDifficulty.MarginBottom = 10;
            this.cmbDifficulty.Name = "cmbDifficulty";
            this.cmbDifficulty.Size = new System.Drawing.Size(453, 46);
            this.cmbDifficulty.TabIndex = 30;
            // 
            // customComboBox1
            // 
            this.customComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.customComboBox1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.customComboBox1.ItemHeight = 0;
            this.customComboBox1.Location = new System.Drawing.Point(97, 483);
            this.customComboBox1.MarginBottom = 0;
            this.customComboBox1.Name = "customComboBox1";
            this.customComboBox1.Size = new System.Drawing.Size(365, 46);
            this.customComboBox1.TabIndex = 30;
            // 
            // cmbCharacteristics
            // 
            this.cmbCharacteristics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.cmbCharacteristics.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.cmbCharacteristics.ItemHeight = 20;
            this.cmbCharacteristics.Items.Add("Standard");
            this.cmbCharacteristics.Items.Add("Single Saber");
            this.cmbCharacteristics.Items.Add("No Arrows");
            this.cmbCharacteristics.Location = new System.Drawing.Point(15, 334);
            this.cmbCharacteristics.MarginBottom = 10;
            this.cmbCharacteristics.Name = "cmbCharacteristics";
            this.cmbCharacteristics.Size = new System.Drawing.Size(607, 46);
            this.cmbCharacteristics.TabIndex = 36;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(637, 610);
            this.Controls.Add(this.cmbCharacteristics);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.cmbDifficulty);
            this.Controls.Add(this.btnRandomDiff);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblDifficulties);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBeatsaverFolder);
            this.Controls.Add(this.btnInstallMap);
            this.Controls.Add(this.btnRandomKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMapID);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnAnalyzeMap);
            this.Controls.Add(this.btnCopyLink);
            this.Controls.Add(this.btnGetDifficulties);
            this.Controls.Add(this.btnCopyMapInfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox4);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(637, 677);
            this.Name = "Form1";
            this.Text = "Random Song Tournament Assistant";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InitializeMoveForm);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMoveFormWindow);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DisableMoveForm);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.TextBox txtMapID;
        private System.Windows.Forms.Button btnRandomKey;
        private System.Windows.Forms.TextBox txtBeatsaverFolder;
        private System.Windows.Forms.Button btnGetDifficulties;
        private System.Windows.Forms.Button btnCopyLink;
        private System.Windows.Forms.Button btnCopyMapInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDifficulties;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblClose;
        private RandomSongTournamentAssistant.CustomComboBox customComboBox1;
        public RandomSongTournamentAssistant.CustomComboBox cmbDifficulty;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnInstallMap;
        private System.Windows.Forms.Button btnAnalyzeMap;
        private System.Windows.Forms.Button btnRandomDiff;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnFilter;
        public CustomComboBox cmbCharacteristics;
    }
}

