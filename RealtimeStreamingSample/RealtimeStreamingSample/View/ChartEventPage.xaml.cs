using Syncfusion.Maui.Charts;
using System.Collections.ObjectModel;

namespace RealtimeStreamingSample;

public partial class ChartEventPage : ContentPage
{
    ChartViewModel viewmodel;

    public ChartEventPage()
    {
        InitializeComponent();
        viewmodel = new ChartViewModel();

        BindingContext = viewmodel;

        Loaded += async (s, e) =>
        {
            await Task.Delay(1000);
            await LoadInitialData();
            await Task.Delay(1000);
            viewmodel.StartStreaming(Chart);
        };
    }

    private async Task LoadInitialData()
    {
        var rand = new Random();
        var baseTime = DateTime.Now.AddSeconds(-50);

        for (int i = 0; i < 50; i++)
        {
            var time = baseTime.AddSeconds(i);
            viewmodel.ChartData.Add(new DataModel(time, rand.Next(100, 180)));
            viewmodel.ChartData1.Add(new DataModel(time, rand.Next(60, 100)));
            viewmodel.ChartData2.Add(new DataModel(time, rand.Next(21, 50)));
        }
    }
}

public class ChartViewModel
{
    public ObservableCollection<DataModel> ChartData { get; set; } = new();
    public ObservableCollection<DataModel> ChartData1 { get; set; } = new();
    public ObservableCollection<DataModel> ChartData2 { get; set; } = new();

    public ObservableCollection<Brush> CustomBrushes { get; set; } = new()
    {
        new SolidColorBrush(Color.FromArgb("#6ED6DE")),
        new SolidColorBrush(Color.FromArgb("#38B7C2")),
        new SolidColorBrush(Color.FromArgb("#1FA3B1")),
    };

    Random rand = new();
    private IDispatcherTimer? _streamingTimer;

    public void StartStreaming(SfCartesianChart chart)
    {
        _streamingTimer = Application.Current!.Dispatcher.CreateTimer();
        _streamingTimer.Interval = TimeSpan.FromMilliseconds(250);
        _streamingTimer.Tick += (sender, e) =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                chart.SuspendSeriesNotification();

                var time = DateTime.Now;
                ChartData.Add(new DataModel(time, rand.Next(100, 180)));
                ChartData1.Add(new DataModel(time, rand.Next(60, 100)));
                ChartData2.Add(new DataModel(time, rand.Next(21, 50)));

                chart.ResumeSeriesNotification();
            });
        };
        _streamingTimer.Start();
    }
}
