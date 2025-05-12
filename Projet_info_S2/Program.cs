using System.Runtime.InteropServices;

class Program
{
    static Graines graines = new Graines();

    static void Main()
    {
        Console.WriteLine("Bienvenue dans votre potager!") ; 

        France france = new France();

        Console.WriteLine("Votre potager est situé en France");
        Console.WriteLine("Voici tout ce que vous pouvez planter :") ; 
        List<Plante> plantesDisponibles = new List<Plante>();

        foreach (Type typePlante in france.PlantesAutorisees)
        {
            Plante plante = null;
            if (typePlante == typeof(Tomate)) plante = new Tomate();
            else if (typePlante == typeof(Salade)) plante = new Salade();
            else if (typePlante == typeof(Ananas)) plante = new Ananas();
            else if (typePlante == typeof(Rose)) plante = new Rose();
            else if (typePlante == typeof(Patate)) plante = new Patate();
            else if (typePlante == typeof(Carotte)) plante = new Carotte();
            else if (typePlante == typeof(Courgette)) plante = new Courgette();
            else if (typePlante == typeof(Fraise)) plante = new Fraise();
            else if (typePlante == typeof(Oignon)) plante = new Oignon();
            else if (typePlante == typeof(Mais)) plante = new Mais();

            if (plante != null)
            {
                plantesDisponibles.Add(plante);
                graines.Ajouter(plante.Nom,3); // 3 graines de départ par plante
                Console.WriteLine($"🌱 {plante.Nom} - Type : {plante.Type} - Terrain préféré : {plante.TerrainPrefere}");
            }
        }

        Meteo meteo = new Meteo("printemps");

        Console.WriteLine("Choisisssez la taille de votre potager");
        Console.WriteLine("Hauteur :");
        int hauteur = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Largeur :");
        int largeur = int.Parse(Console.ReadLine()!);

        Potager potager = new Potager(hauteur, largeur);

            // Boucle de jeu
            while (true)
            {
                // Affiche les conditions météo à chaque tour

                Console.WriteLine($"Jour {meteo.JourActuel} - Saison : {meteo.SaisonActuelle}");
                Console.WriteLine($"Température : {meteo.Temperature} °C");
                Console.WriteLine($"Précipitations : {meteo.Precipitations} mm");
                Console.WriteLine($"Ensoleillement : {meteo.Ensoleillement:F2} (de 0 à 1)");
                Console.WriteLine($"Intempéries : {(meteo.Intemperies ? "Oui" : "Non")}");
                Console.WriteLine($"Événement spécial : {meteo.EvenementSpecial}");
                Console.WriteLine("-------------------------");

                //Affiche l'état des plantes à chaque tour
                
                potager.AfficherEtat();

                //Affiche le potager à chaque tour

                potager.AfficherGrille();



                Console.WriteLine("\n===== Menu Principal =====");
                Console.WriteLine("1. Planter");
                Console.WriteLine("2. Récolter");
                Console.WriteLine("3. Passer au jour suivant");
                Console.WriteLine("4. Afficher graines");
                Console.WriteLine("5. Soigner une plante");
                Console.WriteLine("0. Quitter");

                Console.Write("Choix : ");
                string choix = Console.ReadLine();
                Console.WriteLine();

                switch (choix){
                    case "1":
                    {
                        Console.WriteLine("Quelle plante voulez-vous planter?");
                        string nomP = Console.ReadLine()!;

                        if (!graines.AGraines(nomP.ToLower()))
                        {
                            Console.WriteLine("Vous n'avez pas de graines de cette plante");
                            break;
                        }
                        Plante plante;
                        switch (nomP.ToLower()){
                            case "tomate":
                                plante = new Tomate();
                                break;
                            case "salade":
                                plante = new Salade();
                                break;
                            case "ananas":
                                plante = new Ananas();
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
                            default:
                                plante = null;
                                break;
                        };
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

                        if (potager.Planter(plante,x,y,meteo))
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
                        potager.Recolter(rx,ry);
                        break;
                    case "3":
                        meteo.IncrementeJour();
                        potager.EvaluerPlantes(meteo);
                        break;
                    case "4":
                        graines.Afficher();
                        break;
                    case "5":
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
