namespace Conversor_app;

public partial class UserInfoPage : ContentPage
{
    public UserInfoPage()
    {
        InitializeComponent();
        LoadUserInfo();
        Routing.RegisterRoute("userinfo", typeof(UserInfoPage));
    }

    private void LoadUserInfo()
    {
        string username = Session.CurrentUsername;
        var user = UserManager.GetUser(username);

        if (user != null)
        {
            NameLabel.Text = user.Name;
            UsernameLabel.Text = user.Username;
            PasswordLabel.Text = user.Password;
            OperationCountLabel.Text = user.OperationCount.ToString();
        }
        else
        {
            DisplayAlert("Error", "User not found", "OK");
        }
    }
}
