using BLL.DTOs.Salary;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalariesController : ControllerBase
{
    private readonly ISalaryServices _salaryServices;

    public SalariesController(ISalaryServices salaryServices)
    {
        _salaryServices = salaryServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSalaries()
    {
        var salaries = await _salaryServices.GetAllSalaryAsync();
        return Ok(salaries);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSalaryById(Guid id)
    {
        var salary = await _salaryServices.GetSalaryByIdAsync(id);
        return Ok(salary);
    }

    [HttpPost]
    public async Task<IActionResult> AddSalary([FromBody] SalaryRequestDTO salaryDto)
    {
        var salary = await _salaryServices.AddSalaryAsync(salaryDto);
        return StatusCode(201, salary);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSalary(Guid id, [FromBody] SalaryRequestDTO salaryDto)
    {
        var updatedSalary = await _salaryServices.UpdateSalaryAsync(id, salaryDto);
        return Ok(updatedSalary);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSalary(Guid id)
    {
        await _salaryServices.RemoveSalaryAsync(id);
        return NoContent();
    }
}
