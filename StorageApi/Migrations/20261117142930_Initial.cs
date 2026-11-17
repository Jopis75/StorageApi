using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StorageApi.Migrations;

/// <inheritdoc />
public partial class _20261117142930_Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Product",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Price = table.Column<int>(type: "int", nullable: false),
                Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Shelf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Count = table.Column<int>(type: "int", nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Product", x => x.Id);
            });

        migrationBuilder.InsertData(
            table: "Product",
            columns: new[] { "Id", "Category", "Count", "Description", "Name", "Price", "Shelf" },
            values: new object[,]
            {
                { 1, "Category 1", 100, "Description 1", "Product 1", 10, "Shelf 1" },
                { 2, "Category 2", 200, "Description 2", "Product 2", 20, "Shelf 2" },
                { 3, "Category 3", 300, "Description 3", "Product 3", 30, "Shelf 3" }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Product");
    }
}
