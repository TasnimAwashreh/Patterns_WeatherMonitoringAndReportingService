using Microsoft.Extensions.Configuration;
using WeatherMonitoringAndReportingService.Logic.Readers;
using WeatherMonitoringAndReportingService.Logic.Subjects;

namespace WeatherMonitoringAndReportingService.App
{
    public class BotSystem
    {
        private IConfiguration _config;
        private ISubject _subject;

        public BotSystem(IConfiguration config, ISubject subject)
        {
            _config = config;
            _subject = subject;
        }

        public void ProcessInput(IFormatReader reader, string input)
        {
            Console.WriteLine(Constants.ProcessingStr);
            try
            {
                var data = reader.ReadWeatherData(input);

                if (data == null) Console.WriteLine(Constants.InvalidInput);
                else _subject.ProcessNewData(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{Constants.ErrorInput}");
            }

        }
    }
}
