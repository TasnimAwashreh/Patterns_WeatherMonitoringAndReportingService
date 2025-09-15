using WeatherMonitoringAndReportingService.Logic.BotSystem;
using WeatherMonitoringAndReportingService.Logic.Models;

namespace WeatherMonitoringAndReportingService.Logic.Subjects
{
    public class WeatherStation : IWeatherStation
    {
        public WeatherData WeatherData { get; private set; }
        private readonly List<IBotObserver> _observers;

        public WeatherStation()
        {
            _observers = new List<IBotObserver>();
        }

        public void Attach(IBotObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IBotObserver observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(WeatherData);
            }
        }

        public IReadOnlyList<IBotObserver> GetObservers()
        {
            return _observers;
        }

        public void ProcessNewData(WeatherData weatherData)
        {
            WeatherData = weatherData;
            Notify();
        }
    }
}
