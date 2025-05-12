public class Mais : Plante
{
    public Mais()
    {
        Nom = "Mais";
        Type = "Annuelle";
        TerrainPrefere = "Terre";
        SaisonsDeSemis.AddRange(new List<string> { "printemps" });
        Espacement = 0.4;
        PlaceNecessairePourGrandir = 1.5;
        VitesseCroissance = 0.6;
        BesoinEau = 8;
        BesoinLumiere = 0.65;
        TemperatureMin = 15;
        TemperatureMax = 35;
        EsperanceDeVie = 0.5;
        Production = 2;
        Sante = 100;
        MaladiesProbabilites.Add( "Charbon du mais", 0.05);
       
    }
}
