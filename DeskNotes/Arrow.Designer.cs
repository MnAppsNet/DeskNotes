namespace DeskNotes
{
    partial class Arrow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Arrow));
            this._arrow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._arrow)).BeginInit();
            this.SuspendLayout();
            // 
            // _arrow
            // 
            this._arrow.BackColor = System.Drawing.Color.Transparent;
            this._arrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this._arrow.Image = global::DeskNotes.Properties.Resources.left;
            this._arrow.Location = new System.Drawing.Point(10, 9);
            this._arrow.Name = "_arrow";
            this._arrow.Size = new System.Drawing.Size(92, 92);
            this._arrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._arrow.TabIndex = 1;
            this._arrow.TabStop = false;
            this._arrow.Tag = "<";
            this._arrow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClickEvent);
            // 
            // Arrow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(110, 110);
            this.Controls.Add(this._arrow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Arrow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Arrow";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Load += new System.EventHandler(this.Arrow_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Arrow_Paint);
            ((System.ComponentModel.ISupportInitialize)(this._arrow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox _arrow;
    }
}