using System.Runtime.CompilerServices;

Console.WriteLine("Le jeu du putagerrr") ; 


Ananas Ananas = new Ananas()  ;
Carotte Carotte = new Carotte() ; 
Fraise Fraise = new Fraise() ; 
Mais Mais = new Mais() ; 
Courgette Courgette = new Courgette() ; 
Tomate Tomtate = new Tomate() ; 
Cocotier Cocotier = new Cocotier() ; 
Salade Salade = new Salade() ; 
Rose Rose = new Rose() ; 
Sable terrainSable = new Sable();
Terre terrainTerre = new Terre();
Argile terrainArgile = new Argile();
France france = new France();
Martinique martinique = new Martinique();

Console.WriteLine("votre pays est la france :");
Console.WriteLine("Voici tout ce que vous pouvez plantez") ; 
Console.WriteLine($"🌱 {Ananas.Nom} - Type : {Ananas.Type} - Terrain : {Ananas.TerrainPrefere}");
Console.WriteLine($"🌱 {Carotte.Nom} - Type : {Carotte.Type} - Terrain : {Carotte.TerrainPrefere}");
Console.WriteLine($"🌱 {Fraise.Nom} - Type : {Fraise.Type} - Terrain : {Fraise.TerrainPrefere}");
Console.WriteLine($"🌱 {Mais.Nom} - Type : {Mais.Type} - Terrain : {Mais.TerrainPrefere}");
Console.WriteLine($"🌱 {Courgette.Nom} - Type : {Courgette.Type} - Terrain : {Courgette.TerrainPrefere}");
Console.WriteLine($"🌱 {Tomtate.Nom} - Type : {Tomtate.Type} - Terrain : {Tomtate.TerrainPrefere}");
Console.WriteLine($"🌱 {Cocotier.Nom} - Type : {Cocotier.Type} - Terrain : {Cocotier.TerrainPrefere}");
Console.WriteLine($"🌱 {Salade.Nom} - Type : {Salade.Type} - Terrain : {Salade.TerrainPrefere}");
Console.WriteLine($"🌱 {Rose.Nom} - Type : {Rose.Type} - Terrain : {Rose.TerrainPrefere}");

 Meteo meteo = new Meteo("printemps");

// Affiche les conditions météo pour 35 jours


    Console.WriteLine($"Jour {meteo.JourActuel} - Saison : {meteo.SaisonActuelle}");
    Console.WriteLine($"Température : {meteo.Temperature} °C");
    Console.WriteLine($"Précipitations : {meteo.Precipitations} mm");
    Console.WriteLine($"Ensoleillement : {meteo.Ensoleillement:F2} (de 0 à 1)");
    Console.WriteLine($"Intempéries : {(meteo.Intemperies ? "Oui" : "Non")}");
    Console.WriteLine($"Événement spécial : {meteo.EvenementSpecial}");
    Console.WriteLine("-------------------------");

    meteo.IncrementeJour(); // Passe au jour suivant

    Console.WriteLine("Que voulez-vous faire ?");
    Console.WriteLine("🌱 Planter");
    Console.WriteLine("💧 Arroser");
    Console.WriteLine("🧺 Récolter");
    Console.WriteLine("🚑 Soigner");
    Console.WriteLine("☀️ Mettre du soleil");

    Console.Write("Votre choix : ");
    int choix = int.Parse(Console.ReadLine());


        
