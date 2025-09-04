using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UberFood.Core.Migrations
{
    /// <inheritdoc />
    public partial class fixBDDGM2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Burgers_BurgerID",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Pizzas_PizzaId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_BurgerID",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "BurgerID",
                table: "Ingredients");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_BurgerId",
                table: "Ingredients",
                column: "BurgerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Burgers_BurgerId",
                table: "Ingredients",
                column: "BurgerId",
                principalTable: "Burgers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Pizzas_PizzaId",
                table: "Ingredients",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Burgers_BurgerId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Pizzas_PizzaId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_BurgerId",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "BurgerID",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_BurgerID",
                table: "Ingredients",
                column: "BurgerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Burgers_BurgerID",
                table: "Ingredients",
                column: "BurgerID",
                principalTable: "Burgers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Pizzas_PizzaId",
                table: "Ingredients",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
