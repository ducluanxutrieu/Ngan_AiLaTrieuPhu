namespace MC
{
    partial class Host
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
            this.lvOutPut = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvOutPut
            // 
            this.lvOutPut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOutPut.HideSelection = false;
            this.lvOutPut.Location = new System.Drawing.Point(0, 0);
            this.lvOutPut.Name = "lvOutPut";
            this.lvOutPut.Size = new System.Drawing.Size(800, 450);
            this.lvOutPut.TabIndex = 1;
            this.lvOutPut.UseCompatibleStateImageBehavior = false;
            this.lvOutPut.View = System.Windows.Forms.View.List;
            // 
            // Host
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvOutPut);
            this.Name = "Host";
            this.Text = "Host";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvOutPut;
    }
}