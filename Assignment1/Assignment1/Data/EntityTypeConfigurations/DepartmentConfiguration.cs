using Assignment1.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment1.Data.EntityTypeConfigurations
{
    public class DepartmentConfiguration :IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Configure the primary key
            builder.HasKey(department => department.Id);

            // Configure the properties
            builder.Property(department => department.Name)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
