namespace TextEditorWinForms;

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
        RichTextBox = new RichTextBox();
        LoadFileDialog = new OpenFileDialog();
        SaveFileDialog = new SaveFileDialog();
        menuStrip1 = new MenuStrip();
        openToolStripMenuItem = new ToolStripMenuItem();
        openToolStripMenuItem1 = new ToolStripMenuItem();
        NewDocumentToolStripMenuItem1 = new ToolStripMenuItem();
        saveToolStripMenuItem = new ToolStripMenuItem();
        saveAsToolStripMenuItem = new ToolStripMenuItem();
        editToolStripMenuItem = new ToolStripMenuItem();
        copyToolStripMenuItem = new ToolStripMenuItem();
        pasteToolStripMenuItem = new ToolStripMenuItem();
        cutToolStripMenuItem = new ToolStripMenuItem();
        selectAllToolStripMenuItem = new ToolStripMenuItem();
        styleToolStripMenuItem = new ToolStripMenuItem();
        TextToolStripMenuItem = new ToolStripMenuItem();
        fontToolStripMenuItem = new ToolStripMenuItem();
        textColorToolStripMenuItem = new ToolStripMenuItem();
        backgroundToolStripMenuItem = new ToolStripMenuItem();
        backgroundColorToolStripMenuItem = new ToolStripMenuItem();
        ColorDialog = new ColorDialog();
        FontDialog = new FontDialog();
        menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // RichTextBox
        // 
        RichTextBox.Location = new Point(12, 60);
        RichTextBox.Name = "RichTextBox";
        RichTextBox.Size = new Size(774, 351);
        RichTextBox.TabIndex = 2;
        RichTextBox.Text = "";
        // 
        // LoadFileDialog
        // 
        LoadFileDialog.FileName = "openFileDialog1";
        LoadFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
        // 
        // SaveFileDialog
        // 
        SaveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, editToolStripMenuItem, styleToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(800, 24);
        menuStrip1.TabIndex = 3;
        menuStrip1.Text = "menuStrip1";
        // 
        // openToolStripMenuItem
        // 
        openToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem1, NewDocumentToolStripMenuItem1, saveToolStripMenuItem, saveAsToolStripMenuItem });
        openToolStripMenuItem.Name = "openToolStripMenuItem";
        openToolStripMenuItem.Size = new Size(37, 20);
        openToolStripMenuItem.Text = "File";
        // 
        // openToolStripMenuItem1
        // 
        openToolStripMenuItem1.Name = "openToolStripMenuItem1";
        openToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.O;
        openToolStripMenuItem1.Size = new Size(199, 22);
        openToolStripMenuItem1.Text = "Open";
        openToolStripMenuItem1.Click += LoadButton_Click;
        // 
        // NewDocumentToolStripMenuItem1
        // 
        NewDocumentToolStripMenuItem1.Name = "NewDocumentToolStripMenuItem1";
        NewDocumentToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.N;
        NewDocumentToolStripMenuItem1.Size = new Size(199, 22);
        NewDocumentToolStripMenuItem1.Text = "New document";
        NewDocumentToolStripMenuItem1.Click += NewDocument_Click;
        // 
        // saveToolStripMenuItem
        // 
        saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
        saveToolStripMenuItem.Size = new Size(199, 22);
        saveToolStripMenuItem.Text = "Save";
        saveToolStripMenuItem.Click += SaveButton_Click;
        // 
        // saveAsToolStripMenuItem
        // 
        saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
        saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.S;
        saveAsToolStripMenuItem.Size = new Size(199, 22);
        saveAsToolStripMenuItem.Text = "Save as";
        saveAsToolStripMenuItem.Click += SaveAsButton_Click;
        // 
        // editToolStripMenuItem
        // 
        editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyToolStripMenuItem, pasteToolStripMenuItem, cutToolStripMenuItem, selectAllToolStripMenuItem });
        editToolStripMenuItem.Name = "editToolStripMenuItem";
        editToolStripMenuItem.Size = new Size(39, 20);
        editToolStripMenuItem.Text = "Edit";
        // 
        // copyToolStripMenuItem
        // 
        copyToolStripMenuItem.Name = "copyToolStripMenuItem";
        copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
        copyToolStripMenuItem.Size = new Size(162, 22);
        copyToolStripMenuItem.Text = "Copy";
        copyToolStripMenuItem.Click += CopyTool_Click;
        // 
        // pasteToolStripMenuItem
        // 
        pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
        pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
        pasteToolStripMenuItem.Size = new Size(162, 22);
        pasteToolStripMenuItem.Text = "Paste";
        pasteToolStripMenuItem.Click += PasteTool_Click;
        // 
        // cutToolStripMenuItem
        // 
        cutToolStripMenuItem.Name = "cutToolStripMenuItem";
        cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
        cutToolStripMenuItem.Size = new Size(162, 22);
        cutToolStripMenuItem.Text = "Cut";
        cutToolStripMenuItem.Click += CutTool_Click;
        // 
        // selectAllToolStripMenuItem
        // 
        selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
        selectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
        selectAllToolStripMenuItem.Size = new Size(162, 22);
        selectAllToolStripMenuItem.Text = "Select all";
        selectAllToolStripMenuItem.Click += SelectAll_Click;
        // 
        // styleToolStripMenuItem
        // 
        styleToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { TextToolStripMenuItem, backgroundToolStripMenuItem });
        styleToolStripMenuItem.Name = "styleToolStripMenuItem";
        styleToolStripMenuItem.Size = new Size(44, 20);
        styleToolStripMenuItem.Text = "Style";
        // 
        // TextToolStripMenuItem
        // 
        TextToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fontToolStripMenuItem, textColorToolStripMenuItem });
        TextToolStripMenuItem.Name = "TextToolStripMenuItem";
        TextToolStripMenuItem.Size = new Size(138, 22);
        TextToolStripMenuItem.Text = "Text";
        // 
        // fontToolStripMenuItem
        // 
        fontToolStripMenuItem.Name = "fontToolStripMenuItem";
        fontToolStripMenuItem.Size = new Size(103, 22);
        fontToolStripMenuItem.Text = "Font";
        fontToolStripMenuItem.Click += StyleFont_Click;
        // 
        // textColorToolStripMenuItem
        // 
        textColorToolStripMenuItem.Name = "textColorToolStripMenuItem";
        textColorToolStripMenuItem.Size = new Size(103, 22);
        textColorToolStripMenuItem.Text = "Color";
        // 
        // backgroundToolStripMenuItem
        // 
        backgroundToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { backgroundColorToolStripMenuItem });
        backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
        backgroundToolStripMenuItem.Size = new Size(138, 22);
        backgroundToolStripMenuItem.Text = "Background";
        // 
        // backgroundColorToolStripMenuItem
        // 
        backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
        backgroundColorToolStripMenuItem.Size = new Size(103, 22);
        backgroundColorToolStripMenuItem.Text = "Color";
        backgroundColorToolStripMenuItem.Click += BackgroundColor_Click;
        // 
        // ColorDialog
        // 
        ColorDialog.FullOpen = true;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(RichTextBox);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Name = "Form1";
        Text = "Form1";
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private RichTextBox RichTextBox;
    private OpenFileDialog LoadFileDialog;
    private SaveFileDialog SaveFileDialog;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem openToolStripMenuItem;
    private ToolStripMenuItem openToolStripMenuItem1;
    private ToolStripMenuItem NewDocumentToolStripMenuItem1;
    private ToolStripMenuItem saveToolStripMenuItem;
    private ToolStripMenuItem saveAsToolStripMenuItem;
    private ToolStripMenuItem editToolStripMenuItem;
    private ToolStripMenuItem copyToolStripMenuItem;
    private ToolStripMenuItem pasteToolStripMenuItem;
    private ToolStripMenuItem cutToolStripMenuItem;
    private ToolStripMenuItem styleToolStripMenuItem;
    private ToolStripMenuItem TextToolStripMenuItem;
    private ToolStripMenuItem fontToolStripMenuItem;
    private ToolStripMenuItem textColorToolStripMenuItem;
    private ToolStripMenuItem backgroundToolStripMenuItem;
    private ToolStripMenuItem backgroundColorToolStripMenuItem;
    private ColorDialog ColorDialog;
    private ToolStripMenuItem selectAllToolStripMenuItem;
    private FontDialog FontDialog;
}
