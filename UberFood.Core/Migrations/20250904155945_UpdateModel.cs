using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UberFood.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Burgers_BurgerID",
                table: "Ingredients");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Burgers_BurgerID",
                table: "Ingredients",
                column: "BurgerID",
                principalTable: "Burgers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Burgers_BurgerID",
                table: "Ingredients");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Burgers_BurgerID",
                table: "Ingredients",
                column: "BurgerID",
                principalTable: "Burgers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
