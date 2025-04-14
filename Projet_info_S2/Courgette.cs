public class Patate : Plante : Terra
{
    public Patate()
    {
        Nom = "Patate";
        Type = "Annuelle, Comestible";
        SaisonsDeSemis = new List<string> { "Printemps" };
        TerrainsPreferes = new List<string> { "Terre", "Argile" };
        Espacement = 0.4;
        PlaceNecessairePourGrandir = 1.2;
        VitesseCroissance = 1.1;
        BesoinEau = 1.3;
        BesoinLumiere = 5.5;
        TemperatureMin = 7.0;
        TemperatureMax = 30.0;
        MaladiesPossibles = new List<string> { "Mildiou", "Gale" };
        ProbabiliteMaladie = 0.22;
        EsperanceDeVie = 100.0;
        ProductionMax = 10;
        Sante = 100;
    }
}
