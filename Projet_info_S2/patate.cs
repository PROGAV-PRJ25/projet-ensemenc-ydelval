public class Patate : Plante
{
    public Patate()
    {
        Nom = "Patate";
        Type = "Annuelle";
        SaisonsDeSemis.AddRange(new List<string> { "Printemps" });
        Espacement = 0.4;
        PlaceNecessairePourGrandir = 0.9;
        VitesseCroissance = 1.1;
        BesoinEau = 0.7;
        BesoinLumiere = 0.9;
        TemperatureMin = 8.0;
        TemperatureMax = 26.0;
        EsperanceDeVie = 120.0;
        Production = 8;
        Sante = 100;

        MaladiesProbabilites.Add("Mildiou", 0.35);
        MaladiesProbabilites.Add("Rhizoctone", 0.2);
    }
}
