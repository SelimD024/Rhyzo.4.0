namespace Rhyzo.Songs;

public class Song
{
    private readonly int _id;
    private string _name;
    private string _author;

    /// <summary>
    /// Constructor: geeft de fields de values van de params die zijn meegegeven.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="author"></param>
    public Song(int id, string name, string author)
    {
        _id = id;
        _name = name;
        _author = author;
    }

    /// getters setters

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
}