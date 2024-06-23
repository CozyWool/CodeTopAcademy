namespace TDSClientWpfApp;

public class ToDoTask
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public DateTime CreateDate { get; set; }
    
    public DateTime DeadlineDate { get; set; }
    
    public bool IsCompleted { get; set; }
}