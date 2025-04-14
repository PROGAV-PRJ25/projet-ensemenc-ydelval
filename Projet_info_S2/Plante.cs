public abstract class Plante
{
    public string Nom { get; set; }
    public string Type { get; set; } // Annuelle, Vivace, etc.
    public List<string> SaisonsDeSemis { get; set; }
    public double Espacement { get; set; }
    public double PlaceNecessairePourGrandir { get; set; }
    public double VitesseCroissance { get; set; }
    public double BesoinEau { get; set; }
    public double BesoinLumiere { get; set; }
    public double TemperatureMin { get; set; }
    public double TemperatureMax { get; set; }
    public Dictionary<string, double> MaladiesProbabilites { get; set; }
    public double EsperanceDeVie { get; set; }
    public int Production { get; set; } // nombre de fruits/légumes
    public int Sante { get; set; } // 0-100
    
}