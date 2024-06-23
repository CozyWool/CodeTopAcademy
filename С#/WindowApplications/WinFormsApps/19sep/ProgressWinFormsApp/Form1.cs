namespace ProgressWinFormsApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    //private void button1_Click(object sender, EventArgs e)
    //{
    //    var start = progressBar1.Minimum;
    //    var end = progressBar1.Maximum;
    //    for (int i = start; i < end; i++)
    //    {
    //        //progressBar1.PerformStep();
    //        progressBar1.Increment(1);
    //        ProgressLabel.Text = progressBar1.Value.ToString();
    //        Update();
    //        Thread.Sleep(50);
    //    }
    //}
    private void StartButton_Click(object sender, EventArgs e)
    {
        Thread thread = new(DoWork);
        thread.Start();
    }
    private void DoWork(object data)
    {
        int start = 0;
        int end = 0;
        for (int i = start; i < end; i++)
        {
            //progressBar1.PerformStep();
            //progressBar1.Increment(1);
            Invoke(() =>
            {
                progressBar1.PerformStep();
                ProgressLabel.Text = progressBar1.Value.ToString();
                Update();
            });
            Thread.Sleep(50);
        }
    }
    private void ResetButton_Click(object sender, EventArgs e)
    {
        progressBar1.Value = progressBar1.Minimum;
    }
}
