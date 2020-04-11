using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusCompanyManagement.DataAccess.Migrations
{
    public partial class CreateMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    AnnouncementId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    AddedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.AnnouncementId);
                });

            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    BusId = table.Column<Guid>(nullable: false),
                    BusBrand = table.Column<string>(nullable: true),
                    TotalSeats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.BusId);
                });

            migrationBuilder.CreateTable(
                name: "Stops",
                columns: table => new
                {
                    StopId = table.Column<Guid>(nullable: false),
                    LocationName = table.Column<string>(nullable: true),
                    StopDuration = table.Column<DateTime>(nullable: false),
                    TouristicPoints = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stops", x => x.StopId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    EmailAdress = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AvailableSeats",
                columns: table => new
                {
                    AvailableSeatId = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    BusId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableSeats", x => x.AvailableSeatId);
                    table.ForeignKey(
                        name: "FK_AvailableSeats_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusFacilities",
                columns: table => new
                {
                    BusFacilityId = table.Column<Guid>(nullable: false),
                    HasTv = table.Column<string>(nullable: true),
                    HasAirConditioning = table.Column<string>(nullable: true),
                    HasBabyChair = table.Column<string>(nullable: true),
                    BusId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusFacilities", x => x.BusFacilityId);
                    table.ForeignKey(
                        name: "FK_BusFacilities_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<Guid>(nullable: false),
                    Destination = table.Column<string>(nullable: true),
                    Arrival = table.Column<string>(nullable: true),
                    DestinationTime = table.Column<DateTime>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    PersonalTripId = table.Column<Guid>(nullable: false),
                    BusId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                    table.ForeignKey(
                        name: "FK_Trips_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalTrips",
                columns: table => new
                {
                    PersonalTripId = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    TicketPrice = table.Column<int>(nullable: false),
                    SeatNumber = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTrips", x => x.PersonalTripId);
                    table.ForeignKey(
                        name: "FK_PersonalTrips_Trips_PersonalTripId",
                        column: x => x.PersonalTripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalTrips_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoppingPoint",
                columns: table => new
                {
                    TripId = table.Column<Guid>(nullable: false),
                    StopId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoppingPoint", x => new { x.TripId, x.StopId });
                    table.ForeignKey(
                        name: "FK_StoppingPoint_Stops_StopId",
                        column: x => x.StopId,
                        principalTable: "Stops",
                        principalColumn: "StopId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoppingPoint_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableSeats_BusId",
                table: "AvailableSeats",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_BusFacilities_BusId",
                table: "BusFacilities",
                column: "BusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTrips_UserId",
                table: "PersonalTrips",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoppingPoint_StopId",
                table: "StoppingPoint",
                column: "StopId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_BusId",
                table: "Trips",
                column: "BusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "AvailableSeats");

            migrationBuilder.DropTable(
                name: "BusFacilities");

            migrationBuilder.DropTable(
                name: "PersonalTrips");

            migrationBuilder.DropTable(
                name: "StoppingPoint");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Stops");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Buses");
        }
    }
}
