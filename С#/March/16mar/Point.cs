namespace _16mar;

//internal record Point(int X, int Y);
public class Point
{
    public Point()
    {
        X = 0; Y = 0;
    }
    public Point(int x, int y)
    {
        X = x; Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public static Point operator ++(Point p)
    {
        p.X++;
        p.Y++;
        return p;
    }

    public static Point operator --(Point p)
    {
        p.X--; 
        p.Y--;
        return p;
    }

    public static Point operator -(Point p)
    {
        return new Point(-p.X, -p.Y);
    }

    public static bool operator ==(Point p1, Point p2)
    {
        return p1.X == p2.X && p1.Y == p2.Y;
    }
    public static bool operator !=(Point p1, Point p2)
    {
        return !(p1 == p2);
    }

    public static bool operator >(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow(p1.X, 2) + Math.Pow(p1.Y, 2)) > Math.Sqrt(Math.Pow(p1.X, 2) + Math.Pow(p1.Y, 2));
    }
    public static bool operator <(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow(p1.X, 2) + Math.Pow(p1.Y, 2)) < Math.Sqrt(Math.Pow(p1.X, 2) + Math.Pow(p1.Y, 2));
    }
    public static bool operator <=(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow(p1.X, 2) + Math.Pow(p1.Y, 2)) <= Math.Sqrt(Math.Pow(p1.X, 2) + Math.Pow(p1.Y, 2));
    }
    public static bool operator >=(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow(p1.X, 2) + Math.Pow(p1.Y, 2)) >= Math.Sqrt(Math.Pow(p1.X, 2) + Math.Pow(p1.Y, 2));
    }

    public static bool operator true(Point p)
    {
        return p.X != 0 || p.Y != 0;
    }
    public static bool operator false(Point p)
    {
        return p.X == 0 && p.Y == 0;
    }

    public static Point operator |(Point p1, Point p2)
    {
        if (p1.X != 0 || p1.Y != 0 || p2.X != 0 || p2.Y != 0) return p2;
        return p1;
    }
    public static Point operator &(Point p1, Point p2)
    {
        if (p1.X != 0 && p1.Y != 0 && p2.X != 0 && p2.Y != 0) return p2;
        return p1;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (ReferenceEquals(this, obj)) return true;


        if (obj is not Point p) return false;
        //return X == p.X && Y == p.Y;
        return this == p;
    }

    public override int GetHashCode()
    {
        return X ^ Y;
        //return HashCode.Combine(X, Y);
    }

    public static explicit operator int(Point p)
    {
        return (int)Math.Sqrt(Math.Pow(p.X, 2) + Math.Pow(p.Y, 2));
    }
    public static implicit operator Point(int value)
    {
        return new Point(value, value);
    }


    public override string ToString()
    {
        return $"Point: X = {X}, Y = {Y}";
    }
}
