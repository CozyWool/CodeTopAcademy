namespace _12._09_HW;

partial class Task3Form
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
        Rectangle = new Panel();
        Border = new Panel();
        SuspendLayout();
        // 
        // Rectangle
        // 
        Rectangle.BackColor = SystemColors.HotTrack;
        Rectangle.Location = new Point(25, 25);
        Rectangle.Margin = new Padding(0);
        Rectangle.Name = "Rectangle";
        Rectangle.Size = new Size(180, 80);
        Rectangle.TabIndex = 0;
        Rectangle.Click += Rectangle_Click;
        Rectangle.MouseEnter += Rectangle_MouseEnter;
        Rectangle.MouseLeave += Rectangle_MouseLeave;
        Rectangle.MouseMove += Task3Form_MouseMove;
        // 
        // Border
        // 
        Border.BackColor = SystemColors.HotTrack;
        Border.ForeColor = SystemColors.ControlDarkDark;
        Border.Location = new Point(10, 10);
        Border.Margin = new Padding(0);
        Border.Name = "Border";
        Border.Size = new Size(210, 110);
        Border.TabIndex = 1;
        Border.Click += Border_Click;
        Border.MouseEnter += Border_MouseEnter;
        Border.MouseLeave += Border_MouseLeave;
        Border.MouseMove += Task3Form_MouseMove;
        // 
        // Task3Form
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(Rectangle);
        Controls.Add(Border);
        Name = "Task3Form";
        Text = "Task3Form";
        KeyDown += Task3Form_KeyDown;
        KeyUp += Task3Form_KeyUp;
        MouseDown += Task3Form_MouseDown;
        MouseMove += Task3Form_MouseMove;
        MouseUp += Task3Form_MouseUp;
        ResumeLayout(false);
    }

    #endregion

    private Panel Rectangle;
    private Panel Border;
}