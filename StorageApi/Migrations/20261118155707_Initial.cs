using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StorageApi.Migrations;

/// <inheritdoc />
public partial class _20261118155707_Initial : Migration
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
                { 1, "GPU", 10, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "PRIME GeForce RTX™ 5080", 19700, "Shelf 1" },
                { 2, "Console", 25, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "PlayStation®5 Pro", 11900, "Shelf 2" },
                { 3, "Gaming Headset", 100, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "ASUS ROG Delta II", 2989, "Shelf 3" }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Product");
    }
}
