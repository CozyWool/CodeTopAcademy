namespace DialogWinForms;

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
        colorDialog1 = new ColorDialog();
        folderBrowserDialog1 = new FolderBrowserDialog();
        fontDialog1 = new FontDialog();
        openFileDialog1 = new OpenFileDialog();
        saveFileDialog1 = new SaveFileDialog();
        OpenFolderButton = new Button();
        SaveFileButton = new Button();
        OpenFileButton = new Button();
        OpenFontButton = new Button();
        OpenColorButton = new Button();
        SuspendLayout();
        // 
        // openFileDialog1
        // 
        openFileDialog1.FileName = "openFileDialog1";
        // 
        // OpenFolderButton
        // 
        OpenFolderButton.Location = new Point(53, 75);
        OpenFolderButton.Name = "OpenFolderButton";
        OpenFolderButton.Size = new Size(347, 23);
        OpenFolderButton.TabIndex = 0;
        OpenFolderButton.Text = "Open folder dialog";
        OpenFolderButton.UseVisualStyleBackColor = true;
        OpenFolderButton.Click += OpenFolderButton_Click;
        // 
        // SaveFileButton
        // 
        SaveFileButton.Location = new Point(53, 162);
        SaveFileButton.Name = "SaveFileButton";
        SaveFileButton.Size = new Size(347, 23);
        SaveFileButton.TabIndex = 0;
        SaveFileButton.Text = "Open save dialog";
        SaveFileButton.UseVisualStyleBackColor = true;
        SaveFileButton.Click += SaveFileButton_Click;
        // 
        // OpenFileButton
        // 
        OpenFileButton.Location = new Point(53, 133);
        OpenFileButton.Name = "OpenFileButton";
        OpenFileButton.Size = new Size(347, 23);
        OpenFileButton.TabIndex = 0;
        OpenFileButton.Text = "Open file dialog";
        OpenFileButton.UseVisualStyleBackColor = true;
        OpenFileButton.Click += OpenFileButton_Click;
        // 
        // OpenFontButton
        // 
        OpenFontButton.Location = new Point(53, 104);
        OpenFontButton.Name = "OpenFontButton";
        OpenFontButton.Size = new Size(347, 23);
        OpenFontButton.TabIndex = 0;
        OpenFontButton.Text = "Open font dialog";
        OpenFontButton.UseVisualStyleBackColor = true;
        OpenFontButton.Click += OpenFontButton_Click;
        // 
        // OpenColorButton
        // 
        OpenColorButton.Location = new Point(53, 46);
        OpenColorButton.Name = "OpenColorButton";
        OpenColorButton.Size = new Size(347, 23);
        OpenColorButton.TabIndex = 0;
        OpenColorButton.Text = "Open color dialog";
        OpenColorButton.UseVisualStyleBackColor = true;
        OpenColorButton.Click += OpenColorButton_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(459, 228);
        Controls.Add(OpenColorButton);
        Controls.Add(OpenFontButton);
        Controls.Add(OpenFileButton);
        Controls.Add(SaveFileButton);
        Controls.Add(OpenFolderButton);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    private ColorDialog colorDialog1;
    private FolderBrowserDialog folderBrowserDialog1;
    private FontDialog fontDialog1;
    private OpenFileDialog openFileDialog1;
    private SaveFileDialog saveFileDialog1;
    private Button OpenFolderButton;
    private Button SaveFileButton;
    private Button OpenFileButton;
    private Button OpenFontButton;
    private Button OpenColorButton;
}
