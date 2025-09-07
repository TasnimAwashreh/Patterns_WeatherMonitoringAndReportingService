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

        public void ChooseReader(string input)
        {
            input = input.Trim();
            if (input[0].CompareTo('<') == 0)
                _reader = new XMLFormatReader();
            else
                _reader = new JsonFormatReader();
        }

        public WeatherData? ParseWeatherData(string input)
        {
            return _reader.ParseWeatherData(input);
        }
    }
}
