using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Department
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
    public List<Employee> Employees { get; } = new List<Employee>();
}
