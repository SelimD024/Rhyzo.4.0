namespace Rhyzo.Playlists;

public class PlaylistManager
{

    // Dictionary (list met keys) voor Playlist
    private readonly Dictionary<int, Playlist> _playlists = new Dictionary<int, Playlist>();
    private static int _idCounter;

    /// <summary>
    /// Maakt een nieuwe Playlist aan (maakt een nieuwe instantie aan en voegt het toe aan de Playlist dictionary
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="name"></param>
    /// <returns>playlist</returns>
    public Playlist CreatePlaylist(int userId, string name)
    {
        Playlist playlist = new Playlist(++_idCounter, name, userId);
        _playlists.Add(playlist.Id, playlist);
        return playlist;
    }

    /// <summary>
    /// Pakt playlist van de meegegeven naam van de user
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="playlistName"></param>
    /// <returns>Playlist</returns>
    public Playlist? GetPlaylist(int userId, string playlistName)
    {
        foreach (var playlist in GetPlaylists(userId))
        {
            if (playlist.Name.ToLower() == playlistName.ToLower())
            {
                return playlist;
            }
        }
        return null;
    }

    /// <summary>
    /// Maakt een nieuwe List instantie aan van Playlist en kijkt of de parameter overeenkomt met de userID om de playlist in de juiste user instantie toe te voegen.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Playlists</returns>
    public List<Playlist> GetPlaylists(int userId)
    {
        List<Playlist> playlists = new List<Playlist>();
        foreach (var playlist in _playlists.Values)
        {
            if (playlist.UserId == userId)
            {
                playlists.Add(playlist);
            }
        }
        return playlists;
    }

    /// <summary>
    /// Verwijderd playlist
    /// </summary>
    /// <param name="playlistId"></param>
    public void RemovePlaylist(int playlistId)
    {
        _playlists.Remove(playlistId);
    }
}