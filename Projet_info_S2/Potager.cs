public class Potager
{
    public int Largeur { get; set; }
    public int Hauteur { get; set; }
    public Parcelle[,] Grille { get; set; }

    // Constructeur qui permet de spécifier la largeur et la hauteur
    public Potager(int largeur, int hauteur)
    {
        Largeur = largeur;
        Hauteur = hauteur;
        Grille = new Parcelle[Hauteur, Largeur];
        InitialiserGrille();
    }

    public void InitialiserGrille()
    {
        var random = new Random();
        for (int y = 0; y < Hauteur; y++)
        {
            for (int x = 0; x < Largeur; x++)
            {
                int choix = random.Next(3);
                Terrain terrain = choix switch
                {
                    0 => new Terre(),
                    1 => new Sable(),
                    _ => new Argile()
                };
                Grille[y, x] = new Parcelle(null, terrain);
            }
        }
    }

    public bool PeutPlanterIci(int x, int y, Plante plante)
    {
        int directionsBloquees = 0;

        List<(int dx, int dy)> directions = new List<(int, int)>
        {
            (0, -1), // haut
            (0, 1),  // bas
            (-1, 0), // gauche
            (1, 0)   // droite
        };

        // Mélanger les directions pour éviter que les mêmes soient toujours bloquées
        Random random = new Random();
        directions = directions.OrderBy(d => random.Next()).ToList();

        foreach (var (dx, dy) in directions)
        {
            int nx = x + dx;
            int ny = y + dy;

            if (nx >= 0 && nx < Largeur && ny >= 0 && ny < Hauteur)
            {
                if (Grille[ny, nx].Plante != null)
                {
                    directionsBloquees++;
                }
            }
        }

        // On peut planter uniquement si moins de "Espacement" directions sont déjà occupées
        return directionsBloquees < plante.Espacement;
    }

    public bool Planter(Plante plante, int x, int y)
    {
        if (!PeutPlanterIci(x, y, plante))
        {
            Console.WriteLine($"❌ Trop proche d'une autre plante pour placer {plante.Nom} en ({x},{y}) !");
            return false;
        }

        Grille[y, x].Plante = plante;
        Console.WriteLine($"✅ {plante.Nom} a été plantée en ({x},{y}) sur un terrain {Grille[y, x].Terrain.TypeSol}.");
        return true;
    }

    public void EvaluerPlantes(Meteo meteo)
    {
        for (int y = 0; y < Hauteur; y++)
        {
            for (int x = 0; x < Largeur; x++)
            {
                var parcelle = Grille[y, x];
                if (parcelle.Plante != null)
                {
                    parcelle.Plante.Evaluer(meteo, parcelle.Terrain);
                }
            }
        }
    }

    public void AfficherEtat()
{
    Console.WriteLine("\n--- État du potager ---");
    for (int y = 0; y < Hauteur; y++)
    {
        for (int x = 0; x < Largeur; x++)
        {
            var p = Grille[y, x];
            string nom;
            if (p.Plante != null)
            {
                nom = p.Plante.Nom; // Assigner le nom de la plante si elle existe
            }
            else
            {
                nom = "vide"; // Assigner "vide" si la plante est null
            }

            string sol = p.Terrain.TypeSol;

            string sante;
            if (p.Plante != null)
            {
                sante = $"{p.Plante.Sante}/100"; // Assigner la santé de la plante si elle existe
            }
            else
            {
                sante = "-"; // Assigner "-" si la plante est null
            }

            Console.WriteLine($"[{x},{y}] - {nom} sur {sol} – Santé : {sante}");
        }
    }
}


    public void AfficherGrille()
{
    Console.WriteLine("\n Vue du potager :\n");

    for (int y = 0; y < Hauteur; y++)
    {
        for (int x = 0; x < Largeur; x++)
        {
            var parcelle = Grille[y, x];
            string symbole;

            if (parcelle.Plante == null)
            {
                symbole = " . "; // Assigner un symbole pour une parcelle vide
            }
            else
            {
                symbole = GetSymboleSimple(parcelle.Plante.Nom); // Assigner le symbole de la plante
            }

            Console.Write(symbole);
        }
        Console.WriteLine();
    }

    Console.WriteLine("\nLégende : T = Tomate, S = Salade, A = Ananas, R = Rose, . = Vide");
}


    private string GetSymboleSimple(string nom)
    {
        return nom.ToLower() switch
        {
            "tomate" => " T ",
            "salade" => " S ",
            "ananas" => " A ",
            "rose" => " R ",
            "carotte" => " C ",
            "patate" => " P ",
            "mais" => " M ",
            "Cocotier" => " CO ",
            "Courgette" => " CT ",
            _ => " ? "
        };
    }

    public void AfficherTypeSol(int x, int y)
    {
        if (x < 0 || x >= Largeur || y < 0 || y >= Hauteur)
        {
            Console.WriteLine("❌ Coordonnées invalides !");
            return;
        }

        var typeSol = Grille[y, x].Terrain.TypeSol;
        Console.WriteLine($"📍 La parcelle ({x}, {y}) est de type : {typeSol}");
    }
}

