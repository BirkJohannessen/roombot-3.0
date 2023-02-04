using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace roombotapi.Migrations
{
    /// <inheritdoc />
    public partial class renameTbls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservation_user_userid",
                table: "reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reservation",
                table: "reservation");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "tbl_users");

            migrationBuilder.RenameTable(
                name: "reservation",
                newName: "tbl_reservations");

            migrationBuilder.RenameIndex(
                name: "IX_reservation_userid",
                table: "tbl_reservations",
                newName: "IX_tbl_reservations_userid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_users",
                table: "tbl_users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_reservations",
                table: "tbl_reservations",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_reservations_tbl_users_userid",
                table: "tbl_reservations",
                column: "userid",
                principalTable: "tbl_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_reservations_tbl_users_userid",
                table: "tbl_reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_users",
                table: "tbl_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_reservations",
                table: "tbl_reservations");

            migrationBuilder.RenameTable(
                name: "tbl_users",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "tbl_reservations",
                newName: "reservation");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_reservations_userid",
                table: "reservation",
                newName: "IX_reservation_userid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reservation",
                table: "reservation",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_reservation_user_userid",
                table: "reservation",
                column: "userid",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
