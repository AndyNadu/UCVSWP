using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCVSWP.Migrations
{
    /// <inheritdoc />
    public partial class fileassignmentid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_Assignment_AssignmentID",
                table: "File");

            migrationBuilder.RenameColumn(
                name: "AssignmentID",
                table: "File",
                newName: "AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_File_AssignmentID",
                table: "File",
                newName: "IX_File_AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_File_Assignment_AssignmentId",
                table: "File",
                column: "AssignmentId",
                principalTable: "Assignment",
                principalColumn: "AssignmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_Assignment_AssignmentId",
                table: "File");

            migrationBuilder.RenameColumn(
                name: "AssignmentId",
                table: "File",
                newName: "AssignmentID");

            migrationBuilder.RenameIndex(
                name: "IX_File_AssignmentId",
                table: "File",
                newName: "IX_File_AssignmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_File_Assignment_AssignmentID",
                table: "File",
                column: "AssignmentID",
                principalTable: "Assignment",
                principalColumn: "AssignmentID");
        }
    }
}
