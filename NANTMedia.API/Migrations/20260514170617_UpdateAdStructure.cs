using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NANTMedia.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "ScheduledTime",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "createdby",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "Platform",
                table: "Ads",
                newName: "DocumentUrl");

            migrationBuilder.AddColumn<string>(
                name: "SubscriptionType",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscriptionType",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "DocumentUrl",
                table: "Ads",
                newName: "Platform");

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "Ads",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledTime",
                table: "Ads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "createdby",
                table: "Ads",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
