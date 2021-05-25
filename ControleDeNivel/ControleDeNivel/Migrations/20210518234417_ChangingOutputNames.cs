using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleDeNivel.Migrations
{
    public partial class ChangingOutputNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "I07",
                table: "Sinais",
                newName: "Q17");

            migrationBuilder.RenameColumn(
                name: "I06",
                table: "Sinais",
                newName: "Q16");

            migrationBuilder.RenameColumn(
                name: "I05",
                table: "Sinais",
                newName: "Q15");

            migrationBuilder.RenameColumn(
                name: "I04",
                table: "Sinais",
                newName: "Q14");

            migrationBuilder.RenameColumn(
                name: "I03",
                table: "Sinais",
                newName: "Q13");

            migrationBuilder.RenameColumn(
                name: "I02",
                table: "Sinais",
                newName: "Q12");

            migrationBuilder.RenameColumn(
                name: "I01",
                table: "Sinais",
                newName: "Q11");

            migrationBuilder.RenameColumn(
                name: "I00",
                table: "Sinais",
                newName: "Q10");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Q17",
                table: "Sinais",
                newName: "I07");

            migrationBuilder.RenameColumn(
                name: "Q16",
                table: "Sinais",
                newName: "I06");

            migrationBuilder.RenameColumn(
                name: "Q15",
                table: "Sinais",
                newName: "I05");

            migrationBuilder.RenameColumn(
                name: "Q14",
                table: "Sinais",
                newName: "I04");

            migrationBuilder.RenameColumn(
                name: "Q13",
                table: "Sinais",
                newName: "I03");

            migrationBuilder.RenameColumn(
                name: "Q12",
                table: "Sinais",
                newName: "I02");

            migrationBuilder.RenameColumn(
                name: "Q11",
                table: "Sinais",
                newName: "I01");

            migrationBuilder.RenameColumn(
                name: "Q10",
                table: "Sinais",
                newName: "I00");
        }
    }
}
