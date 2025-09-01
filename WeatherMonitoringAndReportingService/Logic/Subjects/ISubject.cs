using WeatherMonitoringAndReportingService.Data.Models;
using WeatherMonitoringAndReportingService.Logic.BotSystem;

namespace WeatherMonitoringAndReportingService.Logic.Subjects
{
    public interface ISubject
    {
        void Attach(IBotObserver observer);
        void Detach(IBotObserver observer);
        void Notify();
        void ProcessNewData(WeatherData weatherData);
    }
}
