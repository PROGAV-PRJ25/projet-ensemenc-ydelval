public class Tomate : Plante
{
    public Tomate()
    {
        Nom = "Tomate";
        Type = "Annuelle";
        SaisonsDeSemis.AddRange(new List<string> { "Printemps" });
        Espacement = 0.4;
        PlaceNecessairePourGrandir = 0.8;
        VitesseCroissance = 1.2;
        BesoinEau = 0.8;
        BesoinLumiere = 1.0;
        TemperatureMin = 15.0;
        TemperatureMax = 30.0;
        EsperanceDeVie = 90.0;
        Production = 10;
        Sante = 100;

        MaladiesProbabilites.Add("Mildiou", 0.3);
        MaladiesProbabilites.Add("Oïdium", 0.2);
    }
}
