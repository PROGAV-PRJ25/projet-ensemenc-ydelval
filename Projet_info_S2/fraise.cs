public class Fraise : Plante
{
    public Fraise()
    {
        Nom = "Fraise";
        Type = "Vivace, Comestible";
        SaisonsDeSemis = new List<string> { "Printemps", "Automne" };
        TerrainsPreferes = new List<string> { "Terre", "Sable" };
        Espacement = 0.3;
        PlaceNecessairePourGrandir = 0.6;
        VitesseCroissance = 1.0;
        BesoinEau = 1.2;
        BesoinLumiere = 5.0;
        TemperatureMin = 10.0;
        TemperatureMax = 30.0;
        MaladiesPossibles = new List<string> { "Botrytis", "Anthracnose" };
        ProbabiliteMaladie = 0.2;
        EsperanceDeVie = 730.0;
        ProductionMax = 15;
        Sante = 100;
    }
}
