using _16mar;

//PointExample();
//VectorExample();
//PointBoolExample();
//PointEqualsExample();
//PointGetHashCodeExample();
//PointCastExample();
MatrixExample();

static void PointExample()
{
    Point point = new Point(10, 10);
    Console.WriteLine($"Исходная точка\n{point}");
    Console.WriteLine("Префиксная и постфиксная формы инкремента выполняются одинаково");
    Console.WriteLine(++point); // x=11, y=11
    Console.WriteLine(point++); // x=12, y=12
    Console.WriteLine($"Префиксная форма декремента\n{--point}");
    Console.WriteLine($"Выполнение оператора –\n{-point}");
    Console.WriteLine($"не изменило исходную точку\n{point}");
}

static void VectorExample()
{
    var p1 = new Point(2, 3);
    var p2 = new Point(3, 1);
    Vector a = new Vector(p1, p2);
    Vector b = new Vector(2, 3);

    Console.WriteLine($"a = {a}");
    Console.WriteLine($"b = {b}");

    Console.WriteLine($"a + b = {a + b}");
    Console.WriteLine($"a - b = {a - b}");

    a *= 5;
    Console.WriteLine($"a * 5 = {a}");

    b *= 5;
    Console.WriteLine($"b * 5 = {b}");
}

static void PointBoolExample()
{
    //var p1 = new Point(2, 3);
    //var p2 = new Point(3, 1);
    //if (p1)
    //    Console.WriteLine("Точка не в начале координат");
    
    //else
    //    Console.WriteLine("Точка в начале координат");

    Point p1 = new(10, 10);
    Point p2 = new(0,0);

    Console.WriteLine($"p1 && p2 = {(p1 && p2 ? true : false)}");
    Console.WriteLine($"p1 || p2 = {(p1 || p2 ? true : false)}");

    
}

static void PointEqualsExample()
{
    var p1 = new Point(2, 3);
    var p2 = new Point(2, 3);
    Console.WriteLine($"p1 == p2 = {p1 == p2}");
    Console.WriteLine($"p1.Equals(p2) = {p1.Equals(p2)}");
}
static void PointGetHashCodeExample()
{
    var p1 = new Point(2, 3);
    var p2 = new Point(2, 3);
    Console.WriteLine($"p1.GetHashCode() = {p1.GetHashCode()}");
    Console.WriteLine($"p2.GetHashCode() = {p2.GetHashCode()}");
}

static void PointCastExample()
{
    var point = new Point(10, 10);
    int value = 45;
    point = value;
    Console.WriteLine($"point to int: {(int)point}");
    Console.WriteLine($"int to point: {point}");

}

static void MatrixExample()
{
    Matrix matrix = new();
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            matrix[i, j] = i + j;
        }
    }

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }

    for (int i = 0; i < 12; i++)
    {
        Console.Write($"{matrix[i]} ");
    }
}
