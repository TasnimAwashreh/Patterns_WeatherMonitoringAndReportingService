using WeatherMonitoringAndReportingService.Data.Models;

namespace WeatherMonitoringAndReportingService.Logic.BotSystem
{
    public class Subject : ISubject
    {
        public WeatherData weatherData { get; set; }
        private List<IBotObserver> _observers;

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
                observer.Update(this);
            }
        }

        public void ProcessNewData(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            this.Notify();
        }
    }
}
