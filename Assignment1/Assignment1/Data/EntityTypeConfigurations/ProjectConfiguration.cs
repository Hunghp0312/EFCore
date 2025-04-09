using Assignment1.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment1.Data.EntityTypeConfigurations;

public class ProjectConfiguration :IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        // Configure the primary key
        builder.HasKey(project => project.Id);

        // Configure the properties
        builder.Property(project => project.Name)
               .IsRequired()
               .HasMaxLength(100);
    }
}