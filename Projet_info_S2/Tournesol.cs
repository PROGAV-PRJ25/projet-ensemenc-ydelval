public class Tournesol : Plante
{
    public Tournesol()
    {
        Nom = "Tournesol";
        Type = "Annuelle";
        TerrainPrefere = "Terre";
        SaisonsDeSemis.AddRange(new List<string> { "printemps", "été" });
        Espacement = 0.5;
        PlaceNecessairePourGrandir = 1.2;
        VitesseCroissance = 0.7;
        BesoinEau = 35;
        BesoinLumiere = 0.8;
        TemperatureMin = 10;
        TemperatureMax = 30;
        EsperanceDeVie = 12;
        QuantiteFruits = 1; 
        GrainesParFruit = 50; 
        Sante = 100;

        MaladiesProbabilites.Add("Mildiou", 0.1);
        MaladiesProbabilites.Add("Sclérotiniose", 0.05);
    }
}
