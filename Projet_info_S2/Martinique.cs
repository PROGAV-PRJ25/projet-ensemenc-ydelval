public class Martinique : Pays
{
    public Martinique()
    {
        Nom = "Martinique";
        TypeClimat = "Tropical";
        PlantesAutorisees = new List<Type>
        {
            typeof(Ananas),
            typeof(Cocotier),
            typeof(Tomate),
            typeof(Courgette),
            typeof(Rose)
        };
    }



    public override bool PeutPlanter(Plante plante)
    {
        foreach (Type type in PlantesAutorisees)
        {
            if (type == plante.GetType())
            {
                return true;
            }
        }
        return false;

    }
}
