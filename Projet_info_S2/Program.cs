using System.Runtime.InteropServices;

class Program
{
    static Dictionary<string, int> graines = new Dictionary<string, int>();

    static void Main()
    {
        Console.WriteLine("Bienvenue dans votre potager!") ; 

        France france = new France();
        Martinique martinique = new Martinique();
        

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
            else if (typePlante == typeof(Cocotier)) plante = new Cocotier();
            else if (typePlante == typeof(Mais)) plante = new Mais();

            if (plante != null)
            {
                plantesDisponibles.Add(plante);
                graines[plante.Nom] = 1; // 1 graine de départ
                Console.WriteLine($"🌱 {plante.Nom} - Type : {plante.Type} - Terrain préféré : {plante.TerrainPrefere}");
            }
        }

        Meteo meteo = new Meteo("printemps");

        Console.WriteLine("Choisisssez la taille de votre potager");
        Console.WriteLine("Hauteur :");
        int hauteur = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Hauteur :");
        int largeur = int.Parse(Console.ReadLine()!);

        Potager potager = new Potager(hauteur, largeur);

        // Affiche les conditions météo 


            Console.WriteLine($"Jour {meteo.JourActuel} - Saison : {meteo.SaisonActuelle}");
            Console.WriteLine($"Température : {meteo.Temperature} °C");
            Console.WriteLine($"Précipitations : {meteo.Precipitations} mm");
            Console.WriteLine($"Ensoleillement : {meteo.Ensoleillement:F2} (de 0 à 1)");
            Console.WriteLine($"Intempéries : {(meteo.Intemperies ? "Oui" : "Non")}");
            Console.WriteLine($"Événement spécial : {meteo.EvenementSpecial}");
            Console.WriteLine("-------------------------");

            // Boucle de jeu
            while (true)
            {
                Console.WriteLine("\n===== Menu Principal =====");
                Console.WriteLine("1. Afficher potager");
                Console.WriteLine("2. Afficher état des plantes");
                Console.WriteLine("3. Planter");
                Console.WriteLine("4. Récolter");
                Console.WriteLine("5. Passer au jour suivant");
                Console.WriteLine("6. Afficher météo");
                Console.WriteLine("7. Afficher graines");
                Console.WriteLine("0. Quitter");

                Console.Write("Choix : ");
                string choix = Console.ReadLine();
                Console.WriteLine();

                switch (choix){
                    case "1":
                        potager.AfficherGrille();
                        break;
                    case "2":
                        potager.AfficherEtat();
                        break;
                    case "3":
                    {
                        Console.WriteLine("Quelle plante voulez-vous planter?");
                        string nomP = Console.ReadLine()!;

                        if (!graines.ContainsKey(nomP) || graines[nomP] <= 0)
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
                            case "cocotier":
                                plante = new Cocotier();
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
                            graines[nomP]--;
                        }
                        break;
                    }
                    case "4":
                        Console.WriteLine("Coordonnées X : ");
                        int rx = int.Parse(Console.ReadLine()!);
                        Console.WriteLine("Coordonnées Y : ");
                        int ry = int.Parse(Console.ReadLine()!);
                        potager.Recolter(rx,ry);
                        break;
                }



                
        }
    }
}
