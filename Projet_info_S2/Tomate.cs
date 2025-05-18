public class Tomate : Plante
{
    public Tomate()
    {
        Nom = "Tomate";
        Type = "Annuelle";
        SaisonsDeSemis.AddRange(new List<string> { "printemps" });
        Espacement = 0.4;
        TerrainPrefere = "Terre";
        PlaceNecessairePourGrandir = 0.8;
        VitesseCroissance = 0.2;
        BesoinEau = 10;
        BesoinLumiere = 0.9;
        TemperatureMin = 15.0;
        TemperatureMax = 30.0;
        EsperanceDeVie = 13.0;
        QuantiteFruits = 10;
        GrainesParFruit = 2;
        Sante = 100;

        MaladiesProbabilites.Add("Mildiou", 0.3);
        MaladiesProbabilites.Add("Oïdium", 0.2);
    }
}