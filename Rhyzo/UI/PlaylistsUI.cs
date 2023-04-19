using Rhyzo.Playlists;

namespace Rhyzo.UI;

public class PlaylistsUI : UI
{
    private readonly UI _previousUi;

    public PlaylistsUI(UI previousUi)
    {
        _previousUi = previousUi;
    }
    
    public void Display()
    {
        Console.WriteLine("Commands:");
        Console.WriteLine("exit");
        Console.WriteLine("create {playlist_name}");
        Console.WriteLine("remove {index}");
        Console.WriteLine("select {index}");
        var playlists = Program.GetInstance().PlaylistManager.GetPlaylists(Program.GetInstance().UserId);
        Console.WriteLine("Found {0} playlists\n", playlists.Count());
        var i = 0;
        foreach (var playlist in playlists)
        {
            Console.WriteLine("{0}. {1}", ++i, playlist.Name);
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
            if (line.StartsWith("create"))
            {
                var name = line.Replace("create ", "");
                var playlist = Program.GetInstance().PlaylistManager.CreatePlaylist(Program.GetInstance().UserId, name);
                Console.WriteLine("Created playlist {0}", playlist.Name);
                return;
            }
            if (line.StartsWith("remove"))
            {
                line = line.Replace("remove ", "");
                var playlist = ParseIndex(line, playlists);
                if (playlist == null)
                {
                    Console.WriteLine("Playlist not found");
                    continue;
                }
                Program.GetInstance().PlaylistManager.RemovePlaylist(playlist.Id);
                Console.WriteLine("Removed playlist {0}", playlist.Name);
                return;
            }
            if (line.StartsWith("select"))
            {
                line = line.Replace("select ", "");
                var playlist = ParseIndex(line, playlists);
                if (playlist == null)
                {
                    Console.WriteLine("Playlist not found");
                    continue;
                }
                Program.GetInstance().Ui = new PlaylistUI(this, playlist);
                return;
            }
            Console.WriteLine("Command {0} not found", line);
        }
    }

    private Playlist? ParseIndex(string line, List<Playlist> playlists)
    {
        // convert string naar int
        if (!int.TryParse(line, out var index))
        {
            Console.WriteLine("{0} is not a number", line);
            return null;
        }
        // Valideert voor als er range exceptions zijn
        if (index < 1 || index > playlists.Count)
        {
            return null;
        }
         // pak de daadwerkelijke index en returned de juiste playlist ervan
        return playlists[index - 1];
    }
}