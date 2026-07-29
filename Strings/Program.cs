using DataAbstract.Models;


using var file = new FileStream("musicas.csv", FileMode.Open, FileAccess.Read);
using var stream = new StreamReader(file);

var allMusics = Music.RequestMusic(stream).ToList().Where(m => m.Artist.Equals("COLDPLAY", StringComparison.OrdinalIgnoreCase));
Music.PrintMusicsInTable(allMusics);