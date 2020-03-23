namespace DeskNotes
{
    partial class document
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
            this.button = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.button)).BeginInit();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button.Image = global::DeskNotes.Properties.Resources.plus;
            this.button.Location = new System.Drawing.Point(0, 0);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(67, 64);
            this.button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.button.TabIndex = 0;
            this.button.TabStop = false;
            this.button.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_MouseClick);
            this.button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
            this.button.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            this.button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
            // 
            // document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(67, 64);
            this.ControlBox = false;
            this.Controls.Add(this.button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "document";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "document";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            ((System.ComponentModel.ISupportInitialize)(this.button)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox button;
    }
}