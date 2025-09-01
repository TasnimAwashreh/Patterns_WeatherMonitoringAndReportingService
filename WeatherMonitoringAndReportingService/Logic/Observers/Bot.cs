using WeatherMonitoringAndReportingService.Data.Models;
using WeatherMonitoringAndReportingService.Logic.BotSystem;

namespace WeatherMonitoringAndReportingService.Logic.Observers
{
    public abstract class Bot : IBotObserver
    {
        public string Message { get; set; }
        public bool Enabled { get; set; }

        public abstract void Update(WeatherData weatherData);
    }
}
