namespace WeatherSpace
{
    using System;
    using System.Collections.Generic;
    using TimerClock;

    /// <summary>
    /// Генератор показателей погоды, с заданной частотой
    /// </summary>
    /// <remarks>Поддерживает работу через интерфейс и через события</remarks>
    public class WeatherData : IObservable
    {
        private int temperature = 20; // температура - от -30 до 30 - 60 значений Temperature

        private int humidity = 70; // влажность от 20% до 100% - 60 +- 40 - 80 значения Humidity

        private int pressure = 740; // давление от 730 - 760 - 30 значений Pressure

        private List<IObserver> observers;

        private TClock TimeWeatherCheck = new TClock(1000);

        /// <summary>
        /// конструктор задает частоту изменения показателей погоды по таймеру
        /// </summary>
        /// <param name="time">время в мс, частота обновления показателей погоды</param>
        public WeatherData(int time = 1000)
        {
            TimeWeatherCheck.Interval = time;
            TimeWeatherCheck.Ring += TimeWeatherCheck_Ring;
            observers = new List<IObserver>();
        }

        public event EventHandler<CheckWeatherEventArgs> NewWeatherEvent;

        public int Temperature { get => temperature; }

        public int Humidity { get => humidity; }

        public int Pressure { get => pressure; }

        public void Start()
        {
            TimeWeatherCheck.Start();
        }

        public void Stop()
        {
            TimeWeatherCheck.Stop();
        }

        // методы для работы через интерфейсы

        /// <summary>
        /// Регистрация подписчика через интерфейс
        /// </summary>
        /// <param name="observer"></param>
        public void Register(IObserver observer)
        {
            observers.Add(observer);
        }

        /// <summary>
        /// Отмена регистрации подписчика, через интерфейс
        /// </summary>
        /// <param name="observer"></param>
        public void Unregister(IObserver observer)
        {
            observers.Remove(observer);
        }

        /// <summary>
        /// Запуск методов подписчиков через интерфейс
        /// </summary>
        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer?.Update(this, new CheckWeatherEventArgs(Humidity, Pressure, Temperature));
            }
        }

        /// <summary>
        /// событие изменения показателей погоды по таймеру
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Данные о событии</param>
        private void TimeWeatherCheck_Ring(object sender, TimerEventArgs e)
        {
            NewTemperature();
            NewHumidity();
            NewPressure();
            OnCheckWeather();
        }

        /// <summary>
        /// метод запускает выполнение методов подписанных на событие
        /// </summary>
        private void OnCheckWeather()
        {
            var subscriber = NewWeatherEvent;
            subscriber?.Invoke(this, new CheckWeatherEventArgs(Humidity, Pressure, Temperature));
        }

        /// <summary>
        /// новое значение температуры
        /// </summary>
        private void NewTemperature()
        {
            temperature = new Random(DateTime.Now.Millisecond).Next(-30, 30);
        }

        /// <summary>
        /// новое значение влажности
        /// </summary>
        private void NewHumidity()
        {
            humidity = new Random(DateTime.Now.Millisecond).Next(80, 100);
        }

        /// <summary>
        /// новое значение давления
        /// </summary>
        private void NewPressure()
        {
            pressure = new Random(DateTime.Now.Millisecond).Next(730, 750);
        }
    }
}
