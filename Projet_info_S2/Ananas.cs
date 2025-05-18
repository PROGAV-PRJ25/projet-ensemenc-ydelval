public class Ananas : Plante
{
    public Ananas()
    {
        Nom = "Ananas";
        Type = "Vivace";
        SaisonsDeSemis.AddRange(new List<string> { "printemps", "été" });
        Espacement = 1;
        TerrainPrefere = "Sable";
        PlaceNecessairePourGrandir = 1.5;
        VitesseCroissance = 0.5;
        BesoinEau = 8;
        BesoinLumiere = 0.8;
        TemperatureMin = 20.0;
        TemperatureMax = 35.0;
        EsperanceDeVie = 30.0; // 3 ans
        QuantiteFruits = 1;
        GrainesParFruit = 5;
        Sante = 100;

        MaladiesProbabilites.Add("Pourriture du cœur", 0.2);
        MaladiesProbabilites.Add("Fusariose", 0.15);
    }
}
