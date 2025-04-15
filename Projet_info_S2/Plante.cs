public abstract class Plante
{
    public string Nom { get; set; }
    public string Type { get; set; } // Annuelle, Vivace, etc.
    public List<string> SaisonsDeSemis { get; set; }
    public double Espacement { get; set; }
    public string TerrainPrefere { get; set;}
    public double PlaceNecessairePourGrandir { get; set; }
    public double VitesseCroissance { get; set; }
    public double BesoinEau { get; set; }
    public double BesoinLumiere { get; set; }
    public double TemperatureMin { get; set; }
    public double TemperatureMax { get; set; }
    public Dictionary<string, double> MaladiesProbabilites { get; set; }
    public double EsperanceDeVie { get; set; } // en jours
    public int Production { get; set; } // nombre de fruits/légumes
    public int Sante { get; set; } // 0-100
    
    public void Evaluer(Meteo meteo, Terrain terrain)
{
    if (Sante <= 0)
    {
        Console.WriteLine($"{Nom} est déjà morte.");
        return;
    }

    // Température
    if (meteo.Temperature < TemperatureMin || meteo.Temperature > TemperatureMax)
    {
        Sante -= 15;
        Console.WriteLine($"{Nom} souffre d'une température extrême ({meteo.Temperature}°C).");
    }

    // Lumière
    if (meteo.Ensoleillement < BesoinLumiere)
    {
        Sante -= 10;
        Console.WriteLine($"{Nom} manque de lumière (ensoleillement {meteo.Ensoleillement}).");
    }

    // Eau
    if (meteo.Precipitations < BesoinEau)
    {
        Sante -= 10;
        Console.WriteLine($"{Nom} n’a pas reçu assez d’eau ({meteo.Precipitations}mm).");
    }
    else if (meteo.Precipitations > BesoinEau * 2)
    {
        Sante -= 5;
        Console.WriteLine($"{Nom} a trop d’eau ({meteo.Precipitations}mm).");
    }

    // Terrain (type uniquement ici)
    if (terrain.TypeSol != TerrainPrefere)
    {
        Sante -= 10;
        Console.WriteLine($"{Nom} est mal adaptée au terrain {terrain.TypeSol} (préféré : {TerrainPrefere}).");
    }

    // Maladies aléatoires
    foreach (var maladie in MaladiesProbabilites)
    {
        if (new Random().NextDouble() < maladie.Value)
        {
            Sante -= 10;
            Console.WriteLine($"{Nom} a été touchée par la maladie : {maladie.Key}.");
        }
    }

    // Intempéries (aléatoire)
    if (meteo.Intemperies && new Random().NextDouble() < 0.3)
    {
        Sante -= 10;
        Console.WriteLine($"{Nom} a été endommagée par une intempérie ({meteo.EvenementSpecial}).");
    }

    // Croissance si tout va bien
    if (Sante > 70)
    {
        VitesseCroissance += 0.1;
        Console.WriteLine($"{Nom} pousse bien.");
    }

    // Mort
    if (Sante <= 0)
    {
        Sante = 0;
        Console.WriteLine($"{Nom} est morte.");
    }
}

}