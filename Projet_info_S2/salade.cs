public class Salade : Plante
{
    public Salade()
    {
        Nom = "Salade";
        Type = "Annuelle";
        SaisonsDeSemis.AddRange(new List<string> { "Printemps", "Automne" });
        Espacement = 0.25;
        PlaceNecessairePourGrandir = 0.4;
        VitesseCroissance = 1.5;
        BesoinEau = 0.6;
        BesoinLumiere = 0.8;
        TemperatureMin = 5.0;
        TemperatureMax = 22.0;
        EsperanceDeVie = 60.0;
        Production = 1;
        Sante = 100;

        MaladiesProbabilites.Add("Fonte des semis", 0.1);
        MaladiesProbabilites.Add("Sclerotinia", 0.15);
    }
}
