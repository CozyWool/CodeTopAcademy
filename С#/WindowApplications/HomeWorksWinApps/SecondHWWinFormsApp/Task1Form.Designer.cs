namespace SecondHWWinFormsApp;

partial class Task1Form
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
        progressBar = new ProgressBar();
        richTextBox1 = new RichTextBox();
        OpenFile = new Button();
        openFileDialog = new OpenFileDialog();
        SuspendLayout();
        // 
        // progressBar
        // 
        progressBar.Location = new Point(12, 12);
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(776, 78);
        progressBar.TabIndex = 0;
        // 
        // richTextBox1
        // 
        richTextBox1.Location = new Point(12, 96);
        richTextBox1.Name = "richTextBox1";
        richTextBox1.Size = new Size(776, 271);
        richTextBox1.TabIndex = 1;
        richTextBox1.Text = "";
        // 
        // OpenFile
        // 
        OpenFile.Location = new Point(12, 393);
        OpenFile.Name = "OpenFile";
        OpenFile.Size = new Size(193, 45);
        OpenFile.TabIndex = 2;
        OpenFile.Text = "Открыть текстовый файл";
        OpenFile.UseVisualStyleBackColor = true;
        OpenFile.Click += OpenFile_Click;
        // 
        // openFileDialog
        // 
        openFileDialog.FileName = "openFileDialog";
        openFileDialog.Filter = "Текстовые файлы|*.txt";
        // 
        // Task1Form
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(OpenFile);
        Controls.Add(richTextBox1);
        Controls.Add(progressBar);
        Name = "Task1Form";
        Text = "Task1Form";
        ResumeLayout(false);
    }

    #endregion

    private ProgressBar progressBar;
    private RichTextBox richTextBox1;
    private Button OpenFile;
    private OpenFileDialog openFileDialog;
}