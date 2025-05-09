﻿// <auto-generated />
using System;
using Assignment1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignment1.Entity.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5b671e57-cc34-4c2a-85f4-052d4986fc3f"),
                            Name = "Software Development"
                        },
                        new
                        {
                            Id = new Guid("34f1fc66-f258-4470-8c79-16f86f030ec9"),
                            Name = "Finance"
                        },
                        new
                        {
                            Id = new Guid("f5bd00a2-2f2a-4a60-9e20-c7c8cb78583e"),
                            Name = "Accountant"
                        },
                        new
                        {
                            Id = new Guid("78a83ad9-d7c1-4cc7-9134-8813fa8ad3e9"),
                            Name = "HR"
                        });
                });

            modelBuilder.Entity("Assignment1.Entity.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("JoinedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0fae57cc-486b-499c-a0ae-84dc4f5f0d3e"),
                            DepartmentId = new Guid("5b671e57-cc34-4c2a-85f4-052d4986fc3f"),
                            JoinedDate = new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Alice"
                        },
                        new
                        {
                            Id = new Guid("a792e5b5-4a38-4957-b8ce-2907aebcebe6"),
                            DepartmentId = new Guid("34f1fc66-f258-4470-8c79-16f86f030ec9"),
                            JoinedDate = new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Bob"
                        },
                        new
                        {
                            Id = new Guid("d0d5a610-ecdd-4ed7-b7df-d76b74b0f78b"),
                            DepartmentId = new Guid("5b671e57-cc34-4c2a-85f4-052d4986fc3f"),
                            JoinedDate = new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Charlie"
                        },
                        new
                        {
                            Id = new Guid("7dc4313e-b237-4a7e-bfa9-4edc5a86000c"),
                            DepartmentId = new Guid("f5bd00a2-2f2a-4a60-9e20-c7c8cb78583e"),
                            JoinedDate = new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Diana"
                        },
                        new
                        {
                            Id = new Guid("3e6f0cf7-8fe6-47f1-8474-2f10a2a67e67"),
                            DepartmentId = new Guid("78a83ad9-d7c1-4cc7-9134-8813fa8ad3e9"),
                            JoinedDate = new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Charlie"
                        },
                        new
                        {
                            Id = new Guid("b3691587-ff4e-4e0b-b7f9-86bc058f4c38"),
                            DepartmentId = new Guid("f5bd00a2-2f2a-4a60-9e20-c7c8cb78583e"),
                            JoinedDate = new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Diana"
                        });
                });

            modelBuilder.Entity("Assignment1.Entity.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4b0b00f0-3372-44e1-96ee-3bb5382e540b"),
                            Name = "Website Redesign"
                        },
                        new
                        {
                            Id = new Guid("12c0bc46-df24-4cf0-ae91-0b1613478a9b"),
                            Name = "Recruitment Drive"
                        },
                        new
                        {
                            Id = new Guid("62792c90-1772-439a-85f0-2f2e9c6922ce"),
                            Name = "Budget Planning"
                        });
                });

            modelBuilder.Entity("Assignment1.Entity.ProjectEmployee", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.HasKey("ProjectId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Project_Employees");

                    b.HasData(
                        new
                        {
                            ProjectId = new Guid("4b0b00f0-3372-44e1-96ee-3bb5382e540b"),
                            EmployeeId = new Guid("0fae57cc-486b-499c-a0ae-84dc4f5f0d3e"),
                            Enable = true
                        },
                        new
                        {
                            ProjectId = new Guid("4b0b00f0-3372-44e1-96ee-3bb5382e540b"),
                            EmployeeId = new Guid("d0d5a610-ecdd-4ed7-b7df-d76b74b0f78b"),
                            Enable = true
                        },
                        new
                        {
                            ProjectId = new Guid("12c0bc46-df24-4cf0-ae91-0b1613478a9b"),
                            EmployeeId = new Guid("a792e5b5-4a38-4957-b8ce-2907aebcebe6"),
                            Enable = true
                        },
                        new
                        {
                            ProjectId = new Guid("62792c90-1772-439a-85f0-2f2e9c6922ce"),
                            EmployeeId = new Guid("7dc4313e-b237-4a7e-bfa9-4edc5a86000c"),
                            Enable = false
                        });
                });

            modelBuilder.Entity("Assignment1.Entity.Salaries", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Salaries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0b138abc-2972-44d2-bb4e-3297c1c7dc70"),
                            EmployeeId = new Guid("0fae57cc-486b-499c-a0ae-84dc4f5f0d3e"),
                            Salary = 70000m
                        },
                        new
                        {
                            Id = new Guid("3826c308-9644-4190-8d0c-1a2f3074ec2e"),
                            EmployeeId = new Guid("a792e5b5-4a38-4957-b8ce-2907aebcebe6"),
                            Salary = 55000m
                        },
                        new
                        {
                            Id = new Guid("bfcfe80f-259c-4f20-b153-f8c7c3e89ed6"),
                            EmployeeId = new Guid("d0d5a610-ecdd-4ed7-b7df-d76b74b0f78b"),
                            Salary = 75000m
                        },
                        new
                        {
                            Id = new Guid("f7d3ff43-4639-4812-b508-5fcdd648e7c0"),
                            EmployeeId = new Guid("7dc4313e-b237-4a7e-bfa9-4edc5a86000c"),
                            Salary = 60000m
                        });
                });

            modelBuilder.Entity("Assignment1.Entity.Employee", b =>
                {
                    b.HasOne("Assignment1.Entity.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Assignment1.Entity.ProjectEmployee", b =>
                {
                    b.HasOne("Assignment1.Entity.Employee", "Employee")
                        .WithMany("Project_Employees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment1.Entity.Project", "Project")
                        .WithMany("Project_Employees")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Assignment1.Entity.Salaries", b =>
                {
                    b.HasOne("Assignment1.Entity.Employee", "Employee")
                        .WithOne("Salary")
                        .HasForeignKey("Assignment1.Entity.Salaries", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Assignment1.Entity.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Assignment1.Entity.Employee", b =>
                {
                    b.Navigation("Project_Employees");

                    b.Navigation("Salary")
                        .IsRequired();
                });

            modelBuilder.Entity("Assignment1.Entity.Project", b =>
                {
                    b.Navigation("Project_Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
