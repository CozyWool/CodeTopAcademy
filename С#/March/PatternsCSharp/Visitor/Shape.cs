using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsCSharp.Visitor
{
    public abstract class Visitor
    {
        public abstract void VisitCircle(Circle circle);
        public abstract void VisitRectangle(Rectangle rectangle);
    }

    public class XmlExportVisitor : Visitor
    {
        public override void VisitCircle(Circle circle)
        {
            Console.WriteLine($"Выгружаем координаты окружности");
        }

        public override void VisitRectangle(Rectangle rectangle)
        {
            Console.WriteLine($"Выгружаем координаты прямоугольника");
        }
    }

    public static class ShapeExtensions
    {
        public static void Accept2(this Shape shape)
        {
            if(shape is Circle)
            {
                Console.WriteLine($"Выгружаем координаты окружности");
            }
            else if(shape is Rectangle)
                Console.WriteLine($"Выгружаем координаты прямоугольника");
        }
    }


    public abstract class Shape
    {
        public abstract void Move(double x, double y);
        public abstract void Draw();
        public abstract void Accept(Visitor v);
    }

    public class Circle : Shape
    {
        public override void Accept(Visitor v)
        {
            v.VisitCircle(this);
        }

        public override void Draw()
        {
            Console.WriteLine("Рисуем окружность");
        }

        public override void Move(double x, double y)
        {
            Console.WriteLine($"Двигаем окружность в точку {x}; {y}");
        }
    }
    public class Rectangle : Shape
    {
        public override void Accept(Visitor v)
        {
           v.VisitRectangle(this);
        }

        public override void Draw()
        {
            Console.WriteLine("Рисуем прямоугольник");
        }

        public override void Move(double x, double y)
        {
            Console.WriteLine($"Двигаем прямоугольник в точку {x}; {y}");
        }
    }
}
