public class Oignon: Plante
{
    public Oignon()
    {
        Nom = "Oignon";
        Type = "Bisannuelle"; 
        SaisonsDeSemis.AddRange(new List<string> { "printemps", "automne" });
        Espacement = 3.0;
        TerrainPrefere = "Terre";
        PlaceNecessairePourGrandir = 0.5;
        VitesseCroissance = 0.4;
        BesoinEau = 5;
        BesoinLumiere = 0.8;
        TemperatureMin = 4.0;
        TemperatureMax = 30.0;
        EsperanceDeVie = 10.0; 
        QuantiteFruits = 1;
        GrainesParFruit = 10;
        Sante = 100;

        MaladiesProbabilites.Add("Mildiou", 0.15);
        MaladiesProbabilites.Add("Pourriture blanche", 0.1);
        MaladiesProbabilites.Add("Fusariose", 0.05);
    }
}
