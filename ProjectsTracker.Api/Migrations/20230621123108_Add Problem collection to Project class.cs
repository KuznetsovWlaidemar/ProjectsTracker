using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectsTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddProblemcollectiontoProjectclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Problems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Problems_ProjectId",
                table: "Problems",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_Projects_ProjectId",
                table: "Problems",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_Projects_ProjectId",
                table: "Problems");

            migrationBuilder.DropIndex(
                name: "IX_Problems_ProjectId",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Problems");
        }
    }
}
