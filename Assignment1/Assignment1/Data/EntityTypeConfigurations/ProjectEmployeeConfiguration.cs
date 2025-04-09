using Assignment1.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment1.Data.EntityTypeConfigurations;

public class ProjectEmployeeConfiguration : IEntityTypeConfiguration<ProjectEmployee>
{
    public void Configure(EntityTypeBuilder<ProjectEmployee> builder)
    {
        // Configure the primary key
        builder.HasKey(projectEmployee => new { projectEmployee.ProjectId, projectEmployee.EmployeeId });

        // Configure the properties
        builder.Property(projectEmployee => projectEmployee.Enable)
               .IsRequired();

        // Configure the relationships
        builder.HasOne(projectEmployee => projectEmployee.Project)
               .WithMany(project => project.Project_Employees)
               .HasForeignKey(projectEmployee => projectEmployee.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(projectEmployee => projectEmployee.Employee)
               .WithMany(employee => employee.Project_Employees)
               .HasForeignKey(projectEmployee => projectEmployee.EmployeeId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}