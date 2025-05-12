public class Potager
{
    public int Largeur { get; set; }
    public int Hauteur { get; set; }
    public Parcelle[,] Grille { get; set; }

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

    public bool Planter(Plante plante, int x, int y, Meteo meteo)
    {
        if (!plante.SaisonsDeSemis.Contains(meteo.SaisonActuelle.ToLower()))
    {
        Console.WriteLine($"❌ La saison actuelle ({meteo.SaisonActuelle}) ne permet pas de planter {plante.Nom} !");
        return false;
    }
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
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    Console.Clear();
    Console.WriteLine("\n🌿 VUE DU POTAGER 🌿\n");

    // En-tête X
    Console.Write("    ");
    for (int x = 0; x < Largeur; x++)
    {
        Console.Write($" {x:D2} ");
    }
    Console.WriteLine();

    // Bordure supérieure
    Console.Write("    ┌");
    for (int x = 0; x < Largeur; x++)
    {
        Console.Write("───");
        if (x < Largeur - 1) Console.Write("┬");
    }
    Console.WriteLine("┐");

    for (int y = 0; y < Hauteur; y++)
    {
        // Ligne de données
        Console.Write($" {y:D2} │");
        for (int x = 0; x < Largeur; x++)
        {
            var parcelle = Grille[y, x];
            string symbole;

            if (parcelle.Plante == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                symbole = "🟫";
            }
            else
            {
                switch (parcelle.Plante.Nom.ToLower())
                {
                    case "tomate":
                        Console.ForegroundColor = ConsoleColor.Red;
                        symbole = "🍅";
                        break;
                    case "carotte":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        symbole = "🥕";
                        break;
                    case "salade":
                        Console.ForegroundColor = ConsoleColor.Green;
                        symbole = "🥬";
                        break;
                    case "oignon":
                        Console.ForegroundColor = ConsoleColor.White;
                        symbole = "🧅";
                        break;
                    case "mais":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        symbole = "🌽";
                        break;
                    case "tournesol":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        symbole = "🌻";
                        break;
                    case "fraise":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        symbole = "🍓";
                        break;
                    case "ananas":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        symbole = "🍍";
                        break;
                    case "patate":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        symbole = "🥔";
                        break;
                    case "rose":
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        symbole = "🌹";
                        break;
                    case "courgette":
                        Console.ForegroundColor = ConsoleColor.Green;
                        symbole = "🥒";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        symbole = "🌱";
                        break;
                }
            }

            Console.Write($" {symbole} ");
            Console.ResetColor();
            Console.Write("│");
        }
        Console.WriteLine();

        // Bordure intermédiaire ou inférieure
        if (y < Hauteur - 1)
        {
            Console.Write("    ├");
            for (int x = 0; x < Largeur; x++)
            {
                Console.Write("───");
                if (x < Largeur - 1) Console.Write("┼");
            }
            Console.WriteLine("┤");
        }
    }

    // Bordure inférieure
    Console.Write("    └");
    for (int x = 0; x < Largeur; x++)
    {
        Console.Write("───");
        if (x < Largeur - 1) Console.Write("┴");
    }
    Console.WriteLine("┘");

    Console.WriteLine("\nLégende : 🍅 Tomate | 🥕 Carotte | 🥬 Salade | 🧅 Oignon | 🌽 Maïs | 🌻 Tournesol | 🍍 Ananas | 🍓 Fraise | 🥔 Patate | 🌹 Rose | 🥒 Courgette | 🟫 Vide\n");
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
   public bool ProposerRecolte()
{
    bool recoltePossible = false;

    for (int y = 0; y < Hauteur; y++)
    {
        for (int x = 0; x < Largeur; x++)
        {
            var parcelle = Grille[y, x];
            if (parcelle.Plante != null && parcelle.Plante.EstMure)
            {
                Console.WriteLine($" {parcelle.Plante.Nom} mûre en ({x}, {y}) !");
                recoltePossible = true;
            }
        }
    }

    if (!recoltePossible)
    {
        Console.WriteLine("aie Aucune plante n'est encore prête à être récoltée.");
    }

    return recoltePossible;
}

public void Recolter(int x, int y)
{
    var parcelle = Grille[y, x];

    if (parcelle.Plante == null)
    {
        Console.WriteLine("oupsi Aucune plante à récolter ici.");
        return;
    }

    var plante = parcelle.Plante;

    if (!plante.EstMure)
    {
        Console.WriteLine($" oh no {plante.Nom} n'est pas encore mûre à ({x},{y}).");
        return;
    }

    int quantiteRecoltee = plante.Production;
    Console.WriteLine($"youhou Vous avez récolté {quantiteRecoltee} {plante.Nom}(s) à ({x},{y}).");

    ReinitialiserApresRecolte(plante);
}

private void ReinitialiserApresRecolte(Plante plante)
{
    plante.CroissanceActuelle = 0;
    Console.WriteLine($"{plante.Nom} va repousser à nouveau.");
}


    
}
