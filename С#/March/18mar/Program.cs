using _18mar;
using System.Linq;
using System.Net.Http.Headers;

//WorkerExample();
//AuditoryExample();
ICloneableExample();

// IEnumerable
// IComparable
// IComparer
// IClonable

//TestMethod();

void WorkerExample()
{
    //IWorker
    Console.WriteLine("\n------IWorker------\n");
    Worker worker = new("Джон");
    worker.WorkEnd += Worker_WorkEnd;
    worker.DoWork("Домашнее задание");
    Console.WriteLine($"{worker.Name} работает? {(worker.IsWorking() ? "Да" : "Нет")}");
    worker.EndWork();
    Console.WriteLine("Отписывание от события EndWork");
    worker.WorkEnd -= Worker_WorkEnd;
    worker.EndWork();

    //IHasStaff
    Console.WriteLine("\n------IHasStaff------\n");
    IHasStaff staff = worker;
    staff.Employees.Add(new Worker("Tom"));
    staff.Employees.Add(new Worker("Mike"));
    for (int i = 0; i < staff.Employees.Count; i++)
    {
        Console.WriteLine($"{staff[i].Name}");
    }
}

void Worker_WorkEnd(object? sender, string message)
{
    var m = sender as Worker;
    if (m == null) return;
    Console.WriteLine(nameof(Worker_WorkEnd));
    Console.WriteLine($"{m.Name} работает? {(m.IsWorking() ? "Да" : "Нет")}");
    Console.WriteLine($"{message}");
    Console.WriteLine(nameof(Worker_WorkEnd));
}

void AuditoryExample()
{
    var auditory = new Auditory
    {
        new Student(45,"Иван", 123,new("Тюмень","Фабричная")),
        new Student(4,"Петр", 123, new("Тюмень", "Фабричная")),
        new Student(5,"Сергей", 123, new("Тюмень", "Фабричная"))
    };
    //foreach (var student in auditory)
    //{
    //    Console.WriteLine(student);
    //}
    var enumerator = auditory.GetEnumerator();
    while (enumerator.MoveNext())
    {
        var student = enumerator.Current;
        Console.WriteLine(student);
    }

    Console.WriteLine("\nОтсортированные студенты:");
    var array = auditory.ToArray();
    //Array.Sort(array, new StudentAscComparer());
    //Array.Sort(array, Compare); 
    Array.Sort(array, (x, y) => x.Id < y.Id ? 1 : x.Id > y.Id ? -1 : 0);
    foreach (var student in array)
    {
        Console.WriteLine(student);
    }
}
int Compare(Student? x, Student? y)
{
    if (x == null) return -1;
    if (y == null) return 1;

    if (x.Id < y.Id) return -1;
    if (x.Id > y.Id) return 1;
    return 0;
}

void ICloneableExample()
{
    var student = new Student(1, "Иван", 123, new("Тюмень", "Фабричная"));
    Student secondStudent = (Student)student.Clone();

    Console.WriteLine("Step 1");
    Console.WriteLine(student);
    Console.WriteLine(secondStudent);

    secondStudent.Id = 2;
    secondStudent.Name = "Петр";
    Console.WriteLine("Step 2");
    Console.WriteLine(student);
    Console.WriteLine(secondStudent);

    student.Address.Street = "50 лет Октября";
    student.Address = new();
    Console.WriteLine("Step 3");
    Console.WriteLine(student);
    Console.WriteLine(secondStudent);
}

void TestMethod()
{
    MyDelegate myDelegate = SendMessage1;
    myDelegate += SendMessage2;
    myDelegate("Привет, мир!");

    CalcResult calcResult = Sum;
    calcResult = Sub;

    Console.WriteLine(calcResult(1, 2));
}
void SendMessage1(string message)
{
    Console.WriteLine(message);
}
void SendMessage2(string message)
{
    foreach (var item in message)
    {
        Console.Write($"{item} ");
    }
    Console.WriteLine();
}
int Sum(int a, int b) => a + b;
int Sub(int a, int b) => a - b;


delegate void MyDelegate(string message);
delegate int CalcResult(int a, int b);



