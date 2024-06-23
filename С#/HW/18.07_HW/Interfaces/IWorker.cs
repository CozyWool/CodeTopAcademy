namespace _18._07_HW.Interfaces
{
    public interface IWorker
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public House House { get; set; }
        public void Work();
    }
}
