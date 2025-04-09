namespace Assignment1.Entity;

public class Salaries
{
    public Guid Id { get; set; }
    public decimal Salary { get; set; }
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
}
