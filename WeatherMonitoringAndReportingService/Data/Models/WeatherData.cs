namespace WeatherMonitoringAndReportingService.Data.Models
{
    public class WeatherData
    {
        public string Location;
        public float Temperature;
        public float Humidity;

        public WeatherData(string location, float temperature, float humidity)
        {
            Location = location;
            Temperature = temperature;
            Humidity = humidity;
        }
    }
}
