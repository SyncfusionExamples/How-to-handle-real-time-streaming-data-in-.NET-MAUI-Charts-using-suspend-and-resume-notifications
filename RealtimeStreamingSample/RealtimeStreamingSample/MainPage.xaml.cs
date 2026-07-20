namespace RealtimeStreamingSample;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void ChartButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ChartEventPage());
    }

    private async void SeriesButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SeriesEventPage());
    }
}
