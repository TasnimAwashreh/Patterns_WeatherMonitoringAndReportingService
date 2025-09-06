using WeatherMonitoringAndReportingService.Logic.Models;

namespace WeatherMonitoringAndReportingService.Logic.Readers
{
    public interface IFormatReader
    {
        public WeatherData? ReadWeatherData(string userInput);
    }
}
