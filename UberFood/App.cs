using Microsoft.EntityFrameworkCore;
using UberFood.Core.Context;
using UberFood.Core.Handlers;
using UberFood.Core.Models;
using static UberFood.Core.Context.DataContext;
using Menu = UberFood.Affichage.Affichage;
using Saisie = UberFood.Interactions.Interactions;



// Configuration manuelle du contexte
var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
optionsBuilder.UseSqlServer("Server=localhost;Database=TaBase;Trusted_Connection=True;");

using var context = new DataContext(optionsBuilder.Options);

// Appel du seeder
DbInitializer.Seed(context);

Console.WriteLine("Base de données initialisée avec succès !");


//TODO : a la place du ensure created : methode dans le core pour ajouter et creer les objets (ADD) "Seeder"

bool quitter = false;
do
{
    Console.Clear();
    Menu.AfficherMenuDepart();
    var choix1 = Saisie.GetEntier("\nVeuiller choisir un option parmis les options proposée : ");
    switch (choix1)
    {
        case 1: //Espace commande
            bool retourEspaceCommande = false;
            do
            {
                Console.Clear();
                Menu.AfficherMenuChoix1();
                var choix2 = Saisie.GetEntier("\nVeuiller choisir un option parmis les options proposée : ");
                switch (choix2)
                {
                    case 1: //Afficher la liste de produits
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Liste des produits");
                        //afficher la liste des produit
                        var pizzaHandler = new PizzaHandler ();
                        var pizzas = pizzaHandler.GetPizzas();
                        Menu.AfficherPizzas(pizzas);
                        var burgerHandler = new BurgerHandler ();
                        var burgers = burgerHandler.GetBurgers();
                        Menu.AfficherBurger(burgers);
                        var pastaHandler = new PastaHandler();
                        var pastas = pastaHandler.GetPastas();
                        Menu .AfficherPasta(pastas);
                        
                        Console.WriteLine("\nAppuyer sur une touche pour revenir en arrière");
                        Console.ReadKey();
                        break;
                    case 2: //Ajouter un produit au panier
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Ajout d'un produit au panier");
                        //afficher la liste de tous les produits
                        var produit = Saisie.GetEntier("\nVeuiller choisir un produit et saisir son id : ");
                        //ajout du produit dans le panier
                        break;
                    case 3: //Supprimer un produit de son panier
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Supprimer un produit de votre panier");
                        //afficher le panier
                        var produitDelete = Saisie.GetEntier("\nVeuiller choisir un produit et saisir son id : ");
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
                        var validation = Saisie.GetString("\nVeuiller saisir oui ou non :");
                        //continuer sur la validation du panier
                        break;
                    case 6: //Supprimer son panier
                        Console.Clear();
                        Menu.AfficherBandeau("UberFood");
                        Menu.AfficherBandeau("Supprimer votre panier");
                        //affficher le panier en cours
                        Console.WriteLine("\nSouhaitez vous supprimer votre panier ?");
                        var suppression = Saisie.GetString("\nVeuiller saisir oui ou non :");
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
                var choix3 = Saisie.GetEntier("\nVeuiller choisir un option parmis les options proposée : ");
                switch (choix3)
                {
                    case 1: //Ajouter un produit
                        bool retourAjoutProduit = false;
                        do
                        {
                            Console.Clear();
                            Menu.AfficherMenuAjoutProduit();
                            var choixTypeProduit = Saisie.GetEntier("\nVeuiller choisir un option parmis les options proposée : ");
                            switch (choixTypeProduit)
                            {
                                case 1: //Ajout d'une pizza
                                    Console.Clear();
                                    Menu.AfficherBandeau("UberFood");
                                    Menu.AfficherBandeau("Ajout d'une pizza");
                                    Console.ReadKey();
                                    break;
                                case 2: //Ajout d'un burger
                                    Console.Clear();
                                    Menu.AfficherBandeau("UberFood");
                                    Menu.AfficherBandeau("Ajout d'un burger");
                                    Console.ReadKey();
                                    break;
                                case 3: //Ajout de pasta
                                    Console.Clear();
                                    Menu.AfficherBandeau("UberFood");
                                    Menu.AfficherBandeau("Ajout de pasta");
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
                            var choixTypeProduit = Saisie.GetEntier("\nVeuiller choisir un option parmis les options proposée : ");
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
                            var choixTypeProduit = Saisie.GetEntier("\nVeuiller choisir un option parmis les options proposée : ");
                            switch (choixTypeProduit)
                            {
                                case 1: //Supprimer une pizza
                                    Console.Clear();
                                    Menu.AfficherBandeau("UberFood");
                                    Menu.AfficherBandeau("Suppression d'une pizza");
                                    //Afficher la liste des pizza
                                    var choixSuppressionPizza = Saisie.GetEntier("\nVeuiller choisir un produit et saisir son id : ");
                                    //Appliquer la suppresion du produit avec la valeur saisie
                                    break;
                                case 2: //Supprimer un burger
                                    Console.Clear();
                                    Menu.AfficherBandeau("UberFood");
                                    Menu.AfficherBandeau("Suppression d'un Burger");
                                    //Afficher la liste des burgers
                                    var choixSuppressionBurger = Saisie.GetEntier("\nVeuiller choisir un produit et saisir son id : ");
                                    //Appliquer la suppresion du produit avec la valeur saisie
                                    break;
                                case 3: //Supprimer une pasta
                                    Console.Clear();
                                    Menu.AfficherBandeau("UberFood");
                                    Menu.AfficherBandeau("Suppression de pasta");
                                    //Afficher la liste des pasta
                                    var choixSuppressionPasta = Saisie.GetEntier("\nVeuiller choisir un produit et saisir son id : ");
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
        case 3: //Quitter l'application
            Console.Clear();
            Menu.AfficherBandeau("UberFood");
            Console.WriteLine("\nMerci pour votre temps ! à bientôt !");
            quitter = true;
            break;
    }
} while(!quitter);

