using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using DAL.Entity;
using BLL.DTOs.Department;
namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase

    {
        private readonly IDepartmentSevices _departmentServices;
        public DepartmentsController(IDepartmentSevices departmentServices)
        {
            _departmentServices = departmentServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _departmentServices.GetAllDepartmentsAsync();
            return Ok(departments);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(Guid id)
        {
            var department = await _departmentServices.GetDepartmentByIdAsync(id);
            return Ok(department);
        }
        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentCreateUpdateDTO departmentDto)
        {
            var department = await _departmentServices.AddDepartmentAsync(departmentDto);
            return StatusCode(201, department);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(Guid id, [FromBody] DepartmentCreateUpdateDTO departmentDto)
        {
            try
            {
                var updatedDepartment = await _departmentServices.UpdateDepartmentAsync(id, departmentDto);
                return Ok(updatedDepartment);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Department with ID {id} not found.");
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(Guid id)
        {
            try
            {
                await _departmentServices.RemoveDepartmentAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Department with ID {id} not found.");
            }

        }
    }
}
