using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEmployees",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployees", x => new { x.ProjectId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salaries_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("34f1fc66-f258-4470-8c79-16f86f030ec9"), "Finance" },
                    { new Guid("5b671e57-cc34-4c2a-85f4-052d4986fc3f"), "Software Development" },
                    { new Guid("78a83ad9-d7c1-4cc7-9134-8813fa8ad3e9"), "HR" },
                    { new Guid("f5bd00a2-2f2a-4a60-9e20-c7c8cb78583e"), "Accountant" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("12c0bc46-df24-4cf0-ae91-0b1613478a9b"), "Recruitment Drive" },
                    { new Guid("4b0b00f0-3372-44e1-96ee-3bb5382e540b"), "Website Redesign" },
                    { new Guid("62792c90-1772-439a-85f0-2f2e9c6922ce"), "Budget Planning" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "JoinedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("0fae57cc-486b-499c-a0ae-84dc4f5f0d3e"), new Guid("5b671e57-cc34-4c2a-85f4-052d4986fc3f"), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice" },
                    { new Guid("3e6f0cf7-8fe6-47f1-8474-2f10a2a67e67"), new Guid("78a83ad9-d7c1-4cc7-9134-8813fa8ad3e9"), new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlie" },
                    { new Guid("7dc4313e-b237-4a7e-bfa9-4edc5a86000c"), new Guid("f5bd00a2-2f2a-4a60-9e20-c7c8cb78583e"), new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diana" },
                    { new Guid("a792e5b5-4a38-4957-b8ce-2907aebcebe6"), new Guid("34f1fc66-f258-4470-8c79-16f86f030ec9"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob" },
                    { new Guid("b3691587-ff4e-4e0b-b7f9-86bc058f4c38"), new Guid("f5bd00a2-2f2a-4a60-9e20-c7c8cb78583e"), new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diana" },
                    { new Guid("d0d5a610-ecdd-4ed7-b7df-d76b74b0f78b"), new Guid("5b671e57-cc34-4c2a-85f4-052d4986fc3f"), new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlie" }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployees",
                columns: new[] { "EmployeeId", "ProjectId", "Enable" },
                values: new object[,]
                {
                    { new Guid("a792e5b5-4a38-4957-b8ce-2907aebcebe6"), new Guid("12c0bc46-df24-4cf0-ae91-0b1613478a9b"), true },
                    { new Guid("0fae57cc-486b-499c-a0ae-84dc4f5f0d3e"), new Guid("4b0b00f0-3372-44e1-96ee-3bb5382e540b"), true },
                    { new Guid("d0d5a610-ecdd-4ed7-b7df-d76b74b0f78b"), new Guid("4b0b00f0-3372-44e1-96ee-3bb5382e540b"), true },
                    { new Guid("7dc4313e-b237-4a7e-bfa9-4edc5a86000c"), new Guid("62792c90-1772-439a-85f0-2f2e9c6922ce"), false }
                });

            migrationBuilder.InsertData(
                table: "Salaries",
                columns: new[] { "Id", "EmployeeId", "Salary" },
                values: new object[,]
                {
                    { new Guid("0566d7a5-442b-49db-8d7e-b7662311d238"), new Guid("3e6f0cf7-8fe6-47f1-8474-2f10a2a67e67"), 60m },
                    { new Guid("0b138abc-2972-44d2-bb4e-3297c1c7dc70"), new Guid("0fae57cc-486b-499c-a0ae-84dc4f5f0d3e"), 120m },
                    { new Guid("3826c308-9644-4190-8d0c-1a2f3074ec2e"), new Guid("a792e5b5-4a38-4957-b8ce-2907aebcebe6"), 110m },
                    { new Guid("bfcfe80f-259c-4f20-b153-f8c7c3e89ed6"), new Guid("d0d5a610-ecdd-4ed7-b7df-d76b74b0f78b"), 350m },
                    { new Guid("f7d3ff43-4639-4812-b508-5fcdd648e7c0"), new Guid("7dc4313e-b237-4a7e-bfa9-4edc5a86000c"), 80m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployees_EmployeeId",
                table: "ProjectEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmployeeId",
                table: "Salaries",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectEmployees");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
