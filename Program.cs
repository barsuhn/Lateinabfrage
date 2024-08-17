using Lateinabfrage;

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

Vokabeln AusDatei(string pfad)
{
    var vokabeln = new Vokabeln();

    if (!File.Exists(pfad))
    {
        Console.WriteLine($"Die Datei {pfad} gibt es scheinbar nicht!");

        return vokabeln;
    }

    using var datenStrom = new StreamReader(pfad);
    var latein = datenStrom.ReadLine();

    while (!string.IsNullOrEmpty(latein))
    {
        var deutsch = datenStrom.ReadLine();

        vokabeln.Latein.Add(latein);
        vokabeln.Deutsch.Add(deutsch);

        latein = datenStrom.ReadLine();
    }

    return vokabeln;
}

void Mischen(List<int> zahlen)
{
    var random = Random.Shared;

    for (int i = 0; i < 2*zahlen.Count; i++)
    {
        var i1 = random.Next(zahlen.Count);
        var i2 = random.Next(zahlen.Count);

        var merker = zahlen[i1];

        zahlen[i1] = zahlen[i2];
        zahlen[i2] = merker;
    }
}

var verzeichnisName = "Vokabeln";
var pfad = DateiAuswahl(verzeichnisName);
var vokabeln = AusDatei(pfad);
var reihenfolge = Enumerable.Range(0, vokabeln.Latein.Count).ToList();

Mischen(reihenfolge);

for (int i = 0; i < vokabeln.Latein.Count; i++)
{
    Console.WriteLine($"Übersetze: {vokabeln.Latein[reihenfolge[i]].Substring(2)}");
    Console.ReadLine();
    Console.WriteLine($"Richtig: {vokabeln.Deutsch[reihenfolge[i]].Substring(2)}");
}

