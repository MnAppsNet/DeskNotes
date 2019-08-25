using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DeskNotes
{
    public partial class Arrow : Form
    {
        private int Spacing = 5;
        private Form1 main_form;
        public Arrow(Form1 Main_Form)
        {
            InitializeComponent();
            main_form = Main_Form;
        }

        private void Arrow_Load(object sender, EventArgs e)
        {
            this.Size = new Size(_arrow.Width + 2 * Spacing, _arrow.Height + 2 * Spacing);
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - this.Width, Screen.PrimaryScreen.Bounds.Bottom - this.Height - 50);
            main_form.Hide();
        }

        private void MouseClickEvent(object sender, MouseEventArgs e)
        {
            PictureBox S = (PictureBox)sender;

            if (S.Tag.ToString() == ">")
            {
                if (e.Button == MouseButtons.Middle)
                {
                    Application.Exit();
                    return;
                }
                main_form.Hide_Panel();
                this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - this.Width, this.Location.Y);
            }
            else if (S.Tag.ToString() == "<")
            {
                
                if (e.Button == MouseButtons.Right)
                {
                    Application.Restart();
                    return;
                }
                else if (e.Button == MouseButtons.Middle)
                {
                    main_form.checkBox1.Checked = !main_form.checkBox1.Checked;
                    return;
                }
                main_form.Show_Panel();
            }
            ChangeArrow();
            main_form.save(false);
        }
        private void ChangeArrow()
        {
            if (_arrow.Tag.ToString() == ">")
            {
                _arrow.Image = Properties.Resources.left;
                _arrow.Tag = "<";
            }
            else
            {
                _arrow.Image = Properties.Resources.right;
                _arrow.Tag = ">";
            }
        }

        private void Arrow_Paint(object sender, PaintEventArgs e)
        {
            if (!this.TopMost)
            {
                this.SendToBack();
                main_form.SendToBack();
            }
        }
    }
}
