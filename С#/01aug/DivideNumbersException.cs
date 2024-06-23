public class DivideNumbersException : Exception
{
    private string message;
    public int NumberOne { get; set; }
    public int NumberTwo { get; set; }
    public DivideNumbersException(int numberOne, int numberTwo)
    {
        NumberOne = numberOne;
        NumberTwo = numberTwo;
        message = $"Деление {NumberOne} на {NumberTwo}";
    }
}
