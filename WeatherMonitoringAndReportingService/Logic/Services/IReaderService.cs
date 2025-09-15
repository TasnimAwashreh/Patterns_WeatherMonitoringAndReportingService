using WeatherMonitoringAndReportingService.Logic.Models;
using WeatherMonitoringAndReportingService.Logic.Readers;

namespace WeatherMonitoringAndReportingService.Logic.Services
{
    public interface IReaderService
    {
        public WeatherData? ParseWeatherData(string input);
        public void SetReader(IFormatReader reader);
    }
}
