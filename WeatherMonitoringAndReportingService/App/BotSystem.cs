using Microsoft.Extensions.Configuration;
using WeatherMonitoringAndReportingService.Logic.Models;
using WeatherMonitoringAndReportingService.Logic.Subjects;

namespace WeatherMonitoringAndReportingService.App
{
    public class BotSystem
    {
        private IConfiguration _config;
        private IWeatherStation _subject;

        public BotSystem(IConfiguration config, IWeatherStation subject)
        {
            _config = config;
            _subject = subject;
        }

        public void ProcessInput(WeatherData weatherData)
        {
            Console.WriteLine(Constants.ProcessingStr);
            try
            {
                if (weatherData == null) Console.WriteLine(Constants.InvalidInput);
                else _subject.ProcessNewData(weatherData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{Constants.ErrorInput}");
            }
        }
    }
}
