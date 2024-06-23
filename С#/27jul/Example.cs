//delegate [(параметры)]
//{
//    // код
//}
public delegate void Show(string message);

public class Example
{
    public Show show;
    public void Test(string message)
    {
        if (show != null) show(message);
    }
}
