using Assignment1.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment1.Data.EntityTypeConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        // Configure the primary key
        builder.HasKey(employee => employee.Id);

        // Configure the properties
        builder.Property(employee => employee.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(employee => employee.JoinedDate)
               .IsRequired()
               .HasColumnType("datetime2");

        // Configure the relationships
        builder.HasOne(employee => employee.Department)
               .WithMany(department => department.Employees)
               .HasForeignKey(employee => employee.DepartmentId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(employee => employee.Salary)
               .WithOne(salary => salary.Employee)
               .HasForeignKey<Salaries>(salary => salary.EmployeeId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
