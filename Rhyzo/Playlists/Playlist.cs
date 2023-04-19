using Rhyzo.Songs;

namespace Rhyzo.Playlists;

/// <summary>
/// 
public class Playlist
{
    private readonly int _id;
    private string _name;
    private readonly int _userId;
    private readonly List<int> _songs = new List<int>();

    /// <summary>
    /// Zet de values van de private fields naar de waardes die worden meegegeven via de params
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="userId"></param>
    public Playlist(int id, string name, int userId)
    {
        _id = id;
        _name = name;
        _userId = userId;
    }

    public int Id => _id;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public int UserId => _userId;

    /// <summary>
    /// Convert de id's naar objecten
    /// </summary>
    /// <returns>List songs</returns>
    public List<Song> GetSongs()
    {
        var songs = new List<Song>();
        foreach (var songId in _songs)
        {
            var song = Program.GetInstance().SongManager.GetSong(songId);
            if (song != null)
            {
                songs.Add(song);
            }
        }
        return songs;
    }

    /// <summary>
    /// Voegt song aan playlist
    /// </summary>
    /// <param name="songId"></param>
    public void AddSong(int songId)
    {
        _songs.Add(songId);
    }

    /// <summary>
    /// Verwijderd song van playlist
    /// </summary>
    /// <param name="songId"></param>
    public void RemoveSong(int songId)
    {
        _songs.Remove(songId);
    }

    /// <summary>
    /// Kijkt of de song in de playlist zit
    /// </summary>
    /// <param name="songId"></param>
    /// <returns>Bool</returns>
    public bool HasSong(int songId)
    {
        return _songs.Contains(songId);
    }
}