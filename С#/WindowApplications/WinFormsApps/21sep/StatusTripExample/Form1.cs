namespace StatusTripExample;

public partial class Form1 : Form
{
    enum DateTimeFormat { ShowClock, ShowDate }
    private DateTimeFormat format = DateTimeFormat.ShowDate;
    public Form1()
    {
        InitializeComponent();
        timer1.Start();
        var vScroll = new VScrollBar
        {
            Dock = DockStyle.Right
        };
        var hScroll = new HScrollBar
        {
            Dock = DockStyle.Bottom
        };

        pictureBox1.Controls.Add(vScroll);
        pictureBox1.Controls.Add(hScroll);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        TimeStatusLabel.Text = DateTime.Now.ToShortDateString();
        DayOfWeekToolStripMenuItem.Text = DateTime.Now.DayOfWeek.ToString();
        switch (format)
        {
            case DateTimeFormat.ShowClock:
                toolStripStatusLabel2.Text = DateTime.Now.ToShortTimeString();
                format = DateTimeFormat.ShowDate;
                break;
            case DateTimeFormat.ShowDate:
                toolStripStatusLabel2.Text = DateTime.Now.ToShortDateString();
                format = DateTimeFormat.ShowClock;
                break;
        }
    }
}
