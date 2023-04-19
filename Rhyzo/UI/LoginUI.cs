using Rhyzo.Users;

namespace Rhyzo.UI;

public class LoginUI : UI
{

    public void Display()
    {
        User? user = null;
        var isLoggedIn = false;
        while (!isLoggedIn)
        {
            Console.WriteLine("Enter your username");
            Console.Write("> ");
            string? line = Console.ReadLine();
            if(line == null) continue;
            user = Program.GetInstance().UserManager.GetUser(line);
            if (user == null)
            {
                Console.WriteLine("User {0} not found", line);
                continue;
            }
            while (true)
            {
                Console.WriteLine("Enter your password");
                Console.Write("> ");
                line = Console.ReadLine();
                if (String.IsNullOrEmpty(line))
                {
                    user = null;
                    break;
                }
                if (user.Password == line)
                {
                    isLoggedIn = true;
                    break;
                }
                Console.WriteLine("Invalid password for user {0}", user.Username);
            }
        }
        if (user == null) return;
        Console.WriteLine("Logged in as user: {0}", user.Username);
        Program.GetInstance().UserId = user.Id;
        Program.GetInstance().Ui = new MainUI();
    }
}