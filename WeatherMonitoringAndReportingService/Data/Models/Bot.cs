namespace WeatherMonitoringAndReportingService.Data.Models
{
    public class Bot
    {
        public string Message;
        public float Threshold;
        public bool IsEnabled;

        public Bot(string message, float threshold, bool isEnabled)
        {
            Message = message;
            Threshold = threshold;
            IsEnabled = isEnabled;
        }
    }
}
