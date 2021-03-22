using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace logTrip.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Accommodation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccommodationPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccommodationEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThingToDo1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThingToDo2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThingToDo3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "Accommodation", "AccommodationEmail", "AccommodationPhone", "Destination", "EndDate", "StartDate", "ThingToDo1", "ThingToDo2", "ThingToDo3" },
                values: new object[] { 1, "Night starts hotel", "stars@booling.com", "501-388-0001", "Paris", new DateTime(2021, 3, 22, 22, 6, 0, 24, DateTimeKind.Local).AddTicks(7260), new DateTime(2021, 3, 21, 22, 6, 0, 24, DateTimeKind.Local).AddTicks(7260), "Conference", null, null });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "Accommodation", "AccommodationEmail", "AccommodationPhone", "Destination", "EndDate", "StartDate", "ThingToDo1", "ThingToDo2", "ThingToDo3" },
                values: new object[] { 2, "Sunset hotel", "info@sunset.com", "801-846-2701", "New York", new DateTime(2021, 4, 6, 22, 6, 0, 24, DateTimeKind.Local).AddTicks(7260), new DateTime(2021, 3, 31, 22, 6, 0, 24, DateTimeKind.Local).AddTicks(7260), "Go to central park", "Visit the world Trade Center's Liberty Park", "Grand Central Terminal" });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "Accommodation", "AccommodationEmail", "AccommodationPhone", "Destination", "EndDate", "StartDate", "ThingToDo1", "ThingToDo2", "ThingToDo3" },
                values: new object[] { 3, "Holiday-in Hotel", "booking@holiday.com", "901-786-4325", "Boston", new DateTime(2021, 4, 13, 22, 6, 0, 24, DateTimeKind.Local).AddTicks(7260), new DateTime(2021, 4, 10, 22, 6, 0, 24, DateTimeKind.Local).AddTicks(7260), "", "", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
