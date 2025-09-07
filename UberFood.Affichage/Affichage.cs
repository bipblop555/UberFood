using System;
using UberFood.Core.Context;
using UberFood.Core.Entities;
using UberFood.Core.Handlers;
using UberFood.Core.Models;

namespace UberFood.Affichage
{
    public class Affichage
    {
        public static void AfficherBandeau(string texte, int largeurFixe = 50)
        {
            texte = texte.Trim();

            string contenu = texte.Length > largeurFixe - 4
                ? texte.Substring(0, largeurFixe - 7) + "..."
                : texte;

            int espaceDisponible = largeurFixe;
            int leftPadding = (espaceDisponible - contenu.Length) / 2;
            int rightPadding = espaceDisponible - contenu.Length - leftPadding;

            string bordureHautBas = "+" + new string('=', largeurFixe) + "+";
            string ligneVide = "|" + new string(' ', largeurFixe) + "|";
            string ligneTexte = "|" + new string(' ', leftPadding) + contenu + new string(' ', rightPadding) + "|";

            Console.WriteLine(bordureHautBas);
            Console.WriteLine(ligneVide);
            Console.WriteLine(ligneTexte);
            Console.WriteLine(ligneVide);
            Console.WriteLine(bordureHautBas);
        }
        public static void AfficherBoutons(string texte, int largeurFixe = 50)
        {
            texte = texte.Trim();

            string contenu = texte.Length > largeurFixe - 4
                ? texte.Substring(0, largeurFixe - 7) + "..."
                : texte;

            int espaceDisponible = largeurFixe;
            int leftPadding = (espaceDisponible - contenu.Length) / 2;
            int rightPadding = espaceDisponible - contenu.Length - leftPadding;

            string bordureHautBas = "+" + new string('-', largeurFixe) + "+";
            string ligneVide = "|" + new string(' ', largeurFixe) + "|";
            string ligneTexte = "|" + new string(' ', leftPadding) + contenu + new string(' ', rightPadding) + "|";

            Console.WriteLine(bordureHautBas);
            Console.WriteLine(ligneVide);
            Console.WriteLine(ligneTexte);
            Console.WriteLine(ligneVide);
            Console.WriteLine(bordureHautBas);
        }
        public static void AfficherMenuDepart()
        {
            AfficherBandeau("Uberfood");

            Console.WriteLine("\nPar Axel, Guillaume et Tom\n");
            Console.WriteLine("Que souhaitez vous faire ?\n");
            AfficherBoutons("1. Commander");
            AfficherBoutons("2. Gestion de produits");
            AfficherBoutons("3. Gestion de clients");
            AfficherBoutons("4. Statistiques");
            AfficherBoutons("5. Quitter l'application");

        }
        public static void AfficherMenuChoix1()
        {
            AfficherBandeau("Uberfood");
            AfficherBandeau("Espace Commande");
            Console.WriteLine("\nVoici les options disponibles : \n");
            AfficherBoutons("1. Afficher la liste des produits");
            AfficherBoutons("2. Ajouter un produit au panier");
            AfficherBoutons("3. Supprimer un produit de votre panier");
            AfficherBoutons("4. Afficher votre panier en cours");
            AfficherBoutons("5. Valider votre panier");
            AfficherBoutons("6. Supprimer votre panier");
            AfficherBoutons("7. Afficher mes commandes");
            AfficherBoutons("8. Supprimer une commande");
            AfficherBoutons("9. Modifier statut commande");
            AfficherBoutons("10. Retour en arrière");
            AfficherBoutons("11. Quitter l'application");
        }
        public static void AfficherMenuChoix2()
        {
            AfficherBandeau("Uberfood");
            AfficherBandeau("Espace de gestion de produits");
            Console.WriteLine("\nVoici les options disponibles : \n");
            AfficherBoutons("1. Ajouter un produit");
            AfficherBoutons("2. Modifier un produit");
            AfficherBoutons("3. Supprimer un produit");
            AfficherBoutons("4. Retour en arrière");
            AfficherBoutons("5. Quitter l'application");
        }
        public static void AfficherMenuChoix3()
        {
            AfficherBandeau("Uberfood");
            AfficherBandeau("Espace de gestion de Clients");
            Console.WriteLine("\nVoici les options disponibles : \n");
            AfficherBoutons("1. Ajouter un Client");
            AfficherBoutons("2. Modifier un Client");
            AfficherBoutons("3. Supprimer un Client");
            AfficherBoutons("4. Liste des Client");
            AfficherBoutons("5. Retour en arrière");
            AfficherBoutons("6. Quitter l'application");
        }

        public static void AfficherMenuChoix4()
        {
            AfficherBandeau("Uberfood");
            AfficherBandeau("Statistiques");
            Console.WriteLine("\nVoici les options disponibles : \n");
            AfficherBoutons("1. Liste des utilisateurs qui ont commandés");
            AfficherBoutons("2. Liste des commandes vegetariennes");
            AfficherBoutons("3. Moyennes des calories par commande");
            AfficherBoutons("4. Liste des produits allergène");
            AfficherBoutons("5. Liste des commandes en cours");
            AfficherBoutons("6. Retour en arrière");
            AfficherBoutons("7. Quitter l'application");
        }
        public static void AfficherMenuAjoutProduit()
        {
            AfficherBandeau("UberFood");
            AfficherBandeau("Ajouter un produit");
            Console.WriteLine("\nQuel type de produit souhaitez vous ajouter : \n");
            AfficherBoutons("1. Pizza");
            AfficherBoutons("2. Burger");
            AfficherBoutons("3. Pasta");
            AfficherBoutons("4. Retour en arrière");
        }
        public static void AfficherMenuModificationProduit()
        {
            AfficherBandeau("UberFood");
            AfficherBandeau("Modifier un produit");
            Console.WriteLine("\nQuel type de produit souhaitez vous modifier : \n");
            AfficherBoutons("1. Pizza");
            AfficherBoutons("2. Burger");
            AfficherBoutons("3. Pasta");
            AfficherBoutons("4. Retour en arrière");
        }
        public static void AfficherMenuSuppressionProduit()
        {
            AfficherBandeau("UberFood");
            AfficherBandeau("Supprimer un produit");
            Console.WriteLine("\nQuel type de produit souhaitez vous supprimer : \n");
            AfficherBoutons("1. Pizza");
            AfficherBoutons("2. Burger");
            AfficherBoutons("3. Pasta");
            AfficherBoutons("4. Retour en arrière");
        }
        public static void AfficherPizzas(List<PizzaDto> pizzas)
        {
            int largeurFixe = 40;

            foreach (var pizza in pizzas)
            {
                
                var handleringredient = new IngredientsHandler();
                var ingredients = handleringredient.GetIngredients();
                var pizzaIngredients = ingredients.Where(e => e.PizzaId == pizza.Id);
                string ingre = "";
                foreach(var ingredient in pizzaIngredients)
                {
                    ingre += ingredient.Name + " ";
                }
                string texte = $"{pizza.Id} : {pizza.Name} - {pizza.Price} Euros ";
                
                
                texte = texte.Trim();
                ingre = ingre.Trim();

                string contenu = texte.Length > largeurFixe - 4
                    ? texte.Substring(0, largeurFixe - 7) + "..."
                    : texte;

                int espaceDisponible = largeurFixe;

                int leftPadding = (espaceDisponible - contenu.Length) / 2;
                int rightPadding = espaceDisponible - contenu.Length - leftPadding;

               

                string bordureHautBas = "+" + new string('-', largeurFixe) + "+";
                string ligneVide = "|" + new string(' ', largeurFixe) + "|";
                string ligneTexte = "|" + new string(' ', leftPadding) + contenu + new string(' ', rightPadding) + "|";

                

                Console.WriteLine(bordureHautBas);
                Console.WriteLine(ligneVide);
                Console.WriteLine(ligneTexte);
                //ajout d'une ligne ingredient
                if (!string.IsNullOrEmpty(ingre))
                {
                    string texteIngredients = ingre.Length > largeurFixe
                        ? ingre.Substring(0, largeurFixe - 3) + "..."
                        : ingre;

                    int leftPaddingIngredients = (largeurFixe - texteIngredients.Length) / 2;
                    int rightPaddingIngredients = largeurFixe - texteIngredients.Length - leftPaddingIngredients;

                    string ligneIngredients = "|" + new string(' ', leftPaddingIngredients) + texteIngredients + new string(' ', rightPaddingIngredients) + "|";
                    Console.WriteLine(ligneIngredients);
                }
                Console.WriteLine(ligneVide);
                Console.WriteLine(bordureHautBas);
                Console.WriteLine();
            }
        }
        public static void AfficherBurger(List<BurgerDto> burgers)
        {
            int largeurFixe = 40;

            foreach (var burger in burgers)
            {
                var handleringredient = new IngredientsHandler();
                var ingredients = handleringredient.GetIngredients();
                var burgerIngredients = ingredients.Where(e => e.BurgerId == burger.Id);
                string ingre = "";
                foreach (var ingredient in burgerIngredients)
                {
                    ingre += ingredient.Name + " ";
                }
                string texte = $" {burger.Id} : {burger.Name} - {burger.Price} Euros";
                texte = texte.Trim();

                string contenu = texte.Length > largeurFixe - 4
                    ? texte.Substring(0, largeurFixe - 7) + "..."
                    : texte;

                int espaceDisponible = largeurFixe;
                int leftPadding = (espaceDisponible - contenu.Length) / 2;
                int rightPadding = espaceDisponible - contenu.Length - leftPadding;

                string bordureHautBas = "+" + new string('-', largeurFixe) + "+";
                string ligneVide = "|" + new string(' ', largeurFixe) + "|";
                string ligneTexte = "|" + new string(' ', leftPadding) + contenu + new string(' ', rightPadding) + "|";

                Console.WriteLine(bordureHautBas);
                Console.WriteLine(ligneVide);
                Console.WriteLine(ligneTexte);
                if (!string.IsNullOrEmpty(ingre))
                {
                    string texteIngredients = ingre.Length > largeurFixe
                        ? ingre.Substring(0, largeurFixe - 3) + "..."
                        : ingre;

                    int leftPaddingIngredients = (largeurFixe - texteIngredients.Length) / 2;
                    int rightPaddingIngredients = largeurFixe - texteIngredients.Length - leftPaddingIngredients;

                    string ligneIngredients = "|" + new string(' ', leftPaddingIngredients) + texteIngredients + new string(' ', rightPaddingIngredients) + "|";
                    Console.WriteLine(ligneIngredients);
                }
                Console.WriteLine(ligneVide);
                Console.WriteLine(bordureHautBas);
                Console.WriteLine();
            }
        }
        public static void AfficherPasta(List<PastaDto> Pastas)
        {
            int largeurFixe = 40;

            foreach (var pasta in Pastas)
            {
                string texte = $"{pasta.Id} : {pasta.Name} - {pasta.Price} Euros";
                texte = texte.Trim();

                string contenu = texte.Length > largeurFixe - 4
                    ? texte.Substring(0, largeurFixe - 7) + "..."
                    : texte;

                int espaceDisponible = largeurFixe;
                int leftPadding = (espaceDisponible - contenu.Length) / 2;
                int rightPadding = espaceDisponible - contenu.Length - leftPadding;

                string bordureHautBas = "+" + new string('-', largeurFixe) + "+";
                string ligneVide = "|" + new string(' ', largeurFixe) + "|";
                string ligneTexte = "|" + new string(' ', leftPadding) + contenu + new string(' ', rightPadding) + "|";

                Console.WriteLine(bordureHautBas);
                Console.WriteLine(ligneVide);
                Console.WriteLine(ligneTexte);
                Console.WriteLine(ligneVide);
                Console.WriteLine(bordureHautBas);
                Console.WriteLine();
            }

        }
        public static void AfficherUsers(List<UserDto> Users)
        {
            int largeurFixe = 80;

            foreach (var user in Users)
            {
                string texte = $"{user.Id} - {user.FirstName} - {user.LastName} - {user.Phone} - {user.Mail}";
                texte = texte.Trim();

                string contenu = texte.Length > largeurFixe - 4
                    ? texte.Substring(0, largeurFixe - 7) + "..."
                    : texte;

                int espaceDisponible = largeurFixe;
                int leftPadding = (espaceDisponible - contenu.Length) / 2;
                int rightPadding = espaceDisponible - contenu.Length - leftPadding;

                string bordureHautBas = "+" + new string('-', largeurFixe) + "+";
                string ligneVide = "|" + new string(' ', largeurFixe) + "|";
                string ligneTexte = "|" + new string(' ', leftPadding) + contenu + new string(' ', rightPadding) + "|";

                Console.WriteLine(bordureHautBas);
                Console.WriteLine(ligneVide);
                Console.WriteLine(ligneTexte);
                Console.WriteLine(ligneVide);
                Console.WriteLine(bordureHautBas);
                Console.WriteLine();
            }


        }
        public static void AfficherUser(int userId)
        {
            using (var context = new DataContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);

                if (user == null)
                {
                    Console.WriteLine("User not found.");
                    return;
                }

                int largeurFixe = 80;

                string texte = $"{user.Id} - {user.FirstName} - {user.LastName} - {user.Phone} - {user.Mail}";
                texte = texte.Trim();

                string contenu = texte.Length > largeurFixe - 4
                    ? texte.Substring(0, largeurFixe - 7) + "..."
                    : texte;

                int leftPadding = (largeurFixe - contenu.Length) / 2;
                int rightPadding = largeurFixe - contenu.Length - leftPadding;

                string bordureHautBas = "+" + new string('-', largeurFixe) + "+";
                string ligneVide = "|" + new string(' ', largeurFixe) + "|";
                string ligneTexte = "|" + new string(' ', leftPadding) + contenu + new string(' ', rightPadding) + "|";

                Console.WriteLine(bordureHautBas);
                Console.WriteLine(ligneVide);
                Console.WriteLine(ligneTexte);
                Console.WriteLine(ligneVide);
                Console.WriteLine(bordureHautBas);
                Console.WriteLine();
            }
        }
        public static void AfficherListeProduit()
        {
            var pizzaHandler = new PizzaHandler();
            var pizzas = pizzaHandler.GetPizzas();
            AfficherPizzas(pizzas);
            var burgerHandler = new BurgerHandler();
            var burgers = burgerHandler.GetBurgers();
            AfficherBurger(burgers);
            var pastaHandler = new PastaHandler();
            var pastas = pastaHandler.GetPastas();
            AfficherPasta(pastas);
        }

        public static void AfficherCommande(string name, List<IGrouping<int, OrderProductDto>> orderProductDtos)
        {
            int largeurFixe = 40;
            double total = 0;
            var i = 0;
            foreach (var groups in orderProductDtos)
            {
                total = 0;
                i++;
                Console.WriteLine($"Commande n° {i}");
                foreach (var item in groups)
                {
                    Console.WriteLine($"Numéro d'identification de commande : {item.OrderId}");
                    total += item.Product.Price;
                    string texte = $"{item.OrderId}. {item.Product.Name} - {item.Product.Price} Euros";
                    texte = texte.Trim();

                    string contenu = texte.Length > largeurFixe - 4
                        ? texte.Substring(0, largeurFixe - 7) + "..."
                        : texte;

                    int espaceDisponible = largeurFixe;
                    int leftPadding = (espaceDisponible - contenu.Length) / 2;
                    int rightPadding = espaceDisponible - contenu.Length - leftPadding;

                    string bordureHautBas = "+" + new string('-', largeurFixe) + "+";
                    string ligneVide = "|" + new string(' ', largeurFixe) + "|";
                    string ligneTexte = "|" + new string(' ', leftPadding) + contenu + new string(' ', rightPadding) + "|";

                    Console.WriteLine(bordureHautBas);
                    Console.WriteLine(ligneVide);
                    Console.WriteLine(ligneTexte);
                    Console.WriteLine(ligneVide);
                    Console.WriteLine(bordureHautBas);
                    Console.WriteLine();
                }
                AfficherTotal(name, total);
            }
        }
        public static void AfficherTotal(string name, double price)
        {
            int largeurFixe = 40;

            string texte = $"{name} votre total est de {price} Euros";
            texte = texte.Trim();

            string contenu = texte.Length > largeurFixe - 4
                ? texte.Substring(0, largeurFixe - 7) + "..."
                : texte;

            int espaceDisponible = largeurFixe;
            int leftPadding = (espaceDisponible - contenu.Length) / 2;
            int rightPadding = espaceDisponible - contenu.Length - leftPadding;

            string bordureHautBas = "+" + new string('-', largeurFixe) + "+";
            string ligneVide = "|" + new string(' ', largeurFixe) + "|";
            string ligneTexte = "|" + new string(' ', leftPadding) + contenu + new string(' ', rightPadding) + "|";

            Console.WriteLine(bordureHautBas);
            Console.WriteLine(ligneVide);
            Console.WriteLine(ligneTexte);
            Console.WriteLine(ligneVide);
            Console.WriteLine(bordureHautBas);
            Console.WriteLine();
        }

        public static void AfficherProduits(List<ProductDto> products)
        {
            int largeurFixe = 40;

            foreach (var product in products)
            {
                string texte = $"{product.Id}. {product.Name} - {product.Price} Euros";
                texte = texte.Trim();

                string contenu = texte.Length > largeurFixe - 4
                    ? texte.Substring(0, largeurFixe - 7) + "..."
                    : texte;

                int espaceDisponible = largeurFixe;
                int leftPadding = (espaceDisponible - contenu.Length) / 2;
                int rightPadding = espaceDisponible - contenu.Length - leftPadding;

                string bordureHautBas = "+" + new string('-', largeurFixe) + "+";
                string ligneVide = "|" + new string(' ', largeurFixe) + "|";
                string ligneTexte = "|" + new string(' ', leftPadding) + contenu + new string(' ', rightPadding) + "|";

                Console.WriteLine(bordureHautBas);
                Console.WriteLine(ligneVide);
                Console.WriteLine(ligneTexte);
                Console.WriteLine(ligneVide);
                Console.WriteLine(bordureHautBas);
                Console.WriteLine();
            }
        }
        public static void AfficherListeUsers()
        {
            var userHandler = new UserHandler();
            var users = userHandler.GetUsers();
            AfficherUsers(users);
        }
        public static void AfficherChoixPate()
        {
            var doughHandler = new DoughHandler();
            var doughs = doughHandler.GetDoughs();
            foreach (var dough in doughs)
            {
                AfficherBoutons($"{dough.Id} : {dough.Name}");
            }
        }
    }
}
