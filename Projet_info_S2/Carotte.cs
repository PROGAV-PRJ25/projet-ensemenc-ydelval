public class Carotte : Plante
{
    public Carotte()
    {
        Nom = "Carotte";
        Type = "Annuelle";
        TerrainPrefere = "Sable";
        SaisonsDeSemis.AddRange(new List<string> { "printemps", "été" });
        Espacement = 0.1;
        PlaceNecessairePourGrandir = 0.2;
        VitesseCroissance = 0.5;
        BesoinEau = 5;
        BesoinLumiere = 0.5;
        TemperatureMin = 8;
        TemperatureMax = 28;
        EsperanceDeVie = 0.4;
        Production = 3;
        Sante = 100;
        MaladiesProbabilites.Add("Mouche de la carotte", 0.1 );
    }
}
