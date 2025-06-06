public abstract class Plante
{
    //  Propriétés générales de la plante
    public string Nom { get; set; }
    public string Type { get; set; } // Annuelle, Vivace, etc.
    public List<string> SaisonsDeSemis { get; set; } = new List<string>();
    public double Espacement { get; set; }
    public string TerrainPrefere { get; set; }
    public double PlaceNecessairePourGrandir { get; set; }
    public double VitesseCroissance { get; set; }
    public double BesoinEau { get; set; } //en mm/semaine
    public double BesoinLumiere { get; set; } // de 0 à 1
    public double TemperatureMin { get; set; }
    public double TemperatureMax { get; set; }
    public Dictionary<string, double> MaladiesProbabilites { get; set; } = new Dictionary<string, double>();
    public double EsperanceDeVie { get; set; } // en semaines
    public int QuantiteFruits { get; set; }
    public int GrainesParFruit { get; set; }
    public int Sante { get; set; } // 0-100
    public List<string> MaladiesActives { get; set; } = new List<string>();
    public bool EstBlessee => Sante < 100 && Sante > 0;  //   savoir si une plante est blessée
    private bool SoinEffectueCeTour = false;
    public double CroissanceActuelle { get; set; } = 0; // 0 à 1 permet de savoir si l'on peut ou non récolter la plante 
    public bool EstMure => CroissanceActuelle >= 1 && Sante > 0;
    public bool ASoif { get; set; } = false;
    public bool DoitEtreArrosee(double precipitations)
    {
        return precipitations < BesoinEau * 0.8;
    }
    int conditionsFavorables = 0;
    
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
        SoinEffectueCeTour = true;
    }

    // Interaction utilisateur pour proposer un soin
    public void ProposerSoin()
    {
        if (EstBlessee)
        {
            if (MaladiesActives != null && MaladiesActives.Count != 0)
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
    }
    public void Arroser(int x, int y)
    {
        if (Sante <= 0)
        {
            Console.WriteLine($"{Nom} ({x},{y}) en  est morte. Impossible de l'arroser.");
            return;
        }
        int gain = 5;
        int santeInitiale = Sante;
        Sante += gain;
        if (Sante > 100) Sante = 100;

        Console.WriteLine($"{Nom} ({x},{y}) a été arrosée.");
        ASoif = false;
        conditionsFavorables++;
    }
    public void ProposerArrosage(int x, int y)
    {
        if (ASoif)
        {
            Console.WriteLine($"{Nom} en ({x},{y})est a soif. Souhaitez-vous l'arroser ? Tapez 'arroser' pour lui administrer l'eau suffisante.");
            string reponse = Console.ReadLine().ToLower();
            if (reponse != null && reponse.Trim().ToLower() == "arroser")
            {
                Arroser(x,y);
            }
            else
            {
                Console.WriteLine($"{Nom} n'a pas été arrosée.");
            }

        }
    }

    //  Évaluation quotidienne de la plante selon météo et terrain

    public void Evaluer(Meteo meteo, Terrain terrain, int x, int y)
    {
        if (Sante <= 0)
        {
            Console.WriteLine($"{Nom} en ({x},{y}) est morte.");
            return;
        }

        int santeInitiale = Sante;
        int conditionsTotal = 5;

        //  Température
        if (meteo.Temperature < TemperatureMin || meteo.Temperature > TemperatureMax)
        {
            Sante -= 5;
            Console.WriteLine($"{Nom} en ({x},{y}) souffre d'une température extrême ({meteo.Temperature}°C).");
        }
        else
        {
            conditionsFavorables++;
        }
        // Croissance
        if (Sante > 70)
        {
            VitesseCroissance += 0.1;
            CroissanceActuelle += VitesseCroissance;
            Console.WriteLine($"{Nom} en ({x},{y}) pousse bien.");
        }

        //  Lumière
        if (meteo.Ensoleillement < BesoinLumiere)
        {
            Sante -= 5;
            Console.WriteLine($"{Nom} en ({x},{y}) manque de lumière (ensoleillement {meteo.Ensoleillement}).");
        }
        else
        {
            conditionsFavorables++;
        }

        //  Eau
        if (meteo.Precipitations < BesoinEau * 0.9)
        {
            ASoif = true;
            Console.WriteLine($"{Nom} en ({x},{y}) n’a pas reçu assez d’eau ({meteo.Precipitations}mm).");
            ProposerArrosage(x,y);
        }

        else if (meteo.Precipitations > BesoinEau * 1.9)

        {
            Sante -= 5;
            Console.WriteLine($"{Nom} en ({x},{y}) a trop d’eau ({meteo.Precipitations}mm).");
        }
        else
        {
            conditionsFavorables++;
        }

        //  Terrain
        if (terrain.TypeSol != TerrainPrefere)
        {
            Sante -= 10;
            Console.WriteLine($"{Nom} en ({x},{y}) est mal adaptée au terrain {terrain.TypeSol} (préféré : {TerrainPrefere}).");
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
                if (!MaladiesActives.Contains(maladie.Key))
                {
                    MaladiesActives.Add(maladie.Key);
                    Console.WriteLine($"{Nom} en ({x},{y}) a été touchée par la maladie : {maladie.Key}.");
                }
            }
        }

        //  Intempéries
        if (meteo.Intemperies && new Random().NextDouble() < 0.3)
        {
            Sante -= 10;
            Console.WriteLine($"{Nom} en ({x},{y}) a été endommagée par une intempérie ({meteo.EvenementSpecial}).");
        }

        //  Bonus si au moins 3 conditions sont favorables
        if (conditionsFavorables > 2)
        {
            int gain = 10;
            if (Sante + gain > 100) gain = 100 - Sante;
            Sante += gain;
            Console.WriteLine($"{Nom} en ({x},{y}) prospère grâce à des conditions favorables ! Santé +{gain}.");
        }
        else if (conditionsFavorables / conditionsTotal < 0.5)
        {
            Sante = 0;
            Console.WriteLine($"{Nom} en ({x},{y}) est morte car moins de 50% des conditions essentielles sont remplies.");
            return;
        }

        // Croissance
        if (Sante > 70)
        {
            VitesseCroissance += 0.1;
            Console.WriteLine($"{Nom} en ({x},{y}) pousse bien.");
        }

        //  Clamp santé entre 0 et 100
        if (Sante <= 0)
        {
            Sante = 0;
            Console.WriteLine($"{Nom} en ({x},{y}) est morte.");
        }
        else if (Sante > 100)
        {
            Sante = 100;
        }

        // Affichage si la santé a changé
        if (Sante != santeInitiale)
        {
            Console.WriteLine($"Santé de {Nom} en ({x},{y}) : {santeInitiale} → {Sante}");
        }
        if (EstBlessee && SoinEffectueCeTour == true)
        {
            Sante -= 10;
            Console.WriteLine($"{Nom} en ({x},{y}) n'a pas été soignée et s'affaiblit davantage. Santé -10.");
            if (Sante <= 0)
            {
                Sante = 0;
                Console.WriteLine($"{Nom} en ({x},{y}) est morte par négligence.");
            }
        }

        // Proposer un soin à la fin de l’évaluation si la plante est malade
        ProposerSoin();

        SoinEffectueCeTour = false;
    }
    public bool EstMorte()
{
    return Sante <= 0;
}
}
