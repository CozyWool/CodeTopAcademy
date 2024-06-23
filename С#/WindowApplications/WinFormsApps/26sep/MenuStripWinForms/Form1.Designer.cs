namespace MenuStripWinForms;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        menuStrip1 = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        closeToolStripMenuItem = new ToolStripMenuItem();
        editToolStripMenuItem = new ToolStripMenuItem();
        copyToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator1 = new ToolStripSeparator();
        pasteToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator2 = new ToolStripSeparator();
        cutToolStripMenuItem = new ToolStripMenuItem();
        styleToolStripMenuItem = new ToolStripMenuItem();
        redToolStripMenuItem = new ToolStripMenuItem();
        richTextBox1 = new RichTextBox();
        contextMenuStrip1 = new ContextMenuStrip(components);
        cutToolStripMenuItem1 = new ToolStripMenuItem();
        toolStripSeparator4 = new ToolStripSeparator();
        copyToolStripMenuItem1 = new ToolStripMenuItem();
        toolStripSeparator3 = new ToolStripSeparator();
        pasteToolStripMenuItem1 = new ToolStripMenuItem();
        printDialog1 = new PrintDialog();
        RootToolStrip = new ToolStrip();
        OpenToolStripButton = new ToolStripButton();
        SaveToolStripButton = new ToolStripButton();
        ExitToolStripButton = new ToolStripButton();
        menuStrip1.SuspendLayout();
        contextMenuStrip1.SuspendLayout();
        RootToolStrip.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, styleToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(800, 24);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { closeToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.ShortcutKeyDisplayString = "";
        fileToolStripMenuItem.Size = new Size(37, 20);
        fileToolStripMenuItem.Text = "&File";
        // 
        // closeToolStripMenuItem
        // 
        closeToolStripMenuItem.Name = "closeToolStripMenuItem";
        closeToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
        closeToolStripMenuItem.Size = new Size(145, 22);
        closeToolStripMenuItem.Text = "Close";
        closeToolStripMenuItem.Click += CloseTool_Click;
        // 
        // editToolStripMenuItem
        // 
        editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyToolStripMenuItem, toolStripSeparator1, pasteToolStripMenuItem, toolStripSeparator2, cutToolStripMenuItem });
        editToolStripMenuItem.Name = "editToolStripMenuItem";
        editToolStripMenuItem.Size = new Size(39, 20);
        editToolStripMenuItem.Text = "Edit";
        // 
        // copyToolStripMenuItem
        // 
        copyToolStripMenuItem.Name = "copyToolStripMenuItem";
        copyToolStripMenuItem.Size = new Size(102, 22);
        copyToolStripMenuItem.Text = "Copy";
        copyToolStripMenuItem.Click += CopyTool_Click;
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(99, 6);
        // 
        // pasteToolStripMenuItem
        // 
        pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
        pasteToolStripMenuItem.Size = new Size(102, 22);
        pasteToolStripMenuItem.Text = "Paste";
        pasteToolStripMenuItem.Click += PasteTool_Click;
        // 
        // toolStripSeparator2
        // 
        toolStripSeparator2.Name = "toolStripSeparator2";
        toolStripSeparator2.Size = new Size(99, 6);
        // 
        // cutToolStripMenuItem
        // 
        cutToolStripMenuItem.Name = "cutToolStripMenuItem";
        cutToolStripMenuItem.Size = new Size(102, 22);
        cutToolStripMenuItem.Text = "Cut";
        cutToolStripMenuItem.Click += CutTool_Click;
        // 
        // styleToolStripMenuItem
        // 
        styleToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { redToolStripMenuItem });
        styleToolStripMenuItem.Name = "styleToolStripMenuItem";
        styleToolStripMenuItem.Size = new Size(44, 20);
        styleToolStripMenuItem.Text = "Style";
        // 
        // redToolStripMenuItem
        // 
        redToolStripMenuItem.CheckOnClick = true;
        redToolStripMenuItem.Name = "redToolStripMenuItem";
        redToolStripMenuItem.Size = new Size(94, 22);
        redToolStripMenuItem.Text = "Red";
        redToolStripMenuItem.Click += RedTool_Click;
        // 
        // richTextBox1
        // 
        richTextBox1.Location = new Point(12, 27);
        richTextBox1.Name = "richTextBox1";
        richTextBox1.Size = new Size(429, 115);
        richTextBox1.TabIndex = 1;
        richTextBox1.Text = "";
        // 
        // contextMenuStrip1
        // 
        contextMenuStrip1.Items.AddRange(new ToolStripItem[] { cutToolStripMenuItem1, toolStripSeparator4, copyToolStripMenuItem1, toolStripSeparator3, pasteToolStripMenuItem1 });
        contextMenuStrip1.Name = "contextMenuStrip1";
        contextMenuStrip1.Size = new Size(103, 82);
        // 
        // cutToolStripMenuItem1
        // 
        cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
        cutToolStripMenuItem1.Size = new Size(102, 22);
        cutToolStripMenuItem1.Text = "Cut";
        cutToolStripMenuItem1.Click += CutTool_Click;
        // 
        // toolStripSeparator4
        // 
        toolStripSeparator4.Name = "toolStripSeparator4";
        toolStripSeparator4.Size = new Size(99, 6);
        // 
        // copyToolStripMenuItem1
        // 
        copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
        copyToolStripMenuItem1.Size = new Size(102, 22);
        copyToolStripMenuItem1.Text = "Copy";
        copyToolStripMenuItem1.Click += CopyTool_Click;
        // 
        // toolStripSeparator3
        // 
        toolStripSeparator3.Name = "toolStripSeparator3";
        toolStripSeparator3.Size = new Size(99, 6);
        // 
        // pasteToolStripMenuItem1
        // 
        pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
        pasteToolStripMenuItem1.Size = new Size(102, 22);
        pasteToolStripMenuItem1.Text = "Paste";
        pasteToolStripMenuItem1.Click += PasteTool_Click;
        // 
        // printDialog1
        // 
        printDialog1.UseEXDialog = true;
        // 
        // RootToolStrip
        // 
        RootToolStrip.Items.AddRange(new ToolStripItem[] { OpenToolStripButton, SaveToolStripButton, ExitToolStripButton });
        RootToolStrip.Location = new Point(0, 24);
        RootToolStrip.Name = "RootToolStrip";
        RootToolStrip.Size = new Size(800, 25);
        RootToolStrip.TabIndex = 2;
        RootToolStrip.Text = "toolStrip";
        // 
        // OpenToolStripButton
        // 
        OpenToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
        OpenToolStripButton.Image = (Image)resources.GetObject("OpenToolStripButton.Image");
        OpenToolStripButton.ImageTransparentColor = Color.Magenta;
        OpenToolStripButton.Name = "OpenToolStripButton";
        OpenToolStripButton.Size = new Size(23, 22);
        OpenToolStripButton.Text = "toolStripButton1";
        // 
        // SaveToolStripButton
        // 
        SaveToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
        SaveToolStripButton.Image = (Image)resources.GetObject("SaveToolStripButton.Image");
        SaveToolStripButton.ImageTransparentColor = Color.Magenta;
        SaveToolStripButton.Name = "SaveToolStripButton";
        SaveToolStripButton.Size = new Size(23, 22);
        SaveToolStripButton.Text = "toolStripButton1";
        // 
        // ExitToolStripButton
        // 
        ExitToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
        ExitToolStripButton.Image = (Image)resources.GetObject("ExitToolStripButton.Image");
        ExitToolStripButton.ImageTransparentColor = Color.Magenta;
        ExitToolStripButton.Name = "ExitToolStripButton";
        ExitToolStripButton.Size = new Size(23, 22);
        ExitToolStripButton.Text = "toolStripButton2";
        ExitToolStripButton.Click += CloseTool_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        ContextMenuStrip = contextMenuStrip1;
        Controls.Add(RootToolStrip);
        Controls.Add(richTextBox1);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Name = "Form1";
        Text = "Form1";
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        contextMenuStrip1.ResumeLayout(false);
        RootToolStrip.ResumeLayout(false);
        RootToolStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem closeToolStripMenuItem;
    private ToolStripMenuItem editToolStripMenuItem;
    private ToolStripMenuItem copyToolStripMenuItem;
    private ToolStripMenuItem pasteToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem cutToolStripMenuItem;
    private RichTextBox richTextBox1;
    private ToolStripMenuItem styleToolStripMenuItem;
    private ToolStripMenuItem redToolStripMenuItem;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem cutToolStripMenuItem1;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripMenuItem copyToolStripMenuItem1;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripMenuItem pasteToolStripMenuItem1;
    private PrintDialog printDialog1;
    private ToolStrip RootToolStrip;
    private ToolStripButton OpenToolStripButton;
    private ToolStripButton SaveToolStripButton;
    private ToolStripButton ExitToolStripButton;
}
