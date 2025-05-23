public class Cerisier : Plante
{
    public Cerisier()
    {
        Nom = "Cerisier";
        Type = "Vivace";
        SaisonsDeSemis.AddRange(new List<string> { "automne", "hiver" }); 
        Espacement = 2.0; 
        TerrainPrefere = "Terre";
        PlaceNecessairePourGrandir = 2.5;
        VitesseCroissance = 0.2; 
        BesoinEau = 25; 
        BesoinLumiere = 0.6; 
        TemperatureMin = -10.0; 
        TemperatureMax = 30.0;
        EsperanceDeVie = 40.0; 
        QuantiteFruits = 15; 
        GrainesParFruit = 1; 
        Sante = 100;

        MaladiesProbabilites.Add("Moniliose", 0.2);
        MaladiesProbabilites.Add("Puceron noir", 0.15);
    }
}
