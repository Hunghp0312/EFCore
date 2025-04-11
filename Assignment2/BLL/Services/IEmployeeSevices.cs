using BLL.DTOs.Employee;
using DAL.Entity;

namespace BLL.Services;

public interface IEmployeeSevices
{
    Task<IEnumerable<EmployeeDepartmentResponseDTO>> GetAllEmployeeIncludeDepartment();
    Task<IEnumerable<EmployeeProjectResponseDTO>> GetAllEmployeeIncludeProject();
    Task<IEnumerable<EmployeeSalaryResponseDTO>> GetAllEmployeeIncludeSalary();
    Task<IEnumerable<EmployeeDepartmentResponseDTO>> GetAllEmployeeIncludeDepartmentRawSql();
    Task<IEnumerable<EmployeeProjectResponseDTO>> GetAllEmployeeIncludeProjectRawSql();
    Task<IEnumerable<EmployeeSalaryResponseDTO>> GetAllEmployeeIncludeSalaryRawSql();
    Task<Employee> GetEmployeeByIdAsync(Guid id);
    Task<Employee> AddEmployeeAsync(EmployeeCreateUpdateDTO employeeDto);
    Task<Employee> UpdateEmployeeAsync(Guid id, EmployeeCreateUpdateDTO employeeDto);
    Task RemoveEmployeeAsync(Guid id);

}
