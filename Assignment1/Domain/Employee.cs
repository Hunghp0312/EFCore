using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Employee
{
    [Key]

    public Guid Id { get; set; }
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
    [Required]
    public DateTime JoinedDate { get; set; }

    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }

    public Guid SalaryId { get; set; }
    public Salary Salary { get; set; }

    public List<ProjectEmployee> Project_Employees { get; } = new List<ProjectEmployee>();
}
