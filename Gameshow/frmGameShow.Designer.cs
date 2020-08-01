namespace Gameshow
{
    partial class MC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MC));
            this.btnStart = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtCountDown = new System.Windows.Forms.TextBox();
            this.grvGameShow = new System.Windows.Forms.DataGridView();
            this.lbDay = new System.Windows.Forms.Label();
            this.lbHour = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grvGameShow)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnStart.Enabled = false;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnStart.Location = new System.Drawing.Point(449, 605);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(318, 60);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 41.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblName.Location = new System.Drawing.Point(438, 524);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(211, 63);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "#Name";
            // 
            // txtCountDown
            // 
            this.txtCountDown.BackColor = System.Drawing.SystemColors.Info;
            this.txtCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtCountDown.ForeColor = System.Drawing.Color.Red;
            this.txtCountDown.Location = new System.Drawing.Point(275, 647);
            this.txtCountDown.Name = "txtCountDown";
            this.txtCountDown.Size = new System.Drawing.Size(150, 38);
            this.txtCountDown.TabIndex = 6;
            this.txtCountDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grvGameShow
            // 
            this.grvGameShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grvGameShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvGameShow.Location = new System.Drawing.Point(16, 313);
            this.grvGameShow.Name = "grvGameShow";
            this.grvGameShow.Size = new System.Drawing.Size(391, 111);
            this.grvGameShow.TabIndex = 5;
            // 
            // lbDay
            // 
            this.lbDay.AutoSize = true;
            this.lbDay.BackColor = System.Drawing.Color.Firebrick;
            this.lbDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbDay.Location = new System.Drawing.Point(213, 250);
            this.lbDay.Name = "lbDay";
            this.lbDay.Size = new System.Drawing.Size(79, 24);
            this.lbDay.TabIndex = 13;
            this.lbDay.Text = "#Time1";
            // 
            // lbHour
            // 
            this.lbHour.AutoSize = true;
            this.lbHour.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbHour.Location = new System.Drawing.Point(139, 643);
            this.lbHour.Name = "lbHour";
            this.lbHour.Size = new System.Drawing.Size(148, 42);
            this.lbHour.TabIndex = 14;
            this.lbHour.Text = "#Time2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(573, 453);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(412, 42);
            this.label3.TabIndex = 15;
            this.label3.Text = "Game show truyền hình";
            // 
            // MC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1272, 693);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbHour);
            this.Controls.Add(this.lbDay);
            this.Controls.Add(this.txtCountDown);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.grvGameShow);
            this.Name = "MC";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvGameShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtCountDown;
        private System.Windows.Forms.DataGridView grvGameShow;
        private System.Windows.Forms.Label lbDay;
        private System.Windows.Forms.Label lbHour;
        private System.Windows.Forms.Label label3;
    }
}

