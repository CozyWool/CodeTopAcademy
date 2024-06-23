namespace SecondHWWinFormsApp;

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
        Task2Button = new Button();
        Task1Button = new Button();
        SuspendLayout();
        // 
        // Task2Button
        // 
        Task2Button.Location = new Point(12, 238);
        Task2Button.Name = "Task2Button";
        Task2Button.Size = new Size(776, 200);
        Task2Button.TabIndex = 1;
        Task2Button.Text = "Task 2";
        Task2Button.UseVisualStyleBackColor = true;
        Task2Button.Click += Task2Button_Click;
        // 
        // Task1Button
        // 
        Task1Button.Location = new Point(12, 12);
        Task1Button.Name = "Task1Button";
        Task1Button.Size = new Size(776, 200);
        Task1Button.TabIndex = 2;
        Task1Button.Text = "Task 1";
        Task1Button.UseVisualStyleBackColor = true;
        Task1Button.Click += Task1Button_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ClientSize = new Size(800, 450);
        Controls.Add(Task2Button);
        Controls.Add(Task1Button);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    private Button Task2Button;
    private Button Task1Button;
}
