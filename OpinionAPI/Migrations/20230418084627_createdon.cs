using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpinionAPI.Migrations
{
    /// <inheritdoc />
    public partial class createdon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Rating",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Rating");
        }
    }
}
