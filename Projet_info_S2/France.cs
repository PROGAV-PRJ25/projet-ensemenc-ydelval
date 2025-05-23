public class France : Pays
{
    public France()
    {
        Nom = "France";
        TypeClimat = "Tempéré";
        PlantesAutorisees = new List<Type>
        {
            typeof(Patate),
            typeof(Cerisier),
            typeof(Tomate),
            typeof(Courgette),
            typeof(Tournesol),
            typeof(Oignon),
            typeof(Fraise),
            typeof(Carotte),
            typeof(Rose),
            typeof(Mais),
            typeof(Salade)
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
