﻿namespace Conversor_app;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new LoginShell();
	}
}
