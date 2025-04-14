public class Cocotier : Plante
{
    public Cocotier()
    {
        Nom = "Cocotier";
        Type = "Vivace";
        SaisonsDeSemis.AddRange(new List<string> { "Printemps", "Été" });
        Espacement = 1.5;
        PlaceNecessairePourGrandir = 3.0;
        VitesseCroissance = 0.3;
        BesoinEau = 0.9;
        BesoinLumiere = 1.0;
        TemperatureMin = 22.0;
        TemperatureMax = 40.0;
        EsperanceDeVie = 10950.0; // 30 ans
        Production = 60;
        Sante = 100;

        MaladiesProbabilites.Add("Jaunissement Létal", 0.25);
    }
}
