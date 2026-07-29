using CollectionsAndOperations.Models;

Musica musicaUm = new Musica("Que Pais é esse?", "Legião Urbana", 150);
Musica musicaDois = new Musica("Tempo Perdido", "Legião Urbana", 200);
Musica musicaTres = new Musica("Pro Dia Nascer Feliz", "Barão Vermelho", 178);
Musica musicaQuatro = new Musica("Eduardo e Mônica", "Legião Urbana", 153);
Musica musicaCinco = new Musica("Bola na Trave", "Skank", 150);
Musica musicaSeis = new Musica("Pais do Futebol", "Skank", 150);

Playlist rockNacional = new Playlist("Rock Nacional");

rockNacional.AdicionaMusicasPlaylist(musicaUm);
rockNacional.AdicionaMusicasPlaylist(musicaDois);
rockNacional.AdicionaMusicasPlaylist(musicaTres);
rockNacional.AdicionaMusicasPlaylist(musicaQuatro);
rockNacional.AdicionaMusicasPlaylist(musicaCinco);
rockNacional.AdicionaMusicasPlaylist(musicaSeis); // Proving that it is not possible to create two objects using HashSet
rockNacional.AdicionaMusicasPlaylist(new Musica("Pais do Futebol", "Skank", 150)); // Proving that it is not possible to create two objects using HashSet

rockNacional.ExibirPlaylist();

var player = new PlayerMusica();
player.AdicionarNaFila(musicaUm);
player.AdicionarNaFila(rockNacional);

player.ExibirFila(player);

System.Console.WriteLine($"\nVerificando a existência da Música na Playlist: {musicaSeis.Titulo}");
var existencia = rockNacional.Contains(musicaSeis);

try
{
    System.Console.WriteLine($"A música existe? {existencia}");
}
catch (Exception ex)
{
    System.Console.WriteLine($"A música existe? {existencia}");
}

var musicaAleatoria = rockNacional.ObterMusicaAleatorio();

if (musicaAleatoria is not null)
{
    System.Console.WriteLine($"\nMúsica aleatória: {musicaAleatoria.Titulo}");
} else
{
    System.Console.WriteLine("Playlist vazia!");
}


rockNacional.OrdernarPorDuracao();
rockNacional.ExibirPlaylist();