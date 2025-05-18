public class Fruits
{
    private Dictionary<string, int> stock = new Dictionary<string, int>();

    public void Ajouter(string nomFruit, int quantite)
    {
        nomFruit = nomFruit.ToLower();
        if (stock.ContainsKey(nomFruit))
            stock[nomFruit] += quantite;
        else
            stock[nomFruit] = quantite;
    }

    public bool Avoir(string nomFruit)
    {
        return stock.ContainsKey(nomFruit) && stock[nomFruit] > 0;
    }

    public void Afficher()
    {
        Console.WriteLine("\n🍎 Inventaire de fruits :");
        foreach (var entry in stock)
        {
            Console.WriteLine($"- {entry.Key} : {entry.Value} fruit(s)");
        }
    }

    public Dictionary<string, int> GetStock() => stock;
}
