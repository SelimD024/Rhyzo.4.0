namespace Rhyzo.Users;

public class User
{
    private readonly int _id;
    private string _username;
    private string _password;
    private readonly List<int> _friends = new List<int>();
    
    public User(int id, string username, string password)
    {
        _id = id;
        _username = username;
        _password = password;
    }

    public int Id => _id;

    public string Username
    {
        get => _username;
        set => _username = value;
    }

    public string Password
    {
        get => _password;
        set => _password = value;
    }

    public void AddFriend(int userId)
    {
        _friends.Add(userId);
    }

    public void RemoveFriend(int userId)
    {
        _friends.Remove(userId);
    }

    public List<User> GetFriends()
    {
        var friends = new List<User>();
        foreach (var userId in _friends)
        {
            var user = Program.GetInstance().UserManager.GetUser(userId);
            if (user != null)
            {
                friends.Add(user);
            }
        }
        return friends;
    }
}