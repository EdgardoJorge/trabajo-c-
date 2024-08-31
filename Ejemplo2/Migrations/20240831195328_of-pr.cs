using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ejemplo2.Migrations
{
    public partial class ofpr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ofertas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fecha_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    banner_url = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ofertas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "oferta_productos",
                columns: table => new
                {
                    oferta_id = table.Column<int>(type: "int", nullable: false),
                    producto_id = table.Column<int>(type: "int", nullable: false),
                    precio_oferta = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oferta_productos", x => new { x.oferta_id, x.producto_id });
                    table.ForeignKey(
                        name: "FK_oferta_productos_ofertas_oferta_id",
                        column: x => x.oferta_id,
                        principalTable: "ofertas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_oferta_productos_productos_producto_id",
                        column: x => x.producto_id,
                        principalTable: "productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_oferta_productos_producto_id",
                table: "oferta_productos",
                column: "producto_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "oferta_productos");

            migrationBuilder.DropTable(
                name: "ofertas");
        }
    }
}
