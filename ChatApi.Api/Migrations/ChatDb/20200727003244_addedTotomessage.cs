using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatApi.Api.Migrations.ChatDb
{
    public partial class addedTotomessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "To",
                table: "Messages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "To",
                table: "Messages");
        }
    }
}
