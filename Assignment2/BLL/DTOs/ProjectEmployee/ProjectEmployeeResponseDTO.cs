using BLL.DTOs.Project;

namespace BLL.DTOs.ProjectEmployee;

public class ProjectEmployeeResponseDTO
{
    public Guid ProjectId { get; set; }
    public Guid EmployeeId { get; set; }
    public bool Enable { get; set; }
}
