public class Salade : Plante
{
    public Salade()
    {
        Nom = "Salade";
        Type = "Annuelle, Comestible";
        SaisonsDeSemis = new List<string> { "Printemps", "Automne" };
        TerrainsPreferes = new List<string> { "Terre" };
        Espacement = 0.25;
        PlaceNecessairePourGrandir = 0.4;
        VitesseCroissance = 1.4;
        BesoinEau = 1.0;
        BesoinLumiere = 4.0;
        TemperatureMin = 5.0;
        TemperatureMax = 25.0;
        MaladiesPossibles = new List<string> { "Fonte des semis", "Mildiou" };
        ProbabiliteMaladie = 0.15;
        EsperanceDeVie = 60.0;
        ProductionMax = 1;
        Sante = 100;
    }
}
