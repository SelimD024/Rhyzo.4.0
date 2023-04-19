namespace Rhyzo.Users;

public class UserManager
{
    private readonly Dictionary<int, User> _users = new Dictionary<int, User>();
    private static int _idCounter;
    
    public UserManager()
    {
        CreateUser("Selim", "123");
        CreateUser("Test", "123");
    }

    /// <summary>
    /// Maakt een user aan en voegt het toe aan de _user dictionary en user.id als key
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    public void CreateUser(string username, string password)
    {
        var user = new User(++_idCounter, username, password);
        _users[user.Id] = user;
    }

    public User? GetUser(int id)
    {
        _users.TryGetValue(id, out var user);
        return user;
    }

    public User? GetUser(string username)
    {
        foreach(var user in _users.Values)
        {
            if(user.Username.ToLower() == username.ToLower())
            {
                return user;
            }
        }
        return null;
    }
}