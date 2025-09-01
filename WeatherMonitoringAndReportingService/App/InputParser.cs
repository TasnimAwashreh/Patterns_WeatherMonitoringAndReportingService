namespace WeatherMonitoringAndReportingService.App
{
    public static class InputParser
    {
        public static string ParseInput()
        {
            var lines = new List<string>();
            string line;

            while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
                lines.Add(line);

            string input = string.Join(Environment.NewLine, lines);
            if (input == "")
            {
                Console.WriteLine(Constants.EmptyInput);
                Environment.Exit(0);
            }
            return input;
        }
    }
}
