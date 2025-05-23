public class Carotte : Plante
{
    public Carotte()
    {
        Nom = "Carotte";
        Type = "Annuelle";
        TerrainPrefere = "Sableux";
        SaisonsDeSemis.AddRange(new List<string> { "printemps", "été" });
        Espacement = 0.2;
        PlaceNecessairePourGrandir = 0.4;
        VitesseCroissance = 0.8;
        BesoinEau = 25;
        BesoinLumiere = 0.6;
        TemperatureMin = 8;
        TemperatureMax = 28;
        EsperanceDeVie = 12;
        QuantiteFruits = 1;
        GrainesParFruit = 10;
        Sante = 100;
        MaladiesProbabilites.Add("Mouche de la carotte", 0.1 );
    }
}
