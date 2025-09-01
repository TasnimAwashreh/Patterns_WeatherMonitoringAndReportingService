using WeatherMonitoringAndReportingService.Data.Models;
using WeatherMonitoringAndReportingService.Logic.BotSystem;

namespace WeatherMonitoringAndReportingService.Logic.Subjects
{
    public class Subject : ISubject
    {
        public WeatherData WeatherData { get; private set; }
        private readonly List<IBotObserver> _observers;

        public Subject()
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

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(WeatherData);
            }
        }

        public void ProcessNewData(WeatherData weatherData)
        {
            WeatherData = weatherData;
            Notify();
        }
    }
}
