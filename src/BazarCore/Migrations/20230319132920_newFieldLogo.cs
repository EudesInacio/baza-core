using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazarCore.Migrations
{
    public partial class newFieldLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Organizers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Organizers");
        }
    }
}
