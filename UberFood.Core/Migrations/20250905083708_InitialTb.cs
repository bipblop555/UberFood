using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UberFood.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialTb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_AdresseId",
                table: "Users",
                column: "AdresseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_AdresseId",
                table: "Users",
                column: "AdresseId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_AdresseId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AdresseId",
                table: "Users");
        }
    }
}
