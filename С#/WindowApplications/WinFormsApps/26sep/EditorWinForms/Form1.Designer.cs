namespace EditorWinForms;

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
        SaveButton = new Button();
        LoadButton = new Button();
        LoadFileDialog = new OpenFileDialog();
        SaveFileDialog = new SaveFileDialog();
        SuspendLayout();
        // 
        // RichTextBox
        // 
        RichTextBox.Location = new Point(12, 12);
        RichTextBox.Name = "RichTextBox";
        RichTextBox.Size = new Size(774, 290);
        RichTextBox.TabIndex = 0;
        RichTextBox.Text = "";
        // 
        // SaveButton
        // 
        SaveButton.Location = new Point(656, 308);
        SaveButton.Name = "SaveButton";
        SaveButton.Size = new Size(130, 23);
        SaveButton.TabIndex = 1;
        SaveButton.Text = "Сохранить";
        SaveButton.UseVisualStyleBackColor = true;
        SaveButton.Click += SaveButton_Click;
        // 
        // LoadButton
        // 
        LoadButton.Location = new Point(520, 308);
        LoadButton.Name = "LoadButton";
        LoadButton.Size = new Size(130, 23);
        LoadButton.TabIndex = 1;
        LoadButton.Text = "Загрузить";
        LoadButton.UseVisualStyleBackColor = true;
        LoadButton.Click += LoadButton_Click;
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
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(798, 351);
        Controls.Add(LoadButton);
        Controls.Add(SaveButton);
        Controls.Add(RichTextBox);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    private RichTextBox RichTextBox;
    private Button SaveButton;
    private Button LoadButton;
    private OpenFileDialog LoadFileDialog;
    private SaveFileDialog SaveFileDialog;
}
