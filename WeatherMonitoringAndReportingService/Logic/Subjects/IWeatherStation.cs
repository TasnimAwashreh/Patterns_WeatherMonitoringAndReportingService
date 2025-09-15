using WeatherMonitoringAndReportingService.Logic.BotSystem;
using WeatherMonitoringAndReportingService.Logic.Models;

namespace WeatherMonitoringAndReportingService.Logic.Subjects
{
    public interface IWeatherStation
    {
        void Attach(IBotObserver observer);
        void Detach(IBotObserver observer);
        void ProcessNewData(WeatherData weatherData);
    }
}
