using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkshopWebAPI.API.Migrations
{
    public partial class TestSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthdate", "Email", "Firstname", "Lastname", "Phone" },
                values: new object[] { new Guid("b9e30ed2-16d2-4d80-8823-3af375945ce1"), new DateTime(1995, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "stefano.tomba@nttdata.com", "Stefano", "Tomba", "0230303049" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthdate", "Email", "Firstname", "Lastname", "Phone" },
                values: new object[] { new Guid("e1b327d5-471a-48ab-8c8d-04203808fcc7"), new DateTime(1994, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "luca.bianchi@nttdata.com", "Luca", "Bianchi", "0237853485" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthdate", "Email", "Firstname", "Lastname", "Phone" },
                values: new object[] { new Guid("ed92c708-f4c9-456c-9c5c-2b59ccbd219a"), new DateTime(1993, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "mario.rossi@nttdata.com", "Mario", "Rossi", "0230330219" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("b9e30ed2-16d2-4d80-8823-3af375945ce1"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("e1b327d5-471a-48ab-8c8d-04203808fcc7"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("ed92c708-f4c9-456c-9c5c-2b59ccbd219a"));
        }
    }
}
