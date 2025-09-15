using WeatherMonitoringAndReportingService.Logic.Models;
using WeatherMonitoringAndReportingService.Logic.Readers;

namespace WeatherMonitoringAndReportingService.Logic.Services
{
    public class ReaderService : IReaderService
    {
        private IFormatReader _reader;

        public ReaderService(IFormatReader reader)
        {
            _reader = reader;
        }

        public void SetReader(IFormatReader reader)
        {
            _reader = reader;
        }

        public WeatherData? ParseWeatherData(string input)
        {
            return _reader.ParseWeatherData(input);
        }
    }
}
