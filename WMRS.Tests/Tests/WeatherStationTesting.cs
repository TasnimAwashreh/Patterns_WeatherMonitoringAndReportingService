using Moq;
using WeatherMonitoringAndReportingService.Logic.BotSystem;
using WeatherMonitoringAndReportingService.Logic.Models;
using WeatherMonitoringAndReportingService.Logic.Subjects;

namespace WMRS.Tests.Tests
{
    public class WeatherStationTesting
    {
        [Fact]
        public void AttachObserver_WithValidObserver_ShouldAttachObserver()
        {
            var station = new WeatherStation();
            var mockObserver = new Mock<IBotObserver>();

            station.Attach(mockObserver.Object);

            Assert.Single(station.GetObservers());
            Assert.Contains(mockObserver.Object, station.GetObservers());
        }

        [Fact]
        public void DetatchObserver_WithValidObserver_ShouldRemoveObserver()
        {
            var station = new WeatherStation();
            var mockObserver = new Mock<IBotObserver>();
            station.Attach(mockObserver.Object);
            int initialObserverCount = station.GetObservers().Count();

            station.Detach(mockObserver.Object);

            int finalObserverCount = station.GetObservers().Count();
            Assert.Equal(initialObserverCount, finalObserverCount + 1);
        }

        [Fact]
        public void ProcessData_WithValidWeatherData_ShouldNotifyAllObservers()
        {
            //Arrange
            var weatherData = new WeatherData("Ramallah", 30, 35);
            var station = new WeatherStation();
            var mockRainBot = new Mock<IBotObserver>();
            var mockSnowBot = new Mock<IBotObserver>();

            station.Attach(mockRainBot.Object);
            station.Attach(mockSnowBot.Object);

            //Act
            station.ProcessNewData(weatherData);

            //Assert
            mockRainBot.Verify(b => b.Update(weatherData), Times.Once);
            mockSnowBot.Verify(b => b.Update(weatherData), Times.Once);
        }
    }
}