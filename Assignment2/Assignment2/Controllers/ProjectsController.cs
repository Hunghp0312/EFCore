using BLL.DTOs.Project;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IProjectServices _projectServices;

    public ProjectsController(IProjectServices projectServices)
    {
        _projectServices = projectServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProjects()
    {
        var projects = await _projectServices.GetAllProjectAsync();

        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjectById(Guid id)
    {
        var project = await _projectServices.GetProjectByIdAsync(id);

        return Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> AddProject([FromBody] ProjectRequestDTO projectDto)
    {
        var project = await _projectServices.AddProjectAsync(projectDto);

        return StatusCode(201, project);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProject(Guid id, [FromBody] ProjectRequestDTO projectDto)
    {
        var updatedProject = await _projectServices.UpdateProjectAsync(id, projectDto);

        return Ok(updatedProject);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(Guid id)
    {
        await _projectServices.DeleteProjectAsync(id);

        return NoContent();
    }
}
