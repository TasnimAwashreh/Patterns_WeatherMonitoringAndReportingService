using WeatherMonitoringAndReportingService.Logic.Models;

namespace WeatherMonitoringAndReportingService.Logic.BotSystem
{
    public interface IBotObserver
    {
        void Update(WeatherData weatherData);
    }
}
