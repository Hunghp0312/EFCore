using BLL.DTOs.Employee;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeSevices _employeeServices;

    public EmployeesController(IEmployeeSevices employeeServices)
    {
        _employeeServices = employeeServices;
    }

    [HttpGet("include-department")]
    public async Task<IActionResult> GetAllEmployeeIncludeDepartment()
    {
        var employees = await _employeeServices.GetAllEmployeeIncludeDepartment();

        return Ok(employees);
    }
    [HttpGet("include-department-raw-sql")]
    public async Task<IActionResult> GetAllEmployeeIncludeDepartmentRawSql()
    {
        var employees = await _employeeServices.GetAllEmployeeIncludeDepartmentRawSql();
        return Ok(employees);
    }
    [HttpGet("include-project-raw-sql")]
    public async Task<IActionResult> GetAllEmployeeIncludeProjectRawSql()
    {
        var employees = await _employeeServices.GetAllEmployeeIncludeProjectRawSql();
        return Ok(employees);
    }

    [HttpGet("include-project")]
    public async Task<IActionResult> GetAllEmployeeIncludeProject()
    {
        var employees = await _employeeServices.GetAllEmployeeIncludeProjectRawSql();

        return Ok(employees);
    }

    [HttpGet("with-salary-joined-date")]
    public async Task<IActionResult> GetAllEmployeeIncludeSalary()
    {
        var employees = await _employeeServices.GetAllEmployeeIncludeSalary();

        return Ok(employees);
    }

    [HttpGet("include-salary-raw-sql")]
    public async Task<IActionResult> GetAllEmployeeIncludeSalaryRawSql()
    {
        var employees = await _employeeServices.GetAllEmployeeIncludeSalaryRawSql();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(Guid id)
    {
        var employee = await _employeeServices.GetEmployeeByIdAsync(id);

        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody] EmployeeCreateUpdateDTO employeeDto)
    {
        var employee = await _employeeServices.AddEmployeeAsync(employeeDto);

        return StatusCode(201, employee);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] EmployeeCreateUpdateDTO employeeDto)
    {
        var updatedEmployee = await _employeeServices.UpdateEmployeeAsync(id, employeeDto);

        return Ok(updatedEmployee);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        await _employeeServices.RemoveEmployeeAsync(id);

        return NoContent();
    }
}
