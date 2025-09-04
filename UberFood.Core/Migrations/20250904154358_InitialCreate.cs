using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UberFood.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Adresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Adresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Burgers",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Burgers",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Burgers",
                keyColumn: "Id",
                keyValue: 102);

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
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 28);

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
                table: "Foods",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "Id", "City", "Country", "State", "Street", "Zip" },
                values: new object[,]
                {
                    { 1, "Orléans", "France", "Loiret", "1 rue bidon", "45000" },
                    { 2, "Paris", "France", "Ile de France", "5 avenue du Général de Gaule", "75000" }
                });

            migrationBuilder.InsertData(
                table: "Doughs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Classique" },
                    { 2, "Fine" },
                    { 3, "Épaisse" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "BurgerId", "KCal", "Name", "PizzaId" },
                values: new object[,]
                {
                    { 1, 1, 100.0, "Tomate", 0 },
                    { 2, 2, 100.0, "Tomate", 0 },
                    { 3, 3, 100.0, "Tomate", 0 },
                    { 4, 1, 500.0, "Steak Haché", 0 },
                    { 5, 2, 500.0, "Steak Haché", 0 },
                    { 6, 3, 500.0, "Steak de Poulet", 0 },
                    { 7, 1, 300.0, "Cheddar", 0 },
                    { 8, 2, 300.0, "Cheddar", 0 },
                    { 9, 3, 300.0, "Cheddar", 0 },
                    { 20, 1, 50.0, "Salade", 0 },
                    { 21, 2, 50.0, "Salade", 0 },
                    { 22, 3, 50.0, "Salade", 0 },
                    { 23, 1, 300.0, "Sauce Bigmac", 0 },
                    { 24, 2, 300.0, "Sauce Mayo", 0 },
                    { 25, 3, 300.0, "Sauce Fumée", 0 },
                    { 26, 1, 50.0, "Oignons", 0 },
                    { 27, 2, 50.0, "Oignons", 0 },
                    { 28, 3, 50.0, "Oignons", 0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "4 Fromages", 9.9900000000000002 },
                    { 2, "Chèvre Miel", 10.0 },
                    { 3, "Reine", 8.5 },
                    { 7, "Coca", 2.5 },
                    { 8, "Eau", 1.0 },
                    { 9, "Fanta", 2.3999999999999999 },
                    { 10, "Pâtes Pesto", 11.0 },
                    { 11, "Pâtes Carbonara", 10.0 },
                    { 12, "Pâtes aux fromages", 9.0 },
                    { 100, "Big Mac", 9.0999999999999996 },
                    { 101, "Smash Burger", 12.1 },
                    { 102, "Mac Chicken", 9.0999999999999996 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AdresseId", "FirstName", "LastName", "Mail", "Phone" },
                values: new object[,]
                {
                    { 1, 1, "John", "Doe", "johndoe@mail.com", "0633333333" },
                    { 2, 2, "Jane", "Dae", "janedae@mail.com", "0644444444" }
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
                columns: new[] { "Id", "ContainAlergene", "IsVegetarian" },
                values: new object[,]
                {
                    { 1, true, true },
                    { 2, true, true },
                    { 3, true, false },
                    { 10, true, false },
                    { 11, true, false },
                    { 12, true, true },
                    { 100, true, false },
                    { 101, true, false },
                    { 102, true, false }
                });

            migrationBuilder.InsertData(
                table: "Burgers",
                column: "Id",
                values: new object[]
                {
                    100,
                    101,
                    102
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

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "DoughId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "BurgerId", "KCal", "Name", "PizzaId" },
                values: new object[,]
                {
                    { 10, 0, 250.0, "Sauce Tomate", 1 },
                    { 11, 0, 250.0, "Sauce Tomate", 2 },
                    { 12, 0, 250.0, "Sauce Tomate", 3 },
                    { 13, 0, 300.0, "Jambon", 3 },
                    { 14, 0, 100.0, "Champignons", 3 },
                    { 15, 0, 300.0, "Fromage de chèvre", 3 },
                    { 16, 0, 300.0, "Fromage de chèvre", 1 },
                    { 17, 0, 300.0, "Roquefort", 1 },
                    { 18, 0, 250.0, "Sauce Tomate", 3 },
                    { 19, 0, 250.0, "Miel", 2 }
                });
        }
    }
}
