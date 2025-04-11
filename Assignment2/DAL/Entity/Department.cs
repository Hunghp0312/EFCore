namespace DAL.Entity;

public class Department
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<Employee> Employees { get; } = [];
}
