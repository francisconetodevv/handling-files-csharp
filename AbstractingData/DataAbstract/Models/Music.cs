namespace DataAbstract.Models
{
    public class Music
    {
        public string Title { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public IEnumerable<string> ?Genres { get; set; }
        public int Duration { get; set; }

        public static IEnumerable<Music> RequestMusic(StreamReader stream)
        {
            var line = stream.ReadLine();

            while (line is not null)
            {
                var split = line.Split(';');
                var music = new Music
                {
                    Title = split[0],
                    Artist = split[1],
                    Duration = Convert.ToInt32(split[2]),
                    Genres = split[3].Split(',').Select(g => g.Trim())
                };

                yield return music;
                line = stream.ReadLine();
            }
        }

        public static void PrintMusics(IEnumerable<Music> musics)
        {
            var quantity = 0;
            System.Console.WriteLine($"\nExibindo as músicas: ");
            foreach (var music in musics)
            {
                System.Console.WriteLine($"\t - {music.Title} - {music.Artist} - {music.Duration}(s) - {music.Genres}");
                quantity++;

                if (quantity > 10)
                {
                    break;
                }
            }
        }

        public static void MusicStatistics(IEnumerable<Music> musics)
        {
            System.Console.WriteLine("\nEstatísticas da Lista de Músicas.");
            System.Console.WriteLine($"Quantidade de Músicas na Lista: {musics.Count()}");
            System.Console.WriteLine($"Quantidade de Músicas com mais de 10 min: {musics.Count(m => m.Duration >= 600)}");
            System.Console.WriteLine($"Música com menor duração: {musics.Min(m => m.Duration)}");
            System.Console.WriteLine($"Música com maior duração: {musics.Max(m => m.Duration)}");
            System.Console.WriteLine($"Duração média das Músicas: {musics.Average(m => m.Duration)} (s)");
            System.Console.WriteLine($"Soma em dias de todas as Músicas: {musics.Sum(m => m.Duration) / (3600 * 24)}");
        }

        public static void ArtistAndMusic(IEnumerable<Music> musics)
        {
            var artistasAndMusics = musics.GroupBy(m => m.Artist);

            System.Console.WriteLine("\nExibindo as Músicas de cada Artista:");
            foreach (var artista in artistasAndMusics)
            {
                System.Console.WriteLine($"\nArtista: {artista.Key} | Quantidade de Músicas: {artista.Count()}");
                foreach (var musica in artista)
                {
                    System.Console.WriteLine($"\t - {musica.Title}");
                }
            }
        }

        public static void MusicWithMostDuration(IEnumerable<Music> musics)
        {
            var musicWithMostDuration = musics.MaxBy(m => m.Duration);

            if (musicWithMostDuration is not null)
            {
                System.Console.WriteLine($"Música com maior duração: {musicWithMostDuration.Title} - {musicWithMostDuration.Duration} (s)");
            }
        }

        public static void ArtistAndMusicMostListened(IEnumerable<Music> musics)
        {
            var artistMusic = musics.GroupBy(m => m.Artist)
                       .Select(g => new
                       {
                           Artista = g.Key,
                           Musicas = g,
                           Total = g.Count()
                       })
                       .MaxBy(a => a.Total);

            if (artistMusic is not null)
            {
                System.Console.WriteLine($"Artista com mais músicas: {artistMusic.Artista} | Quantidade: {artistMusic.Total}");
            }
        }
    }
}