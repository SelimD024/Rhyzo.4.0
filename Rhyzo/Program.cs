// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using Rhyzo.Playlists;
using Rhyzo.Songs;
using Rhyzo.UI;
using Rhyzo.Users;


namespace Rhyzo;

class Program
{

    
    // static variabel slaat instantie van  Program op
    private static Program? _instance;
    private readonly UserManager _userManager;
    private readonly PlaylistManager _playlistManager;
    private readonly SongManager _songManager;
    private UI.UI? _ui;
    private int _userId = -1;

    /// <summary>
    /// Constructor initalizeert de manager classes
    /// </summary>
    public Program()
    {
        _userManager = new UserManager();
        _playlistManager = new PlaylistManager();
        _songManager = new SongManager();


    }


    /// <summary>
    /// Main bevat de Start() functie waarmee we de programma kunnen runnen
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        GetInstance().Start();
    }

    /// <summary>
    /// Valideert of instance variabel al is geinializeerd
    /// </summary>
    /// <returns>Instance van program</returns>
    public static Program GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Program();
        }
        return _instance;
    }

    /// <summary>
    /// Een infinte loop die constant de ui.display() aanroept.
    /// </summary>
    private void Start()
    {

        while (true)
        {


            // Kijkt of UI null anders wordt LoginUI() geroepen.
            _ui ??= new LoginUI();
            _ui.Display();
        }
    }


    // getters en setters

    public UI.UI Ui
    {
        set => _ui = value;
    }

    public UserManager UserManager => _userManager;

    public PlaylistManager PlaylistManager => _playlistManager;

    public SongManager SongManager => _songManager;
    
    public int UserId
    {
        get => _userId;
        set => _userId = value;
    }
}