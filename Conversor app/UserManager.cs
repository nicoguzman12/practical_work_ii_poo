namespace Conversor_app;

public static class UserManager
{
    private static string filePath = Path.Combine(FileSystem.AppDataDirectory, "users.csv");

    public static List<User> LoadUsers()
    {
        var users = new List<User>();

        if (!File.Exists(filePath))
            return users;

        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
                users.Add(User.FromCsv(line));
        }

        return users;
    }

    public static void SaveUsers(List<User> users)
    {
        var lines = users.Select(u => u.ToCsv());
        File.WriteAllLines(filePath, lines);
    }

    public static bool Register(User newUser)
    {
        var users = LoadUsers();
        if (users.Any(u => u.Username == newUser.Username))
            return false;

        users.Add(newUser);
        SaveUsers(users);
        return true;
    }

    public static bool Login(string username, string password)
    {
        var users = LoadUsers();
        return users.Any(u => u.Username == username && u.Password == password);
    }

    public static User? GetUser(string username)
    {
        return LoadUsers().FirstOrDefault(u => u.Username == username);
    }

    public static void IncrementOperations(string username)
    {
        var users = LoadUsers();
        var user = users.FirstOrDefault(u => u.Username == username);
        if (user != null)
        {
            user.OperationCount++;
            SaveUsers(users);
        }
    }
}
