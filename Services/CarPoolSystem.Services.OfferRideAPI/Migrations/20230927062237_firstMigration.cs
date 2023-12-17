using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarPoolSystem.Services.OfferRideAPI.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Offer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Car_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seat_Available = table.Column<int>(type: "int", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone_no = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Offer_Id);
                });

            migrationBuilder.InsertData(
                table: "Offer",
                columns: new[] { "Offer_Id", "Car_Name", "DepartureTime", "Destination", "Name", "Phone_no", "Seat_Available", "Source" },
                values: new object[,]
                {
                    { 1, "Honda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hyderabad", "Roma", 9569045767L, 5, "Hyderabad" },
                    { 2, "Alto", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hyderabad", "Kaju", 9569045767L, 5, "Hyderabad" },
                    { 3, "BMW", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hyderabad", "Raju", 9569045767L, 5, "Hyderabad" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offer");
        }
    }
}
