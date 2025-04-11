using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Employee;

public class EmployeeCreateUpdateDTO
{
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
    [Required]
    public DateTime JoinedDate { get; set; }
    [Required]
    public Guid DepartmentId { get; set; }
}
