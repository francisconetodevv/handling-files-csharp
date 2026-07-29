using DataAbstract.Models;

/*
    Seja um arquivo com músicas em formato CSV (Comma Separated Values). 

    Implemente as funções abaixo:
    //     [X] Leia-o como uma coleção de músicas
    //     [X] Filtre a coleção por artista (por ex. Coldplay, Metallica, AC/DC)
    //     [X] Filtre a coleção por gênero (por ex. rock)
    //     [X] Filtre a coleção por duração (por ex. maiores que 5 minutos)
    //     [X] Ordene a coleção por artista
    //     [X] Ordene a coleção por artista e em seguida por músicas com duração crescente
    //     [X] Crie uma coleção de artistas e suas músicas
    //     [X] Informe a duração média das músicas da coleção
    //     [X] Informe a duração total das músicas da coleção
    //     [] Informe qual artista tem mais músicas na coleção
 
*/

/*
    ESTAGIO DE COLEÇÕES:
        1. OBTENÇÃO DOS DADOS;
        2. ARMAZENAMENTO EM ESTRUTURAS PRÉ-DEFINIDAS
        3. MANIPULAÇÃO DA COLEÇÃO
*/

using var file = new FileStream("musicas.csv", FileMode.Open, FileAccess.Read);
using var stream = new StreamReader(file);

var allMusics = Music.RequestMusic(stream).ToList();
Music.ArtistAndMusicMostListened(allMusics);