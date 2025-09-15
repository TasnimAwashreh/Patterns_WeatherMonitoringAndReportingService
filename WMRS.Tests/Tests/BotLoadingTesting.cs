using Microsoft.Extensions.Configuration;
using WeatherMonitoringAndReportingService.Logic.Services;
using WeatherMonitoringAndReportingService.Logic.Subjects;

namespace WMRS.Tests.Tests
{
    public class BotLoadingTesting
    {
        public BotLoadingTesting()
        {

        }

        [Fact]
        public void LoadBots_ShouldAttachEnabledBots()
        {
            int initialBotsCount = 3;
            var rainBotDTO = DummyData.TestRainBot;
            var sunBotDTO = DummyData.TestSunBot;
            var snowBotDTO = DummyData.TestSnowBot;

            var fakeAppSettings = new Dictionary<string, string>
            {
                ["RainBot:Message"] = rainBotDTO.Message,
                ["RainBot:Enabled"] = rainBotDTO.Enabled.ToString(),
                ["RainBot:HumidityThreshold"] = rainBotDTO.HumidityThreshold.ToString(),

                ["SunBot:Message"] = sunBotDTO.Message,
                ["SunBot:Enabled"] = sunBotDTO.Enabled.ToString(),
                ["SunBot:TemperatureThreshold"] = sunBotDTO.TemperatureThreshold.ToString(),

                ["SnowBot:Message"] = snowBotDTO.Message,
                ["SnowBot:Enabled"] = snowBotDTO.Enabled.ToString(),
                ["SnowBot:TemperatureThreshold"] = snowBotDTO.TemperatureThreshold.ToString()
            };

            IConfiguration config =
                new ConfigurationBuilder()
                  .AddInMemoryCollection(fakeAppSettings)
                  .Build();

            var station = new WeatherStation();
            var loader = new BotLoader(config);

            //Act
            loader.LoadBots(station);

            //Assert
            int actualBotsCount = station.GetObservers().Count();
            Assert.Equal(3, actualBotsCount);
        }
    }
}
