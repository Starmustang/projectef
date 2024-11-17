using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("f83bc361-e443-47f7-89ec-556241277222"), null, "Actividades pendientes", 20 },
                    { new Guid("f83bc361-e443-47f7-89ec-556241277233"), null, "Actividades personales", 69 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "Prioridad", "Titulo" },
                values: new object[,]
                {
                    { new Guid("f83bc361-e443-47f7-89ec-556241277234"), new Guid("f83bc361-e443-47f7-89ec-556241277222"), null, new DateTime(2024, 6, 20, 12, 50, 17, 995, DateTimeKind.Local).AddTicks(9426), 1, "Pago de servicios publicos" },
                    { new Guid("f83bc361-e443-47f7-89ec-556241277235"), new Guid("f83bc361-e443-47f7-89ec-556241277233"), null, new DateTime(2024, 6, 20, 12, 50, 17, 995, DateTimeKind.Local).AddTicks(9459), 0, "Terminar pelicula" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("f83bc361-e443-47f7-89ec-556241277234"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("f83bc361-e443-47f7-89ec-556241277235"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("f83bc361-e443-47f7-89ec-556241277222"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("f83bc361-e443-47f7-89ec-556241277233"));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "Descripcion",
                keyValue: null,
                column: "Descripcion",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Descripcion",
                keyValue: null,
                column: "Descripcion",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
