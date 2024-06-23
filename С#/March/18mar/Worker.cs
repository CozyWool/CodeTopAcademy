namespace _18mar
{
    public class Worker : IWorker, IHasStaff
    {
        private bool _isWorking = true;
        public string Name { get; set; }
        List<Worker> IHasStaff.Employees { get; set; } = new List<Worker>();

        Worker IHasStaff.this[int index] 
        {
            get 
            {
                IHasStaff staff = this;
                return staff.Employees[index];
            }
            set
            {
                IHasStaff staff = this;
                staff.Employees[index] = value;
            }
        }

        public event EventHandler<string>? WorkEnd;

        public Worker()
        {
            Name = "John";
        }
        public Worker(string name)
        {
            Name = name;
        }

        public void DoWork(string workName)
        {
            Console.WriteLine($"{Name} делает работу: {workName}");
        }

        public void EndWork()
        {
            _isWorking = false;
            //if (WorkEnd != null) 
            //{
            //    WorkEnd(this, $"{Name} закончил свою работу");
            //}
            WorkEnd?.Invoke(this, $"{Name} закончил свою работу");
        }

        public bool IsWorking()
        {
            return _isWorking;
        }
    }
}
