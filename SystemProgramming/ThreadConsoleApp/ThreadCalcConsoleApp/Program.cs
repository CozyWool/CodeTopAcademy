object obj = new object();
int number = 0;
var t = new Thread(SumNumber);

t.Start();
for (int i = 0; i < 1000000; i++)
{
    /* 3 операции:
    1. обращение к переменной number и получение ее значения
    2. сложить
    3. присвоить новое значение переменной number
    number++; ---> */
    lock (obj)
    {
        number = number + 1;
    }
}

t.Join();

Console.WriteLine(number);
Console.WriteLine(number);


void SumNumber()
{
    for (int i = 0; i < 1000000; i++)
    {
        lock (obj)
        {
            number++;
        }
    }
}