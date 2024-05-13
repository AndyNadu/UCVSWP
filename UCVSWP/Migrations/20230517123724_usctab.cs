﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCVSWP.Migrations
{
    /// <inheritdoc />
    public partial class usctab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClasssroomID",
                table: "UserClassroom",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClasssroomID",
                table: "UserClassroom");
        }
    }
}
