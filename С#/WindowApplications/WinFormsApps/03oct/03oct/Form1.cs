namespace _03oct;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        PaintButton.Visible = false;
        Show();

        var g = CreateGraphics();
        var brush = new SolidBrush(Color.Red);
        var rect = new Rectangle(10, 10, 200, 100);
        g.FillRectangle(brush, rect);
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        //g.PageUnit = GraphicsUnit.Inch;

        //g.TranslateTransform(10, 50);
        //Point a = new Point(10, 50);
        //Point b = new Point(0, 0);
        //g.DrawLine(new Pen(Brushes.Blue, 5),a,b);

        //g.RotateTransform(45);
        //g.DrawRectangle(new Pen(Brushes.Blue, 5), 300, 0, 100, 200);
        //g.ResetTransform();
        //g.DrawRectangle(new Pen(Brushes.Blue, 5), 300, 0, 100, 200);



    }

    private void PaintButton_Click(object sender, EventArgs e)
    {
        var bitmap = new Bitmap("Cat.jpg");
        var g = Graphics.FromImage(bitmap);

        var font = new Font("Verdana", 8, FontStyle.Bold);
        string helloString = "Hello World!";


        var size = g.MeasureString(helloString, font);
        g.DrawString(helloString, font, Brushes.Green, 20, 20);
        g.DrawRectangle(new Pen(Color.Blue,2), 20, 20, size.Width + 1, size.Height);

        bitmap.Save("CatRedacted.jpg");


    }
}
