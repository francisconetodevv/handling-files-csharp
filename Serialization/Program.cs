using System.Text.Json;
using DataAbstract.Models;

// Etapas de recebimento de dados:
// 1. Extracao dos dados
// 2. Manipulacao dos dados
// 3. Tratamento e estruturacao
// 4. Serializacao


using var file = new FileStream("musicas.csv", FileMode.Open, FileAccess.Read);
using var stream = new StreamReader(file);

var allMusics = Music.RequestMusic(stream).ToList().Where(m => m.Artist.Equals("COLDPLAY", StringComparison.OrdinalIgnoreCase));
Music.PrintMusicsInTable(allMusics);

var artist = allMusics.GroupBy(m => m.Artist).Select(g => new { Artista = g.Key, Musicas = g.OrderBy(m => m.Launched), Total = g.Count()}).ToList();
var options = new JsonSerializerOptions
{
  WriteIndented = true  
};
var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "artistas.json");
using var arquivoJson = new FileStream(fileName, FileMode.Create, FileAccess.Write);
JsonSerializer.Serialize(arquivoJson, artist, options); // Geralmente ja e gerado no desktop do sistema

System.Console.WriteLine("Serializacao concluida!");