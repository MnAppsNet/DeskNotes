namespace DeskNotes
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TextView = new System.Windows.Forms.RichTextBox();
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoCTRLZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCTRLNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutCTRLXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllCTRLAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.styleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.italicCTRLIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.underlineCTRLUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontCTRLTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerCTRLUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftCTRLLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightCTRLRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.executeCommandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoExecution = new System.Windows.Forms.ToolStripMenuItem();
            this.commandsSymbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CommandSymbolInput = new System.Windows.Forms.ToolStripComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bg_color = new System.Windows.Forms.Panel();
            this.txt_color = new System.Windows.Forms.Label();
            this.TopMostOption = new System.Windows.Forms.CheckBox();
            this.Menu.SuspendLayout();
            this.bg_color.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextView
            // 
            this.TextView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextView.ContextMenuStrip = this.Menu;
            this.TextView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.TextView.Location = new System.Drawing.Point(5, 0);
            this.TextView.Name = "TextView";
            this.TextView.Size = new System.Drawing.Size(118, 117);
            this.TextView.TabIndex = 0;
            this.TextView.Text = "";
            this.TextView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormatSelection);
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoCTRLZToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.deleteAllToolStripMenuItem,
            this.toolStripSeparator4,
            this.fileToolStripMenuItem,
            this.toolStripSeparator2,
            this.copyToolStripMenuItem,
            this.cutCTRLXToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.selectAllCTRLAToolStripMenuItem,
            this.toolStripSeparator1,
            this.groupToolStripMenuItem,
            this.styleToolStripMenuItem,
            this.alignToolStripMenuItem,
            this.toolStripSeparator3,
            this.executeCommandsToolStripMenuItem});
            this.Menu.Name = "contextMenuStrip1";
            this.Menu.Size = new System.Drawing.Size(264, 445);
            // 
            // undoCTRLZToolStripMenuItem
            // 
            this.undoCTRLZToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.undoCTRLZToolStripMenuItem.Name = "undoCTRLZToolStripMenuItem";
            this.undoCTRLZToolStripMenuItem.Size = new System.Drawing.Size(263, 32);
            this.undoCTRLZToolStripMenuItem.Tag = "Z";
            this.undoCTRLZToolStripMenuItem.Text = "Undo          (CTRL + Z)";
            this.undoCTRLZToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(263, 32);
            this.redoToolStripMenuItem.Tag = "Y";
            this.redoToolStripMenuItem.Text = "Redo          (CTRL + Y)";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // deleteAllToolStripMenuItem
            // 
            this.deleteAllToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem";
            this.deleteAllToolStripMenuItem.Size = new System.Drawing.Size(263, 32);
            this.deleteAllToolStripMenuItem.Tag = "Q";
            this.deleteAllToolStripMenuItem.Text = "Delete All   (CTRL + Q)";
            this.deleteAllToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(260, 6);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.dToolStripMenuItem,
            this.newCTRLNToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(263, 32);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(288, 34);
            this.saveToolStripMenuItem.Tag = "S";
            this.saveToolStripMenuItem.Text = "Save           (CTRL + S)";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(288, 34);
            this.dToolStripMenuItem.Tag = "O";
            this.dToolStripMenuItem.Text = "Open         (CTRL + O)";
            this.dToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // newCTRLNToolStripMenuItem
            // 
            this.newCTRLNToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.newCTRLNToolStripMenuItem.Name = "newCTRLNToolStripMenuItem";
            this.newCTRLNToolStripMenuItem.Size = new System.Drawing.Size(288, 34);
            this.newCTRLNToolStripMenuItem.Tag = "N";
            this.newCTRLNToolStripMenuItem.Text = "New           (CTRL + N)";
            this.newCTRLNToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.Black;
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.Black;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(260, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(263, 32);
            this.copyToolStripMenuItem.Tag = "C";
            this.copyToolStripMenuItem.Text = "Copy           (CTRL + C)";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // cutCTRLXToolStripMenuItem
            // 
            this.cutCTRLXToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.cutCTRLXToolStripMenuItem.Name = "cutCTRLXToolStripMenuItem";
            this.cutCTRLXToolStripMenuItem.Size = new System.Drawing.Size(263, 32);
            this.cutCTRLXToolStripMenuItem.Tag = "X";
            this.cutCTRLXToolStripMenuItem.Text = "Cut              (CTRL + X)";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(263, 32);
            this.pasteToolStripMenuItem.Tag = "V";
            this.pasteToolStripMenuItem.Text = "Paste           (CTRL + V)";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // selectAllCTRLAToolStripMenuItem
            // 
            this.selectAllCTRLAToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.selectAllCTRLAToolStripMenuItem.Name = "selectAllCTRLAToolStripMenuItem";
            this.selectAllCTRLAToolStripMenuItem.Size = new System.Drawing.Size(263, 32);
            this.selectAllCTRLAToolStripMenuItem.Tag = "A";
            this.selectAllCTRLAToolStripMenuItem.Text = "Select All     (CTRL + A)";
            this.selectAllCTRLAToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.Black;
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.Black;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(260, 6);
            // 
            // groupToolStripMenuItem
            // 
            this.groupToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            this.groupToolStripMenuItem.Size = new System.Drawing.Size(263, 32);
            this.groupToolStripMenuItem.Tag = "P";
            this.groupToolStripMenuItem.Text = "Protect        (CTRL + P)";
            this.groupToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // styleToolStripMenuItem
            // 
            this.styleToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.styleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boldToolStripMenuItem,
            this.italicCTRLIToolStripMenuItem,
            this.underlineCTRLUToolStripMenuItem,
            this.fontCTRLTToolStripMenuItem,
            this.changeColorToolStripMenuItem});
            this.styleToolStripMenuItem.Name = "styleToolStripMenuItem";
            this.styleToolStripMenuItem.Size = new System.Drawing.Size(263, 32);
            this.styleToolStripMenuItem.Tag = "T";
            this.styleToolStripMenuItem.Text = "Style";
            this.styleToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // boldToolStripMenuItem
            // 
            this.boldToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.boldToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.boldToolStripMenuItem.Name = "boldToolStripMenuItem";
            this.boldToolStripMenuItem.Size = new System.Drawing.Size(305, 34);
            this.boldToolStripMenuItem.Tag = "B";
            this.boldToolStripMenuItem.Text = "Bold            (CTRL + B)";
            this.boldToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // italicCTRLIToolStripMenuItem
            // 
            this.italicCTRLIToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.italicCTRLIToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.italicCTRLIToolStripMenuItem.Name = "italicCTRLIToolStripMenuItem";
            this.italicCTRLIToolStripMenuItem.Size = new System.Drawing.Size(305, 34);
            this.italicCTRLIToolStripMenuItem.Tag = "I";
            this.italicCTRLIToolStripMenuItem.Text = "Italic            (CTRL + I)";
            this.italicCTRLIToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // underlineCTRLUToolStripMenuItem
            // 
            this.underlineCTRLUToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.underlineCTRLUToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.underlineCTRLUToolStripMenuItem.Name = "underlineCTRLUToolStripMenuItem";
            this.underlineCTRLUToolStripMenuItem.Size = new System.Drawing.Size(305, 34);
            this.underlineCTRLUToolStripMenuItem.Tag = "U";
            this.underlineCTRLUToolStripMenuItem.Text = "Underline    (CTRL + U)";
            this.underlineCTRLUToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // fontCTRLTToolStripMenuItem
            // 
            this.fontCTRLTToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.fontCTRLTToolStripMenuItem.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontCTRLTToolStripMenuItem.Name = "fontCTRLTToolStripMenuItem";
            this.fontCTRLTToolStripMenuItem.Size = new System.Drawing.Size(305, 34);
            this.fontCTRLTToolStripMenuItem.Tag = "T";
            this.fontCTRLTToolStripMenuItem.Text = "Font            (CTRL + T)";
            this.fontCTRLTToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // changeColorToolStripMenuItem
            // 
            this.changeColorToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.changeColorToolStripMenuItem.ForeColor = System.Drawing.Color.Green;
            this.changeColorToolStripMenuItem.Name = "changeColorToolStripMenuItem";
            this.changeColorToolStripMenuItem.Size = new System.Drawing.Size(305, 34);
            this.changeColorToolStripMenuItem.Tag = "R";
            this.changeColorToolStripMenuItem.Text = "Color          (CTRL + R)";
            this.changeColorToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // alignToolStripMenuItem
            // 
            this.alignToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.alignToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.centerCTRLUpToolStripMenuItem,
            this.leftCTRLLeftToolStripMenuItem,
            this.rightCTRLRightToolStripMenuItem});
            this.alignToolStripMenuItem.Name = "alignToolStripMenuItem";
            this.alignToolStripMenuItem.Size = new System.Drawing.Size(263, 32);
            this.alignToolStripMenuItem.Text = "Align";
            // 
            // centerCTRLUpToolStripMenuItem
            // 
            this.centerCTRLUpToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.centerCTRLUpToolStripMenuItem.Name = "centerCTRLUpToolStripMenuItem";
            this.centerCTRLUpToolStripMenuItem.Size = new System.Drawing.Size(314, 34);
            this.centerCTRLUpToolStripMenuItem.Tag = "UP";
            this.centerCTRLUpToolStripMenuItem.Text = "Center        (CTRL + Up)";
            this.centerCTRLUpToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // leftCTRLLeftToolStripMenuItem
            // 
            this.leftCTRLLeftToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.leftCTRLLeftToolStripMenuItem.Name = "leftCTRLLeftToolStripMenuItem";
            this.leftCTRLLeftToolStripMenuItem.Size = new System.Drawing.Size(314, 34);
            this.leftCTRLLeftToolStripMenuItem.Tag = "LEFT";
            this.leftCTRLLeftToolStripMenuItem.Text = "Left            (CTRL + Left)";
            this.leftCTRLLeftToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // rightCTRLRightToolStripMenuItem
            // 
            this.rightCTRLRightToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rightCTRLRightToolStripMenuItem.Name = "rightCTRLRightToolStripMenuItem";
            this.rightCTRLRightToolStripMenuItem.Size = new System.Drawing.Size(314, 34);
            this.rightCTRLRightToolStripMenuItem.Tag = "RIGHT";
            this.rightCTRLRightToolStripMenuItem.Text = "Right         (CTRL + Right)";
            this.rightCTRLRightToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(260, 6);
            // 
            // executeCommandsToolStripMenuItem
            // 
            this.executeCommandsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.executeCommandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoExecution,
            this.commandsSymbolToolStripMenuItem});
            this.executeCommandsToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.executeCommandsToolStripMenuItem.Name = "executeCommandsToolStripMenuItem";
            this.executeCommandsToolStripMenuItem.Size = new System.Drawing.Size(263, 32);
            this.executeCommandsToolStripMenuItem.Tag = "E";
            this.executeCommandsToolStripMenuItem.Text = "Execute Commands";
            this.executeCommandsToolStripMenuItem.Click += new System.EventHandler(this.MenuClick);
            // 
            // autoExecution
            // 
            this.autoExecution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.autoExecution.Checked = true;
            this.autoExecution.CheckOnClick = true;
            this.autoExecution.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoExecution.Name = "autoExecution";
            this.autoExecution.Size = new System.Drawing.Size(298, 34);
            this.autoExecution.Text = "Auto Execution";
            this.autoExecution.CheckStateChanged += new System.EventHandler(this.AutoExecution_CheckStateChanged);
            // 
            // commandsSymbolToolStripMenuItem
            // 
            this.commandsSymbolToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.commandsSymbolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CommandSymbolInput});
            this.commandsSymbolToolStripMenuItem.Name = "commandsSymbolToolStripMenuItem";
            this.commandsSymbolToolStripMenuItem.Size = new System.Drawing.Size(298, 34);
            this.commandsSymbolToolStripMenuItem.Text = "Commands Symbol >";
            // 
            // CommandSymbolInput
            // 
            this.CommandSymbolInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.CommandSymbolInput.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.CommandSymbolInput.Items.AddRange(new object[] {
            "$",
            "#",
            "?",
            "@",
            " "});
            this.CommandSymbolInput.Name = "CommandSymbolInput";
            this.CommandSymbolInput.Size = new System.Drawing.Size(121, 33);
            this.CommandSymbolInput.TextChanged += new System.EventHandler(this.CommandSymbolInput_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 117);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseUp);
            // 
            // bg_color
            // 
            this.bg_color.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bg_color.BackColor = System.Drawing.Color.White;
            this.bg_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bg_color.Controls.Add(this.txt_color);
            this.bg_color.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bg_color.Location = new System.Drawing.Point(78, 91);
            this.bg_color.Name = "bg_color";
            this.bg_color.Size = new System.Drawing.Size(43, 25);
            this.bg_color.TabIndex = 2;
            this.bg_color.Click += new System.EventHandler(this.ChangeColors);
            // 
            // txt_color
            // 
            this.txt_color.AutoSize = true;
            this.txt_color.Location = new System.Drawing.Point(3, 1);
            this.txt_color.Name = "txt_color";
            this.txt_color.Size = new System.Drawing.Size(37, 20);
            this.txt_color.TabIndex = 0;
            this.txt_color.Text = "Abc";
            this.txt_color.Click += new System.EventHandler(this.ChangeColors);
            // 
            // TopMostOption
            // 
            this.TopMostOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TopMostOption.AutoSize = true;
            this.TopMostOption.Location = new System.Drawing.Point(-21, 92);
            this.TopMostOption.Name = "TopMostOption";
            this.TopMostOption.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TopMostOption.Size = new System.Drawing.Size(97, 24);
            this.TopMostOption.TabIndex = 3;
            this.TopMostOption.Text = "TopMost";
            this.TopMostOption.UseVisualStyleBackColor = true;
            this.TopMostOption.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(123, 117);
            this.Controls.Add(this.TopMostOption);
            this.Controls.Add(this.bg_color);
            this.Controls.Add(this.TextView);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormatSelection);
            this.Menu.ResumeLayout(false);
            this.bg_color.ResumeLayout(false);
            this.bg_color.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox TextView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel bg_color;
        private System.Windows.Forms.Label txt_color;
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem undoCTRLZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllCTRLAToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cutCTRLXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem styleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem italicCTRLIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem underlineCTRLUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontCTRLTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alignToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerCTRLUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftCTRLLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightCTRLRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllToolStripMenuItem;
        public System.Windows.Forms.CheckBox TopMostOption;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem executeCommandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoExecution;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCTRLNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandsSymbolToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox CommandSymbolInput;
    }
}

