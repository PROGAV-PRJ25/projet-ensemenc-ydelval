public class France : Pays
{
    public France()
    {
        Nom = "France";
        TypeClimat = "Tempéré";
        PlantesAutorisees = new List<Type>
        {
            typeof(Patate),
            typeof(Tomate),
            typeof(Courgette),
            typeof(Fraise),
            typeof(Carotte),
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
