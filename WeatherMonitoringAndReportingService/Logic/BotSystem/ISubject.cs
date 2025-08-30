using WeatherMonitoringAndReportingService.Data.Models;

namespace WeatherMonitoringAndReportingService.Logic.BotSystem
{
    public interface ISubject
    {
        public void Attach(IBotObserver observer);
        public void Detach(IBotObserver observer);
        public void Notify();
        public void ProcessNewData(WeatherData weatherData);
    }
}
