public class Fraise : Plante
{
    public Fraise()
    {
        Nom = "Fraise";
        Type = "Vivace";
        SaisonsDeSemis.AddRange(new List<string> { "Printemps", "Automne" });
        Espacement = 0.3;
        TerrainPrefere = "Terre";
        PlaceNecessairePourGrandir = 0.5;
        VitesseCroissance = 1.0;
        BesoinEau = 0.7;
        BesoinLumiere = 0.9;
        TemperatureMin = 10.0;
        TemperatureMax = 25.0;
        EsperanceDeVie = 730.0; // 2 ans
        Production = 20;
        Sante = 100;

        MaladiesProbabilites.Add("Botrytis", 0.2);
        MaladiesProbabilites.Add("Anthracnose", 0.15);
    }
}
