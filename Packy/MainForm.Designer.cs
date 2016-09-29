namespace Packy
{
    partial class MainForm
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
            this.destinationUserControl1 = new Packy.UserControls.DestinationUserControl();
            this.SuspendLayout();
            // 
            // destinationUserControl1
            // 
            this.destinationUserControl1.AutoScroll = true;
            this.destinationUserControl1.BackColor = System.Drawing.Color.Black;
            this.destinationUserControl1.Location = new System.Drawing.Point(21, 24);
            this.destinationUserControl1.Name = "destinationUserControl1";
            this.destinationUserControl1.Size = new System.Drawing.Size(259, 341);
            this.destinationUserControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(741, 465);
            this.Controls.Add(this.destinationUserControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Packy";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.DestinationUserControl destinationUserControl1;









    }
}

