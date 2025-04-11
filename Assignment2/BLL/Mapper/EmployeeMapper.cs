using BLL.DTOs;
using BLL.DTOs.Employee;
using DAL.Entity;
using DAL.RawSqlDTO;

namespace BLL.Mapper;

public class EmployeeMapper
{
    public static Employee MapToEntity(EmployeeCreateUpdateDTO employeeDto)
    {
        return new Employee
        {
            Id = Guid.NewGuid(),
            Name = employeeDto.Name,
            DepartmentId = employeeDto.DepartmentId,
            JoinedDate = employeeDto.JoinedDate
        };
    }
    public static IEnumerable<EmployeeDepartmentResponseDTO> MapToEmployeeResponseDTOs(IEnumerable<Employee> employees)
    {
        return employees.Select(e => new EmployeeDepartmentResponseDTO
        {
            Id = e.Id,
            Name = e.Name,
            DepartmentId = e.DepartmentId,
            JoinedDate = e.JoinedDate,
            DepartmentName = e.Department.Name,
        });
    }
    public static IEnumerable<EmployeeDepartmentResponseDTO> MapToEmployeeResponseDTOs(IEnumerable<EmployeeDepartmentDTO> employees)
    {
        return employees.Select(e => new EmployeeDepartmentResponseDTO
        {
            Id = e.Id,
            Name = e.Name,
            DepartmentId = e.DepartmentId,
            JoinedDate = e.JoinedDate,
            DepartmentName = e.DepartmentName,
        });
    }
    public static IEnumerable<EmployeeProjectResponseDTO> MapToEmployeeProjectResponseDTOs(IEnumerable<EmployeeProjectDTO> employees)
    {
        var groupedResults = employees
                            .GroupBy(x => x.Id)
                            .Select(g => new EmployeeProjectResponseDTO
                            {
                                Id = g.Key,
                                Name = g.First().Name,
                                JoinedDate = g.First().JoinedDate,
                                ProjectName = g.Select(c => c.ProjectName).ToList()
                            })
                            .ToList();
        return groupedResults;
    }

    public static IEnumerable<EmployeeProjectResponseDTO> MapToEmployeeProjectResponseDTOs(IEnumerable<Employee> employees)
    {
        return employees.Select(e => new EmployeeProjectResponseDTO
        {
            Id = e.Id,
            Name = e.Name,
            JoinedDate = e.JoinedDate,
            ProjectName = e.ProjectEmployees.Select(pe => pe.Project.Name),
        });
    }
    public static IEnumerable<EmployeeSalaryResponseDTO> MapToEmployeeSalaryResponseDTOs(IEnumerable<Employee> employees)
    {
        return employees.Select(e => new EmployeeSalaryResponseDTO
        {
            Id = e.Id,
            Name = e.Name,
            JoinedDate = e.JoinedDate,
            Salary = e.Salary.Salary,
        });
    }
}
