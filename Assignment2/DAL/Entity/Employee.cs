namespace DAL.Entity;

public class Employee
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public DateTime JoinedDate { get; set; }
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
    public Salaries Salary { get; set; } = null!;
    public List<ProjectEmployee> ProjectEmployees { get; } = [];
}
