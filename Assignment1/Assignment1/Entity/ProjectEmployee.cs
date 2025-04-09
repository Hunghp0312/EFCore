namespace Assignment1.Entity;

public class ProjectEmployee
{
    public Guid ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
    public bool Enable { get; set; }
}
