public class Patate : Plante
{
    public Patate()
    {
        Nom = "Patate";
        Type = "Annuelle";
        SaisonsDeSemis.AddRange(new List<string> { "printemps" });
        Espacement = 0.4;
        TerrainPrefere = "Argile";
        PlaceNecessairePourGrandir = 0.9;
        VitesseCroissance = 1.1;
        BesoinEau = 0.7;
        BesoinLumiere = 0.7;
        TemperatureMin = 8.0;
        TemperatureMax = 26.0;
        EsperanceDeVie = 120.0;
        Production = 8;
        Sante = 100;

        MaladiesProbabilites.Add("Mildiou", 0.35);
        MaladiesProbabilites.Add("Rhizoctone", 0.2);
    }
}
