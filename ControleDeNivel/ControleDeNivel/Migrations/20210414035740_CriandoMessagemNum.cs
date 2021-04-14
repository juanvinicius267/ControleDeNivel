using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleDeNivel.Migrations
{
    public partial class CriandoMessagemNum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessagemNum",
                table: "Sinais",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessagemNum",
                table: "Sinais");
        }
    }
}
