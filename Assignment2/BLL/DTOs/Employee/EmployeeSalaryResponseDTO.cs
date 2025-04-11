namespace BLL.DTOs.Employee;

public class EmployeeSalaryResponseDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public decimal Salary { get; set; }
    public DateTime JoinedDate { get; set; }
}
