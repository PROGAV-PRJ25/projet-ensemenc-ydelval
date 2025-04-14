public abstract class Terrain
{
    public string Nom { get; set; }
    public string TypeSol { get; set; } // Sable, Argile, Terre
    public double Acidite { get; set; } // pH du sol
    public double Drainage { get; set; } // 0.0 à 1.0
    public double Ensoleillement { get; set; } // 0.0 à 1.0
    public double RetentionEau { get; set; } // 0.0 à 1.0
    public double TemperatureActuelle { get; set; }
}
