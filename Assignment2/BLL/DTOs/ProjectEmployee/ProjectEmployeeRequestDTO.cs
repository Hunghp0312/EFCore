using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.ProjectEmployee;

public class ProjectEmployeeRequestDTO
{
    [Required]
    public Guid ProjectId { get; set; }
    [Required]
    public Guid EmployeeId { get; set; }
    [Required]
    public bool Enable { get; set; }
}
