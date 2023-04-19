using Rhyzo.Users;

namespace Rhyzo.UI;

public class FriendsUI : UI
{
    
    private readonly UI _previousUi;

    public FriendsUI(UI previousUi)
    {
        _previousUi = previousUi;
    }
    
    public void Display()
    {
        var user = Program.GetInstance().UserManager.GetUser(Program.GetInstance().UserId);
        if (user != null)
        {
            Console.WriteLine("Your friends");
            var friends = user.GetFriends();
            Console.WriteLine("Your friends ({0})", friends.Count);
            var i = 0;
            foreach (var friend in friends)
            {
                Console.WriteLine("{0}. {1}", ++i, friend.Username);
            }
        }
        Program.GetInstance().Ui = _previousUi;
    }
}