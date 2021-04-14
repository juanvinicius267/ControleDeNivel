using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleDeNivel.Migrations
{
    public partial class CriandoSinalInputModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SinaisDeInputDaPagina",
                columns: table => new
                {
                    IdSinal = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdDeviceInfo = table.Column<int>(nullable: false),
                    I00 = table.Column<bool>(nullable: false),
                    I01 = table.Column<bool>(nullable: false),
                    I02 = table.Column<bool>(nullable: false),
                    I03 = table.Column<bool>(nullable: false),
                    I04 = table.Column<bool>(nullable: false),
                    I05 = table.Column<bool>(nullable: false),
                    I06 = table.Column<bool>(nullable: false),
                    I07 = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinaisDeInputDaPagina", x => x.IdSinal);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinaisDeInputDaPagina");
        }
    }
}
