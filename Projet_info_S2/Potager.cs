public class Potager
{
    public List<Parcelle> Parcelles { get; set; } = new List<Parcelle>();

    // Ajouter une plante à une parcelle libre
    public void Planter(Plante plante, Terrain terrain)
    {
        Parcelle nouvelleParcelle = new Parcelle(plante, terrain);
        Parcelles.Add(nouvelleParcelle);
        Console.WriteLine($"{plante.Nom} a été plantée sur un terrain {terrain.TypeSol}.");
    }

    // Évaluer chaque plante en fonction de la météo
    public void EvaluerPlantes(Meteo meteo)
    {
        foreach (var parcelle in Parcelles)
        {
            if (parcelle.Plante != null)
            {
                parcelle.Plante.Evaluer(meteo, parcelle.Terrain);
            }
        }
    }

    // Affichage de l’état global du potager
    public void AfficherEtat()
    {
        Console.WriteLine("\n--- État du potager ---");
        foreach (var parcelle in Parcelles)
        {
            Console.WriteLine($"{parcelle.Plante.Nom} sur terrain {parcelle.Terrain.TypeSol} – Santé : {parcelle.Plante.Sante}/100");
        }
    }
}
