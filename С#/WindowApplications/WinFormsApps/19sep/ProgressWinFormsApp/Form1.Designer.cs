namespace ProgressWinFormsApp;

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
        progressBar1 = new ProgressBar();
        ProgressLabel = new Label();
        StartButton = new Button();
        ResetButton = new Button();
        SuspendLayout();
        // 
        // progressBar1
        // 
        progressBar1.Location = new Point(12, 12);
        progressBar1.Name = "progressBar1";
        progressBar1.Size = new Size(776, 27);
        progressBar1.Step = 1;
        progressBar1.TabIndex = 0;
        // 
        // ProgressLabel
        // 
        ProgressLabel.AutoSize = true;
        ProgressLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        ProgressLabel.Location = new Point(12, 53);
        ProgressLabel.Name = "ProgressLabel";
        ProgressLabel.Size = new Size(0, 25);
        ProgressLabel.TabIndex = 1;
        // 
        // StartButton
        // 
        StartButton.Location = new Point(12, 93);
        StartButton.Name = "StartButton";
        StartButton.Size = new Size(75, 23);
        StartButton.TabIndex = 2;
        StartButton.Text = "Start";
        StartButton.UseVisualStyleBackColor = true;
        StartButton.Click += StartButton_Click;
        // 
        // ResetButton
        // 
        ResetButton.Location = new Point(713, 93);
        ResetButton.Name = "ResetButton";
        ResetButton.Size = new Size(75, 23);
        ResetButton.TabIndex = 3;
        ResetButton.Text = "Reset";
        ResetButton.UseVisualStyleBackColor = true;
        ResetButton.Click += ResetButton_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(ResetButton);
        Controls.Add(StartButton);
        Controls.Add(ProgressLabel);
        Controls.Add(progressBar1);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ProgressBar progressBar1;
    private Label ProgressLabel;
    private Button StartButton;
    private Button ResetButton;
}
