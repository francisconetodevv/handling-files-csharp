namespace DataAbstract.Models
{
    public static class ExtensionsMusic
    {
        public static IEnumerable<Music> FilterMusicByBand(this IEnumerable<Music> musics, string band)
        {
            foreach (var music in musics)
            {
                if (music.Artist == band)
                {
                    yield return music;
                }
            }
        }

        public static IEnumerable<Music> FilterMusicByDuration(this IEnumerable<Music> musics, int duration)
        {
            foreach (var music in musics)
            {
                if (music.Duration >= duration)
                {
                    yield return music;
                }
            }
        }

        // Turning into a abstract method to use with delegate func
        public static IEnumerable<Music> FilterBy(this IEnumerable<Music> musics, Func<Music, bool> condicao)
        {
            foreach (var music in musics)
            {
                // condição: função que, ao ser executada, retorna true/false
                if (condicao(music)) yield return music;
            }
        }

        public static IEnumerable<T> FilterByLinq<T>(this IEnumerable<T> colection, Func<T, bool> condicao)
        {
            foreach (var element in colection)
            {
                if (condicao(element)) yield return element;
            }
        }
    }
}