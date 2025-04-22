public class Meteo
{
    public string SaisonActuelle { get; private set; }
    public double Temperature { get; private set; } // °C
    public double Precipitations { get; private set; } // mm
    public double Ensoleillement { get; private set; } // 0.0 à 1.0
    public bool Intemperies { get; private set; } // True si événement météo fort
    public string EvenementSpecial { get; private set; } // "Gel", "Grêle", etc.
    public int JourActuel { get; private set; } 

    private Random random = new Random();

    public Meteo(string saison)
    {
        SaisonActuelle = saison;
        JourActuel = 1;
        GenererConditions();
    }

    public void GenererConditions()
    {
        EvenementSpecial = "Aucun";
        Intemperies = false;

        switch (SaisonActuelle.ToLower())
        {
            case "printemps":
                Temperature = random.Next(10, 20);
                Precipitations = random.Next(2, 10);
                Ensoleillement = random.NextDouble() * 0.7 + 0.3;
                if (random.NextDouble() < 0.1)
                {
                    Intemperies = true;
                    EvenementSpecial = "Grêle";
                }
                break;

            case "été":
                Temperature = random.Next(20, 35);
                Precipitations = random.Next(0, 5);
                Ensoleillement = random.NextDouble() * 0.3 + 0.7;
                if (random.NextDouble() < 0.1)
                {
                    Intemperies = true;
                    EvenementSpecial = "Canicule";
                }
                break;

            case "automne":
                Temperature = random.Next(5, 18);
                Precipitations = random.Next(5, 15);
                Ensoleillement = random.NextDouble() * 0.6;
                if (random.NextDouble() < 0.1)
                {
                    Intemperies = true;
                    EvenementSpecial = "Orage";
                }
                break;

            case "hiver":
                Temperature = random.Next(-5, 10);
                Precipitations = random.Next(1, 8);
                Ensoleillement = random.NextDouble() * 0.4;
                if (random.NextDouble() < 0.1)
                {
                    Intemperies = true;
                    EvenementSpecial = "Gel";
                }
                break;

            default:
                throw new Exception("Saison inconnue");
        }
    }

    public void ChangerSaison(string nouvelleSaison)
    {
        SaisonActuelle = nouvelleSaison;
        GenererConditions();
    }

    public void IncrementeJour()
    {
    JourActuel++;
    if (JourActuel > 30)
    {
        JourActuel = 1; // Réinitialiser à 1 pour nouvelle saison
        ChangerSaison();
    }
    }

}