public abstract class Plante
{
    //  Propriétés générales de la plante
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
    public bool EstBlessee => Sante < 100 && Sante > 0;  //   savoir si une plante est blessée

    //  Méthode pour soigner une plante
    public void Soigner()
    {
        if (Sante <= 0)
        {
            Console.WriteLine($"{Nom} est morte. Impossible de la soigner.");
            return;
        }

        int gain = 20;
        int santeInitiale = Sante;
        Sante += gain;
        if (Sante > 100) Sante = 100;

        Console.WriteLine($"{Nom} a été soignée. Santé : {santeInitiale} → {Sante}");
    }

    // Interaction utilisateur pour proposer un soin
    public void ProposerSoin()
    {
        if (EstBlessee)
        {
            Console.WriteLine($"{Nom} est affaiblie. Souhaitez-vous la soigner ? Tapez 'soigner' pour lui administrer un soin.");
            string reponse = Console.ReadLine();
            if (reponse != null && reponse.Trim().ToLower() == "soigner")
            {
                Soigner();
            }
            else
            {
                Console.WriteLine($"{Nom} n'a pas été soignée.");
            }
        }
    }

    //  Évaluation quotidienne de la plante selon météo et terrain
    public void Evaluer(Meteo meteo, Terrain terrain)
    {
        if (Sante <= 0)
        {
            Console.WriteLine($"{Nom} est déjà morte.");
            return;
        }

        int santeInitiale = Sante;
        int conditionsFavorables = 0;
        int conditionsTotal = 5;

        //  Température
        if (meteo.Temperature < TemperatureMin || meteo.Temperature > TemperatureMax)
        {
            Sante -= 15;
            Console.WriteLine($"{Nom} souffre d'une température extrême ({meteo.Temperature}°C).");
        }
        else
        {
            conditionsFavorables++;
        }

        //  Lumière
        if (meteo.Ensoleillement < BesoinLumiere)
        {
            Sante -= 10;
            Console.WriteLine($"{Nom} manque de lumière (ensoleillement {meteo.Ensoleillement}).");
        }
        else
        {
            conditionsFavorables++;
        }

        //  Eau
        if (meteo.Precipitations < BesoinEau * 0.8)
        {
            Sante -= 10;
            Console.WriteLine($"{Nom} n’a pas reçu assez d’eau ({meteo.Precipitations}mm).");
        }
        else if (meteo.Precipitations > BesoinEau * 1.5)
        {
            Sante -= 5;
            Console.WriteLine($"{Nom} a trop d’eau ({meteo.Precipitations}mm).");
        }
        else
        {
            conditionsFavorables++;
        }

        //  Terrain
        if (terrain.TypeSol != TerrainPrefere)
        {
            Sante -= 10;
            Console.WriteLine($"{Nom} est mal adaptée au terrain {terrain.TypeSol} (préféré : {TerrainPrefere}).");
        }
        else
        {
            conditionsFavorables++;
        }

        //  Maladies
        foreach (var maladie in MaladiesProbabilites)
        {
            if (new Random().NextDouble() < maladie.Value)
            {
                Sante -= 10;
                Console.WriteLine($"{Nom} a été touchée par la maladie : {maladie.Key}.");
            }
        }

        //  Intempéries
        if (meteo.Intemperies && new Random().NextDouble() < 0.3)
        {
            Sante -= 10;
            Console.WriteLine($"{Nom} a été endommagée par une intempérie ({meteo.EvenementSpecial}).");
        }

        //  Bonus si au moins 3 conditions sont favorables
        if (conditionsFavorables >= 3)
        {
            int gain = 10;
            if (Sante + gain > 100) gain = 100 - Sante;
            Sante += gain;
            Console.WriteLine($"{Nom} prospère grâce à des conditions favorables ! Santé +{gain}.");
        }
        else if ((double)conditionsFavorables / conditionsTotal < 0.5)
        {
            Sante = 0;
            Console.WriteLine($"{Nom} est morte car moins de 50% des conditions essentielles sont remplies.");
            return;
        }

        // 📈 Croissance
        if (Sante > 70)
        {
            VitesseCroissance += 0.1;
            Console.WriteLine($"{Nom} pousse bien.");
        }

        //  Clamp santé entre 0 et 100
        if (Sante <= 0)
        {
            Sante = 0;
            Console.WriteLine($"{Nom} est morte.");
        }
        else if (Sante > 100)
        {
            Sante = 100;
        }

        // Affichage si la santé a changé
        if (Sante != santeInitiale)
        {
            Console.WriteLine($"Santé de {Nom} : {santeInitiale} → {Sante}");
        }

        // Proposer un soin à la fin de l’évaluation si la plante est blessée
        ProposerSoin();
    }
}
