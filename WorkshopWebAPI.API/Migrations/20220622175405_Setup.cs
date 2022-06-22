using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkshopWebAPI.API.Migrations
{
    public partial class Setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ColorType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternalColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: false),
                    ExternalColorId = table.Column<int>(type: "int", nullable: false),
                    InternalColorId = table.Column<int>(type: "int", nullable: false),
                    SmokerPackage = table.Column<bool>(type: "bit", nullable: false),
                    HasSmokerPackage = table.Column<bool>(type: "bit", nullable: false),
                    SeatType = table.Column<int>(type: "int", nullable: false),
                    ElettricFoldableExteriorMirrors = table.Column<bool>(type: "bit", nullable: false),
                    AutomaticAirConditioning = table.Column<bool>(type: "bit", nullable: false),
                    StoragePackage = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configurations_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configurations_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationsOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ConfigurationId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationsOrders", x => new { x.OrderId, x.ConfigurationId });
                    table.ForeignKey(
                        name: "FK_ConfigurationsOrders_Configurations_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "Configurations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConfigurationsOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Birthdate", "Email", "Firstname", "Lastname", "Phone" },
                values: new object[,]
                {
                    { new Guid("b9e30ed2-16d2-4d80-8823-3af375945ce1"), new DateTime(1995, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "stefano.tomba@nttdata.com", "Stefano", "Tomba", "0230303049" },
                    { new Guid("e1b327d5-471a-48ab-8c8d-04203808fcc7"), new DateTime(1994, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "luca.bianchi@nttdata.com", "Luca", "Bianchi", "0237853485" },
                    { new Guid("ed92c708-f4c9-456c-9c5c-2b59ccbd219a"), new DateTime(1993, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "mario.rossi@nttdata.com", "Mario", "Rossi", "0230330219" }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "1.0 TFSI 95 cv" },
                    { 2, "1.0 TFSI 116 cv" },
                    { 3, "1.5 TFSI 150 cv" },
                    { 4, "2.0 TFSI 200 cv" }
                });

            migrationBuilder.InsertData(
                table: "ExternalColors",
                columns: new[] { "Id", "ColorType", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Black" },
                    { 2, 0, "Red" },
                    { 3, 0, "Blue" },
                    { 4, 0, "White" },
                    { 5, 1, "White Pearl" },
                    { 6, 1, "Black Pearl" }
                });

            migrationBuilder.InsertData(
                table: "InternalColors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Light" },
                    { 2, "Dark" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "FullName", "Name" },
                values: new object[,]
                {
                    { 1, "A1", "A1" },
                    { 2, "A1 Sportback", "A1" },
                    { 3, "A3", "A3" }
                });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "AutomaticAirConditioning", "ElettricFoldableExteriorMirrors", "EngineId", "ExternalColorId", "HasSmokerPackage", "InternalColorId", "ModelId", "SeatType", "SmokerPackage", "StoragePackage" },
                values: new object[] { 1, true, true, 1, 1, true, 2, 1, 1, true, false });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "AutomaticAirConditioning", "ElettricFoldableExteriorMirrors", "EngineId", "ExternalColorId", "HasSmokerPackage", "InternalColorId", "ModelId", "SeatType", "SmokerPackage", "StoragePackage" },
                values: new object[] { 2, false, false, 3, 1, true, 2, 3, 0, true, false });

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_EngineId",
                table: "Configurations",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_ModelId",
                table: "Configurations",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationsOrders_ConfigurationId",
                table: "ConfigurationsOrders",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Engines_Name",
                table: "Engines",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExternalColors_Name",
                table: "ExternalColors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InternalColors_Name",
                table: "InternalColors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_FullName",
                table: "Models",
                column: "FullName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigurationsOrders");

            migrationBuilder.DropTable(
                name: "ExternalColors");

            migrationBuilder.DropTable(
                name: "InternalColors");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
