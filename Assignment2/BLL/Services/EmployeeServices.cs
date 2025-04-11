using BLL.CustomException;
using BLL.DTOs.Employee;
using BLL.Mapper;
using DAL.Entity;
using DAL.Repository;

namespace BLL.Services;

public class EmployeeServices : IEmployeeSevices
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDepartmentRepository _departmentRepository;

    public EmployeeServices(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
    }

    public async Task<Employee> AddEmployeeAsync(EmployeeCreateUpdateDTO employeeDto)
    {
        var department = await _departmentRepository.GetByIdAsync(employeeDto.DepartmentId) ?? throw new NotFoundException($"Department with ID {employeeDto.DepartmentId} not found.");
        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            Name = employeeDto.Name,
            DepartmentId = employeeDto.DepartmentId,
            JoinedDate = employeeDto.JoinedDate
        };

        return await _employeeRepository.AddAsync(employee);
    }

    public async Task<IEnumerable<EmployeeDepartmentResponseDTO>> GetAllEmployeeIncludeDepartment()
    {
        var employees = await _employeeRepository.GetAllEmployeeIncludeDepartment();
        var employeesReponse = EmployeeMapper.MapToEmployeeResponseDTOs(employees);

        return employeesReponse;
    }

    public async Task<IEnumerable<EmployeeDepartmentResponseDTO>> GetAllEmployeeIncludeDepartmentRawSql()
    {
        var employees = await _employeeRepository.GetAllEmployeeIncludeDepartmentRawSql();
        var employeesReponse = EmployeeMapper.MapToEmployeeResponseDTOs(employees);

        return employeesReponse;
    }

    public async Task<IEnumerable<EmployeeProjectResponseDTO>> GetAllEmployeeIncludeProject()
    {
        var employees = await _employeeRepository.GetAllEmployeeIncludeProject();
        var employeesReponse = EmployeeMapper.MapToEmployeeProjectResponseDTOs(employees);

        return employeesReponse;
    }

    public async Task<IEnumerable<EmployeeProjectResponseDTO>> GetAllEmployeeIncludeProjectRawSql()
    {
        var employees = await _employeeRepository.GetAllEmployeeIncludeProjectRawSql();
        var employeesReponse = EmployeeMapper.MapToEmployeeProjectResponseDTOs(employees);

        return employeesReponse;
    }

    public async Task<IEnumerable<EmployeeSalaryResponseDTO>> GetAllEmployeeIncludeSalary()
    {
        var employees = await _employeeRepository.GetAllEmployeeIncludeSalary();
        var employeesReponse = EmployeeMapper.MapToEmployeeSalaryResponseDTOs(employees);

        return employeesReponse;
    }

    public async Task<IEnumerable<EmployeeSalaryResponseDTO>> GetAllEmployeeIncludeSalaryRawSql()
    {
        var employees = await _employeeRepository.GetAllEmployeeIncludeSalaryRawSql();
        var employeesReponse = employees.Select(e =>
        new EmployeeSalaryResponseDTO
        { Id = e.Id, Name = e.Name, Salary = e.Salary, JoinedDate = e.JoinedDate });
        return employeesReponse;
    }

    public async Task<Employee> GetEmployeeByIdAsync(Guid id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id) ?? throw new NotFoundException($"Employee with ID {id} not found.");

        return employee;
    }

    public async Task RemoveEmployeeAsync(Guid id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id) ?? throw new NotFoundException($"Employee with ID {id} not found.");
        _employeeRepository.Remove(employee);
        await _employeeRepository.SaveChangesAsync();
    }

    public async Task<Employee> UpdateEmployeeAsync(Guid id, EmployeeCreateUpdateDTO employeeDto)
    {
        var employee = await _employeeRepository.GetByIdAsync(id) ?? throw new NotFoundException($"Employee with ID {id} not found.");
        _ = await _departmentRepository.GetByIdAsync(employeeDto.DepartmentId) ?? throw new NotFoundException($"Department with ID {employeeDto.DepartmentId} not found.");
        employee.Name = employeeDto.Name;
        employee.DepartmentId = employeeDto.DepartmentId;
        employee.JoinedDate = employeeDto.JoinedDate;
        await _employeeRepository.SaveChangesAsync();

        return employee;
    }
}
