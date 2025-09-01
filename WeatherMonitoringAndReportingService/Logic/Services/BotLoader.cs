using Microsoft.Extensions.Configuration;
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

        public void LoadBots(ISubject subject)
        {
            var rainBot = _config.GetSection("RainBot").Get<RainBot>();
            var sunBot = _config.GetSection("SunBot").Get<SunBot>();
            var snowBot = _config.GetSection("SnowBot").Get<SnowBot>();

            if (rainBot != null && rainBot.Enabled)
                subject.Attach(rainBot);
            if (sunBot != null && sunBot.Enabled)
                subject.Attach(sunBot);
            if (snowBot != null && snowBot.Enabled)
                subject.Attach(snowBot);
        }
    }
}
