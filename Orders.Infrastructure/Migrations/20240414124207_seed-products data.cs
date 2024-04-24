using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Orders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedproductsdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Products",
                columns: new[] { "Id", "ProductName", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("4d47bfb2-17af-49dd-981b-6d3d6a5a7904"), "Botatoes", 20.0 },
                    { new Guid("c52611f0-d410-45be-aaef-a37e58f7b47d"), "Tomatoes", 50.0 },
                    { new Guid("d1069ebf-28e1-4d28-b216-57604ba6fc1c"), "Carrot", 30.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4d47bfb2-17af-49dd-981b-6d3d6a5a7904"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c52611f0-d410-45be-aaef-a37e58f7b47d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d1069ebf-28e1-4d28-b216-57604ba6fc1c"));
        }
    }
}
