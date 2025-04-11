using BLL.DTOs;
using DAL.Entity;
using DAL.RawSqlDTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Salaries> Salaries { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
    public DbSet<EmployeeDepartmentDTO> EmployeeDepartmentDTOs { get; set; }
    public DbSet<EmployeeProjectDTO> EmployeeProjectDTOs { get; set; }
    public DbSet<EmployeeSalaryDTO> EmployeeSalaryDTOs { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeDepartmentDTO>().HasNoKey().ToView(null);
        modelBuilder.Entity<EmployeeProjectDTO>().HasNoKey().ToView(null);
        modelBuilder.Entity<EmployeeSalaryDTO>().HasNoKey().ToView(null);
        // Apply configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        // Seed Data
        var dep1 = Guid.Parse("5b671e57-cc34-4c2a-85f4-052d4986fc3f"); var dep2 = Guid.Parse("34f1fc66-f258-4470-8c79-16f86f030ec9"); var dep3 = Guid.Parse("f5bd00a2-2f2a-4a60-9e20-c7c8cb78583e");
        var dep4 = Guid.Parse("78a83ad9-d7c1-4cc7-9134-8813fa8ad3e9");

        var emp1 = Guid.Parse("0fae57cc-486b-499c-a0ae-84dc4f5f0d3e"); var emp2 = Guid.Parse("a792e5b5-4a38-4957-b8ce-2907aebcebe6"); var emp3 = Guid.Parse("d0d5a610-ecdd-4ed7-b7df-d76b74b0f78b");
        var emp4 = Guid.Parse("7dc4313e-b237-4a7e-bfa9-4edc5a86000c"); var emp5 = Guid.Parse("3e6f0cf7-8fe6-47f1-8474-2f10a2a67e67"); var emp6 = Guid.Parse("b3691587-ff4e-4e0b-b7f9-86bc058f4c38");

        var proj1 = Guid.Parse("4b0b00f0-3372-44e1-96ee-3bb5382e540b"); var proj2 = Guid.Parse("12c0bc46-df24-4cf0-ae91-0b1613478a9b"); var proj3 = Guid.Parse("62792c90-1772-439a-85f0-2f2e9c6922ce");

        var sal1 = Guid.Parse("0b138abc-2972-44d2-bb4e-3297c1c7dc70"); var sal2 = Guid.Parse("3826c308-9644-4190-8d0c-1a2f3074ec2e"); var sal3 = Guid.Parse("bfcfe80f-259c-4f20-b153-f8c7c3e89ed6");
        var sal4 = Guid.Parse("f7d3ff43-4639-4812-b508-5fcdd648e7c0"); var sal5 = Guid.Parse("0566d7a5-442b-49db-8d7e-b7662311d238");

        modelBuilder.Entity<Department>().HasData(
            new Department { Id = dep1, Name = "Software Development" },
            new Department { Id = dep2, Name = "Finance" },
            new Department { Id = dep3, Name = "Accountant" },
            new Department { Id = dep4, Name = "HR" }
        );

        modelBuilder.Entity<Project>().HasData(
            new Project { Id = proj1, Name = "Website Redesign" },
            new Project { Id = proj2, Name = "Recruitment Drive" },
            new Project { Id = proj3, Name = "Budget Planning" }
        );

        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = emp1, Name = "Alice", DepartmentId = dep1, JoinedDate = new DateTime(2024, 5, 1) },
            new Employee { Id = emp2, Name = "Bob", DepartmentId = dep2, JoinedDate = new DateTime(2024, 1, 15) },
            new Employee { Id = emp3, Name = "Charlie", DepartmentId = dep1, JoinedDate = new DateTime(2021, 8, 20) },
            new Employee { Id = emp4, Name = "Diana", DepartmentId = dep3, JoinedDate = new DateTime(2022, 11, 5) },
            new Employee { Id = emp5, Name = "Charlie", DepartmentId = dep4, JoinedDate = new DateTime(2024, 8, 20) },
            new Employee { Id = emp6, Name = "Diana", DepartmentId = dep3, JoinedDate = new DateTime(2022, 11, 5) }
        );

        modelBuilder.Entity<ProjectEmployee>().HasData(
            new ProjectEmployee { ProjectId = proj1, EmployeeId = emp1, Enable = true },
            new ProjectEmployee { ProjectId = proj1, EmployeeId = emp3, Enable = true },
            new ProjectEmployee { ProjectId = proj2, EmployeeId = emp2, Enable = true },
            new ProjectEmployee { ProjectId = proj3, EmployeeId = emp4, Enable = false }
        );

        modelBuilder.Entity<Salaries>().HasData(
            new Salaries { Id = sal1, EmployeeId = emp1, Salary = 120 },
            new Salaries { Id = sal2, EmployeeId = emp2, Salary = 110 },
            new Salaries { Id = sal3, EmployeeId = emp3, Salary = 350 },
            new Salaries { Id = sal4, EmployeeId = emp4, Salary = 80 },
            new Salaries { Id = sal5, EmployeeId = emp5, Salary = 60 }
        );
    }
}
