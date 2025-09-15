using WeatherMonitoringAndReportingService.Logic.DTOs;

namespace WMRS.Tests
{
    public class DummyData
    {
        public static string XMLFormat =
                       """
                            <WeatherData>
                              <Location> City Name</Location>
                              <Temperature>23.0</Temperature>
                              <Humidity>85.0</Humidity>
                            </WeatherData>
                        """;

        public static string JSONFormat =
                         """
                            {
                              "Location": "City Name",
                              "Temperature": 23.0,
                              "Humidity": 85.0
                            }
                        """;

        public static RainBotConfig TestRainBot = new RainBotConfig { Message = "Rainy Day!", Enabled = true, HumidityThreshold = 30f};
        public static SunBotConfig TestSunBot = new SunBotConfig { Message = "Sunny Day!", Enabled = false, TemperatureThreshold = 40f};
        public static SnowBotConfig TestSnowBot = new SnowBotConfig { Message = "Snowy Day!", Enabled = true, TemperatureThreshold = 10f};
    }
}
