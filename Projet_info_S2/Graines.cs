public class Graines
{
    private Dictionary<string, int> stock = new Dictionary<string, int>();

    // Ajouter une ou plusieurs graines
    public void Ajouter(string nomPlante, int quantite = 1)
    {
        if (stock.ContainsKey(nomPlante))
            stock[nomPlante] += quantite;
        else
            stock[nomPlante] = quantite;
    }

    // Utiliser une graine (retire 1 si dispo, sinon refuse)
    public bool Utiliser(string nomPlante)
    {
        if (stock.ContainsKey(nomPlante) && stock[nomPlante] > 0)
        {
            stock[nomPlante]--;
            return true;
        }

        Console.WriteLine($"❌ Vous n'avez plus de graines pour {nomPlante} !");
        return false;
    }

    // Vérifie si on a au moins 1 graine
    public bool AGraines(string nomPlante)
    {
        return stock.ContainsKey(nomPlante) && stock[nomPlante] > 0;
    }

    // Affiche l’inventaire complet
    public void Afficher()
    {
        Console.WriteLine("\n Inventaire de graines :");
        foreach (var entry in stock)
        {
            Console.WriteLine($"- {entry.Key} : {entry.Value} graine(s)");
        }
    }
}
