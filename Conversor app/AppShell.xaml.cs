namespace Conversor_app;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
	}
	public AppShell()
	{
    InitializeComponent();
    Routing.RegisterRoute("register", typeof(RegisterPage));
    Routing.RegisterRoute("conversor", typeof(ConversorPage));
    Routing.RegisterRoute("userinfo", typeof(UserInfoPage));
	}

}
