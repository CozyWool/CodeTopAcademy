namespace _18mar
{
    public interface IHasStaff
    {
        List<Worker> Employees { get; set; }

        Worker this[int index] { get; set; }
    }
}
