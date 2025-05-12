public class Rose : Plante
{
    public Rose()
    {
        Nom = "Rose";
        Type = "Vivace";
        TerrainPrefere = "Terre";
        SaisonsDeSemis.AddRange(new List<string> { "printemps", "automne" });
        Espacement = 0.4;
        PlaceNecessairePourGrandir = 1.0;
        VitesseCroissance = 0.3;
        BesoinEau = 6;
        BesoinLumiere = 0.55;
        TemperatureMin = 5;
        TemperatureMax = 30;
        EsperanceDeVie = 5; // en années si tu veux simuler long terme
        Production = 0; // pas comestible
        Sante = 100;
        MaladiesProbabilites.Add("Oïdium", 0.1);
        MaladiesProbabilites.Add("Taches noires", 0.08 );
        MaladiesProbabilites.Add("Rouille", 0.05 );
        
    }
}
