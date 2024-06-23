public class MyException : Exception
{
    public MyException() : base("Моё кастомное исключение") { }
    public MyException(string message, Exception innerException) : base(message, innerException) { }
}
