using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PhotoPortfolia.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "Title" },
                values: new object[] { 1, 1, new DateTime(2026, 3, 6, 10, 46, 4, 277, DateTimeKind.Local).AddTicks(4035), "Beautiful landscapes from the Alps.", "Mountain Serenity" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Nature");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Portraits");

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "AlbumId", "Caption", "ImageUrl" },
                values: new object[,]
                {
                    { 1, 1, "Alpine Peaks", "https://images.unsplash.com/photo-1464822759023-fed622ff2c3b" },
                    { 2, 1, "Forest Mist", "https://images.unsplash.com/photo-1470071459604-3b5ec3a7fe05" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Portraits");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Weddings");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Nature" });
        }
    }
}
