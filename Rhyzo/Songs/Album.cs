namespace Rhyzo.Songs;

public class Album
{
    private readonly int _id;
    private string _name;
    private string _author;
    private readonly List<int> _songs = new List<int>();

    /// <summary>
    /// Constructor: geeft de fields de values die zijn meegegeven via de params.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="author"></param>
    public Album(int id, string name, string author)
    {
        _id = id;
        _name = name;
        _author = author;
    }

    // Getters & setters

    public int Id => _id;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string Author
    {
        get => _author;
        set => _author = value;
    }

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
    /// Voegt songs in Album
    /// </summary>
    /// <param name="songId"></param>
    public void AddSong(int songId)
    {
        _songs.Add(songId);
    }

    /// <summary>
    /// Verwijderd songs van Album
    /// </summary>
    /// <param name="songId"></param>

    public void RemoveSong(int songId)
    {
        _songs.Remove(songId);
    }
}