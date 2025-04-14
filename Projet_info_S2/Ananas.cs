public class Ananas : Plante
{
    public Ananas()
    {
        Nom = "Ananas";
        Type = "Vivace, Comestible";
        SaisonsDeSemis = new List<string> { "Printemps" };
        TerrainsPreferes = new List<string> { "Sable", "Terre" };
        Espacement = 0.8;
        PlaceNecessairePourGrandir = 1.5;
        VitesseCroissance = 0.8;
        BesoinEau = 1.0;
        BesoinLumiere = 7.0;
        TemperatureMin = 20.0;
        TemperatureMax = 35.0;
        MaladiesPossibles = new List<string> { "Pourriture", "Fusariose" };
        ProbabiliteMaladie = 0.18;
        EsperanceDeVie = 730.0;
        ProductionMax = 1;
        Sante = 100;
    }
}
