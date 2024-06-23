using System.Drawing.Drawing2D;

namespace GdiWinForms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        //var pen = new Pen(Color.Blue, 5)
        //{
        //    DashStyle = System.Drawing.Drawing2D.DashStyle.Dot
        //};
        //g.DrawEllipse(pen, new Rectangle(50, 100, 170, 40));
        //g.Dispose();
        //var rect = new Rectangle(20, 20, 200, 40);
        //LinearGradientBrush lgBrush = new(rect,
        //    Color.Red,
        //    Color.Green,
        //    0,
        //    true);
        //g.FillRectangle(lgBrush, rect);

        //var rect2 = new Rectangle(20, 80, 200, 40);
        //var htBush = new HatchBrush(HatchStyle.Cross, Color.Blue, Color.WhiteSmoke);
        //g.FillRectangle(htBush, rect2);

        //var rect3 = new Rectangle(20, 140, Width, Height);
        //var txBrush = new TextureBrush(new Bitmap("Cat.jpg"));
        //g.FillRectangle(txBrush, rect3);

        //Font font = new Font("Verdana", 14, FontStyle.Bold | FontStyle.Italic);
        //g.DrawString("Hello Font!",font, Brushes.Blue, 30, 60);

        //var image = new Bitmap("Cat.jpg");
        //g.DrawImage(image, ClientRectangle);

        //var rect1 = new Rectangle(40, 100, 140, 140);
        //var rect2 = new Rectangle(100, 130, 140, 140);

        //var rgn1 = new Region(rect1);
        //var rgn2 = new Region(rect2);

        //g.DrawRectangle(Pens.Blue, rect1);
        //g.DrawRectangle(Pens.Green, rect2);

        //rgn1.Xor(rgn2);
        //rgn2.Intersect(rgn1);

        //g.FillRegion(Brushes.Red, rgn1);
        //g.FillRegion(Brushes.White, rgn2);

        //Point[] points = new Point[]
        //{
        //    new Point(5, 10),
        //    new Point(23, 130),
        //    new Point(130,57)
        //};

        //var path = new GraphicsPath();

        //path.AddEllipse(170, 170, 100, 50);
        //g.FillPath(Brushes.Aqua, path);

        //path.StartFigure();
        //path.AddCurve(points, 0.7f);
        //path.AddArc(100, 50, 100, 100, 0, 120);
        //path.AddLine(50, 150, 50, 220);
        //path.CloseFigure();

        //path.StartFigure();
        //path.AddArc(180, 30, 60, 60, 0, -170);
        //g.DrawPath(Pens.Blue, path);

        DrawMickeyMouse(g);
        g.Dispose();

    }

    private static void DrawMickeyMouse(Graphics g)
    {
        g.SmoothingMode = SmoothingMode.HighQuality;

        // ears
        g.FillEllipse(Brushes.Black, 63, 70, 65, 55);
        g.FillEllipse(Brushes.Black, 200, 70, 65, 55);

        // head
        g.DrawEllipse(Pens.Black, 100, 100, 130, 110);

        // face
        g.FillEllipse(Brushes.Black, 135, 120, 20, 40);
        g.FillEllipse(Brushes.Black, 175, 120, 20, 40);
        g.FillEllipse(Brushes.Black, 150, 145, 30, 30);
        g.DrawArc(Pens.Black, 130, 155, 70, 30, 0, -180);
        g.DrawArc(Pens.Black, 125, 165, 80, 30, 0, 180);

        // body
        g.FillRectangle(Brushes.Black, 115, 210, 100, 100);

        // arms
        g.DrawLine(Pens.Black, 115, 230, 20, 245);
        g.DrawLine(Pens.Black, 215, 230, 310, 245);
        

        // pants
        g.FillRectangle(Brushes.White, 115, 310, 100, 40);
        g.DrawEllipse(Pens.Black, 136, 313, 25, 30);
        g.DrawEllipse(Pens.Black, 166, 313, 25, 30);

        // left leg
        var leftLeg = new Rectangle(125, 350, 20, 70);
        var leftFoot = new GraphicsPath();
        leftFoot.AddEllipse(95, 410, 55, 30);
        var leftLegRgn = new Region(leftLeg);
        var leftFootRgn = new Region(leftFoot);
        leftLegRgn.Exclude(leftFootRgn);
        g.FillRegion(Brushes.Black, leftLegRgn);
        g.DrawPath(Pens.Black, leftFoot);

        // right leg
        var rightLeg = new Rectangle(185, 350, 20, 70);
        var rightFoot = new GraphicsPath();
        rightFoot.AddEllipse(175, 410, 55, 30);
        var rightLegRgn = new Region(rightLeg);
        var rightFootRgn = new Region(rightFoot);
        rightLegRgn.Exclude(rightFootRgn);
        g.FillRegion(Brushes.Black, rightLegRgn);
        g.DrawPath(Pens.Black, rightFoot);

    }

}
