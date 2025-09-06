using WeatherMonitoringAndReportingService.Logic.BotSystem;
using WeatherMonitoringAndReportingService.Logic.Models;

namespace WeatherMonitoringAndReportingService.Logic.Observers
{
    public abstract class Bot : IBotObserver
    {
        public string Message { get; set; }
        public bool Enabled { get; set; }

        public abstract void Update(WeatherData weatherData);
    }
}
