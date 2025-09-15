using WeatherMonitoringAndReportingService.Logic.Readers;

namespace WeatherMonitoringAndReportingService.App
{
    public class FormatReader
    {
        public static IFormatReader ChooseReader(string input)
        {
            input = input.Trim();
            if (input[0].CompareTo('<') == 0)
                return new XMLFormatReader();
            else
                return new JsonFormatReader();
        }
    }
}
