public class Meteo
{
    public string SaisonActuelle { get; private set; }
    public double Temperature { get; private set; } // °C
    public double Precipitations { get; private set; } // mm
    public double Ensoleillement { get; private set; } // 0.0 à 1.0
    public bool Intemperies { get; private set; } // True si événement météo fort
    public string EvenementSpecial { get; private set; } // "Gel", "Grêle", etc.
    public int SemaineActuelle { get; private set; }

    private Random random = new Random();

    public Meteo(string saison)
    {
        SaisonActuelle = saison;
        SemaineActuelle = 1;
        GenererConditions();
    }

    public void GenererConditions()
    {
        EvenementSpecial = "Aucun";
        Intemperies = false;

        switch (SaisonActuelle.ToLower())
        {
            case "printemps":
                Temperature = random.Next(13, 25);
                Precipitations = random.Next(10, 50);
                Ensoleillement = random.NextDouble() * 0.8 + 0.3;
                if (random.NextDouble() < 0.1)
                {
                    Intemperies = true;
                    EvenementSpecial = "Grêle";
                }
                break;

            case "été":
                Temperature = random.Next(20, 35);
                Precipitations = random.Next(0, 25);
                Ensoleillement = random.NextDouble() * 0.3 + 0.7;
                if (random.NextDouble() < 0.1)
                {
                    Intemperies = true;
                    EvenementSpecial = "Canicule";
                }
                break;

            case "automne":
                Temperature = random.Next(5, 18);
                Precipitations = random.Next(20, 60);
                Ensoleillement = random.NextDouble() * 0.6;
                if (random.NextDouble() < 0.1)
                {
                    Intemperies = true;
                    EvenementSpecial = "Orage";
                }
                break;

            case "hiver":
                Temperature = random.Next(-5, 10);
                Precipitations = random.Next(5,30);
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

    public void IncrementerSemaine()
    {
        SemaineActuelle++;
        if (SemaineActuelle > 12)
        {
            SemaineActuelle = 1; // Réinitialiser à 1 pour nouvelle saison
            SaisonActuelle = SaisonSuivante(SaisonActuelle);
            GenererConditions(); // Génère nouvelles conditions météo
        }
        else
        {
            GenererConditions(); // Génère les conditions la semaine suivante
        }
    }

    private string SaisonSuivante(string actuelle)
    {
        switch (actuelle.ToLower())
        {
            case "printemps": return "été";
            case "été": return "automne";
            case "automne": return "hiver";
            case "hiver": return "printemps";
            default: return "printemps";
        }
    }
}
