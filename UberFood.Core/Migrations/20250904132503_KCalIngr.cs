using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UberFood.Core.Migrations
{
    /// <inheritdoc />
    public partial class KCalIngr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "KCal",
                table: "Ingredient",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 1,
                column: "KCal",
                value: 100.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 2,
                column: "KCal",
                value: 100.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 3,
                column: "KCal",
                value: 100.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 4,
                column: "KCal",
                value: 500.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 5,
                column: "KCal",
                value: 500.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 6,
                column: "KCal",
                value: 500.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 7,
                column: "KCal",
                value: 300.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 8,
                column: "KCal",
                value: 300.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 9,
                column: "KCal",
                value: 300.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 10,
                column: "KCal",
                value: 250.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 11,
                column: "KCal",
                value: 250.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 12,
                column: "KCal",
                value: 250.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 13,
                column: "KCal",
                value: 300.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 14,
                column: "KCal",
                value: 100.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 15,
                column: "KCal",
                value: 300.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 16,
                column: "KCal",
                value: 300.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 17,
                column: "KCal",
                value: 300.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 18,
                column: "KCal",
                value: 250.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 19,
                column: "KCal",
                value: 250.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 20,
                column: "KCal",
                value: 50.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 21,
                column: "KCal",
                value: 50.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 22,
                column: "KCal",
                value: 50.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 23,
                column: "KCal",
                value: 300.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 24,
                column: "KCal",
                value: 300.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 25,
                column: "KCal",
                value: 300.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 26,
                column: "KCal",
                value: 50.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 27,
                column: "KCal",
                value: 50.0);

            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 28,
                column: "KCal",
                value: 50.0);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_DoughId",
                table: "Pizzas",
                column: "DoughId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_BurgerID",
                table: "Ingredient",
                column: "BurgerID");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_PizzaID",
                table: "Ingredient",
                column: "PizzaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Burgers_BurgerID",
                table: "Ingredient",
                column: "BurgerID",
                principalTable: "Burgers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Pizzas_PizzaID",
                table: "Ingredient",
                column: "PizzaID",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Doughs_DoughId",
                table: "Pizzas",
                column: "DoughId",
                principalTable: "Doughs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Burgers_BurgerID",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Pizzas_PizzaID",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Doughs_DoughId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_DoughId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_BurgerID",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_PizzaID",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "KCal",
                table: "Ingredient");
        }
    }
}
