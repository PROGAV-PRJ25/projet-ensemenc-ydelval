Console.WriteLine("Le jeu du putagerrr") ; 
Console.WriteLine("Entrez la largeur du potager :");
int largeur = int.Parse(Console.ReadLine());

Console.WriteLine("Entrez la hauteur du potager :");
int hauteur = int.Parse(Console.ReadLine());

Potager potager = new Potager(largeur, hauteur);

Meteo meteo = new Meteo("été");
Console.WriteLine($"Température : {meteo.Temperature}°C, Soleil : {meteo.Ensoleillement}, Événement : {meteo.EvenementSpecial}");