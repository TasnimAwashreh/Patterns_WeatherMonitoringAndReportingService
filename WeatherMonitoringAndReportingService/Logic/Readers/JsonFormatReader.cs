using System.Text.Json;
using WeatherMonitoringAndReportingService.Logic.Models;

namespace WeatherMonitoringAndReportingService.Logic.Readers
{
    public class JsonFormatReader : IFormatReader
    {
        public WeatherData? ReadWeatherData(string userInput)
        {
            try
            {
                return JsonSerializer.Deserialize<WeatherData>(userInput);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
