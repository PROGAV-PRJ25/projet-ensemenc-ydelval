public class Courgette : Plante
{
    public Courgette()
    {
        Nom = "Courgette";
        Type = "Annuelle";
        SaisonsDeSemis.AddRange(new List<string> { "Printemps", "Début Été" });
        Espacement = 0.7;
        PlaceNecessairePourGrandir = 1.0;
        VitesseCroissance = 1.3;
        BesoinEau = 0.85;
        BesoinLumiere = 0.95;
        TemperatureMin = 15.0;
        TemperatureMax = 30.0;
        EsperanceDeVie = 100.0;
        Production = 10;
        Sante = 100;

        MaladiesProbabilites.Add("Oïdium", 0.2);
        MaladiesProbabilites.Add("Mildiou", 0.25);
    }
}
