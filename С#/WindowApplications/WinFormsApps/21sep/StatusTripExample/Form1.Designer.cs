namespace StatusTripExample;

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
        statusStrip1 = new StatusStrip();
        TimeStatusLabel = new ToolStripStatusLabel();
        toolStripDropDownButton1 = new ToolStripDropDownButton();
        DayOfWeekToolStripMenuItem = new ToolStripMenuItem();
        toolStripStatusLabel2 = new ToolStripStatusLabel();
        timer1 = new System.Windows.Forms.Timer(components);
        pictureBox1 = new PictureBox();
        statusStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // statusStrip1
        // 
        statusStrip1.Items.AddRange(new ToolStripItem[] { TimeStatusLabel, toolStripDropDownButton1, toolStripStatusLabel2 });
        statusStrip1.Location = new Point(0, 428);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Size = new Size(800, 22);
        statusStrip1.TabIndex = 0;
        statusStrip1.Text = "statusStrip1";
        // 
        // TimeStatusLabel
        // 
        TimeStatusLabel.Name = "TimeStatusLabel";
        TimeStatusLabel.Size = new Size(118, 17);
        TimeStatusLabel.Text = "toolStripStatusLabel1";
        // 
        // toolStripDropDownButton1
        // 
        toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { DayOfWeekToolStripMenuItem });
        toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
        toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
        toolStripDropDownButton1.Name = "toolStripDropDownButton1";
        toolStripDropDownButton1.Size = new Size(29, 20);
        toolStripDropDownButton1.Text = "toolStripDropDownButton1";
        // 
        // DayOfWeekToolStripMenuItem
        // 
        DayOfWeekToolStripMenuItem.Name = "DayOfWeekToolStripMenuItem";
        DayOfWeekToolStripMenuItem.Size = new Size(136, 22);
        DayOfWeekToolStripMenuItem.Text = "DayOfWeek";
        // 
        // toolStripStatusLabel2
        // 
        toolStripStatusLabel2.Name = "toolStripStatusLabel2";
        toolStripStatusLabel2.Size = new Size(118, 17);
        toolStripStatusLabel2.Text = "toolStripStatusLabel2";
        // 
        // timer1
        // 
        timer1.Interval = 2000;
        timer1.Tick += timer1_Tick;
        // 
        // pictureBox1
        // 
        pictureBox1.Image = Properties.Resources.Фон_для_презентации_физика;
        pictureBox1.Location = new Point(91, 43);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(258, 241);
        pictureBox1.TabIndex = 1;
        pictureBox1.TabStop = false;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(pictureBox1);
        Controls.Add(statusStrip1);
        Name = "Form1";
        Text = "Form1";
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private StatusStrip statusStrip1;
    private ToolStripStatusLabel TimeStatusLabel;
    private ToolStripDropDownButton toolStripDropDownButton1;
    private ToolStripMenuItem DayOfWeekToolStripMenuItem;
    private ToolStripStatusLabel toolStripStatusLabel2;
    private System.Windows.Forms.Timer timer1;
    private PictureBox pictureBox1;
}
