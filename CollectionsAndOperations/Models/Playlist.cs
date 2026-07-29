using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsAndOperations.Models
{
    public class Playlist : ICollection<Musica>
    {
        private HashSet<Musica> setMusicas = new HashSet<Musica>();
        private List<Musica> listaMusicas = new List<Musica>();
        public string Nome { get; set; }

        public int Count => listaMusicas.Count;

        public bool IsReadOnly => false;

        public Playlist(string nome)
        {
            Nome = nome;
        }

        public void AdicionaMusicasPlaylist(Musica musica)
        {
            if (setMusicas.Add(musica))
            {
                listaMusicas.Add(musica);
            }
        }

        public List<Musica> ExibirPlaylist()
        {
            System.Console.WriteLine($"\nTocando as Músicas da Playlist: {Nome}");

            foreach (var musica in listaMusicas)
            {
                System.Console.WriteLine($"\t - Título: '{musica.Titulo}' | Artista: {musica.Artista} | Duração: {musica.Duracao}");
            }

            return listaMusicas;
        }

        public Musica? ObterMusicaAleatorio()
        {
            if (listaMusicas.Count == 0)
            {
                return null;
            }
            else
            {
                var random = new Random();
                var numAleatorio = random.Next(0, listaMusicas.Count);

                return listaMusicas[numAleatorio];
            }
        }

        public void OrdernarPorDuracao()
        {
            listaMusicas.Sort(); // Tipos de elementos da lista está implementando o IComparable
        }

        public void ExibirMaisTocadas(Playlist playlist1, Playlist playlist2)
        {
            Dictionary<Musica, int> ranking = new Dictionary<Musica, int>();

            foreach (var musica in playlist1)
            {
                ranking[musica] = ranking.GetValueOrDefault(musica) + 1;
            }

            foreach (var musica in playlist2)
            {
                ranking[musica] = ranking.GetValueOrDefault(musica) + 1;
            }

            var colecaoPlaylist = ranking
                .OrderByDescending(item => item.Value)
                .ThenBy(item => item.Key.Titulo)
                .ToList();

            System.Console.WriteLine($"\nMúsicas mais tocadas entre '{playlist1.Nome}' e '{playlist2.Nome}':");
            foreach (var (musica, contagem) in colecaoPlaylist)
            {
                System.Console.WriteLine($"\t- '{musica.Titulo}' | Artista: {musica.Artista} | Tocou: {contagem} vezes");
            }
        }

        public void Add(Musica item)
        {
            if (setMusicas.Add(item))
            {
                listaMusicas.Add(item);
            }
        }

        public void Clear()
        {
            listaMusicas.Clear();
            setMusicas.Clear();
        }

        public bool Contains(Musica item)
        {
            return setMusicas.Contains(item);
        }

        public void CopyTo(Musica[] array, int arrayIndex)
        {
            listaMusicas.CopyTo(array, arrayIndex);
        }

        public bool Remove(Musica item)
        {
            setMusicas.Remove(item);
            return listaMusicas.Remove(item);
        }

        public IEnumerator<Musica> GetEnumerator()
        {
            return listaMusicas.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}