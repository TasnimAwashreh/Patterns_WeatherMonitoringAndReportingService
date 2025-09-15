using Microsoft.Extensions.Configuration;
using WeatherMonitoringAndReportingService.Logic.DTOs;
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
            var rainBotConfig = DummyData.TestRainBot;
            var sunBotConfig = DummyData.TestSunBot;
            var snowBotConfig = DummyData.TestSnowBot;

            var fakeAppSettings = new Dictionary<string, string>
            {
                ["RainBot:Message"] = rainBotConfig.Message,
                ["RainBot:Enabled"] = rainBotConfig.Enabled.ToString(),
                ["RainBot:HumidityThreshold"] = rainBotConfig.HumidityThreshold.ToString(),

                ["SunBot:Message"] = sunBotConfig.Message,
                ["SunBot:Enabled"] = sunBotConfig.Enabled.ToString(),
                ["SunBot:TemperatureThreshold"] = sunBotConfig.TemperatureThreshold.ToString(),

                ["SnowBot:Message"] = snowBotConfig.Message,
                ["SnowBot:Enabled"] = snowBotConfig.Enabled.ToString(),
                ["SnowBot:TemperatureThreshold"] = snowBotConfig.TemperatureThreshold.ToString()
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
