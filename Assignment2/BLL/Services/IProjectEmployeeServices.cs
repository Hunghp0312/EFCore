using BLL.DTOs.ProjectEmployee;

namespace BLL.Services;

public interface IProjectEmployeeServices
{
    Task<IEnumerable<ProjectEmployeeResponseDTO>> GetAllProjectEmployeeAsync();
    Task<ProjectEmployeeResponseDTO> GetProjectEmployeeByIdAsync(Guid id);
    Task<ProjectEmployeeResponseDTO> AddProjectEmployeeAsync(ProjectEmployeeRequestDTO projectEmployee);
    Task<ProjectEmployeeResponseDTO> UpdateProjectEmployeeAsync(Guid id, ProjectEmployeeRequestDTO projectEmployee);
    Task RemoveProjectEmployeeAsync(Guid id);

}
