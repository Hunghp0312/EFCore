using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Project
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
    public List<ProjectEmployee> Project_Employees { get; } = new List<ProjectEmployee>();
}
