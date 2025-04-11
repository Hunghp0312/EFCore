using BLL.DTOs;
using DAL.Context;
using DAL.Entity;
using DAL.RawSqlDTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class EmployeeRepository : Repository<Employee>,  IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeeIncludeDepartment()
    {
        return await _dbSet.Include(e => e.Department).ToListAsync();
    }

    public async Task<IEnumerable<EmployeeDepartmentDTO>> GetAllEmployeeIncludeDepartmentRawSql()
    {
        var employees = await _context.Set<EmployeeDepartmentDTO>().FromSqlRaw(@"SELECT e.Id, e.Name, e.DepartmentId,e.JoinedDate, d.Name AS DepartmentName 
                                                                                FROM Employees e 
                                                                                INNER JOIN Departments d 
                                                                                ON e.DepartmentId = d.Id")
                                .ToListAsync();
        return employees;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeeIncludeProject()
    {
        return await _dbSet.Include(e => e.ProjectEmployees).ThenInclude(pe => pe.Project).ToListAsync();
    }

    public async Task<IEnumerable<EmployeeProjectDTO>> GetAllEmployeeIncludeProjectRawSql()
    {
        var employees = await _context.Set<EmployeeProjectDTO>().FromSqlRaw(@"SELECT e.Id, e.Name, p.Name AS ProjectName,e.JoinedDate,pe.Enable 
                                                                                FROM Employees e 
                                                                                JOIN ProjectEmployees pe ON e.Id = pe.EmployeeId 
                                                                                JOIN Projects AS p ON pe.ProjectId = p.Id")
                                                                .ToListAsync();
        return employees;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeeIncludeSalary()
    {
        var targetDate = new DateTime(2024, 1, 1);

        return await _dbSet.Include(e => e.Salary)
                    .Where(e => e.Salary.Salary > 100)
                    .Where(e => e.JoinedDate >= targetDate).ToListAsync();
    }

    public async Task<IEnumerable<EmployeeSalaryDTO>> GetAllEmployeeIncludeSalaryRawSql()
    {
        var employees = await _context.Set<EmployeeSalaryDTO>().FromSqlRaw(@"SELECT e.Id, e.Name, s.Salary, e.JoinedDate 
                                                            FROM Employees e 
                                                            JOIN Salaries s ON e.Id = s.EmployeeId 
                                                            WHERE s.Salary > 100 AND e.JoinedDate >= '2024-01-01'")
                                                            .ToListAsync();

        return employees;
    }

    public async Task<Employee> UpdateAsync(Employee entity)
    {
        // Custom logic for updating a Person entity can be added here
        var employee = await _dbSet.FindAsync(entity.Id) ?? throw new KeyNotFoundException($"Entity with ID {entity.Id} not found."); ;
        employee.Name = entity.Name;
        employee.JoinedDate = entity.JoinedDate;
        employee.DepartmentId = entity.DepartmentId;
        await _context.SaveChangesAsync();
        return employee;
    }
}
