using WeatherMonitoringAndReportingService.Logic.Subjects;

namespace WeatherMonitoringAndReportingService.Logic.Services
{
    public interface IBotLoader
    {
        public void LoadBots(ISubject subject);
    }
}
