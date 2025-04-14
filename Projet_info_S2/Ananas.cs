public class Ananas : Plante
{
    public Ananas()
    {
        Nom = "Ananas";
        Type = "Vivace";
        SaisonsDeSemis.AddRange(new List<string> { "Printemps" });
        Espacement = 0.5;
        TerrainPrefere = "Sable";
        PlaceNecessairePourGrandir = 1.2;
        VitesseCroissance = 0.6;
        BesoinEau = 0.8;
        BesoinLumiere = 1.0;
        TemperatureMin = 20.0;
        TemperatureMax = 35.0;
        EsperanceDeVie = 1095.0; // 3 ans
        Production = 1;
        Sante = 100;

        MaladiesProbabilites.Add("Pourriture du cœur", 0.2);
        MaladiesProbabilites.Add("Fusariose", 0.15);
    }
}
