using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ejemplo2.Migrations
{
    public partial class uspro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tipo_documento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nombre_document = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    salt = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    persona_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuarios_personas_persona_id",
                        column: x => x.persona_id,
                        principalTable: "personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_persona_id",
                table: "usuarios",
                column: "persona_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "personas");
        }
    }
}
