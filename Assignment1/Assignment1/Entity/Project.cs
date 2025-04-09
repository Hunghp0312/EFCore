namespace Assignment1.Entity;

public class Project
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<ProjectEmployee> Project_Employees { get; } = [];
}
