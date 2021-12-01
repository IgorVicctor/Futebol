using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Futebol.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arbitragem",
                columns: table => new
                {
                    jogoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numGols = table.Column<int>(type: "integer", nullable: false),
                    numCartAm = table.Column<int>(type: "integer", nullable: false),
                    numCartVer = table.Column<int>(type: "integer", nullable: false),
                    numFaltas = table.Column<int>(type: "integer", nullable: false),
                    numImpedimentos = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbitragem", x => x.jogoId);
                });

            migrationBuilder.CreateTable(
                name: "Competicao",
                columns: table => new
                {
                    timeId = table.Column<int>(type: "integer", nullable: false),
                    jogoId = table.Column<int>(type: "integer", nullable: false),
                    time = table.Column<string>(type: "text", nullable: true),
                    premiacao = table.Column<double>(type: "double precision", nullable: false),
                    jogos = table.Column<int>(type: "integer", nullable: false),
                    ganhador = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competicao", x => new { x.timeId, x.jogoId });
                });

            migrationBuilder.CreateTable(
                name: "Jogo",
                columns: table => new
                {
                    arbitragemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Arbitragem = table.Column<string>(type: "text", nullable: true),
                    substituicao = table.Column<bool>(type: "boolean", nullable: false),
                    resultado = table.Column<string>(type: "text", nullable: true),
                    times = table.Column<string>(type: "text", nullable: true),
                    numGols = table.Column<int>(type: "integer", nullable: false),
                    CompeticaojogoId = table.Column<int>(type: "integer", nullable: true),
                    CompeticaotimeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogo", x => x.arbitragemId);
                    table.ForeignKey(
                        name: "FK_Jogo_Competicao_CompeticaotimeId_CompeticaojogoId",
                        columns: x => new { x.CompeticaotimeId, x.CompeticaojogoId },
                        principalTable: "Competicao",
                        principalColumns: new[] { "timeId", "jogoId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    competicaoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true),
                    dataFund = table.Column<double>(type: "double precision", nullable: false),
                    CompeticaotimeId = table.Column<int>(type: "integer", nullable: false),
                    CompeticaojogoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.competicaoId);
                    table.ForeignKey(
                        name: "FK_Time_Competicao_CompeticaotimeId_CompeticaojogoId",
                        columns: x => new { x.CompeticaotimeId, x.CompeticaojogoId },
                        principalTable: "Competicao",
                        principalColumns: new[] { "timeId", "jogoId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jogadores",
                columns: table => new
                {
                    timeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numCamisa = table.Column<int>(type: "integer", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: true),
                    posicao = table.Column<string>(type: "text", nullable: true),
                    TimecompeticaoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogadores", x => x.timeId);
                    table.ForeignKey(
                        name: "FK_Jogadores_Time_TimecompeticaoId",
                        column: x => x.TimecompeticaoId,
                        principalTable: "Time",
                        principalColumn: "competicaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogadores_TimecompeticaoId",
                table: "Jogadores",
                column: "TimecompeticaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogo_CompeticaotimeId_CompeticaojogoId",
                table: "Jogo",
                columns: new[] { "CompeticaotimeId", "CompeticaojogoId" });

            migrationBuilder.CreateIndex(
                name: "IX_Time_CompeticaotimeId_CompeticaojogoId",
                table: "Time",
                columns: new[] { "CompeticaotimeId", "CompeticaojogoId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arbitragem");

            migrationBuilder.DropTable(
                name: "Jogadores");

            migrationBuilder.DropTable(
                name: "Jogo");

            migrationBuilder.DropTable(
                name: "Time");

            migrationBuilder.DropTable(
                name: "Competicao");
        }
    }
}
