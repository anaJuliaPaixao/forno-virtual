using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forno_OttoHx.Infra.Migrations
{
    /// <inheritdoc />
    public partial class fornoscustomizados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Forno",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TipoAquecimento",
                table: "Forno",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FornosCustomizados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeAlimento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Potencia = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Abreviacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SegundosAquecimento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FornosCustomizados", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FornosCustomizados");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Forno");

            migrationBuilder.DropColumn(
                name: "TipoAquecimento",
                table: "Forno");
        }
    }
}
