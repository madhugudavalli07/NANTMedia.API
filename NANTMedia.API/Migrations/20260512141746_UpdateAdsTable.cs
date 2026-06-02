using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NANTMedia.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tittle",
                table: "Ads",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Descprition",
                table: "Ads",
                newName: "Description");

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "Ads",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Ads",
                newName: "Tittle");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Ads",
                newName: "Descprition");
        }
    }
}
