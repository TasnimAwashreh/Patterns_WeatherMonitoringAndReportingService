using Microsoft.Extensions.Configuration;
using WeatherMonitoringAndReportingService.Logic.DTOs;
using WeatherMonitoringAndReportingService.Logic.Observers.BotTypes;
using WeatherMonitoringAndReportingService.Logic.Subjects;

namespace WeatherMonitoringAndReportingService.Logic.Services
{
    public class BotLoader : IBotLoader
    {
        private readonly IConfiguration _config;

        public BotLoader(IConfiguration config)
        {
            _config = config;
        }

        public void LoadBots(IWeatherStation subject)
        {
            var rainBotDto = _config.GetSection("RainBot").Get<RainBotConfig>();
            var sunBotDto = _config.GetSection("SunBot").Get<SunBotConfig>();
            var snowBotDto = _config.GetSection("SnowBot").Get<SnowBotConfig>();

            var rainBot = new RainBot { Message = rainBotDto.Message, Enabled = rainBotDto.Enabled, 
                HumidityThreshold = rainBotDto .HumidityThreshold};
            var sunBot = new SunBot { Message = sunBotDto.Message, Enabled = sunBotDto.Enabled, 
                TemperatureThreshold = sunBotDto .TemperatureThreshold};
            var snowBot = new SnowBot { Message = snowBotDto.Message, Enabled = snowBotDto.Enabled, 
                TemperatureThreshold = snowBotDto .TemperatureThreshold};

            if (rainBot != null && rainBot.Enabled)
                subject.Attach(rainBot);
            if (sunBot != null && sunBot.Enabled)
                subject.Attach(sunBot);
            if (snowBot != null && snowBot.Enabled)
                subject.Attach(snowBot);
        }
    }
}
