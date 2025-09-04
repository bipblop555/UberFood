using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UberFood.Core.Migrations
{
    /// <inheritdoc />
    public partial class ingredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Burgers_BurgerID",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Pizzas_PizzaID",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "PizzaID",
                table: "Ingredients",
                newName: "PizzaId");

            migrationBuilder.RenameColumn(
                name: "BurgerID",
                table: "Ingredients",
                newName: "BurgerId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_PizzaID",
                table: "Ingredients",
                newName: "IX_Ingredients_PizzaId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_BurgerID",
                table: "Ingredients",
                newName: "IX_Ingredients_BurgerId");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 150);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Phone",
                value: "0633333333");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Phone",
                value: "0644444444");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Burgers_BurgerId",
                table: "Ingredients",
                column: "BurgerId",
                principalTable: "Burgers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Pizzas_PizzaId",
                table: "Ingredients",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.RenameColumn(
                name: "PizzaId",
                table: "Ingredients",
                newName: "PizzaID");

            migrationBuilder.RenameColumn(
                name: "BurgerId",
                table: "Ingredients",
                newName: "BurgerID");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_PizzaId",
                table: "Ingredients",
                newName: "IX_Ingredients_PizzaID");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_BurgerId",
                table: "Ingredients",
                newName: "IX_Ingredients_BurgerID");

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Users",
                type: "int",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Phone",
                value: 633333333);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Phone",
                value: 644444444);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Burgers_BurgerID",
                table: "Ingredients",
                column: "BurgerID",
                principalTable: "Burgers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Pizzas_PizzaID",
                table: "Ingredients",
                column: "PizzaID",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
