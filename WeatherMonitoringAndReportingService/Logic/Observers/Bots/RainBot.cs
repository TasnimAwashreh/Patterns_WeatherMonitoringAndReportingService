using WeatherMonitoringAndReportingService.Data.Models;

namespace WeatherMonitoringAndReportingService.Logic.Observers.BotTypes
{
    public class RainBot : Bot
    {
        public float HumidityThreshold { get; set; }

        public override void Update(WeatherData weatherData)
        {
            if (weatherData.Humidity > HumidityThreshold)
                Console.WriteLine(Message);
        }
    }
}
