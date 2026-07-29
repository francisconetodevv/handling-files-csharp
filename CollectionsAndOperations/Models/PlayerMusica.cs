namespace CollectionsAndOperations.Models
{
    public class PlayerMusica
    {
        private Queue<Musica> fila = []; // PRIMEIRO A ENTRAR, PRIMEIRO A SAIR (FIFO)
        private Stack<Musica> historico = []; // ULTIMO A ENTRAR, PRIMEIRO A SAIR (LIFO)
        public void AdicionarNaFila(Musica musica)
        {
            fila.Enqueue(musica);
        }

        public void AdicionarNaFila(Playlist playlist)
        {
            foreach (var musica in playlist)
            {
                AdicionarNaFila(musica);
            }
        }

        public IEnumerable<Musica> Fila()
        {
            foreach (var musica in fila)
            {
                yield return musica;
            }
        }

        public void ExibirFila(PlayerMusica playerMusica)
        {
            System.Console.WriteLine("\nFila de Reprodução: ");
            foreach (var musica in playerMusica.Fila())
            {
                System.Console.WriteLine($"\t - {musica.Titulo}");
            }
        }

        public Musica? ProximaMusica()
        {
            if(fila.Count == 0)
            {
                return null;
            } 

            var musica = fila.Dequeue();
            historico.Push(musica);

            return musica;
        }

        public Musica? MusicaAnterior()
        {
            if (historico.Count == 0)
            {
                return null;
            }

            return historico.Pop();
        }

        public IEnumerable<Musica> Historico()
        {
            foreach(var musica in historico)
            {
                yield return musica;
            }
        }
    }
}