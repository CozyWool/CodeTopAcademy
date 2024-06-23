namespace TrackBarWinFormsApp;

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
        RedTrackBar = new TrackBar();
        GreenTrackBar = new TrackBar();
        BlueTrackBar = new TrackBar();
        Panel = new Panel();
        AlphaTrackBar = new TrackBar();
        ((System.ComponentModel.ISupportInitialize)RedTrackBar).BeginInit();
        ((System.ComponentModel.ISupportInitialize)GreenTrackBar).BeginInit();
        ((System.ComponentModel.ISupportInitialize)BlueTrackBar).BeginInit();
        ((System.ComponentModel.ISupportInitialize)AlphaTrackBar).BeginInit();
        SuspendLayout();
        // 
        // RedTrackBar
        // 
        RedTrackBar.Location = new Point(12, 42);
        RedTrackBar.Maximum = 255;
        RedTrackBar.Name = "RedTrackBar";
        RedTrackBar.Size = new Size(378, 45);
        RedTrackBar.TabIndex = 0;
        RedTrackBar.ValueChanged += TrackBar_ValueChanged;
        // 
        // GreenTrackBar
        // 
        GreenTrackBar.Location = new Point(12, 93);
        GreenTrackBar.Maximum = 255;
        GreenTrackBar.Name = "GreenTrackBar";
        GreenTrackBar.Size = new Size(378, 45);
        GreenTrackBar.TabIndex = 1;
        GreenTrackBar.ValueChanged += TrackBar_ValueChanged;
        // 
        // BlueTrackBar
        // 
        BlueTrackBar.Location = new Point(12, 144);
        BlueTrackBar.Maximum = 255;
        BlueTrackBar.Name = "BlueTrackBar";
        BlueTrackBar.Size = new Size(378, 45);
        BlueTrackBar.TabIndex = 2;
        BlueTrackBar.ValueChanged += TrackBar_ValueChanged;
        // 
        // panel1
        // 
        Panel.Location = new Point(416, 43);
        Panel.Name = "panel1";
        Panel.Size = new Size(197, 180);
        Panel.TabIndex = 3;
        // 
        // AlphaTrackBar
        // 
        AlphaTrackBar.Location = new Point(12, 195);
        AlphaTrackBar.Maximum = 255;
        AlphaTrackBar.Name = "AlphaTrackBar";
        AlphaTrackBar.Size = new Size(378, 45);
        AlphaTrackBar.TabIndex = 4;
        AlphaTrackBar.Value = 255;
        AlphaTrackBar.ValueChanged += TrackBar_ValueChanged;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(659, 321);
        Controls.Add(AlphaTrackBar);
        Controls.Add(Panel);
        Controls.Add(BlueTrackBar);
        Controls.Add(GreenTrackBar);
        Controls.Add(RedTrackBar);
        Name = "Form1";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)RedTrackBar).EndInit();
        ((System.ComponentModel.ISupportInitialize)GreenTrackBar).EndInit();
        ((System.ComponentModel.ISupportInitialize)BlueTrackBar).EndInit();
        ((System.ComponentModel.ISupportInitialize)AlphaTrackBar).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TrackBar RedTrackBar;
    private TrackBar GreenTrackBar;
    private TrackBar BlueTrackBar;
    private Panel Panel;
    private TrackBar AlphaTrackBar;
}
