using Timer = System.Windows.Forms.Timer;

namespace _14sep
{
    public partial class Form1 : Form
    {
        private Timer timer = new();
        public Form1()
        {
            InitializeComponent();
            StopButton.Enabled = false;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            timer.Stop();
            StopButton.Enabled = false;
            MessageBox.Show("Тамйер отработал");
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (TimerNumericUpDown.Value <= 0 && TimerNumericUpDown.Value >= 60)
            {
                MessageBox.Show("Количесво секунд должно быть больше 0");
                return;
            }

            StopButton.Enabled = true;
            //timer.Interval = (int)TimeSpan.FromSeconds((double)TimerNumericUpDown.Value).TotalMilliseconds;
            timer.Interval = Decimal.ToInt32(TimerNumericUpDown.Value) * 1000;
            timer.Start();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            MessageBox.Show("Таймер остановлен");
            StopButton.Enabled = false;
        }
    }
}