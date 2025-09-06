using WeatherMonitoringAndReportingService.Logic.Models;

namespace WeatherMonitoringAndReportingService.Logic.Observers.BotTypes
{
    public class SunBot : Bot
    {
        public float TemperatureThreshold { get; set; }

        public override void Update(WeatherData weatherData)
        {
            if (this.Enabled && weatherData.Temperature > TemperatureThreshold)
                Console.WriteLine(Message);
        }
    }
}
