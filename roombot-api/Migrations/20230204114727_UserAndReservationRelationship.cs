using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace roombotapi.Migrations
{
    /// <inheritdoc />
    public partial class UserAndReservationRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "owner",
                table: "reservation",
                newName: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_userid",
                table: "reservation",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_reservation_user_userid",
                table: "reservation",
                column: "userid",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservation_user_userid",
                table: "reservation");

            migrationBuilder.DropIndex(
                name: "IX_reservation_userid",
                table: "reservation");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "reservation",
                newName: "owner");
        }
    }
}
