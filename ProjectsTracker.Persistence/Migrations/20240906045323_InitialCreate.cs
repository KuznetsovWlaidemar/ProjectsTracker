using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectsTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerCompanyCompanyId = table.Column<int>(type: "int", nullable: true),
                    ExecutorCompanyCompanyId = table.Column<int>(type: "int", nullable: true),
                    ProjectManagerEmployeeId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Company_CustomerCompanyCompanyId",
                        column: x => x.CustomerCompanyCompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_Projects_Company_ExecutorCompanyCompanyId",
                        column: x => x.ExecutorCompanyCompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_Projects_Employees_ProjectManagerEmployeeId",
                        column: x => x.ProjectManagerEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    EmployeesEmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectsProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProject", x => new { x.EmployeesEmployeeId, x.ProjectsProjectId });
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Employees_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Projects_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Problems",
                columns: table => new
                {
                    ProblemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProblemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorEmployeeId = table.Column<int>(type: "int", nullable: true),
                    AssigneeEmployeeId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problems", x => x.ProblemId);
                    table.ForeignKey(
                        name: "FK_Problems_Employees_AssigneeEmployeeId",
                        column: x => x.AssigneeEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Problems_Employees_AuthorEmployeeId",
                        column: x => x.AuthorEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Problems_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectsProjectId",
                table: "EmployeeProject",
                column: "ProjectsProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Problems_AssigneeEmployeeId",
                table: "Problems",
                column: "AssigneeEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Problems_AuthorEmployeeId",
                table: "Problems",
                column: "AuthorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Problems_ProjectId",
                table: "Problems",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerCompanyCompanyId",
                table: "Projects",
                column: "CustomerCompanyCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ExecutorCompanyCompanyId",
                table: "Projects",
                column: "ExecutorCompanyCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerEmployeeId",
                table: "Projects",
                column: "ProjectManagerEmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropTable(
                name: "Problems");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
