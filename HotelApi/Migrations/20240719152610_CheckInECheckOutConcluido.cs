using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelApi.Migrations
{
    /// <inheritdoc />
    public partial class CheckInECheckOutConcluido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CheckInConcluido",
                table: "Reservas",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CheckOutConcluido",
                table: "Reservas",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "QuartoId",
                table: "Hospedes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hospedes_QuartoId",
                table: "Hospedes",
                column: "QuartoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospedes_Quartos_QuartoId",
                table: "Hospedes",
                column: "QuartoId",
                principalTable: "Quartos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospedes_Quartos_QuartoId",
                table: "Hospedes");

            migrationBuilder.DropIndex(
                name: "IX_Hospedes_QuartoId",
                table: "Hospedes");

            migrationBuilder.DropColumn(
                name: "CheckInConcluido",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "CheckOutConcluido",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "QuartoId",
                table: "Hospedes");
        }
    }
}
