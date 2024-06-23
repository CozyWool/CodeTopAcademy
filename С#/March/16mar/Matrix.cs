namespace _16mar;

public class Matrix
{
    private int[,] array = new int[3, 4];
    
    // тип_данных this[типы_аргументов] { get; set; }
    public int this[int row, int column]
    {
        get => array[row, column];
        set => array[row, column] = value;
    }
    
    public int this[int index]
    {
        get 
        {
            int row = index / 4;
            int column = index % 4 - 1;
            return array[row, column];
        }
        set
        {
            int row = index / 4;
            int column = index % 4 - 1;
            array[row, column] = value;
        }
    }
}
