using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpinionAPI.Migrations
{
    /// <inheritdoc />
    public partial class addvarbinary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageByte",
                table: "Movies",
                type: "VARBINARY(MAX)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageByte",
                table: "Movies");
        }
    }
}
