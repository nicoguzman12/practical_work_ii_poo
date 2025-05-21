namespace Conversor_app;

public class User
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int OperationCount { get; set; }

    public string ToCsv()
    {
        return $"{Name},{Username},{Password},{OperationCount}";
    }

    public static User FromCsv(string line)
    {
        var parts = line.Split(',');

        return new User
        {
            Name = parts[0],
            Username = parts[1],
            Password = parts[2],
            OperationCount = int.Parse(parts[3])
        };
    }
}
