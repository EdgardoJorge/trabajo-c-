using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ejemplo2.Migrations
{
    public partial class iiat : Migration
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
                name: "IX_productos_categoria_id",
                table: "productos",
                column: "categoria_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "categorias");
        }
    }
}
