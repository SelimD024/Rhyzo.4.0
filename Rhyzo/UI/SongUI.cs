using Rhyzo.Songs;

namespace Rhyzo.UI;

public class SongUI : UI
{
    
    private readonly UI _previousUi;

    public readonly Song _song;

    public SongUI(UI previousUi, Song song)
    {
        _previousUi = previousUi;
        _song = song;
    }

    public void Display()
    {
        Console.WriteLine("Song: {0} - {1}", _song.Author, _song.Name);
        Console.WriteLine("exit");
        Console.WriteLine("play");
        Console.WriteLine("resume");
        Console.WriteLine("stop");
        Console.WriteLine("playlist add/remove");
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
            if (line == "play")
            {
                Console.WriteLine("Song playing");
                continue;
            }
            if (line == "resume")
            {
                Console.WriteLine("Song resumed");
                continue;
            }
            if (line == "stop")
            {
                Console.WriteLine("Song stopped");
                continue;
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

                if (playlist.HasSong(_song.Id))
                {
                    Console.WriteLine("Playlist {0} has this song already", playlist.Name);
                    continue;
                }
                playlist.AddSong(_song.Id);
                Console.WriteLine("Song added to playlist {0}", playlist.Name);
                continue;
            }
            if (line.StartsWith("playlist remove"))
            {
                line = line.Replace("playlist remove ", "");
                var playlist = Program.GetInstance().PlaylistManager.GetPlaylist(Program.GetInstance().UserId, line);
                if (playlist == null)
                {
                    Console.WriteLine("Playlist {0} not found", line);
                    continue;
                }
                playlist.RemoveSong(_song.Id);
                Console.WriteLine("Song removed from playlist {0}", playlist.Name);
                continue;
            }
            Console.WriteLine("Command {0} not found", line);
        }
    }
}