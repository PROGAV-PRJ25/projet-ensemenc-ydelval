public class Oignon: Plante
{
    public Oignon()
    {
        Nom = "Oignon";
        Type = "Bisannuelle"; 
        SaisonsDeSemis.AddRange(new List<string> { "Printemps", "Automne" });
        Espacement = 3.0;
        TerrainPrefere = "Terre";
        PlaceNecessairePourGrandir = 3.0;
        VitesseCroissance = 0.4;
        BesoinEau = 0.7;
        BesoinLumiere = 1.0;
        TemperatureMin = 4.0;
        TemperatureMax = 30.0;
        EsperanceDeVie = 365.0; 
        Production = 4; 
        Sante = 100;

        MaladiesProbabilites.Add("Mildiou", 0.15);
        MaladiesProbabilites.Add("Pourriture blanche", 0.1);
        MaladiesProbabilites.Add("Fusariose", 0.05);
    }
}
