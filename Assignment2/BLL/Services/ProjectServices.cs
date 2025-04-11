using BLL.CustomException;
using BLL.DTOs.Project;
using DAL.Entity;
using DAL.Repository;

namespace BLL.Services;

public class ProjectServices : IProjectServices
{
    private readonly IProjectRepository _projectRepository;
    public ProjectServices(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    public async Task<ProjectResponseDTO> AddProjectAsync(ProjectRequestDTO projectRequest)
    {
        var project = new Project
        {
            Id = Guid.NewGuid(),
            Name = projectRequest.Name,
        };
        var projectResponse =  await _projectRepository.AddAsync(project);
        await _projectRepository.SaveChangesAsync();
        return new ProjectResponseDTO
        {
            Id = projectResponse.Id,
            Name = projectResponse.Name,
        };


    }

    public async Task DeleteProjectAsync(Guid id)
    {
        var project = await  _projectRepository.GetByIdAsync(id) ?? throw new NotFoundException($"Project with ID {id} not found.");
        _projectRepository.Remove(project);
        await _projectRepository.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProjectResponseDTO>> GetAllProjectAsync()
    {
        var projects = await _projectRepository.GetAllAsync();
        var projectResponse = projects.Select(p => new ProjectResponseDTO
        {
            Id = p.Id,
            Name = p.Name,
        }).ToList();
        return projectResponse;
    }

    public async Task<ProjectResponseDTO> GetProjectByIdAsync(Guid id)
    {
        var project = await _projectRepository.GetByIdAsync(id);
        if (project == null)
        {
            throw new NotFoundException($"Project with ID {id} not found.");
        }
        var projectResponse = new ProjectResponseDTO
        {
            Id = project.Id,
            Name = project.Name,
        };
        return projectResponse;
    }

    public async Task<ProjectResponseDTO> UpdateProjectAsync(Guid id, ProjectRequestDTO projectRequest)
    {
        var project = await _projectRepository.GetByIdAsync(id);
        if (project == null)
        {
            throw new NotFoundException($"Project with ID {id} not found.");
        }
        project.Name = project.Name;
        await _projectRepository.SaveChangesAsync();
        return new ProjectResponseDTO
        {
            Id = project.Id,
            Name = project.Name,
        };

    }
}
