namespace Conversor_app;

public partial class ConversorPage : ContentPage
{
    private Converter converter;
    private Operations ops;

    public ConversorPage()
    {
        InitializeComponent();

        converter = new Converter();
        ops = new Operations(";");

        for (int i = 0; i < converter.GetNumberOfOperations(); i++)
        {
            ConversionPicker.Items.Add(converter.GetOperation(i).GetName());
        }
    }

    private async void OnConvertClicked(object sender, EventArgs e)
    {
        string input = InputEntry.Text;
        int selectedIndex = ConversionPicker.SelectedIndex;

        if (selectedIndex == -1)
        {
            await DisplayAlert("Error", "Please select a conversion.", "OK");
            return;
        }

        try
        {
            string output = converter.PerformConversion(selectedIndex + 1, input);

            ResultLabel.Text = output;

            //storage info in csv
            ops.AddOperation(input, output, converter.GetOperation(selectedIndex).GetName(), "0", "");
            ops.SaveOperationsToFile(Path.Combine(FileSystem.AppDataDirectory, "output.csv"));

            //increment operations to user
            UserManager.IncrementOperations(Session.CurrentUsername);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Invalid input", ex.Message, "OK");
            InputEntry.Text = "";
        }
    }
}
