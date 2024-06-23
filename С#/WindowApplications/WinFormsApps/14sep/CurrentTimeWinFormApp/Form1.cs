using Timer = System.Windows.Forms.Timer;

namespace CurrentTimeWinFormApp;

public partial class CurrentTimeForm : Form
{
    private Timer timer = new();
    public CurrentTimeForm()
    {
        InitializeComponent();
        TimeLabel.Text = DateTime.Now.ToLongTimeString();
        timer.Interval = 1000;
        timer.Tick += Timer_Tick;
        timer.Start();
    }
    private void Timer_Tick(object? sender, EventArgs e)
    {
        TimeLabel.Text = DateTime.Now.ToLongTimeString();
    }
}