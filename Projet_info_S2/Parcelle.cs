public class Parcelle
{
    public Plante Plante { get; set; }
    public Terrain Terrain { get; set; }

    public Parcelle(Plante plante, Terrain terrain)
    {
        this.Plante = plante;
        this.Terrain = terrain;
        
    }
}
