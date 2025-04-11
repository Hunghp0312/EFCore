using BLL.CustomException;
using BLL.DTOs.Salary;
using DAL.Entity;
using DAL.Repository;
namespace BLL.Services;

public class SalaryServices : ISalaryServices
{
    private readonly ISalaryRepository _salaryRepository;
    private readonly IEmployeeRepository _employeeRepository;
    public SalaryServices(ISalaryRepository salaryRepository, IEmployeeRepository employeeRepository)
    {
        _salaryRepository = salaryRepository;
        _employeeRepository = employeeRepository;
    }
    public async Task<SalaryResponseDTO> AddSalaryAsync(SalaryRequestDTO salaryDto)
    {
        var employee = await _employeeRepository.GetByIdAsync(salaryDto.EmployeeId) ?? throw new NotFoundException($"Employee with ID {salaryDto.EmployeeId} not found.");
        var salary = new Salaries
        {
            Id = Guid.NewGuid(),
            EmployeeId = employee.Id,
            Salary = salaryDto.Salary,
        };
        salary = await _salaryRepository.AddAsync(salary);
        await _salaryRepository.SaveChangesAsync();
        var salaryResponse = new SalaryResponseDTO
        {
            Id = salary.Id,
            EmployeeId = salary.EmployeeId,
            Salary = salary.Salary,
            EmployeeName = salary.Employee.Name,
        };

        return salaryResponse;
    }
    public async Task<IEnumerable<SalaryResponseDTO>> GetAllSalaryAsync()
    {
        var salaries = await _salaryRepository.GetAllAsync();
        var salaryResponse = salaries.Select(s => new SalaryResponseDTO
        {
            Id = s.Id,
            EmployeeId = s.EmployeeId,
            Salary = s.Salary,
            EmployeeName = s.Employee.Name,
        }).ToList();
        return salaryResponse;
    }
    public async Task<SalaryResponseDTO> GetSalaryByIdAsync(Guid id)
    {
        var salary = await _salaryRepository.GetByIdAsync(id) ?? throw new NotFoundException($"Salary with ID {id} not found.");
        var salaryResponse = new SalaryResponseDTO
        {
            Id = salary.Id,
            EmployeeId = salary.EmployeeId,
            Salary = salary.Salary,
            EmployeeName = salary.Employee.Name,
        };
        return salaryResponse;
    }
    public async Task RemoveSalaryAsync(Guid id)
    {
        var salary = await _salaryRepository.GetByIdAsync(id) ?? throw new NotFoundException($"Salary with ID {id} not found.");
        _salaryRepository.Remove(salary);
        await _salaryRepository.SaveChangesAsync();
    }
    public async Task<SalaryResponseDTO> UpdateSalaryAsync(Guid id, SalaryRequestDTO salaryDto)
    {
        var salary = await _salaryRepository.GetByIdAsync(id) ?? throw new NotFoundException($"Salary with ID {id} not found.");
        var employee = await _employeeRepository.GetByIdAsync(salaryDto.EmployeeId) ?? throw new NotFoundException($"Employee with ID {salaryDto.EmployeeId} not found.");
        salary.EmployeeId = employee.Id;
        salary.Salary = salaryDto.Salary;
        await _salaryRepository.SaveChangesAsync();
        var salaryResponse = new SalaryResponseDTO
        {
            Id = salary.Id,
            EmployeeId = salary.EmployeeId,
            Salary = salary.Salary,
            EmployeeName = salary.Employee.Name,
        };

        return salaryResponse;
    }
}
