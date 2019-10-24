namespace RandomSongTournamentAssistant
{
    partial class CustomMessageBox
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
            this.lblText = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.BackColor = System.Drawing.Color.Black;
            this.lblText.ForeColor = System.Drawing.Color.White;
            this.lblText.Location = new System.Drawing.Point(0, 63);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(330, 85);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "aerg aerg ";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnOK.FlatAppearance.BorderSize = 2;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(3, 327);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(324, 41);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblText);
            this.Name = "CustomMessageBox";
            this.Size = new System.Drawing.Size(330, 371);
            this.Load += new System.EventHandler(this.CustomMessageBox_Load);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lblText;
        protected System.Windows.Forms.Button btnOK;
    }
}
