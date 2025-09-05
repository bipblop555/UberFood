using Microsoft.EntityFrameworkCore;
using UberFood.Core;
using UberFood.Core.Context;
using UberFood.Core.Handlers;
using UberFood.Core.Models;
using static UberFood.Core.Context.DataContext;
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
    switch (choix1)
    {
        case 1: //Espace commande
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
                        Menu.AfficherListeProduit();
                        Console.WriteLine("\nAppuyer sur une touche pour revenir en arrière");
                        Console.ReadKey();
                        break;
                    case 2: //Ajouter un produit au panier
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Ajout d'un produit au panier");
                        //afficher la liste de tous les produits
                        Menu.AfficherListeProduit();
                        var produit = Saisie.GetEntier("\nVeuillez choisir un produit et saisir son id : ");
                        //ajout du produit dans le panier
                        break;
                    case 3: //Supprimer un produit de son panier
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Supprimer un produit de votre panier");
                        //afficher le panier
                        var produitDelete = Saisie.GetEntier("\nVeuillez choisir un produit et saisir son id : ");
                        //supprimer le produitDelete parmis le panier
                        break;
                    case 4: //Afficher son panier
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Votre panier");
                        //afficher le panier en cours
                        Console.WriteLine("\nAppuyer sur une touche pour revenir en arrière");
                        Console.ReadKey();
                        break;
                    case 5: //Valider son panier
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Valider votre panier");
                        //afficher le panier en cours
                        Console.WriteLine("\nValidez vous votre panier ?");
                        var validation = Saisie.GetString("\nVeuillez saisir oui ou non :");
                        //continuer sur la validation du panier
                        break;
                    case 6: //Supprimer son panier
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Supprimer votre panier");
                        //affficher le panier en cours
                        Console.WriteLine("\nSouhaitez vous supprimer votre panier ?");
                        var suppression = Saisie.GetString("\nVeuillez saisir oui ou non :");
                        //continuer sur la validation du panier
                        break;
                    case 7: //Retour en arrière
                        Console.Clear();
                        retourEspaceCommande = true;
                        break;
                    case 8: //Quitter l'application
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
                                    var newPizza = new PizzaDto(newPateIdPizza, isVeggyPizza, alergenPizza, newNamePizza, newPricePizza);
                                    //ajout a la BDD
                                    var pizzahandler = new PizzaHandler();
                                    pizzahandler.AddPizza(newPizza);
                                    Console.WriteLine("\nAjout de la pizza avec succès !");

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
                                    burgerhandler.AddBurger(newBurger);
                                    Console.WriteLine("\nAjout du burger avec succès !");
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
                                    Console.ReadKey();
                                    break;
                                case 2: //Modification d'un burger
                                    Console.Clear();
                                    Menu.AfficherBandeau("UberFood");
                                    Menu.AfficherBandeau("Modification d'un burger");
                                    Console.ReadKey();
                                    break;
                                case 3: //Modification de pasta
                                    Console.Clear();
                                    Menu.AfficherBandeau("UberFood");
                                    Menu.AfficherBandeau("Modification de pasta");
                                    Console.ReadKey();
                                    break;
                                case 4: //retour au menu de gestion de produit
                                    Console.Clear();
                                    retourModificationProduit = true;
                                    break;
                            }
                        } while(!retourModificationProduit);
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
                                    //Afficher la liste des pizza
                                    var choixSuppressionPizza = Saisie.GetEntier("\nVeuillez choisir un produit et saisir son id : ");
                                    //Appliquer la suppresion du produit avec la valeur saisie
                                    break;
                                case 2: //Supprimer un burger
                                    Console.Clear();
                                    Menu.AfficherBandeau("UberFood");
                                    Menu.AfficherBandeau("Suppression d'un Burger");
                                    //Afficher la liste des burgers
                                    var choixSuppressionBurger = Saisie.GetEntier("\nVeuillez choisir un produit et saisir son id : ");
                                    //Appliquer la suppresion du produit avec la valeur saisie
                                    break;
                                case 3: //Supprimer une pasta
                                    Console.Clear();
                                    Menu.AfficherBandeau("UberFood");
                                    Menu.AfficherBandeau("Suppression de pasta");
                                    //Afficher la liste des pasta
                                    var choixSuppressionPasta = Saisie.GetEntier("\nVeuillez choisir un produit et saisir son id : ");
                                    //Appliquer la suppresion du produit avec la valeur saisie
                                    break;
                                case 4: //retour au menu de gestion de produit
                                    Console.Clear();
                                    retourSuppressionProduit = true;
                                    break;
                            }
                        } while(!retourSuppressionProduit);
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
            } while(!retourEspaceProduit);
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
                        var newAdress = new AdressDto(userStreet,userCity, userState, userZip, userCountry);
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
            } while(!retourEspaceClient);
            break;
        case 4: //Quitter l'application
            Console.Clear();
            Menu.AfficherBandeau("UberFood");
            Console.WriteLine("\nMerci pour votre temps ! à bientôt !");
            quitter = true;
            break;
    }
} while(!quitter);

