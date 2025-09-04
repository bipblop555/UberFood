namespace UberFood.Affichage{
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
            AfficherBoutons("3. Quitter l'application");
            
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
            AfficherBoutons("7. Retour en arrière");
            AfficherBoutons("8. Quitter l'application");

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
    }
}
