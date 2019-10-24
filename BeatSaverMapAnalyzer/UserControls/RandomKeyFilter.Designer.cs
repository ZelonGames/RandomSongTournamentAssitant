namespace RandomSongTournamentAssistant
{
    partial class RandomKeyFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RandomKeyFilter));
            this.btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRatingFilter = new RandomSongTournamentAssistant.CustomComboBox();
            this.cmbNPSFilter = new RandomSongTournamentAssistant.CustomComboBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnOk.FlatAppearance.BorderSize = 2;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.Location = new System.Drawing.Point(15, 330);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(506, 46);
            this.btnOk.TabIndex = 36;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(503, 96);
            this.label2.TabIndex = 39;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Notes per second";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Beatmap rating";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbRatingFilter
            // 
            this.cmbRatingFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.cmbRatingFilter.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.cmbRatingFilter.ItemHeight = 20;
            this.cmbRatingFilter.Items.Add(">= 90%");
            this.cmbRatingFilter.Items.Add(">= 80%");
            this.cmbRatingFilter.Items.Add(">= 70%");
            this.cmbRatingFilter.Items.Add(">= 60%");
            this.cmbRatingFilter.Items.Add(">= 50%");
            this.cmbRatingFilter.Items.Add(">= 40%");
            this.cmbRatingFilter.Items.Add(">= 30%");
            this.cmbRatingFilter.Items.Add("None");
            this.cmbRatingFilter.Location = new System.Drawing.Point(18, 110);
            this.cmbRatingFilter.MarginBottom = 5;
            this.cmbRatingFilter.Name = "cmbRatingFilter";
            this.cmbRatingFilter.Size = new System.Drawing.Size(506, 46);
            this.cmbRatingFilter.TabIndex = 41;
            // 
            // cmbNPSFilter
            // 
            this.cmbNPSFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.cmbNPSFilter.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(171)))), ((int)(((byte)(206)))));
            this.cmbNPSFilter.ItemHeight = 20;
            this.cmbNPSFilter.Items.Add(">= 10 NPS");
            this.cmbNPSFilter.Items.Add(">= 9 NPS");
            this.cmbNPSFilter.Items.Add(">= 8 NPS");
            this.cmbNPSFilter.Items.Add(">= 7 NPS");
            this.cmbNPSFilter.Items.Add(">= 6 NPS");
            this.cmbNPSFilter.Items.Add(">= 5 NPS");
            this.cmbNPSFilter.Items.Add("None");
            this.cmbNPSFilter.Location = new System.Drawing.Point(15, 28);
            this.cmbNPSFilter.MarginBottom = 5;
            this.cmbNPSFilter.Name = "cmbNPSFilter";
            this.cmbNPSFilter.Size = new System.Drawing.Size(506, 46);
            this.cmbNPSFilter.TabIndex = 37;
            // 
            // RandomKeyFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.cmbNPSFilter);
            this.Controls.Add(this.cmbRatingFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOk);
            this.Name = "RandomKeyFilter";
            this.Size = new System.Drawing.Size(536, 388);
            this.Load += new System.EventHandler(this.RandomKeyFilter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private CustomComboBox cmbNPSFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CustomComboBox cmbRatingFilter;
        private System.Windows.Forms.Label label1;
    }
}
