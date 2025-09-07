using WeatherMonitoringAndReportingService.Logic.Models;

namespace WeatherMonitoringAndReportingService.Logic.Services
{
    public interface IReaderService
    {
        public WeatherData? ParseWeatherData(string input);
        public void ChooseReader(string input);
    }
}
