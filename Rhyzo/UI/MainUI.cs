namespace Rhyzo.UI;

public class MainUI : UI
{

    /// <summary>
    /// Maakt de Main menu aan waarbij je kunt navigeren naar waar je naar toe wilt.
    /// </summary>
    /// <remarks>Gebruik gemaakt van <b>switch</b> waarbij die de input opvangt en execute te functies bij de juiste values </remarks>
    public void Display()
    {
        while (true)
        {
            Console.WriteLine("0. Log out");
            Console.WriteLine("1. My playlists");
            Console.WriteLine("2. My Friends");
            Console.WriteLine("3. Albums");
            Console.Write("> ");
            var line = Console.ReadLine();
            if (line == null) continue;
            switch (line)
            {
                case "0":
                {
                    Program.GetInstance().UserId = -1;
                    Program.GetInstance().Ui = new LoginUI();
                    return;
                }
                case "1":
                {
                    Program.GetInstance().Ui = new PlaylistsUI(this);
                    return;
                }
                case "2":
                {
                    Program.GetInstance().Ui = new FriendsUI(this);
                    return;
                }
                case "3":
                {
                    Program.GetInstance().Ui = new AlbumsUI(this);
                    return;
                }
                default:
                {
                    Console.WriteLine("Invalid selection");
                    break;
                }
            }
        }
    }
}