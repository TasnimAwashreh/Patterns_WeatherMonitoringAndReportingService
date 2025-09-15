using WeatherMonitoringAndReportingService.Logic.Models;

namespace WeatherMonitoringAndReportingService.Logic.Observers.BotTypes
{
    public class RainBot : Bot
    {
        public float HumidityThreshold { get; set; }

        public override void Update(WeatherData weatherData)
        {
            if (this.Enabled && weatherData.Humidity > HumidityThreshold)
                Console.WriteLine(Message);
        }
    }
}
