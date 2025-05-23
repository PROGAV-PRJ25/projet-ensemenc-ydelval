public class Courgette : Plante
{
    public Courgette()
    {
        Nom = "Courgette";
        Type = "Annuelle";
        TerrainPrefere = "Terre";
        SaisonsDeSemis.AddRange(new List<string> { "printemps", "été" });
        Espacement = 0.7;
        PlaceNecessairePourGrandir = 1.0;
        VitesseCroissance = 0.9;
        BesoinEau = 35;
        BesoinLumiere = 0.75;
        TemperatureMin = 15.0;
        TemperatureMax = 30.0;
        EsperanceDeVie = 10.0;
        QuantiteFruits = 4;
        GrainesParFruit = 3;
        Sante = 100;

        MaladiesProbabilites.Add("Oïdium", 0.2);
        MaladiesProbabilites.Add("Mildiou", 0.25);
    }
}
