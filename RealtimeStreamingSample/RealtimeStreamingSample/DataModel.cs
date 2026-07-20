namespace RealtimeStreamingSample;

public class DataModel
{
    public DateTime Time { get; set; }
    public double Value { get; set; }

    public DataModel(DateTime time, double value)
    {
        Time = time;
        Value = value;
    }
}