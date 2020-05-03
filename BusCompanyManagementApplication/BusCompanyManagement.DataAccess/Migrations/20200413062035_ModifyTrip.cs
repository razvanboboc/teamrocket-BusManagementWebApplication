using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusCompanyManagement.DataAccess.Migrations
{
    public partial class ModifyTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalTrips_Trips_PersonalTripId",
                table: "PersonalTrips");

            migrationBuilder.DropColumn(
                name: "PersonalTripId",
                table: "Trips");

            migrationBuilder.AddColumn<Guid>(
                name: "TripId",
                table: "PersonalTrips",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTrips_TripId",
                table: "PersonalTrips",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalTrips_Trips_TripId",
                table: "PersonalTrips",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "TripId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalTrips_Trips_TripId",
                table: "PersonalTrips");

            migrationBuilder.DropIndex(
                name: "IX_PersonalTrips_TripId",
                table: "PersonalTrips");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "PersonalTrips");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonalTripId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalTrips_Trips_PersonalTripId",
                table: "PersonalTrips",
                column: "PersonalTripId",
                principalTable: "Trips",
                principalColumn: "TripId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
