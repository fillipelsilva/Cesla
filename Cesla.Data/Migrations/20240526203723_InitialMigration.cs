using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cesla.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "endereco_tb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Rua = table.Column<string>(type: "varchar(200)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false),
                    CEP = table.Column<string>(type: "varchar(8)", nullable: false),
                    Pais = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco_tb", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "empresa_tb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(11)", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresa_tb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_empresa_tb_endereco_tb_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "endereco_tb",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamento_tb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento_tb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_departamento_tb_empresa_tb_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "empresa_tb",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cargo_tb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargo_tb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cargo_tb_departamento_tb_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "departamento_tb",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "colaborador_tb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colaborador_tb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_colaborador_tb_cargo_tb_CargoId",
                        column: x => x.CargoId,
                        principalTable: "cargo_tb",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "endereco_tb",
                columns: new[] { "Id", "CEP", "Cidade", "DataCadastro", "Estado", "Numero", "Pais", "Rua" },
                values: new object[] { 1, "21345678", "Rio de Janeiro", new DateTime(2024, 5, 26, 17, 37, 23, 289, DateTimeKind.Local).AddTicks(2152), "RJ", 20, "Brasil", "Rua Teste" });

            migrationBuilder.InsertData(
                table: "empresa_tb",
                columns: new[] { "Id", "DataCadastro", "EnderecoId", "Nome", "Telefone" },
                values: new object[] { 1, new DateTime(2024, 5, 26, 17, 37, 23, 289, DateTimeKind.Local).AddTicks(2219), 1, "Cesla", "1101234567" });

            migrationBuilder.InsertData(
                table: "departamento_tb",
                columns: new[] { "Id", "DataCadastro", "EmpresaId", "Nome" },
                values: new object[] { 1, new DateTime(2024, 5, 26, 17, 37, 23, 289, DateTimeKind.Local).AddTicks(2248), 1, "Administrativo" });

            migrationBuilder.InsertData(
                table: "cargo_tb",
                columns: new[] { "Id", "DataCadastro", "DepartamentoId", "Nome", "Salario" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1402), 1, "Gerente Administrativo", 12000.00m },
                    { 2, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1440), 1, "Assistente Administrativo", 3000.00m },
                    { 3, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1454), 1, "Secret�ria Executiva", 5000.00m },
                    { 4, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1468), 1, "Analista Administrativo", 6000.00m },
                    { 5, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1481), 1, "Coordenador de Recursos Humanos", 7000.00m },
                    { 6, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1496), 1, "Recepcionista", 2500.00m },
                    { 7, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1510), 1, "Controlador de Documentos", 4000.00m },
                    { 8, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1523), 1, "Supervisor de Escrit�rio", 5500.00m },
                    { 9, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1537), 1, "Analista de Compras", 6500.00m },
                    { 10, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1551), 1, "Gerente de Facilidades", 8000.00m },
                    { 11, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1565), 1, "Analista Financeiro", 7500.00m },
                    { 12, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1579), 1, "Assistente de Contabilidade", 3500.00m },
                    { 13, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1593), 1, "Analista de Planejamento", 7000.00m },
                    { 14, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1606), 1, "Coordenador de Eventos", 4500.00m },
                    { 15, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1620), 1, "Analista de Projetos", 6500.00m },
                    { 16, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1633), 1, "Especialista em Conformidade", 7000.00m },
                    { 17, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1668), 1, "Gerente de Comunica��es Internas", 7500.00m },
                    { 18, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1682), 1, "Analista de Suprimentos", 6000.00m },
                    { 19, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1695), 1, "Assistente de Log�stica", 3500.00m },
                    { 20, new DateTime(2024, 5, 26, 17, 37, 23, 291, DateTimeKind.Local).AddTicks(1709), 1, "Administrador de Contratos", 6500.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cargo_tb_DepartamentoId",
                table: "cargo_tb",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_colaborador_tb_CargoId",
                table: "colaborador_tb",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_tb_EmpresaId",
                table: "departamento_tb",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_empresa_tb_EnderecoId",
                table: "empresa_tb",
                column: "EnderecoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "colaborador_tb");

            migrationBuilder.DropTable(
                name: "cargo_tb");

            migrationBuilder.DropTable(
                name: "departamento_tb");

            migrationBuilder.DropTable(
                name: "empresa_tb");

            migrationBuilder.DropTable(
                name: "endereco_tb");
        }
    }
}
