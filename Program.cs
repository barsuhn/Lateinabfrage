string DateiAuswahl(string verzeichnisName)
{
    var files = Directory.EnumerateFiles(verzeichnisName).ToList();

    for (var i = 0; i < files.Count; i++)
    {
        Console.WriteLine($"{i}> {files[i]}");
    }
    Console.WriteLine();

    int index;

    do
    {
        Console.Write("> ");
        var auswahl = Console.ReadLine();

        if (!Int32.TryParse(auswahl, out index))
            index = -1;

    } while (index < 0 || index >= files.Count);

    Console.WriteLine();

    return files[index];
}


var verzeichnisName = "Vokabeln";
var pfad = DateiAuswahl(verzeichnisName);

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

    latein = datenStrom.ReadLine();
}

