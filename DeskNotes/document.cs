using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DeskNotes
{
    public partial class document : Form
    {
        public int index = 0;
        private string doc = "";
        private string image = "";
        private bool moveIcon = false;
        private Main controller;

        public document(Main Controller, int Index, string DOC = "")
        {
            InitializeComponent();
            doc = "";
            if (DOC.Contains('?'))
            {
                doc = DOC.Split('?').GetValue(0).ToString();
                image = DOC.Split('?').GetValue(1).ToString();
                if (image != "")
                {
                    if (System.IO.File.Exists(image))
                    {
                        button.ImageLocation = image;
                    }
                }
                else
                {
                    button.Image = Properties.Resources.document;
                }
            }
            index = Index;
            controller = Controller;
        }

        private void button_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                if (MessageBox.Show("Do you want to remove the shortcut?", "Remove Shortcut", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Properties.Settings.Default.documents.RemoveAt(index);
                    Properties.Settings.Default.Save();
                    controller.LoadSideDocuments();
                    this.Close();
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (doc == "")
                {
                    OpenFileDialog op = new OpenFileDialog();
                    op.Title = "Select document";
                    op.Filter = "Document|*.rtf;*.txt|All|*.*";
                    if (op.ShowDialog() == DialogResult.OK)
                    {
                        string path = op.FileName;
                        op.Title = "Select image";
                        op.FileName = "";
                        op.Filter = "Image|*.png;*.jpg;*.jpeg;*.gif|All|*.*";
                        op.ShowDialog();
                        Properties.Settings.Default.documents.Add(path + "?" + op.FileName);
                        Properties.Settings.Default.last_opened_file = path;
                        controller.LoadSideDocuments();
                    }
                }
                else
                {
                    if (System.IO.File.Exists(doc))
                    {
                        Properties.Settings.Default.last_opened_file = doc;
                        controller.load();
                    }
                    else
                    {
                        MessageBox.Show("Document doesn't exist anymore");
                        Properties.Settings.Default.documents.Remove(doc + "?" + image);
                        Properties.Settings.Default.Save();
                        this.Close();
                        controller.LoadSideDocuments();
                    }
                }
                Properties.Settings.Default.Save();
            }
        }
        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                moveIcon = true;
        }

        private void button_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                moveIcon = false;
                try
                {
                    if (index != -1)
                    {
                        Properties.Settings.Default.documents[index] = doc + "?" + image + "?" + this.Location.Y;
                    }
                    else
                    {
                        Properties.Settings.Default.plusPossition = this.Location.Y;
                    }
                    Properties.Settings.Default.Save();
                }
                catch { }
            }
        }

        private void button_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveIcon)
                this.Location = new Point(this.Location.X, this.Location.Y + e.Y / 2);
        }
    }
}
