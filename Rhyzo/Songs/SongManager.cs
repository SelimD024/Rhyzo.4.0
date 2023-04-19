namespace Rhyzo.Songs;

public class SongManager
{
    // Readonly dictionary voor Song
    private readonly Dictionary<int, Song> _songs = new Dictionary<int, Song>();
    // Readonly dictionary voor Album
    private readonly Dictionary<int, Album> _albums = new Dictionary<int, Album>();
    private static int _idCounter;

    /// <summary>
    /// (Hardcoded) voegt de album instanties in de Album Dictionary
    /// </summary>
    public SongManager()
    {
        //Voegt albums toe
        _albums.Add(1, new Album(1, "Scorpion", "Drake"));
        _albums.Add(2, new Album(2, "Levensles", "Lijpe"));
        
        //Voegt songs toe in de Scorpion album (id 1)
        GetAlbum(1).AddSong(CreateSong("Talk Up", "Drake").Id);
        GetAlbum(1).AddSong(CreateSong("After Dark", "Drake").Id);
        GetAlbum(1).AddSong(CreateSong("Blue Tint", "Drake").Id);
        GetAlbum(1).AddSong(CreateSong("In My Feelings", "Drake").Id);
        
        //Voegt songs toe in de Jackpot album (id 2)
        GetAlbum(2).AddSong(CreateSong("Jackpot", "Lijpe").Id);
        GetAlbum(2).AddSong(CreateSong("Moeilijke Tijd / Blijf Bezig", "Lijpe").Id);
        GetAlbum(2).AddSong(CreateSong("Actief", "Lijpe").Id);
        GetAlbum(2).AddSong(CreateSong("Beter Dan Eerst", "Lijpe").Id);
    }

    /// <summary>
    /// Haalt de song op met de opgegeven songId (als het nummer niet gevonden wordt, returned hij null.)
    /// </summary>
    /// <param name="songId">Het ID van het nummer dat moet worden opgehaald</param>
    /// <returns></returns>
    public Song? GetSong(int songId)
    {
        _songs.TryGetValue(songId, out var song);
        return song;
    }

    /// <summary>
    /// Maakt een nieuw song aan met de params naam en auteur. Het nummer wordt toegevoegd aan Song dictionary
    /// </summary>
    /// <param name="name"></param>
    /// <param name="author"></param>
    /// <returns></returns>
    public Song CreateSong(string name, string author)
    {
        Song song = new Song(++_idCounter, name, author);
        _songs[song.Id] = song;
        return song;
    }

    /// <summary>
    /// Haalt het album op met de opgegeven albumID (als hij niet gevonden wordt returned hij null)
    /// </summary>
    /// <param name="albumId">Het ID van het nummer dat moet worden opgehaald</param>
    /// <returns></returns>
    public Album? GetAlbum(int albumId)
    {
        _albums.TryGetValue(albumId, out var album);
        return album;
    }

    /// <summary>
    /// Returned list van alle albums in de dictionary
    /// </summary>
    /// <returns>List van alle albums</returns>
    public List<Album> GetAlbums()
    {
        return new List<Album>(_albums.Values);
    }
}