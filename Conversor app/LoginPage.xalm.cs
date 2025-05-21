namespace Conversor_app;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

private async void OnLoginClicked(object sender, EventArgs e)
{
    string username = UsernameEntry.Text;
    string password = PasswordEntry.Text;

    if (UserManager.Login(username, password))
    {
        Session.CurrentUsername = username; // ← Guarda sesión
        await Shell.Current.GoToAsync("conversor");
    }
    else
    {
        await DisplayAlert("Error", "Invalid username or password", "OK");
    }
}


    private async void OnRegisterClicked(object sender, EventArgs e) //async to indicate it will perform asynchronous operations
    {
        await Shell.Current.GoToAsync("register"); //await ensures that each alert waits for users response
    }

}
