namespace DataGridWpfApp
{
    public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public Employee() : this("", "", 0, false) { }

        public Employee(string name, string surname, int age, bool isActive)
        {
            Name = name;
            Surname = surname;
            Age = age;
            IsActive = isActive;
        }
    }
}
