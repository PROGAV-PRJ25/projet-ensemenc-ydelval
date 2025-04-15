public abstract class Pays
{
    public string Nom { get; set; }
    public string TypeClimat { get; set; }

    // Chaque pays définit sa propre liste de plantes autorisées
    public List<Type> PlantesAutorisees { get; set; } = new List<Type>();

    // Méthode pour savoir si une plante est autorisée dans le pays
    public abstract bool PeutPlanter(Plante plante);

  
}
