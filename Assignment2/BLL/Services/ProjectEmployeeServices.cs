using BLL.CustomException;
using BLL.DTOs.ProjectEmployee;
using DAL.Entity;
using DAL.Repository;

namespace BLL.Services;

public class ProjectEmployeeServices : IProjectEmployeeServices
{
    private readonly IProjectEmployeeRepository _projectEmployeeRepository;
    public ProjectEmployeeServices(IProjectEmployeeRepository projectEmployeeRepository)
    {
        _projectEmployeeRepository = projectEmployeeRepository;
    }
    public async Task<IEnumerable<ProjectEmployeeResponseDTO>> GetAllProjectEmployeeAsync()
    {
        var projectEmployees = await _projectEmployeeRepository.GetAllAsync();
        var projectEmployeesResponse = projectEmployees.Select(pe => new ProjectEmployeeResponseDTO { EmployeeId = pe.EmployeeId, Enable = pe.Enable, ProjectId = pe.ProjectId });
        return projectEmployeesResponse;
    }
    public async Task<ProjectEmployeeResponseDTO> GetProjectEmployeeByIdAsync(Guid id)
    {
        var projectEmployee =  await _projectEmployeeRepository.GetByIdAsync(id) ?? throw new NotFoundException($"ProjectEmployee with ID {id} not found.");
        
        return new ProjectEmployeeResponseDTO
        {
            EmployeeId = projectEmployee.EmployeeId,
            Enable = projectEmployee.Enable,
            ProjectId = projectEmployee.ProjectId
        };
    }
    public async Task<ProjectEmployeeResponseDTO> AddProjectEmployeeAsync(ProjectEmployeeRequestDTO projectEmployee)
    {
        var projectEmployeeEntity = new ProjectEmployee
        {
            EmployeeId = projectEmployee.EmployeeId,
            Enable = projectEmployee.Enable,
            ProjectId = projectEmployee.ProjectId
        };
        var addedProjectEmployee = await _projectEmployeeRepository.AddAsync(projectEmployeeEntity);
        await _projectEmployeeRepository.SaveChangesAsync();
        return new ProjectEmployeeResponseDTO
        {
            EmployeeId = addedProjectEmployee.EmployeeId,
            Enable = addedProjectEmployee.Enable,
            ProjectId = addedProjectEmployee.ProjectId
        };
    }
    public async Task<ProjectEmployeeResponseDTO> UpdateProjectEmployeeAsync(Guid id, ProjectEmployeeRequestDTO projectEmployeeRequest)
    {
        var projectEmployee = await _projectEmployeeRepository.GetByIdAsync(id) ?? throw new NotFoundException($"ProjectEmployee with ID {id} not found.");
        projectEmployee.EmployeeId = projectEmployeeRequest.EmployeeId;
        projectEmployee.Enable = projectEmployeeRequest.Enable;
        projectEmployee.ProjectId = projectEmployeeRequest.ProjectId;
        await _projectEmployeeRepository.SaveChangesAsync();
        return new ProjectEmployeeResponseDTO
        {
            EmployeeId = projectEmployee.EmployeeId,
            Enable = projectEmployee.Enable,
            ProjectId = projectEmployee.ProjectId
        };
    }
    public async Task RemoveProjectEmployeeAsync(Guid id)
    {
        var projectEmployee = await _projectEmployeeRepository.GetByIdAsync(id) ?? throw new NotFoundException($"ProjectEmployee with ID {id} not found.");
        _projectEmployeeRepository.Remove(projectEmployee);
        await _projectEmployeeRepository.SaveChangesAsync();
    }
}
