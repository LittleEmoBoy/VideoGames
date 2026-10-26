/*Diseña un gestor de canciones utilizando un struct Cancion { Artista, Titulo, DuracionSeg }.
Utiliza un array de capacidad 50 con menú interactivo:
  1.Añadir canción.
  2.Mostrar listado con duración en m y s (ej. 4m 13s).
  3. Buscar por título o artista (case-insensitive con .ToLower()).
  4. Mostrar la canción de mayor duración.
*/

using System;
//Esto es calidad de vida, simplemente es para añadir un pequeño delay entre respuestas
using System.Threading;

//Constructor de Java pero en C#
struct Song
{
    public string artist;
    public string title;
    public int durationsec;
}


class Program
{
    static void Main()
    {
        Song[] songs = new Song[50];
        int total = 0;
        int option;

        Console.WriteLine("Bienvenido al reproductor de música dinámico");

        //Para que el bucle continue hasta que el usuario decida terminar
        do
        {
            Console.WriteLine();
            Console.WriteLine("---------------------");
            Console.WriteLine("1. Añadir canción ");
            Console.WriteLine("2. Mostrar listado ");
            Console.WriteLine("3. Buscar ");
            Console.WriteLine("4. Canción más larga ");
            Console.WriteLine("5. Canción más larga con límite ");
            Console.WriteLine("0. Salir ");
            Console.WriteLine("---------------------");
            Console.Write("Selecionne una opción: ");
            option = int.Parse(Console.ReadLine());

            //Para realizar una opción u otra conforme el usuario quiera
            switch (option)
            {
                case 1:
                    addSong(songs, ref total);
                    break;

                case 2:
                    showSongs(songs, total);
                    break;

                case 3:
                    searchSongs(songs, total);
                    break;

                case 4:
                    showLongest(songs, total);
                    break;

                case 5:
                    showLongestWithLimit(songs, total);
                    break;
            }

            //Pequeño delay de 2 segundos, quality of life porque me parecía demasiado espontáneo el salto de un opción a otra
            Thread.Sleep(2000);
        } while (option != 0);

    }

    static void addSong(Song[] songs, ref int total)
    {
        if (total == songs.Length)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("Lleno");
            return;
        }
        Console.WriteLine();
        Console.WriteLine("---------------------");
        Console.Write("Artista: ");
        songs[total].artist = Console.ReadLine();
        Console.Write("Título: ");
        songs[total].title = Console.ReadLine();
        Console.Write("Duración (minutos): ");
        int inMin = int.Parse(Console.ReadLine());
        Console.Write("Duración (segundos): ");
        int inSec = int.Parse(Console.ReadLine());
        songs[total].durationsec = inMin * 60 + inSec;
        total++;
        Console.WriteLine("---------------------");
        Console.WriteLine("Canción añadida.");
    }

    static void showSongs(Song[] songs, int total)
    {
        Console.WriteLine();
        Console.WriteLine("---------------------");
        if (total == 0)
        {
            Console.WriteLine("No hay canciones.");
        }
        for (int i = 0; i < total; i++)
        {
            //En cuyo caso pongamos un solo número, esto lo divide y lo convierte a minutos
            int min = songs[i].durationsec / 60;
            //Lo mismo de antes pero ahora para los segundos restantes
            int sec = songs[i].durationsec % 60;
            Console.WriteLine(songs[i].artist + " - " + songs[i].title + " (" + min + "m " + sec + "s)");
        }
        Console.WriteLine("---------------------");
    }

    static void searchSongs(Song[] songs, int total)
    {
        Console.WriteLine();
        Console.WriteLine("---------------------");
        Console.Write("Buscar: ");
        string text = Console.ReadLine().ToLower();
        Console.WriteLine("---------------------");
        for (int i = 0; i < total; i++)
        {
            //Contains(text) busca tanto en artista como en cancion, por si hubiera algún fallo
            if (songs[i].title.ToLower().Contains(text) || songs[i].artist.ToLower().Contains(text))
            {
                Console.WriteLine(songs[i].artist + " - " + songs[i].title);
            }
        }
        Console.WriteLine("---------------------");
    }

    static void showLongest(Song[] songs, int total)
    {
        Console.WriteLine();
        Console.WriteLine("---------------------");
        if (total == 0)
        {
            Console.WriteLine("No hay canciones.");
            return;
        }

        //Creamos una variable par ala duración de cada canción
        int longest = 0;
        for (int i = 1; i < total; i++)
        {
            if (songs[i].durationsec > songs[longest].durationsec)
                longest = i;
        }

        //Calcula cual es la cancion con el longest más largo y después lo imprime
        int minLongest = songs[longest].durationsec / 60;
        int secLongest = songs[longest].durationsec % 60;
        Console.WriteLine("Más larga: " + songs[longest].artist + " - " + songs[longest].title + " (" + minLongest + "m " + secLongest + "s)");
        Console.WriteLine("---------------------");
    }

    static void showLongestWithLimit(Song[] songs, int total)
    {
        Console.WriteLine();
        Console.WriteLine("---------------------");
        Console.Write("Duración máxima (segundos): ");
        int limit = int.Parse(Console.ReadLine());

        //-1 significa que todavía no hemos encontrado ninguna canción válida
        int longest = -1;
        for (int i = 0; i < total; i++)
        {
            if (songs[i].durationsec <= limit && (longest == -1 || songs[i].durationsec > songs[longest].durationsec))
                longest = i;
        }

        if (longest == -1)
        {
            Console.WriteLine("No hay canciones de " + limit + " segundos o menos.");
            Console.WriteLine("---------------------");
            return;
        }

        int minLongest = songs[longest].durationsec / 60;
        int secLongest = songs[longest].durationsec % 60;
        Console.WriteLine("Más larga (máx. " + limit + "s): " + songs[longest].artist + " - " + songs[longest].title + " (" + minLongest + "m " + secLongest + "s)");
        Console.WriteLine("---------------------");
    }

}
