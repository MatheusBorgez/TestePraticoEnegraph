using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestePretico4.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    UnidadeFederativa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.UnidadeFederativa);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoUnidadeFederativa = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidades_Estados_EstadoUnidadeFederativa",
                        column: x => x.EstadoUnidadeFederativa,
                        principalTable: "Estados",
                        principalColumn: "UnidadeFederativa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CEPs",
                columns: table => new
                {
                    CodigoPostal = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CidadeId = table.Column<int>(type: "int", nullable: true),
                    EstadoUnidadeFederativa = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEPs", x => x.CodigoPostal);
                    table.ForeignKey(
                        name: "FK_CEPs_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CEPs_Estados_EstadoUnidadeFederativa",
                        column: x => x.EstadoUnidadeFederativa,
                        principalTable: "Estados",
                        principalColumn: "UnidadeFederativa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CidadeId = table.Column<int>(type: "int", nullable: true),
                    EstadoUnidadeFederativa = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CEPCodigoPostal = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.CPF);
                    table.ForeignKey(
                        name: "FK_Pessoas_CEPs_CEPCodigoPostal",
                        column: x => x.CEPCodigoPostal,
                        principalTable: "CEPs",
                        principalColumn: "CodigoPostal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pessoas_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pessoas_Estados_EstadoUnidadeFederativa",
                        column: x => x.EstadoUnidadeFederativa,
                        principalTable: "Estados",
                        principalColumn: "UnidadeFederativa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CEPs_CidadeId",
                table: "CEPs",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_CEPs_EstadoUnidadeFederativa",
                table: "CEPs",
                column: "EstadoUnidadeFederativa");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_EstadoUnidadeFederativa",
                table: "Cidades",
                column: "EstadoUnidadeFederativa");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_CEPCodigoPostal",
                table: "Pessoas",
                column: "CEPCodigoPostal");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_CidadeId",
                table: "Pessoas",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_EstadoUnidadeFederativa",
                table: "Pessoas",
                column: "EstadoUnidadeFederativa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "CEPs");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
