namespace WeatherMonitoringAndReportingService.Logic.Readers
{
    public static class ChooseFormatReader
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
