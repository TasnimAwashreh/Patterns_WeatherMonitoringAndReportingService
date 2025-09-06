using System.Xml.Serialization;
using WeatherMonitoringAndReportingService.Logic.Models;

namespace WeatherMonitoringAndReportingService.Logic.Readers
{
    public class XMLFormatReader : IFormatReader
    {
        public WeatherData? ReadWeatherData(string userInput)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(WeatherData));
                using var reader = new StringReader(userInput);
                WeatherData data = (WeatherData)serializer.Deserialize(reader);
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
