using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleDeNivel.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceInfos",
                columns: table => new
                {
                    IdDeviceInfo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    GuildCode = table.Column<string>(nullable: true),
                    IpAdress = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceInfos", x => x.IdDeviceInfo);
                });

            migrationBuilder.CreateTable(
                name: "LogFalhas",
                columns: table => new
                {
                    IdLogFalhas = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    RecordDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogFalhas", x => x.IdLogFalhas);
                });

            migrationBuilder.CreateTable(
                name: "Mensagens",
                columns: table => new
                {
                    IdMensagem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<int>(nullable: false),
                    Descrição = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagens", x => x.IdMensagem);
                });

            migrationBuilder.CreateTable(
                name: "Sinais",
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
                    I07 = table.Column<bool>(nullable: false),
                    Q00 = table.Column<bool>(nullable: false),
                    Q01 = table.Column<bool>(nullable: false),
                    Q02 = table.Column<bool>(nullable: false),
                    Q03 = table.Column<bool>(nullable: false),
                    Q04 = table.Column<bool>(nullable: false),
                    Q05 = table.Column<bool>(nullable: false),
                    Q06 = table.Column<bool>(nullable: false),
                    Q07 = table.Column<bool>(nullable: false),
                    DataDeAtualizacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinais", x => x.IdSinal);
                    table.ForeignKey(
                        name: "FK_Sinais_DeviceInfos_IdDeviceInfo",
                        column: x => x.IdDeviceInfo,
                        principalTable: "DeviceInfos",
                        principalColumn: "IdDeviceInfo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sinais_IdDeviceInfo",
                table: "Sinais",
                column: "IdDeviceInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogFalhas");

            migrationBuilder.DropTable(
                name: "Mensagens");

            migrationBuilder.DropTable(
                name: "Sinais");

            migrationBuilder.DropTable(
                name: "DeviceInfos");
        }
    }
}
