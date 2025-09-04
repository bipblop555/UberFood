using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UberFood.Core.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BurgerID = table.Column<int>(type: "int", nullable: false),
                    PizzaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "Id", "City", "Country", "State", "Street", "Zip" },
                values: new object[,]
                {
                    { 1, "Orléans", "France", "Loiret", "1 rue bidon", "45000" },
                    { 2, "Paris", "France", "Ile de France", "5 avenue du Général de Gaule", "75000" }
                });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "Id", "BurgerID", "Name", "PizzaID" },
                values: new object[,]
                {
                    { 1, 1, "Tomate", 0 },
                    { 2, 2, "Tomate", 0 },
                    { 3, 3, "Tomate", 0 },
                    { 4, 1, "Steak Haché", 0 },
                    { 5, 2, "Steak Haché", 0 },
                    { 6, 3, "Steak de Poulet", 0 },
                    { 7, 1, "Cheddar", 0 },
                    { 8, 2, "Cheddar", 0 },
                    { 9, 3, "Cheddar", 0 },
                    { 10, 0, "Sauce Tomate", 1 },
                    { 11, 0, "Sauce Tomate", 2 },
                    { 12, 0, "Sauce Tomate", 3 },
                    { 13, 0, "Jambon", 3 },
                    { 14, 0, "Champignons", 3 },
                    { 15, 0, "Fromage de chèvre", 3 },
                    { 16, 0, "Fromage de chèvre", 1 },
                    { 17, 0, "Roquefort", 1 },
                    { 18, 0, "Sauce Tomate", 3 },
                    { 19, 0, "Miel", 2 },
                    { 20, 1, "Salade", 0 },
                    { 21, 2, "Salade", 0 },
                    { 22, 3, "Salade", 0 },
                    { 23, 1, "Sauce Bigmac", 0 },
                    { 24, 2, "Sauce Mayo", 0 },
                    { 25, 3, "Sauce Fumée", 0 },
                    { 26, 1, "Oignons", 0 },
                    { 27, 2, "Oignons", 0 },
                    { 28, 3, "Oignons", 0 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 7, "Coca", 2.5 },
                    { 8, "Eau", 1.0 },
                    { 9, "Fanta", 2.3999999999999999 },
                    { 10, "Pâtes Pesto", 11.0 },
                    { 11, "Pâtes Carbonara", 10.0 },
                    { 12, "Pâtes aux fromages", 9.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AdresseId", "FirstName", "LastName", "Mail", "Phone" },
                values: new object[,]
                {
                    { 1, 1, "John", "Doe", "johndoe@mail.com", 633333333 },
                    { 2, 2, "Jane", "Dae", "janedae@mail.com", 644444444 }
                });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "Fizzy", "KCal" },
                values: new object[,]
                {
                    { 7, true, 500.0 },
                    { 8, false, 0.0 },
                    { 9, true, 350.0 }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "IsVegetarian" },
                values: new object[,]
                {
                    { 10, false },
                    { 11, false },
                    { 12, true }
                });

            migrationBuilder.InsertData(
                table: "Pastas",
                columns: new[] { "Id", "KCal", "Type" },
                values: new object[,]
                {
                    { 10, 750.0, 0 },
                    { 11, 800.0, 0 },
                    { 12, 750.0, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DeleteData(
                table: "Adresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Adresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pastas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pastas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pastas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
