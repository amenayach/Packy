namespace Packy.UserControls
{
    partial class ProjectUserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grd = new System.Windows.Forms.DataGridView();
            this.FSrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FDest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDestDrop = new System.Windows.Forms.Label();
            this.lblSrcDrop = new System.Windows.Forms.Label();
            this.btnPublish = new System.Windows.Forms.Button();
            this.tbProjectName = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            this.SuspendLayout();
            // 
            // grd
            // 
            this.grd.AllowDrop = true;
            this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd.BackgroundColor = System.Drawing.Color.Black;
            this.grd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FSrc,
            this.FDest});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grd.DefaultCellStyle = dataGridViewCellStyle6;
            this.grd.Location = new System.Drawing.Point(32, 47);
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(686, 282);
            this.grd.TabIndex = 11;
            this.grd.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.grd.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.grd.Resize += new System.EventHandler(this.grd_Resize);
            // 
            // FSrc
            // 
            this.FSrc.HeaderText = "Src";
            this.FSrc.Name = "FSrc";
            this.FSrc.Width = 200;
            // 
            // FDest
            // 
            this.FDest.HeaderText = "Dest";
            this.FDest.Name = "FDest";
            this.FDest.Width = 200;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(32, 344);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 15;
            // 
            // lblDestDrop
            // 
            this.lblDestDrop.AllowDrop = true;
            this.lblDestDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDestDrop.BackColor = System.Drawing.Color.White;
            this.lblDestDrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDestDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestDrop.ForeColor = System.Drawing.Color.DimGray;
            this.lblDestDrop.Location = new System.Drawing.Point(438, 129);
            this.lblDestDrop.Name = "lblDestDrop";
            this.lblDestDrop.Size = new System.Drawing.Size(280, 200);
            this.lblDestDrop.TabIndex = 14;
            this.lblDestDrop.Text = "Drop Destination";
            this.lblDestDrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDestDrop.Visible = false;
            this.lblDestDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.lblDestDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            // 
            // lblSrcDrop
            // 
            this.lblSrcDrop.AllowDrop = true;
            this.lblSrcDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSrcDrop.BackColor = System.Drawing.Color.White;
            this.lblSrcDrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSrcDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrcDrop.ForeColor = System.Drawing.Color.DimGray;
            this.lblSrcDrop.Location = new System.Drawing.Point(32, 129);
            this.lblSrcDrop.Name = "lblSrcDrop";
            this.lblSrcDrop.Size = new System.Drawing.Size(280, 200);
            this.lblSrcDrop.TabIndex = 13;
            this.lblSrcDrop.Text = "Drop Sources";
            this.lblSrcDrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSrcDrop.Visible = false;
            this.lblSrcDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.lblSrcDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            // 
            // btnPublish
            // 
            this.btnPublish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPublish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPublish.ForeColor = System.Drawing.Color.White;
            this.btnPublish.Location = new System.Drawing.Point(643, 335);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(75, 23);
            this.btnPublish.TabIndex = 12;
            this.btnPublish.Text = "&Publish";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // tbProjectName
            // 
            this.tbProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProjectName.Location = new System.Drawing.Point(33, 17);
            this.tbProjectName.Name = "tbProjectName";
            this.tbProjectName.ReadOnly = true;
            this.tbProjectName.Size = new System.Drawing.Size(197, 26);
            this.tbProjectName.TabIndex = 16;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(237, 18);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ProjectUserControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.tbProjectName);
            this.Controls.Add(this.lblDestDrop);
            this.Controls.Add(this.lblSrcDrop);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnPublish);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ProjectUserControl";
            this.Size = new System.Drawing.Size(750, 368);
            this.Load += new System.EventHandler(this.Control_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grd;
        private System.Windows.Forms.DataGridViewTextBoxColumn FSrc;
        private System.Windows.Forms.DataGridViewTextBoxColumn FDest;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDestDrop;
        private System.Windows.Forms.Label lblSrcDrop;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.TextBox tbProjectName;
        private System.Windows.Forms.Button btnDelete;
    }
}
