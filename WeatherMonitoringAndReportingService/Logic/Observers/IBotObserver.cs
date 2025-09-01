using WeatherMonitoringAndReportingService.Data.Models;

namespace WeatherMonitoringAndReportingService.Logic.BotSystem
{
    public interface IBotObserver
    {
        void Update(WeatherData weatherData);
    }
}
