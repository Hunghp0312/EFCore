using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Salary;

public class SalaryRequestDTO
{
    [Required]
    public decimal Salary { get; set; }
    public Guid EmployeeId { get; set; }
}
