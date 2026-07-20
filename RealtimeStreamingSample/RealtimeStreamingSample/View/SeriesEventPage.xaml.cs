using System.Collections.ObjectModel;
using Syncfusion.Maui.Charts;

namespace RealtimeStreamingSample;

public partial class SeriesEventPage : ContentPage
{
    SeriesViewModel viewmodel;

    public SeriesEventPage()
    {
        InitializeComponent();
        viewmodel = new SeriesViewModel();

        BindingContext = viewmodel;

        Loaded += async (s, e) =>
        {
            await Task.Delay(1000);
            await LoadInitialData();
            await Task.Delay(1000);
            viewmodel.StartStreaming(series);
        };
    }

    private async Task LoadInitialData()
    {
        var rand = new Random();
        var baseTime = DateTime.Now.AddSeconds(-50);
        for (int i = 0; i < 50; i++)
        {
            var time = baseTime.AddSeconds(i);
            viewmodel.ChartData.Add(new DataModel(time, rand.Next(10, 100)));
        }
    }
}

public class SeriesViewModel
{
    public ObservableCollection<DataModel> ChartData { get; set; } = new();

    public ObservableCollection<Brush> CustomBrushes { get; set; } = new()
    {
        new SolidColorBrush(Color.FromArgb("#6ED6DE")),
        new SolidColorBrush(Color.FromArgb("#38B7C2")),
        new SolidColorBrush(Color.FromArgb("#1FA3B1")),
        new SolidColorBrush(Color.FromArgb("#168F9B")),
        new SolidColorBrush(Color.FromArgb("#168F9B")),
        new SolidColorBrush(Color.FromArgb("#1FA3B1")),
        new SolidColorBrush(Color.FromArgb("#38B7C2")),
        new SolidColorBrush(Color.FromArgb("#6ED6DE")),
    };

    Random rand = new();
    private IDispatcherTimer? _streamingTimer;

    public void StartStreaming(CartesianSeries series)
    {
        _streamingTimer = Application.Current!.Dispatcher.CreateTimer();
        _streamingTimer.Interval = TimeSpan.FromMilliseconds(250);
        _streamingTimer.Tick += (sender, e) =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                series.SuspendNotification();
                ChartData.Add(new DataModel(DateTime.Now, rand.Next(10, 100)));
                series.ResumeNotification();
            });
        };
        _streamingTimer.Start();
    }
}
