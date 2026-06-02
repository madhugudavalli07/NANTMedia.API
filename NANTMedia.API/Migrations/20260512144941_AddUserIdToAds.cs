using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NANTMedia.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToAds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Users_UsersId",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Ads",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_UsersId",
                table: "Ads",
                newName: "IX_Ads_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Users_UserId",
                table: "Ads",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Users_UserId",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Ads",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_UserId",
                table: "Ads",
                newName: "IX_Ads_UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Users_UsersId",
                table: "Ads",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
