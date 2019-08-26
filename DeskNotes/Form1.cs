using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Threading;

namespace DeskNotes
{
    public partial class Form1 : Form
    {
        Arrow arrow;
        private Size defaultArrowSize;
        private Size smallArrowSize = new Size(20, 20);
        private Point defaultArrowLocation;
        private string CurrentFile = "";

        public Form1()
        {
            InitializeComponent();
            this.Hide();
            this.SendToBack();
        }
        public void Show_Panel()
        {
            this.Width = (Properties.Settings.Default.width == 0) ? (200) : (Properties.Settings.Default.width);
            this.Show();
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - this.Width, Screen.PrimaryScreen.Bounds.Top);
            arrow.Location = new Point(this.Left - arrow.Width, arrow.Location.Y);
            this.TopMost = true;
            arrow.TopMost = true;
        }
        public void Hide_Panel()
        {
            this.Width = 0;
            this.Hide();
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - this.Width, Screen.PrimaryScreen.Bounds.Top);
            arrow.Location = new Point(Screen.PrimaryScreen.Bounds.Right - arrow.Width, arrow.Location.Y);
            this.TopMost = false;
            if (arrow._arrow.Size == defaultArrowSize)
                arrow.TopMost = false;
            this.SendToBack();
            arrow.SendToBack();
        }
        public void save(bool AskForFile)
        {
            if (CurrentFile == "" && AskForFile)
            {
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.Title = "Where do you want to save the file?";
                SFD.Filter = "RTF File|*.rtf";
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SaveFile(SFD.FileName);
                    CurrentFile = SFD.FileName;
                    Properties.Settings.Default.last_opened_file = CurrentFile;
                    Properties.Settings.Default.Save();
                }
            }else if (CurrentFile != "")
            {
                richTextBox1.SaveFile(CurrentFile);
            }
        }
        private void load()
        {
            if (System.IO.File.Exists(Properties.Settings.Default.last_opened_file))
            {
                richTextBox1.LoadFile(Properties.Settings.Default.last_opened_file);
                CurrentFile = Properties.Settings.Default.last_opened_file;
            }
            richTextBox1.Update();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(0, Screen.PrimaryScreen.Bounds.Height);
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - this.Width, Screen.PrimaryScreen.Bounds.Top);
            arrow = new Arrow(this);
            arrow.Show();
            Hide_Panel();
            ChangeColors(null, null);
            defaultArrowSize = arrow._arrow.Size;
            defaultArrowLocation = arrow._arrow.Location;
            CheckForFunctions();
            load();
            autoExecution.Checked = Properties.Settings.Default.auto_execution;
            CommandSymbolInput.Text = Properties.Settings.Default.command_symbol;
            Functions.CommandSymbol = CommandSymbolInput.Text;
            if (Properties.Settings.Default.auto_execution)
            {
                try
                {
                    AutoFunctionExecution = new Thread(() => CheckForFunctions());
                    AutoFunctionExecution.Name = "FunctionCheck";
                    AutoFunctionExecution.Start();
                }
                catch { }
            }

            new Thread(() =>
            {
                Thread.Sleep(100);
                this.BeginInvoke(
                   new Action(() =>
                   {
                       this.Hide();
                       this.SendToBack();
                       arrow.SendToBack();
                   }
                 ));

            }).Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!this.TopMost)
            {
                this.SendToBack();
                arrow.SendToBack();
            }
        }
        bool resize = false;
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            resize = true;
        }
        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            resize = false;
            Properties.Settings.Default.width = this.Width;
            Properties.Settings.Default.Save();
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (resize)
            {
                this.Size = new Size(this.Width - e.X, this.Height);
                this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - this.Width, Screen.PrimaryScreen.Bounds.Top);
                arrow.Location = new Point(this.Left - arrow.Width, arrow.Location.Y);
            }
        }

        private void ChangeColors(object sender, EventArgs e)
        {
            if (sender != null)
            {
                ColorDialog cd = new ColorDialog();

                MessageBox.Show("Choose a background color", "Choose Color", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd.Color = bg_color.BackColor;
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.bg_color = cd.Color;
                }
                MessageBox.Show("Choose a text color", "Choose Color", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd.Color = txt_color.ForeColor;
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.txt_color = cd.Color;
                }
                Properties.Settings.Default.Save();
            }
            bg_color.BackColor = Properties.Settings.Default.bg_color;
            txt_color.ForeColor = Properties.Settings.Default.txt_color;
            richTextBox1.BackColor = Properties.Settings.Default.bg_color;
            checkBox1.BackColor = Properties.Settings.Default.bg_color;
            checkBox1.ForeColor = Properties.Settings.Default.txt_color;
            richTextBox1.ForeColor = Properties.Settings.Default.txt_color;
        }

        private void MenuClick(object sender, EventArgs e)
        {
            string option = ((ToolStripMenuItem)sender).Tag.ToString();
            if (option != "")
                Format(option);
        }

        private void FormatSelection(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                e.SuppressKeyPress = true;
                Format(e.KeyCode.ToString());
            }
        }
        private void Format(string option)
        {
            switch (option.ToUpper())
            {
                case "B":
                    try
                    {
                        SelectCurrentLine();
                        FontStyle style = new FontStyle();
                        if (richTextBox1.SelectionFont.Bold)
                            style = style | FontStyle.Regular;
                        else
                            style = style | FontStyle.Bold;
                        if (richTextBox1.SelectionFont.Italic)
                            style = style | FontStyle.Italic;
                        if (richTextBox1.SelectionFont.Underline)
                            style = style | FontStyle.Underline;
                        richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
                        richTextBox1.DeselectAll();
                    }
                    catch { };
                    break;

                case "I":
                    try
                    {
                        SelectCurrentLine();
                        FontStyle style = new FontStyle();
                        if (richTextBox1.SelectionFont.Italic)
                            style = style | FontStyle.Regular;
                        else
                            style = style | FontStyle.Italic;
                        if (richTextBox1.SelectionFont.Bold)
                            style = style | FontStyle.Bold;
                        if (richTextBox1.SelectionFont.Underline)
                            style = style | FontStyle.Underline;

                        richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
                        richTextBox1.DeselectAll();
                    }
                    catch { };
                    break;
                case "U":
                    try
                    {
                        SelectCurrentLine();
                        FontStyle style = new FontStyle();
                        if (richTextBox1.SelectionFont.Underline)
                            style = style | FontStyle.Regular;
                        else
                            style = style | FontStyle.Underline;
                        if (richTextBox1.SelectionFont.Italic)
                            style = style | FontStyle.Italic;
                        if (richTextBox1.SelectionFont.Bold)
                            style = style | FontStyle.Bold;

                        richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
                        richTextBox1.DeselectAll();
                    }
                    catch { };
                    break;
                case "T":
                    try
                    {
                        SelectCurrentLine();
                        FontDialog fd = new FontDialog();
                        fd.Font = richTextBox1.SelectionFont;
                        if (fd.ShowDialog() == DialogResult.OK)
                        {
                            richTextBox1.SelectionFont = fd.Font;
                        }
                        richTextBox1.DeselectAll();
                    }
                    catch { };
                    break;
                case "UP":
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                    break;
                case "RIGHT":
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
                    break;
                case "LEFT":
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                    break;
                case "A":
                    richTextBox1.SelectAll();
                    break;
                case "C":
                    richTextBox1.Copy();
                    break;
                case "V":
                    richTextBox1.Paste();
                    break;
                case "X":
                    richTextBox1.Cut();
                    break;
                case "Z":
                    richTextBox1.Undo();
                    break;
                case "Y":
                    richTextBox1.Redo();
                    break;
                case "P":
                    SelectCurrentLine();
                    if (richTextBox1.SelectionProtected)
                    {
                        richTextBox1.SelectionColor = Color.FromArgb(
                            (richTextBox1.SelectionColor.R + 70 > 255) ? 255 : richTextBox1.SelectionColor.R + 70,
                            (richTextBox1.SelectionColor.G + 70 > 255) ? 255 : richTextBox1.SelectionColor.G + 70,
                            (richTextBox1.SelectionColor.B + 70 > 255) ? 255 : richTextBox1.SelectionColor.B + 70
                            );

                        richTextBox1.SelectionProtected = false;
                    }
                    else
                    {
                        richTextBox1.SelectionColor = Color.FromArgb(
                            (richTextBox1.SelectionColor.R - 70 < 0)?0: richTextBox1.SelectionColor.R - 70,
                            (richTextBox1.SelectionColor.G - 70 < 0) ? 0 : richTextBox1.SelectionColor.G - 70,
                            (richTextBox1.SelectionColor.B - 70 < 0) ? 0 : richTextBox1.SelectionColor.B - 70
                            );

                        richTextBox1.SelectionProtected = true;
                    }
                    richTextBox1.DeselectAll();
                    break;
                case "R":
                    SelectCurrentLine();
                    ColorDialog CD = new ColorDialog();
                    if (CD.ShowDialog() == DialogResult.OK)
                        richTextBox1.SelectionColor = CD.Color;
                    richTextBox1.DeselectAll();
                    break;
                case "S":
                    save(true);
                    break;
                case "N":
                    if (MessageBox.Show("Do you want to create a new file?","New File", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CurrentFile = "";
                        richTextBox1.Clear();
                        richTextBox1.ForeColor = txt_color.ForeColor;
                        richTextBox1.BackColor = bg_color.BackColor;
                    }
                    break;
                case "O":
                    OpenFileDialog OFD = new OpenFileDialog();
                    OFD.Title = "Select a file to open";
                    if (OFD.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            richTextBox1.LoadFile(OFD.FileName);
                        }
                        catch
                        {
                            try
                            {
                                richTextBox1.Text = System.IO.File.ReadAllText(OFD.FileName);
                            }
                            catch { }
                        }
                        CurrentFile = OFD.FileName;
                        Properties.Settings.Default.last_opened_file = CurrentFile;
                        Properties.Settings.Default.Save();
                        
                    }
                    break;
                case "Q":
                    if (MessageBox.Show("Do you want to delete all?", "Delete All", MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        richTextBox1.SelectionProtected = false;
                        richTextBox1.Clear();
                        richTextBox1.ForeColor = txt_color.ForeColor;
                        richTextBox1.BackColor = bg_color.BackColor;
                    }
                    break;
                case "D":
                    DuplicateLine();
                    break;
                case "E":
                    CheckForFunctions();
                    break;
            }
        }
        private void DuplicateLine()
        {
            SelectCurrentLine();
            richTextBox1.SelectedText = richTextBox1.SelectedText + "\n" + richTextBox1.SelectedText;
            richTextBox1.DeselectAll();
        }
        private void SelectCurrentLine()
        {
            if (richTextBox1.SelectedText == "")
            {
                try
                {
                    int firstcharindex = richTextBox1.GetFirstCharIndexOfCurrentLine();
                    int currentline = richTextBox1.GetLineFromCharIndex(firstcharindex);
                    string currentlinetext = richTextBox1.Lines[currentline];
                    richTextBox1.Select(firstcharindex, currentlinetext.Length);
                }
                catch { }
            }
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            topMost(checkBox1.Checked);
        }

        private void topMost(bool check)
        {
            if (check)
            {
                arrow._arrow.Size = smallArrowSize;
                arrow._arrow.Location = new Point(arrow.Width - arrow._arrow.Width, arrow.Height - arrow._arrow.Height);
            }
            else
            {
                arrow._arrow.Size = defaultArrowSize;
                arrow._arrow.Location = defaultArrowLocation;
                arrow.SendToBack();
            }
            arrow.TopMost = check;
        }

        private void CheckForFunctions()
        {
            try
            {
                if (Thread.CurrentThread.Name == "FunctionCheck") //Check if we are not on main thread
                {
                    int funcIndex = -1;
                    bool FoundChanges = false;
                    FoundChanges = ((funcIndex = Functions.FunctionFound(Tools.GetControlProperty(richTextBox1, "Text").ToString())) != -1);
                    if (FoundChanges && funcIndex != -1)
                    {
                        Control tmprtb = richTextBox1;
                        Functions.CheckAndExecute(ref tmprtb, funcIndex);
                    }

                    Thread.Sleep(500);
                    if (Thread.CurrentThread.ThreadState != ThreadState.Aborted && Thread.CurrentThread.ThreadState != ThreadState.AbortRequested)
                        CheckForFunctions(); //Check again if thread not aborted
                }
                else
                {
                    int i;
                    if ((i = Functions.FunctionFound(richTextBox1.Text)) != -1)
                    {
                        Control tmprtb = richTextBox1;
                        Functions.CheckAndExecute(ref tmprtb, i);
                    }
                }
            }catch(Exception error)
            {
                if (Thread.CurrentThread.ThreadState != ThreadState.Aborted && Thread.CurrentThread.ThreadState != ThreadState.AbortRequested)
                 MessageBox.Show(error.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        Thread AutoFunctionExecution;
        private void AutoExecution_CheckStateChanged(object sender, EventArgs e)
        {
            if (autoExecution.Checked)
            {
                try
                {
                    AutoFunctionExecution = new Thread(() => CheckForFunctions());
                    AutoFunctionExecution.Name = "FunctionCheck";
                    AutoFunctionExecution.Start();
                }
                catch { }
            }
            else
            {
                try
                {
                    AutoFunctionExecution.Abort();
                }
                catch { }
            }
            Properties.Settings.Default.auto_execution = autoExecution.Checked;
            Properties.Settings.Default.Save();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AutoFunctionExecution.Abort();
        }

        private void CommandSymbolInput_TextChanged(object sender, EventArgs e)
        {
            if (CommandSymbolInput.Text.Length > 1)
            {
                CommandSymbolInput.Text = CommandSymbolInput.Text.Substring(0, CommandSymbolInput.Text.Length - 1);
            }
            else
            {
                Properties.Settings.Default.command_symbol = CommandSymbolInput.Text;
                Properties.Settings.Default.Save();
                Functions.CommandSymbol = CommandSymbolInput.Text;
            }
        }
    }
}