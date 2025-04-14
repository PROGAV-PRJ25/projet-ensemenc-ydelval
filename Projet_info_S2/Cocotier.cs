public class Cocotier : Plante
{
    public Cocotier()
    {
        Nom = "Cocotier";
        Type = "Vivace, Comestible";
        SaisonsDeSemis = new List<string> { "Printemps", "Été" };
        TerrainsPreferes = new List<string> { "Sable" };
        Espacement = 2.0;
        PlaceNecessairePourGrandir = 4.0;
        VitesseCroissance = 0.5;
        BesoinEau = 2.0;
        BesoinLumiere = 8.0;
        TemperatureMin = 25.0;
        TemperatureMax = 40.0;
        MaladiesPossibles = new List<string> { "Jaunissement mortel", "Charançon" };
        ProbabiliteMaladie = 0.1;
        EsperanceDeVie = 9125.0;
        ProductionMax = 50;
        Sante = 100;
    }
}
