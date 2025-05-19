public class Mais : Plante
{
    public Mais()
    {
        Nom = "Mais";
        Type = "Annuelle";
        TerrainPrefere = "Terre";
        SaisonsDeSemis.AddRange(new List<string> { "printemps" });
        Espacement = 0.4;
        PlaceNecessairePourGrandir = 1.0;
        VitesseCroissance = 0.9;
        BesoinEau = 40;
        BesoinLumiere = 0.8;
        TemperatureMin = 15;
        TemperatureMax = 35;
        EsperanceDeVie = 14;
        QuantiteFruits = 2;
        GrainesParFruit = 20;
        Sante = 100;
        MaladiesProbabilites.Add( "Charbon du mais", 0.05);
       
    }
}
