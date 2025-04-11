using DAL.Entity;

namespace BLL.DTOs.Project;

public class ProjectResponseDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
