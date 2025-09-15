using Moq;
using WeatherMonitoringAndReportingService.Logic.Models;
using WeatherMonitoringAndReportingService.Logic.Readers;
using WeatherMonitoringAndReportingService.Logic.Services;

namespace WMRS.Tests.Tests
{
    public class ReaderTesting
    {
        [Fact]
        public void ChooseReader_WithXML_ShouldSetToXMLFormatReader()
        {
            //Arrange
            string xmlUserInput = DummyData.XMLFormat;
            var mockReader = new Mock<IFormatReader>();
            var service = new ReaderService(mockReader.Object);

            service.ChooseReader(xmlUserInput);

            //Act
            WeatherData? weatherData = service.ParseWeatherData(xmlUserInput);

            //Assert
            Assert.NotNull(weatherData);
        }

        [Fact]
        public void ChooseReader_WithJSON_ShouldSetToJSONFormatReader()
        {
            //Arrange
            string jsonUserInput = DummyData.JSONFormat;
            var mockReader = new Mock<IFormatReader>();
            var service = new ReaderService(mockReader.Object);

            service.ChooseReader(jsonUserInput);

            //Act
            WeatherData? weatherData = service.ParseWeatherData(jsonUserInput);

            //Assert
            Assert.NotNull(weatherData);
        }
    }
}
