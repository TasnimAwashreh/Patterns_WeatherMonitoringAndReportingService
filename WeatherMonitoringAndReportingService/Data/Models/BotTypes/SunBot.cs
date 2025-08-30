using WeatherMonitoringAndReportingService.Logic.BotSystem;

namespace WeatherMonitoringAndReportingService.Data.Models.Bots
{
    public class SunBot : Bot, IBotObserver
    {
        public SunBot(string message, float threshold, bool isEnabled) : base(message, threshold, isEnabled)
        {
        }

        public void Update(ISubject subject)
        {
            var temperature = (subject as Subject).weatherData.Temperature;
            if (temperature > Threshold)
                Console.WriteLine(Message);
        }
    }
}
