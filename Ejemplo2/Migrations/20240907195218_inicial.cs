using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ejemplo2.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.id);
                });

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
                name: "productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                    codigoBarras = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    precio = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    stock = table.Column<int>(type: "int", nullable: true),
                    categoria_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.id);
                    table.ForeignKey(
                        name: "FK_productos_categorias_categoria_id",
                        column: x => x.categoria_id,
                        principalTable: "categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "categorias",
                columns: new[] { "id", "nombre" },
                values: new object[,]
                {
                    { 1, "Frutas" },
                    { 2, "Verduras" },
                    { 3, "Carnes" },
                    { 4, "Menestras" },
                    { 5, "Bebidas" }
                });

            migrationBuilder.InsertData(
                table: "productos",
                columns: new[] { "id", "categoria_id", "codigoBarras", "descripcion", "nombre", "precio", "stock" },
                values: new object[] { 1, 1, null, "Es una fresa", "Fresa", 8.50m, null });

            migrationBuilder.CreateIndex(
                name: "IX_oferta_productos_producto_id",
                table: "oferta_productos",
                column: "producto_id");

            migrationBuilder.CreateIndex(
                name: "IX_productos_categoria_id",
                table: "productos",
                column: "categoria_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_persona_id",
                table: "usuarios",
                column: "persona_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "oferta_productos");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "ofertas");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "personas");

            migrationBuilder.DropTable(
                name: "categorias");
        }
    }
}
