using Rhyzo.Songs;

namespace Rhyzo.UI;

public class AlbumUI : UI
{
    private readonly UI _previousUi;
    private readonly Album _album;

    public AlbumUI(UI previousUi, Album album)
    {
        _previousUi = previousUi;
        _album = album;
    }
    
    public void Display()
    {
        Console.WriteLine("Album: {0}", _album.Name);
        Console.WriteLine("Commands:");
        Console.WriteLine("exit");
        Console.WriteLine("playlist add {name}");
        Console.WriteLine("select {index}");
        var songs = _album.GetSongs();
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
            if (line.StartsWith("playlist add"))
            {
                line = line.Replace("playlist add ", "");
                var playlist = Program.GetInstance().PlaylistManager.GetPlaylist(Program.GetInstance().UserId, line);
                if (playlist == null)
                {
                    Console.WriteLine("Playlist {0} not found", line);
                    continue;
                }
                int count = 0;
                foreach (var song in _album.GetSongs())
                {
                    if (playlist.HasSong(song.Id)) continue;
                    playlist.AddSong(song.Id);
                    count++;
                }
                Console.WriteLine("Added {0} songs to playlist {1}", count, playlist.Name);
                continue;
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
        // Convert string naar int
        if (!int.TryParse(line, out var index))
        {
            Console.WriteLine("{0} is not a number", line);
            return null;
        }
        // Validatie om te kijken of er range exceptions zijn
        if (index < 1 || index > songs.Count)
        {
            return null;
        }
      // Pakt de index en returned de juiste song
        return songs[index - 1];
    }
}