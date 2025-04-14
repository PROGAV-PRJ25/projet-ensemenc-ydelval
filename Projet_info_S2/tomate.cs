public class Tomate : Plante
{
    public Tomate()
    {
        Nom = "Tomate";
        Type = "Annuelle, Comestible";
        SaisonsDeSemis = new List<string> { "Printemps" };
        TerrainsPreferes = new List<string> { "Terre", "Argile" };
        Espacement = 0.5;
        PlaceNecessairePourGrandir = 1.0;
        VitesseCroissance = 1.2;
        BesoinEau = 1.5;
        BesoinLumiere = 6.0;
        TemperatureMin = 15.0;
        TemperatureMax = 35.0;
        MaladiesPossibles = new List<string> { "Mildiou", "Oïdium" };
        ProbabiliteMaladie = 0.25;
        EsperanceDeVie = 90.0;
        ProductionMax = 20;
        Sante = 100;
    }
}