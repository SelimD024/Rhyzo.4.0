using Rhyzo.Songs;

namespace Rhyzo.UI;

public class AlbumsUI : UI
{
    // instantie van vorige ui, dit wordt gebruikt om terug te gaan naar de vorige selectie
    private readonly UI _previousUi;

    /// <summary>
    /// Maakt een nieuwe instance van AlbumsUI en initialiseert deze met de vorige UI
    /// </summary>
    /// <param name="previousUi"></param>
    public AlbumsUI(UI previousUi)
    {
        _previousUi = previousUi;
    }
    
    /// <summary>
    /// 
    /// </summary>

    public void Display()
    {
        Console.WriteLine("Commands:");
        Console.WriteLine("exit");
        Console.WriteLine("select {index}");
        var albums = Program.GetInstance().SongManager.GetAlbums();
        Console.WriteLine("Found {0} albums\n", albums.Count());
        var i = 0;
        foreach (var album in albums)
        {
            Console.WriteLine("{0}. {1}", ++i, album.Name);
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
                var album = ParseIndex(line, albums);
                if (album == null)
                {
                    Console.WriteLine("Album not found");
                    continue;
                }
                Program.GetInstance().Ui = new AlbumUI(this, album);
                return;
            }
            Console.WriteLine("Command {0} not found", line);
        }
    }

    private Album? ParseIndex(string line, List<Album> albums)
    {
       // Convert string naar int
        if (!int.TryParse(line, out var index))
        {
            Console.WriteLine("{0} is not a number", line);
            return null;
        }
        
         // Validatie om te kijken of List range exceptions heeft
        
        if (index < 1 || index > albums.Count)
        {
            return null;
        }
        //Pakt de index and returned de geselecteerde album
        return albums[index - 1];
    }
}