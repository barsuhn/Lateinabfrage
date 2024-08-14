Console.Write("Dateiname: ");

var dateiName = Console.ReadLine();
var verzeichnisName = "Vokabeln";
var pfad = Path.Combine(verzeichnisName, dateiName);

if (!File.Exists(pfad))
{
    Console.WriteLine($"Die Datei {pfad} gibt es scheinbar nicht!");
    Environment.Exit(-1);
}

using var datenStrom = new StreamReader(pfad);

var latein = datenStrom.ReadLine();

while (!string.IsNullOrEmpty(latein))
{
    Console.WriteLine($"Übersetze: {latein.Substring(2)}");
    Console.ReadLine();

    var deutsch = datenStrom.ReadLine();

    Console.WriteLine($"Richtig: {deutsch.Substring(2)}");
    Console.ReadLine();

    latein = datenStrom.ReadLine();
}

