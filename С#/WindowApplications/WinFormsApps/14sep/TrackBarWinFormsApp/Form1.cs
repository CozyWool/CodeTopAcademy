using System.Drawing;

namespace TrackBarWinFormsApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        Panel.BackColor = Color.FromArgb(255,0,0,0);
    }

    private void TrackBar_ValueChanged(object sender, EventArgs e)
    {
        Color color = Color.FromArgb(
            AlphaTrackBar.Value,
            RedTrackBar.Value,
            GreenTrackBar.Value,
            BlueTrackBar.Value
            );
        Panel.BackColor = color;
    }
}
