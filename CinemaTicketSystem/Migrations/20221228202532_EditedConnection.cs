using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTicketSystem.Migrations
{
    public partial class EditedConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Projection_ProjectionID",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Projection_ProjectionID",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Reservation_ReservationID",
                table: "Seat");

            migrationBuilder.RenameColumn(
                name: "ReservationID",
                table: "Seat",
                newName: "ReservationId");

            migrationBuilder.RenameColumn(
                name: "ProjectionID",
                table: "Seat",
                newName: "ProjectionId");

            migrationBuilder.RenameColumn(
                name: "SeatID",
                table: "Seat",
                newName: "SeatId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_ReservationID",
                table: "Seat",
                newName: "IX_Seat_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_ProjectionID",
                table: "Seat",
                newName: "IX_Seat_ProjectionId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Reservation",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ProjectionID",
                table: "Reservation",
                newName: "ProjectionId");

            migrationBuilder.RenameColumn(
                name: "ReservationID",
                table: "Reservation",
                newName: "ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_ProjectionID",
                table: "Reservation",
                newName: "IX_Reservation_ProjectionId");

            migrationBuilder.RenameColumn(
                name: "ProjectionID",
                table: "Projection",
                newName: "ProjectionId");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "Movie",
                newName: "MovieId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reservation",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_AspNetUsers_UserId",
                table: "Reservation",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Projection_ProjectionId",
                table: "Reservation",
                column: "ProjectionId",
                principalTable: "Projection",
                principalColumn: "ProjectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Projection_ProjectionId",
                table: "Seat",
                column: "ProjectionId",
                principalTable: "Projection",
                principalColumn: "ProjectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Reservation_ReservationId",
                table: "Seat",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "ReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_AspNetUsers_UserId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Projection_ProjectionId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Projection_ProjectionId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Reservation_ReservationId",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Seat",
                newName: "ReservationID");

            migrationBuilder.RenameColumn(
                name: "ProjectionId",
                table: "Seat",
                newName: "ProjectionID");

            migrationBuilder.RenameColumn(
                name: "SeatId",
                table: "Seat",
                newName: "SeatID");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_ReservationId",
                table: "Seat",
                newName: "IX_Seat_ReservationID");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_ProjectionId",
                table: "Seat",
                newName: "IX_Seat_ProjectionID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reservation",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "ProjectionId",
                table: "Reservation",
                newName: "ProjectionID");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Reservation",
                newName: "ReservationID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_ProjectionId",
                table: "Reservation",
                newName: "IX_Reservation_ProjectionID");

            migrationBuilder.RenameColumn(
                name: "ProjectionId",
                table: "Projection",
                newName: "ProjectionID");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Movie",
                newName: "MovieID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Reservation",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Projection_ProjectionID",
                table: "Reservation",
                column: "ProjectionID",
                principalTable: "Projection",
                principalColumn: "ProjectionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Projection_ProjectionID",
                table: "Seat",
                column: "ProjectionID",
                principalTable: "Projection",
                principalColumn: "ProjectionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Reservation_ReservationID",
                table: "Seat",
                column: "ReservationID",
                principalTable: "Reservation",
                principalColumn: "ReservationID");
        }
    }
}
