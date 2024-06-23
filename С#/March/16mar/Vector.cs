namespace _16mar;

public class Vector
{
    public Vector()
    {
        
    }
    public Vector(Point begin, Point end)
    {
        X = end.X - begin.X;
        Y = end.Y - begin.Y;
    }
    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; private set; }
    public int Y { get; private set; }

    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector { X = a.X + b.X, Y = a.Y + b.Y };
    }
    public static Vector operator -(Vector a, Vector b)
    {
        return new Vector { X = a.X - b.X, Y = a.Y - b.Y };
    }
    public static Vector operator *(Vector a, int number)
    {
        return new Vector { X = a.X * number, Y = a.Y * number };
    }
    public static Vector operator *(int number, Vector a)
    {
        return a * number;
    }

    public override string ToString()
    {
        return $"Vector: X = {X}, Y = {Y}";
    }
}
