public class Mais : Plante
{
    public Mais()
    {
        Nom = "Maïs";
        Type = "Annuelle";
        TerrainPrefere = "Terre";
        SaisonsDeSemis = new List<string> { "printemps" };
        Espacement = 0.4;
        PlaceNecessairePourGrandir = 1.5;
        VitesseCroissance = 0.6;
        BesoinEau = 8;
        BesoinLumiere = 0.8;
        TemperatureMin = 15;
        TemperatureMax = 35;
        EsperanceDeVie = 0.5;
        Production = 2;
        Sante = 100;
        MaladiesProbabilites = new Dictionary<string, double>
        {
            { "Charbon du maïs", 0.05 }
        };
    }
}
