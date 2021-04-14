using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleDeNivel.Migrations
{
    public partial class CriandoTemp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Temperatura",
                table: "Sinais",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Temperatura",
                table: "Sinais");
        }
    }
}
