namespace UberFood.Interactions;

public class Interactions
{
    public static string GetString(string message)
    {
        string chaine = "";
        Console.WriteLine(message);
        chaine = Console.ReadLine();
        return chaine;
    }

    public static int GetEntier(string message)
    {
        string chaine = "";
        int sortie;
        Console.WriteLine(message);
        chaine = Console.ReadLine();
        if (!int.TryParse(chaine, out sortie))
            sortie = 0;
        return sortie;
    }
}
