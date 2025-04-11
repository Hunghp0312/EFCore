using BLL.DTOs.ProjectEmployee;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectEmployeesController : ControllerBase
{
    private readonly IProjectEmployeeServices _projectEmployeeServices;
    public ProjectEmployeesController(IProjectEmployeeServices projectEmployeeServices)
    {
        _projectEmployeeServices = projectEmployeeServices;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllProjectEmployees()
    {
        var projectEmployees = await _projectEmployeeServices.GetAllProjectEmployeeAsync();
        return Ok(projectEmployees);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjectEmployeeById(Guid id)
    {
        var projectEmployee = await _projectEmployeeServices.GetProjectEmployeeByIdAsync(id);

        return Ok(projectEmployee);
    }
    [HttpPost]
    public async Task<IActionResult> AddProjectEmployee([FromBody] ProjectEmployeeRequestDTO projectEmployeeDto)
    {
        var projectEmployee = await _projectEmployeeServices.AddProjectEmployeeAsync(projectEmployeeDto);

        return StatusCode(201, projectEmployee);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProjectEmployee(Guid id, [FromBody] ProjectEmployeeRequestDTO projectEmployeeDto)
    {
        var updatedProjectEmployee = await _projectEmployeeServices.UpdateProjectEmployeeAsync(id, projectEmployeeDto);

        return Ok(updatedProjectEmployee);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProjectEmployee(Guid id)
    {
        await _projectEmployeeServices.RemoveProjectEmployeeAsync(id);

        return NoContent();
    }
}
