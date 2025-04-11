namespace BLL.DTOs.Salary;

public class SalaryResponseDTO
{
    public Guid Id { get; set; }
    public decimal Salary { get; set; }
    public Guid EmployeeId { get; set; }
    public required string EmployeeName { get; set; }
}
