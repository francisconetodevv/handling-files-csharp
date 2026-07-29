namespace CollectionsAndOperations.Models
{
    public class Musica : IComparable
    {
        public string Titulo { get; set; }
        public string Artista { get; set; }
        public int Duracao { get; set; }

        public Musica(string titulo, string artista, int duracao)
        {
            Titulo = titulo;
            Artista = artista;
            Duracao = duracao;
        }

        /// <summary>
        /// - Se iguais : 0
        /// - Se menor: -1
        /// - Se maior: 1
        /// </summary>
        public int CompareTo(object? obj) 
        {
            if (obj is null)
            {
                return -1;
            } else if (obj is Musica outraMusica)
            {
                return this.Duracao.CompareTo(outraMusica.Duracao);
            } 
            
            return -1;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is Musica outraMusica) return this.Titulo.Equals(outraMusica.Titulo) && this.Artista.Equals(outraMusica.Artista);
            return false;
        }

        public override int GetHashCode()
        {
            return this.Titulo.GetHashCode() ^ this.Artista.GetHashCode();
        }
    }
}