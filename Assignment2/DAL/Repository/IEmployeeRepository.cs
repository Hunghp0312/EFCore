using BLL.DTOs;
using DAL.Entity;
using DAL.RawSqlDTO;

namespace DAL.Repository;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<IEnumerable<Employee>> GetAllEmployeeIncludeDepartment();
    Task<IEnumerable<Employee>> GetAllEmployeeIncludeProject();
    Task<IEnumerable<Employee>> GetAllEmployeeIncludeSalary();
    Task<IEnumerable<EmployeeDepartmentDTO>> GetAllEmployeeIncludeDepartmentRawSql();
    Task<IEnumerable<EmployeeProjectDTO>> GetAllEmployeeIncludeProjectRawSql();
    Task<IEnumerable<EmployeeSalaryDTO>> GetAllEmployeeIncludeSalaryRawSql();
    Task<Employee> UpdateAsync(Employee entity);
}
