namespace RandomSongTournamentAssistant
{
    partial class CustomComboBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlHoverController = new System.Windows.Forms.Panel();
            this.leftBorder = new System.Windows.Forms.PictureBox();
            this.rightBorder = new System.Windows.Forms.PictureBox();
            this.topBorder = new System.Windows.Forms.PictureBox();
            this.bottomBorder = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.leftBorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topBorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomBorder)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(13, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title";
            // 
            // pnlHoverController
            // 
            this.pnlHoverController.BackColor = System.Drawing.Color.Transparent;
            this.pnlHoverController.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlHoverController.Location = new System.Drawing.Point(0, 0);
            this.pnlHoverController.Name = "pnlHoverController";
            this.pnlHoverController.Size = new System.Drawing.Size(333, 16);
            this.pnlHoverController.TabIndex = 2;
            this.pnlHoverController.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlHoverController_MouseClick);
            this.pnlHoverController.MouseEnter += new System.EventHandler(this.pnlHoverController_MouseEnter);
            this.pnlHoverController.MouseLeave += new System.EventHandler(this.pnlHoverController_MouseLeave);
            // 
            // leftBorder
            // 
            this.leftBorder.BackColor = System.Drawing.Color.Black;
            this.leftBorder.Location = new System.Drawing.Point(174, 14);
            this.leftBorder.Name = "leftBorder";
            this.leftBorder.Size = new System.Drawing.Size(43, 21);
            this.leftBorder.TabIndex = 3;
            this.leftBorder.TabStop = false;
            // 
            // rightBorder
            // 
            this.rightBorder.BackColor = System.Drawing.Color.Black;
            this.rightBorder.Location = new System.Drawing.Point(223, 14);
            this.rightBorder.Name = "rightBorder";
            this.rightBorder.Size = new System.Drawing.Size(43, 21);
            this.rightBorder.TabIndex = 4;
            this.rightBorder.TabStop = false;
            // 
            // topBorder
            // 
            this.topBorder.BackColor = System.Drawing.Color.Black;
            this.topBorder.Location = new System.Drawing.Point(272, 14);
            this.topBorder.Name = "topBorder";
            this.topBorder.Size = new System.Drawing.Size(43, 21);
            this.topBorder.TabIndex = 5;
            this.topBorder.TabStop = false;
            // 
            // bottomBorder
            // 
            this.bottomBorder.BackColor = System.Drawing.Color.Black;
            this.bottomBorder.Location = new System.Drawing.Point(321, 14);
            this.bottomBorder.Name = "bottomBorder";
            this.bottomBorder.Size = new System.Drawing.Size(43, 21);
            this.bottomBorder.TabIndex = 6;
            this.bottomBorder.TabStop = false;
            // 
            // CustomComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.Controls.Add(this.bottomBorder);
            this.Controls.Add(this.rightBorder);
            this.Controls.Add(this.topBorder);
            this.Controls.Add(this.leftBorder);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlHoverController);
            this.Name = "CustomComboBox";
            this.Size = new System.Drawing.Size(365, 35);
            this.Load += new System.EventHandler(this.CustomComboBox_Load);
            this.Resize += new System.EventHandler(this.CustomComboBox_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.leftBorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topBorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomBorder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlHoverController;
        private System.Windows.Forms.PictureBox leftBorder;
        private System.Windows.Forms.PictureBox rightBorder;
        private System.Windows.Forms.PictureBox topBorder;
        private System.Windows.Forms.PictureBox bottomBorder;
    }
}
