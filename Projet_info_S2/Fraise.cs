public class Fraise : Plante
{
    public Fraise()
    {
        Nom = "Fraise";
        Type = "Vivace";
        SaisonsDeSemis.AddRange(new List<string> { "printemps", "automne" });
        Espacement = 0.3;
        TerrainPrefere = "Terre";
        PlaceNecessairePourGrandir = 0.5;
        VitesseCroissance = 0.8;
        BesoinEau = 30;
        BesoinLumiere = 0.7;
        TemperatureMin = 10.0;
        TemperatureMax = 25.0;
        EsperanceDeVie = 20;
        QuantiteFruits = 6;
        GrainesParFruit = 2;
        Sante = 100;
        MaladiesProbabilites.Add("Botrytis", 0.2);
        MaladiesProbabilites.Add("Anthracnose", 0.15);
    }
}
