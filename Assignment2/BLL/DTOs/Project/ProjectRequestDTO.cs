using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Project;

public class ProjectRequestDTO
{
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
}
