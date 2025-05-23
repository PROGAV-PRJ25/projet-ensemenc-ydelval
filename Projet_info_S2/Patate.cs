public class Patate : Plante
{
    public Patate()
    {
        Nom = "Patate";
        Type = "Annuelle";
        SaisonsDeSemis.AddRange(new List<string> { "printemps" });
        Espacement = 0.4;
        TerrainPrefere = "Terre";
        PlaceNecessairePourGrandir = 0.9;
        VitesseCroissance = 0.9;
        BesoinEau = 35;
        BesoinLumiere = 0.7;
        TemperatureMin = 8.0;
        TemperatureMax = 26.0;
        EsperanceDeVie = 12.0;
        QuantiteFruits = 5;
        GrainesParFruit = 1;
        Sante = 100;

        MaladiesProbabilites.Add("Mildiou", 0.35);
        MaladiesProbabilites.Add("Rhizoctone", 0.2);
    }
}
