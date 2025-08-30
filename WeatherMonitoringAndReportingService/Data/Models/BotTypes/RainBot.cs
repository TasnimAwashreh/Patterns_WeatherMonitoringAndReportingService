using WeatherMonitoringAndReportingService.Logic.BotSystem;

namespace WeatherMonitoringAndReportingService.Data.Models.Bots
{
    public class RainBot : Bot, IBotObserver
    {
        public RainBot(string message, float threshold, bool isEnabled) : base(message, threshold, isEnabled)
        {
        }

        public void Update(ISubject subject)
        {
            var humidity = (subject as Subject).weatherData.Humidity;
            if (humidity > Threshold)
                Console.WriteLine(Message);
        }
    }
}
