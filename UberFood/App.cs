using UberFood.Core.Context;
using UberFood.Core.Handlers;
using UberFood.Core.Models;
using Menu = UberFood.Affichage.Affichage;
using Saisie = UberFood.Interactions.Interactions;


//var seeder = new Seeder();
//seeder.SeedData();

Console.WriteLine("Base de données initialisée avec succès !");


//TODO : a la place du ensure created : methode dans le core pour ajouter et creer les objets (ADD) "Seeder"

bool quitter = false;
do
{
    Console.Clear();
    Menu.AfficherMenuDepart();
    var choix1 = Saisie.GetEntier("\nVeuillez choisir un option parmis les options proposée : ");

    var uHandler = new UserHandler();
    var defaultUser = uHandler.GetDefaultUser();
    var orderHandler = new Orderhandler();
    var opHandler = new OrderProductsHandler();

    var myOrders = opHandler.GetOrderProductsByUser(defaultUser.Id);
    var ordersGrouped = myOrders.GroupBy(o => o.OrderId).ToList();
    switch (choix1)
    {
        case 1: //Espace commande
            var prHandler = new ProductHandler();
            var products = prHandler.GetProducts();
            var basket = new List<ProductDto>();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id}. {product.Name}, {product.Price}euros ");
            }

            bool retourEspaceCommande = false;
            do
            {
                Console.Clear();
                Menu.AfficherMenuChoix1();

                var choix2 = Saisie.GetEntier("\nVeuillez choisir un option parmis les options proposée : ");
                switch (choix2)
                {
                    case 1: //Afficher la liste de produits
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Liste des produits");

                        //afficher la liste des produit
                        //Menu.AfficherListeProduit();
                        Menu.AfficherProduits(products);
                        Console.WriteLine("\nAppuyer sur une touche pour revenir en arrière");
                        Console.ReadKey();
                        break;
                    case 2: //Ajouter un produit au panier
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Ajout d'un produit au panier");
                        //afficher la liste de tous les produits
                        Menu.AfficherProduits(products);

                        var produitId = Saisie.GetEntier("\nVeuillez choisir un produit et saisir son id : ");
                        var productToAdd = products.Find(p => p.Id == produitId);
                        if (productToAdd is not null)
                            basket.Add(productToAdd);
                        //ajout du produit dans le panier
                        break;
                    case 3: //Supprimer un produit de son panier
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Supprimer un produit de votre panier");
                        Menu.AfficherProduits(basket);

                        //afficher le panier
                        var produitDelete = Saisie.GetEntier("\nVeuillez choisir un produit et saisir son id : ");
                        var productToRemove = products.Find(p => p.Id == produitDelete);
                        if (productToRemove is not null)
                            basket.Remove(productToRemove);
                        //supprimer le produitDelete parmis le panier
                        break;
                    case 4: //Afficher son panier
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Votre panier");
                        //afficher le panier en cours
                        Menu.AfficherProduits(basket);
                        Console.WriteLine("\nAppuyer sur une touche pour revenir en arrière");
                        Console.ReadKey();
                        break;
                    case 5: //Valider son panier
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Valider votre panier");
                        //afficher le panier en cours
                        Menu.AfficherProduits(basket);

                        Console.WriteLine("\nValidez vous votre panier ?");

                        //var opHandler = new 
                        var orderDto = new OrdersDto(defaultUser.Id, defaultUser.AddressId, DateTime.Now, DateTime.Now.AddHours(1), 1);
                        var orderId = orderHandler.AddOrders(orderDto);

                        foreach (var item in basket)
                        {
                            var oP = new OrderProductDto(orderId.Entity.OrderId, item.Id);
                            opHandler.AddOrderProduct(oP);
                        }
                        var intres = Saisie.GetEntier("\nAppuyez sur n'importe quelle touche pour continuer ");


                        //continuer sur la validation du panier
                        break;
                    case 6: //Supprimer son panier
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Supprimer votre panier");
                        //affficher le panier en cours
                        Console.WriteLine("\nSouhaitez vous supprimer votre panier ?");
                        var suppression = Saisie.GetString("\nVeuillez saisir oui ou non :");
                        if (suppression == "oui")
                        {
                            basket = null;
                        }
                        //continuer sur la validation du panier
                        break;

                    case 7: // Consulter mes commandes
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Afficher mes commandes");

                        myOrders = opHandler.GetOrderProductsByUser(defaultUser.Id);
                        ordersGrouped = myOrders.GroupBy(o => o.OrderId).ToList();
                        Menu.AfficherCommande(defaultUser.FirstName, ordersGrouped);

                        var res = Saisie.GetString("Appuyez sur n'importe quelle touche pour revenir en arrière");

                        break;
                    case 8: //Supprimer une commande
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Supprimer / Annuler une commande");
                        myOrders = opHandler.GetOrderProductsByUser(defaultUser.Id);
                        ordersGrouped = myOrders.GroupBy(o => o.OrderId).ToList();
                        Menu.AfficherCommande(defaultUser.FirstName, ordersGrouped);
                        var orderIdToDelete = Saisie.GetEntier("Merci d'entrer le numéro d'identification de la commande à supprimer");
                        opHandler.RemoveOrderById(orderIdToDelete);
                        //retourEspaceCommande = true;
                        break;

                    case 9: //Modification Statut commande
                        Console.Clear();
                        myOrders = opHandler.GetOrderProductsByUser(defaultUser.Id);
                        ordersGrouped = myOrders.GroupBy(o => o.OrderId).ToList();
                        Menu.AfficherCommande(defaultUser.FirstName, ordersGrouped);

                        var ordId = Saisie.GetEntier("Entrez le numéro de la commande dont le statut doit etre changé");
                        var newStatus = Saisie.GetEntier("Entrez le nouveau statut de commande");

                        orderHandler.UpdateOrderStatusById(ordId, newStatus);

                        res = Saisie.GetString("Appuyez sur n'importe quelle touche pour revenir en arrière");
                        retourEspaceCommande = true;
                        break;
                    case 10: //Retour en arrière
                        Console.Clear();
                        retourEspaceCommande = true;
                        break;
                    case 11: //Quitter l'application
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Console.WriteLine("\nMerci pour votre temps ! à bientôt !");
                        retourEspaceCommande = true;
                        quitter = true;
                        break;
                }
            } while (!retourEspaceCommande);
            break;
        case 2: //Espace gestion de produits
            bool retourEspaceProduit = false;
            do
            {
                Console.Clear();
                Menu.AfficherMenuChoix2();
                var choix3 = Saisie.GetEntier("\nVeuillez choisir un option parmis les options proposée : ");
                switch (choix3)
                {
                    case 1: //Ajouter un produit
                        bool retourAjoutProduit = false;
                        do
                        {
                            Console.Clear();
                            Menu.AfficherMenuAjoutProduit();
                            var choixTypeProduit = Saisie.GetEntier("\nVeuillez choisir un option parmis les options proposée : ");
                            switch (choixTypeProduit)
                            {
                                case 1: //Ajout d'une pizza
                                    Console.Clear();
                                    Menu.AfficherBandeau("UberFood");
                                    Menu.AfficherBandeau("Ajout d'une pizza");
                                    bool isVeggyPizza = Saisie.GetString("\nProduit vegetarien ? : o/n") == "o";
                                    bool alergenPizza = Saisie.GetString("\nProduit alergene ? : o/n") == "o";
                                    string newNamePizza = Saisie.GetString("\nSaisissez son nom");
                                    double newPricePizza = Convert.ToDouble(Saisie.GetEntier("\nSaisissez son prix\n"));
                                    Menu.AfficherChoixPate();
                                    int newPateIdPizza = Saisie.GetEntier("\nSaisissez le type de pate");
                                    //Création de l'objet
                                    PizzaDto newPizza = new(newPateIdPizza, isVeggyPizza, alergenPizza, newNamePizza, newPricePizza);
                                    //ajout a la BDD
                                    var pizzahandler = new PizzaHandler();
                                    var newPizzaId = pizzahandler.AddPizza(newPizza);



                                    //boucle d'ajout d'ingredients
                                    bool pizzaIngredients = true;
                                    while (pizzaIngredients)
                                    {
                                        if (pizzaIngredients = Saisie.GetString("Voulez vous ajouter un ingredient ? : o/n") == "o")
                                        {
                                            try
                                            {

                                                var newIngredientName = Saisie.GetString("Saisissez un ingredient");
                                                var newIngredientKCal = Convert.ToDouble(Saisie.GetEntier("\nSaisissez ses kCal"));
                                                IngredientDto newIngredient = new IngredientDto(newIngredientName, newIngredientKCal, newPizzaId, null);
                                                var ingredientHandler = new IngredientsHandler();
                                                ingredientHandler.AddIngredients(newIngredient);

                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }
                                        }
                                    }
                                    if (newPizzaId != null)
                                    {
                                        Console.WriteLine("\nAjout de la pizza avec succès !");
                                    }


                                    Console.ReadKey();
                                    break;
                                case 2: //Ajout d'un burger
                                    Console.Clear();
                                    Menu.AfficherBandeau("UberFood");
                                    Menu.AfficherBandeau("Ajout d'un burger");
                                    //Déclaration des variables pour les Burgers
                                    bool isVeggyBurger = Saisie.GetString("\nProduit vegetarien ? : o/n") == "o";
                                    bool alergenBurger = Saisie.GetString("\nProduit alergene ? : o/n") == "o";
                                    string newNameBurger = Saisie.GetString("\nSaisissez son nom");
                                    double newPriceBurger = Convert.ToDouble(Saisie.GetEntier("\nSaisissez son prix"));
                                    //Création de l'objet
                                    var newBurger = new BurgerDto(isVeggyBurger, alergenBurger, newNameBurger, newPriceBurger);
                                    //ajout a la BDD
                                    var burgerhandler = new BurgerHandler();
                                    var newBurgerId = burgerhandler.AddBurger(newBurger);
                                    //boucle d'ajout d'ingredients
                                    bool burgerIngredients = true;
                                    while (burgerIngredients)
                                    {
                                        if (burgerIngredients = Saisie.GetString("Voulez vous ajouter un ingredient ? : o/n") == "o")
                                        {
                                            try
                                            {

                                                var newIngredientName = Saisie.GetString("Saisissez un ingredient");
                                                var newIngredientKCal = Convert.ToDouble(Saisie.GetEntier("\nSaisissez ses kCal"));
                                                IngredientDto newIngredient = new IngredientDto(newIngredientName, newIngredientKCal, null, newBurgerId);
                                                var ingredientHandler = new IngredientsHandler();
                                                ingredientHandler.AddIngredients(newIngredient);

                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }
                                        }
                                    }
                                    if (newBurgerId != null)
                                    {
                                        Console.WriteLine("\nAjout du burger avec succès !");
                                    }

                                    Console.ReadKey();
                                    break;
                                case 3: //Ajout de pasta
                                    Console.Clear();
                                    Menu.AfficherBandeau("UberFood");
                                    Menu.AfficherBandeau("Ajout d'un plat de pates");
                                    //Déclaration des variables pour les Pastas
                                    bool isVeggyPasta = Saisie.GetString("\nProduit vegetarien ? : o/n") == "o";
                                    bool alergenPasta = Saisie.GetString("\nProduit alergene ? : o/n") == "o";
                                    string newNamePasta = Saisie.GetString("\nSaisissez son nom");
                                    double newPricePasta = Convert.ToDouble(Saisie.GetEntier("\nSaisissez son prix"));
                                    int newTypePasta = Saisie.GetEntier("Saisissez le type de pâte");
                                    double newKCalPasta = Convert.ToDouble(Saisie.GetEntier("\nSaisissez ses kCal"));
                                    //Création de l'objet
                                    var newPasta = new PastaDto(newTypePasta, newKCalPasta, isVeggyPasta, alergenPasta, newNamePasta, newPricePasta);
                                    //ajout a la BDD
                                    var pastahandler = new PastaHandler();
                                    pastahandler.AddPasta(newPasta);
                                    Console.WriteLine("\nAjout de la pasta avec succès !");
                                    Console.ReadKey();
                                    break;
                                case 4: //Retour au menu de gestion de produit
                                    Console.Clear();
                                    retourAjoutProduit = true;
                                    break;
                            }
                        } while (!retourAjoutProduit);
                        break;
                    case 2: //Modifier un produit
                        bool retourModificationProduit = false;
                        do
                        {
                            Console.Clear();
                            Menu.AfficherMenuModificationProduit();
                            var choixTypeProduit = Saisie.GetEntier("\nVeuillez choisir un option parmis les options proposée : ");
                            switch (choixTypeProduit)
                            {
                                case 1: //Modification d'une pizza
                                    Console.Clear();
                                    Menu.AfficherBandeau("UberFood");
                                    Menu.AfficherBandeau("Modification d'une pizza");
                                    var modifPizzaHandler = new PizzaHandler();
                                    var pizzasToUpdate = modifPizzaHandler.GetPizzas();
                                    Menu.AfficherPizzas(pizzasToUpdate);

                                    int saisiPizzaId = Saisie.GetEntier("Saisissez le burger a modifier");
                                    int updatePizzaId = 0;
                                    string newNamePizza = "";
                                    double newPricePizza = 0;
                                    foreach (var pizza in pizzasToUpdate)
                                    {
                                        if (pizza.Id == saisiPizzaId)
                                        {
                                            updatePizzaId = pizza.Id;
                                            newNamePizza = pizza.Name;
                                            newPricePizza = pizza.Price;

                                        }
                                    }
                                    Console.WriteLine(newNamePizza);

                                    string saisieNamePizza = Saisie.GetString($"Saisissez le nouveau nom du Pizza (laissez vide pour garder la valeur : {newNamePizza})");
                                    if (saisieNamePizza != "")
                                    {
                                        newNamePizza = saisieNamePizza;
                                    }

                                    double saisiePricePizza = Convert.ToDouble(Saisie.GetEntier($"Saisissez le nouveau prix du Pizza (laissez vide pour garder la valeur : {newPricePizza})"));
                                    if (saisiePricePizza != 0)
                                    {
                                        newPricePizza = saisiePricePizza;
                                    }

                                    bool updateVeggyPizza = Saisie.GetString("\nProduit vegetarien ? : o/n") == "o";
                                    bool updateAlergenPizza = Saisie.GetString("\nProduit alergene ? : o/n") == "o";
                                    Menu.AfficherChoixPate();
                                    int newdoughId = Saisie.GetEntier("\nSaisissez le type de pate");
                                    PizzaDto updatedPizza = new(newdoughId, updateVeggyPizza, updateAlergenPizza, newNamePizza, newPricePizza, updatePizzaId);

                                    modifPizzaHandler.UpdatePizza(updatedPizza);
                                    Console.ReadKey();
                                    break;
                                case 2: //Modification d'un burger
                                    Console.Clear();
                                    Menu.AfficherBandeau("UberFood");
                                    Menu.AfficherBandeau("Modification d'un burger");

                                    var modifBurgerHandler = new BurgerHandler();
                                    var burgersToUpdate = modifBurgerHandler.GetBurgers();
                                    Menu.AfficherBurger(burgersToUpdate);

                                    int saisiBurgerId = Saisie.GetEntier("Saisissez le burger a modifier");
                                    int updateBurgerId = 0;
                                    string newNameBurger = "";
                                    double newPriceBurger = 0;
                                    foreach (var burger in burgersToUpdate)
                                    {
                                        if (burger.Id == saisiBurgerId)
                                        {
                                            updateBurgerId = burger.Id;
                                            newNameBurger = burger.Name;
                                            newPriceBurger = burger.Price;

                                        }
                                        string saisieNameBurger = Saisie.GetString($"Saisissez le nouveau nom du burger (laissez vide pour garder la valeur : {newNameBurger})");
                                        if (saisieNameBurger != "")
                                        {
                                            newNameBurger = saisieNameBurger;
                                        }

                                        double saisiePriceBurger = Convert.ToDouble(Saisie.GetEntier($"Saisissez le nouveau prix du burger (laissez vide pour garder la valeur : {newPriceBurger})"));
                                        if (saisiePriceBurger != 0)
                                        {
                                            newPriceBurger = saisiePriceBurger;
                                        }

                                        bool updateVeggyBurger = Saisie.GetString("\nProduit vegetarien ? : o/n") == "o";
                                        bool updateAlergenBurger = Saisie.GetString("\nProduit alergene ? : o/n") == "o";

                                        BurgerDto updatedBurger = new(updateVeggyBurger, updateAlergenBurger, newNameBurger, newPriceBurger, updateBurgerId);

                                        modifBurgerHandler.UpdateBurger(updatedBurger);
                                    }
                                    Console.ReadKey();
                                    break;
                                case 3: //Modification de pasta
                                    Console.Clear();
                                    Menu.AfficherBandeau("UberFood");
                                    Menu.AfficherBandeau("Modification de pasta");
                                    var modifPastaHandler = new PastaHandler();
                                    var PastasToUpdate = modifPastaHandler.GetPastas();
                                    Menu.AfficherPasta(PastasToUpdate);

                                    int saisiPastaId = Saisie.GetEntier("Saisissez le Pasta a modifier");
                                    int updatePastaId = 0;
                                    string newNamePasta = "";
                                    int newTypePasta = 0;
                                    double newKCalPasta = 0;
                                    double newPricePasta = 0;
                                    foreach (var Pasta in PastasToUpdate)
                                    {
                                        if (Pasta.Id == saisiPastaId)
                                        {
                                            updatePastaId = Pasta.Id;
                                            newNamePasta = Pasta.Name;
                                            newPricePasta = Pasta.Price;
                                            newTypePasta = Pasta.Type;

                                        }
                                        string saisieNamePasta = Saisie.GetString($"Saisissez le nouveau nom du Pasta (laissez vide pour garder la valeur : {newNamePasta})");
                                        if (saisieNamePasta != "")
                                        {
                                            newNamePasta = saisieNamePasta;
                                        }


                                        double saisiePricePasta = Convert.ToDouble(Saisie.GetEntier($"Saisissez le nouveau prix du Pasta (laissez vide pour garder la valeur : {newPricePasta})"));
                                        if (saisiePricePasta != 0)
                                        {
                                            newPricePasta = saisiePricePasta;
                                        }
                                        int saisieTypePasta = Saisie.GetEntier($"Saisissez le nouveau nom du Pasta (laissez vide pour garder la valeur : {newTypePasta})");
                                        if (saisieTypePasta != 0)
                                        {
                                            newTypePasta = saisieTypePasta;
                                        }
                                        double saisieKCalPasta = Convert.ToDouble(Saisie.GetEntier($"Saisissez le nouveau prix du Pasta (laissez vide pour garder la valeur : {newKCalPasta})"));
                                        if (saisieKCalPasta != 0)
                                        {
                                            newKCalPasta = saisieKCalPasta;
                                        }

                                        bool updateVeggyPasta = Saisie.GetString("\nProduit vegetarien ? : o/n") == "o";
                                        bool updateAlergenPasta = Saisie.GetString("\nProduit alergene ? : o/n") == "o";

                                        PastaDto updatedPasta = new(newTypePasta, newKCalPasta, updateVeggyPasta, updateAlergenPasta, newNamePasta, newPricePasta, updatePastaId);

                                        modifPastaHandler.UpdatePasta(updatedPasta);
                                    }
                                    Console.ReadKey();
                                    break;
                                case 4: //retour au menu de gestion de produit
                                    Console.Clear();
                                    retourModificationProduit = true;
                                    break;
                            }
                        } while (!retourModificationProduit);
                        break;
                    case 3: //Supprimer un produit
                        bool retourSuppressionProduit = false;
                        do
                        {
                            Console.Clear();
                            Menu.AfficherMenuSuppressionProduit();
                            var choixTypeProduit = Saisie.GetEntier("\nVeuillez choisir un option parmis les options proposée : ");
                            switch (choixTypeProduit)
                            {
                                case 1: //Supprimer une pizza
                                    Console.Clear();
                                    Menu.AfficherBandeau("UberFood");
                                    Menu.AfficherBandeau("Suppression d'une pizza");
                                    //Afficher la liste des pizzas
                                    var delPizzaHandler = new PizzaHandler();
                                    Menu.AfficherPizzas(delPizzaHandler.GetPizzas());
                                    var choixSuppressionPizza = Saisie.GetEntier("\nVeuillez choisir un produit et saisir son id : ");

                                    //Appliquer la suppresion du produit avec la valeur saisie

                                    delPizzaHandler.DeletePizza(choixSuppressionPizza);
                                    break;
                                case 2: //Supprimer un burger
                                    Console.Clear();
                                    Menu.AfficherBandeau("UberFood");
                                    Menu.AfficherBandeau("Suppression d'un Burger");
                                    //Afficher la liste des burgers
                                    var delBurgerHandler = new BurgerHandler();
                                    Menu.AfficherBurger(delBurgerHandler.GetBurgers());
                                    var choixSuppressionBurger = Saisie.GetEntier("\nVeuillez choisir un produit et saisir son id : ");

                                    //Appliquer la suppresion du produit avec la valeur saisie

                                    delBurgerHandler.DeleteBurger(choixSuppressionBurger);
                                    break;
                                case 3: //Supprimer une pasta
                                    Console.Clear();
                                    Menu.AfficherBandeau("UberFood");
                                    Menu.AfficherBandeau("Suppression de pasta");
                                    //Afficher la liste des pasta
                                    var delPastaHandler = new PastaHandler();
                                    Menu.AfficherPasta(delPastaHandler.GetPastas());
                                    var choixSuppressionPasta = Saisie.GetEntier("\nVeuillez choisir un produit et saisir son id : ");

                                    //Appliquer la suppresion du produit avec la valeur saisie

                                    delPastaHandler.DeletePasta(choixSuppressionPasta);
                                    break;
                                case 4: //retour au menu de gestion de produit
                                    Console.Clear();
                                    retourSuppressionProduit = true;
                                    break;
                            }
                        } while (!retourSuppressionProduit);
                        break;
                    case 4: //Retour au menu principal
                        Console.Clear();
                        retourEspaceProduit = true;
                        break;
                    case 5: //Quitter l'application
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Console.WriteLine("\nMerci pour votre temps ! à bientôt !");
                        retourEspaceProduit = true;
                        quitter = true;
                        break;
                }
            } while (!retourEspaceProduit);
            break;
        case 3: //Gestion client
            bool retourEspaceClient = false;
            do
            {
                Console.Clear();
                Menu.AfficherMenuChoix3();
                var choixTypeProduit = Saisie.GetEntier("\nVeuillez choisir un option parmis les options proposée : ");
                switch (choixTypeProduit)
                {
                    case 1: //Ajouter un client
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Ajout d'un client");
                        string userFirstname = Saisie.GetString("\nQuel est votre nom ? : ");
                        string userLastname = Saisie.GetString("\nQuel est votre prénom ? : ");
                        string userPhone = Saisie.GetString("\nQuel est votre numéro de téléphone ? : ");
                        string userMail = Saisie.GetString("\nQuel est votre email ? : ");
                        Console.WriteLine("\nNous allons maintenant vous demander vos informations pour renseigner votre adresse : ");
                        string userStreet = Saisie.GetString("\nQuel est votre rue ? : ");
                        string userCity = Saisie.GetString("\nQuel est votre ville ? : ");
                        string userState = Saisie.GetString("\nQuel est votre région ? : ");
                        string userZip = Saisie.GetString("\nQuel est votre code postal ? : ");
                        string userCountry = Saisie.GetString("\nQuel est votre pays ? : ");
                        var newAdress = new AdressDto(userStreet, userCity, userState, userZip, userCountry);
                        var newUser = new UserDto(userFirstname, userLastname, userPhone, userMail, newAdress.Id);
                        var userHandler = new UserHandler();
                        userHandler.AddUser(newUser);
                        Console.WriteLine("\nAjout de la pasta avec succès !");
                        break;
                    case 2: //Modifier un client
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Modification d'un client");
                        Menu.AfficherListeUsers();
                        int userId = Saisie.GetEntier("\nVeuillez saisir l'ID du client à modifier : ");
                        using (var context = new DataContext())
                        {
                            var user = context.Users.FirstOrDefault(u => u.Id == userId);
                            if (user == null)
                            {
                                Console.WriteLine("Aucun utilisateur trouvé avec cet ID.");
                                break;
                            }
                            Console.WriteLine($"\nUtilisateur sélectionné : {user.FirstName} {user.LastName}");
                            // Saisie des nouvelles infos
                            string nouveauPrenom = Saisie.GetString("Nouveau prénom : ");
                            string nouveauNom = Saisie.GetString("Nouveau nom : ");
                            string nouveauTel = Saisie.GetString("Nouveau téléphone : ");
                            string nouveauMail = Saisie.GetString("Nouvel email : ");
                            // Mise à jour
                            user.FirstName = nouveauPrenom;
                            user.LastName = nouveauNom;
                            user.Phone = nouveauTel;
                            user.Mail = nouveauMail;
                            context.SaveChanges();
                            Console.WriteLine("\nClient modifié avec succès !");
                        }
                        break;
                    case 3: //Supprimer un client
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Suppression d'un client");
                        Menu.AfficherListeUsers();
                        int choixSuppression = Saisie.GetEntier("\nVeuillez saisir l'id du client que vous souhaitez supprimer : ");
                        Menu.AfficherUser(choixSuppression);
                        var userHandler2 = new UserHandler();
                        userHandler2.DeleteUsers(choixSuppression);
                        break;
                    case 4: //Liste des clients
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Liste des clients");
                        Menu.AfficherListeUsers();
                        Console.WriteLine("\nAppuyer sur une touche pour revenir en arrière");
                        Console.ReadKey();
                        break;
                    case 5: //Retour en arrière
                        Console.Clear();
                        retourEspaceClient = true;
                        break;
                    case 6: //Quitter l'application
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Console.WriteLine("\nMerci pour votre temps ! à bientôt !");
                        retourEspaceClient = true;
                        quitter = true;
                        break;
                }
            } while (!retourEspaceClient);
            break;
        case 4: //Quitter l'application
            Console.Clear();
            Menu.AfficherBandeau("UberFood");
            Console.WriteLine("\nMerci pour votre temps ! à bientôt !");
            quitter = true;
            break;
    }
} while (!quitter);

