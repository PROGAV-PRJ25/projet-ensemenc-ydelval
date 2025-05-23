class Program
{
    static Graines graines = new Graines();
    static Fruits fruits = new Fruits();
    static void ActiverModeUrgence(Potager potager)
{
    Console.WriteLine("\n🚨 URGENCE DANS LE POTAGER ! 🚨");

    // Choix aléatoire entre une grêle ou un intrus
    Random rand = new Random();
    int evenement = rand.Next(2);

    if (evenement == 0)
    {
        Console.WriteLine("🌨️ Une violente tempête de grêle s’abat sur votre potager !");
        Console.WriteLine("Souhaitez-vous déployer une bâche de protection ? (oui/non)");
        string reponse = Console.ReadLine()?.ToLower();
        if (reponse == "oui")
        {
            Console.WriteLine("✅ Vous avez limité les dégâts !");
        }
        else
        {
            Console.WriteLine("❌ Des plantes ont été blessées...");
            potager.EndommagerPlantesAleatoirement();
        }
    }
    else
    {
        Console.WriteLine("🐭 Un rongeur s’est infiltré et mange vos récoltes !");
        Console.WriteLine("Souhaitez-vous faire du bruit pour le faire fuir ? (oui/non)");
        string reponse = Console.ReadLine()?.ToLower();
        bool defenseActivee = reponse == "oui";

        Console.WriteLine("🔍 Il rôde dans le potager...");
        potager.AfficherGrille(true);

        // Il vole quand même, mais moins si le joueur agit
        potager.VolDeFruitsAleatoire(defenseActivee);
    }
}

    static void Main()
    {

        Console.WriteLine("Bienvenue dans votre potager!");

        France france = new France();

        Console.WriteLine("Votre potager est situé en France");
        Console.WriteLine("Voici tout ce que vous pouvez planter :");
        List<Plante> plantesDisponibles = new List<Plante>();

        foreach (Type typePlante in france.PlantesAutorisees)
        {
            Plante plante = null;
            if (typePlante == typeof(Tomate)) plante = new Tomate();
            else if (typePlante == typeof(Salade)) plante = new Salade();
            else if (typePlante == typeof(Cerisier)) plante = new Cerisier();
            else if (typePlante == typeof(Rose)) plante = new Rose();
            else if (typePlante == typeof(Patate)) plante = new Patate();
            else if (typePlante == typeof(Carotte)) plante = new Carotte();
            else if (typePlante == typeof(Courgette)) plante = new Courgette();
            else if (typePlante == typeof(Fraise)) plante = new Fraise();
            else if (typePlante == typeof(Oignon)) plante = new Oignon();
            else if (typePlante == typeof(Mais)) plante = new Mais();
            else if (typePlante == typeof(Tournesol)) plante = new Tournesol();

            if (plante != null)
            {
                plantesDisponibles.Add(plante);
                graines.Ajouter(plante.Nom, 3); // 3 graines de départ par plante
                Console.WriteLine($"🌱 {plante.Nom} - Type : {plante.Type} - Terrain préféré : {plante.TerrainPrefere}");
            }
        }

        Meteo meteo = new Meteo("printemps");

        Console.WriteLine("Choisisssez la taille de votre potager");
        Console.WriteLine("Hauteur :");
        int hauteur = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Largeur :");
        int largeur = int.Parse(Console.ReadLine()!);

        // Affichage règles et ce qu'on peut planter
        Console.WriteLine("\n--- Règles du jeu ---");
        Console.WriteLine("- Plantez des graines adaptées à la saison et au terrain.");
        Console.WriteLine("- Soignez vos plantes pour qu'elles poussent mieux.");
        Console.WriteLine("- Récoltez au bon moment.");
        Console.WriteLine("- Surveillez la météo et adaptez-vous.");
        Console.WriteLine("\nAppuyez sur Entrée pour continuer...");
        Console.ReadLine();

        Potager potager = new Potager(largeur, hauteur);



        // Boucle de jeu
        while (true)
        {

            // Affichage météo + état potager
            Console.WriteLine($"\n--- Météo et état du potager ---");
            Console.WriteLine($"Semaine {meteo.SemaineActuelle} - Saison : {meteo.SaisonActuelle}");
            Console.WriteLine($"Température : {meteo.Temperature} °C");
            Console.WriteLine($"Précipitations : {meteo.Precipitations} mm");
            Console.WriteLine($"Ensoleillement : {meteo.Ensoleillement:F2} (de 0 à 1)");
            Console.WriteLine($"Intempéries : {(meteo.Intemperies ? "Oui" : "Non")}");
            Console.WriteLine($"Événement spécial : {meteo.EvenementSpecial}");
            Console.WriteLine("-------------------------");

            potager.AfficherEtat();
            potager.ProposerRecolte();


            // Affichage propositions (planter, soigner, récolter, etc)
            Console.WriteLine("\n===== Menu Principal =====");
            Console.WriteLine("1. Planter");
            Console.WriteLine("2. Récolter");
            Console.WriteLine("3. Passer à la semaine suivante");
            Console.WriteLine("4. Afficher graines");
            Console.WriteLine("5. Afficher fruits");
            Console.WriteLine("6. Afficher le type de sol");
            Console.WriteLine("7. Soigner une plante");
            Console.WriteLine("8. Arroser une plante");
            Console.WriteLine("0. Quitter");
            Console.WriteLine("\nAppuyez sur Entrée pour continuer...");
            Console.ReadLine();

            // Affichage potager
            Console.WriteLine("\n--- Potager ---");
            potager.AfficherGrille();

            // Lecture choix utilisateur
            Console.Write("Choix : ");
            string choix = Console.ReadLine();
            Console.WriteLine();

            switch (choix)
            {
                case "1":
                    {
                        Console.WriteLine("Quelle plante voulez-vous planter?");
                        string nomP = Console.ReadLine()!.ToLower();

                        if (!graines.AGraines(nomP))
                        {
                            Console.WriteLine("Vous n'avez pas de graines de cette plante");
                            break;
                        }
                        Plante plante;
                        switch (nomP)
                        {
                            case "tomate":
                                plante = new Tomate();
                                break;
                            case "salade":
                                plante = new Salade();
                                break;
                            case "cerisier":
                                plante = new Cerisier();
                                break;
                            case "ananas":
                                plante = new Cerisier();
                                break;
                            case "carotte":
                                plante = new Carotte();
                                break;
                            case "oignon":
                                plante = new Oignon();
                                break;
                            case "fraise":
                                plante = new Fraise();
                                break;
                            case "mais":
                                plante = new Mais();
                                break;
                            case "patate":
                                plante = new Patate();
                                break;
                            case "rose":
                                plante = new Rose();
                                break;
                            case "courgette":
                                plante = new Courgette();
                                break;
                            case "tournesol":
                                plante = new Tournesol();
                                break;
                            default:
                                plante = null;
                                break;
                        }
                        ;
                        if (plante == null)
                        {
                            Console.WriteLine("Plante inconnue");
                            break;
                        }
                        if (!france.PeutPlanter(plante))
                        {
                            Console.WriteLine("Cette plante ne pousse pas dans ce pays");
                            break;
                        }

                        Console.WriteLine("Coordonnées X : ");
                        int x = int.Parse(Console.ReadLine()!);
                        Console.WriteLine("Coordonnées Y : ");
                        int y = int.Parse(Console.ReadLine()!);

                        if (potager.Planter(plante, x, y, meteo))
                        {
                            graines.Utiliser(nomP.ToLower());
                        }
                        else
                        {
                            Console.WriteLine($"❌ Échec de plantation de {plante.Nom} en ({x},{y}).");
                        }
                        break;
                    }
                case "2":
                    Console.WriteLine("Coordonnées X : ");
                    int rx = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Coordonnées Y : ");
                    int ry = int.Parse(Console.ReadLine()!);
                    potager.Recolter(rx, ry, graines, fruits);
                    break;
                case "3":
                    meteo.IncrementerSemaine();
                    Random rand = new Random();
                    bool declencherUrgence = rand.NextDouble() < 0.5; // 10% de chance
                    if (declencherUrgence)
                    {
                        ActiverModeUrgence(potager);
                    }

                    potager.EvaluerPlantes(meteo);
                    break;
                case "4":
                    graines.Afficher();
                    break;
                case "5":
                    fruits.Afficher();
                    break;
                case "6":
                    potager.AfficherTypesSols();
                    break;
                case "7":
                    Console.WriteLine("Coordonnées X de la plante à soigner : ");
                    int sx = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Coordonnées Y de la plante à soigner : ");
                    int sy = int.Parse(Console.ReadLine()!);
                    var planteASoigner = potager.Grille[sy, sx].Plante;
                    if (planteASoigner != null)
                    {
                        planteASoigner.Soigner();
                    }
                    else
                    {
                        Console.WriteLine("Aucune plante à cet endroit.");
                    }
                    break;
                case "8":
                    Console.WriteLine("Coordonnées X de la plante à arroser : ");
                    int ax = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Coordonnées Y de la plante à arroser : ");
                    int ay = int.Parse(Console.ReadLine()!);
                    var planteAAroser = potager.Grille[ay, ax].Plante;
                    if (planteAAroser != null)
                    {
                        if (planteAAroser.ASoif)
                        {
                            planteAAroser.Sante += 10;
                            if (planteAAroser.Sante > 100)
                            { planteAAroser.Sante = 100; }
                            planteAAroser.ASoif = false;
                            Console.WriteLine($"{planteAAroser.Nom} a été arrosée. Santé améliorée !");
                        }
                        else
                        { Console.WriteLine($"{planteAAroser.Nom} n'a pas besoin d'eau"); }
                    }
                    else
                    { Console.WriteLine("Aucune plante à cet endroit"); }
                    break;

                case "0":
                    Console.WriteLine("👋 Merci d'avoir joué !");
                    return;
                default:
                    Console.WriteLine("❌ Choix invalide.");
                    break;
            }
        }
    }
}
