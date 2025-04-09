using Assignment1.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment1.Data.EntityTypeConfigurations;

public class SalaryConfiguration : IEntityTypeConfiguration<Salaries>
{
    public void Configure(EntityTypeBuilder<Salaries> builder)
    {
        // Configure the primary key
        builder.HasKey(salary => salary.Id);

        // Configure the properties
        builder.Property(salary => salary.Salary)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        // Configure the relationships
        builder.HasOne(salary => salary.Employee)
               .WithOne(employee => employee.Salary)
               .HasForeignKey<Salaries>(salary => salary.EmployeeId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}