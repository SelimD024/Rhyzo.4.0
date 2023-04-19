using Rhyzo.Playlists;
using Rhyzo.Songs;

namespace Rhyzo.UI;

public class PlaylistUI : UI
{
    private readonly UI _previousUi;

    public Playlist _playlist;

    public PlaylistUI(UI previousUi, Playlist playlist)
    {
        _previousUi = previousUi;
        _playlist = playlist;
    }
    
    public void Display()
    {
        Console.WriteLine("Playlist: {0}", _playlist.Name);
        Console.WriteLine("Commands:");
        Console.WriteLine("exit");
        Console.WriteLine("select {index}");
        var songs = _playlist.GetSongs();
        Console.WriteLine("Found {0} songs\n", songs.Count());
        var i = 0;
        foreach (var song in songs)
        {
            Console.WriteLine("{0}. {1}", ++i, song.Name);
        }
        while (true)
        {
            Console.Write("> ");
            var line = Console.ReadLine();
            if (String.IsNullOrEmpty(line)) continue;
            if (line.StartsWith("exit"))
            {
                Program.GetInstance().Ui = _previousUi;
                return;
            }
            if (line.StartsWith("select"))
            {
                line = line.Replace("select ", "");
                var song = ParseIndex(line, songs);
                if (song == null)
                {
                    Console.WriteLine("Song not found");
                    continue;
                }
                Program.GetInstance().Ui = new SongUI(this, song);
                return;
            }
            Console.WriteLine("Command {0} not found", line);
        }
    }

    private Song? ParseIndex(string line, List<Song> songs)
    {
        /*
         * converts string to int
         */
        if (!int.TryParse(line, out var index))
        {
            Console.WriteLine("{0} is not a number", line);
            return null;
        }
        /*
         * checks to prevent the list throwing range exceptions
         */
        if (index < 1 || index > songs.Count)
        {
            return null;
        }
        /*
         * get the actual index and return the selected song
         */
        return songs[index - 1];
    }
}