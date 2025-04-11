using BLL.DTOs.Project;

namespace BLL.Services;

public interface IProjectServices
{
    Task<IEnumerable<ProjectResponseDTO>> GetAllProjectAsync();
    Task<ProjectResponseDTO> GetProjectByIdAsync(Guid id);
    Task<ProjectResponseDTO> AddProjectAsync(ProjectRequestDTO project);
    Task<ProjectResponseDTO> UpdateProjectAsync(Guid id, ProjectRequestDTO project);
    Task DeleteProjectAsync(Guid id);
}
