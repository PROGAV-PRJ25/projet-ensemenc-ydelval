public class Salade : Plante
{
    public Salade()
    {
        Nom = "Salade";
        Type = "Annuelle";
        SaisonsDeSemis.AddRange(new List<string> { "printemps", "automne" });
        Espacement = 0.25;
        TerrainPrefere = "Terre";
        PlaceNecessairePourGrandir = 0.4;
        VitesseCroissance = 1;
        BesoinEau = 25;
        BesoinLumiere = 0.6;
        TemperatureMin = 5.0;
        TemperatureMax = 22.0;
        EsperanceDeVie = 5;
        QuantiteFruits = 3;
        GrainesParFruit = 8;
        Sante = 100;

        MaladiesProbabilites.Add("Fonte des semis", 0.1);
        MaladiesProbabilites.Add("Sclerotinia", 0.15);
    }
}
