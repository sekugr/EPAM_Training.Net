namespace WeatherSpace
{
    using System;
    using System.Collections.Generic;

    public class WeatherStation : IObserver
    {
        private List<string> statistics;

        private string curentWeather;

        public WeatherStation()
        {
            this.statistics = new List<string>();
        }

        /// <summary>
        /// Вывод текущих показателей погоды
        /// </summary>
        public void CurrentConditionsReport()
        {
            Console.WriteLine(curentWeather);
        }

        /// <summary>
        /// Статистика показателей погоды
        /// </summary>
        public void StatisticReport()
        {
            foreach (var item in statistics)
            {
                Console.WriteLine(item);
            }
        }

        // метод для подписки на событие измерения погоды
        public void WeatherCheckEvent(object sender, CheckWeatherEventArgs e)
        {
            curentWeather = $"{DateTime.Now.ToLongTimeString()} { WeatherCube.GetWeather(e.Pressure, e.Temperature, e.Humidity)}";
            statistics.Add(curentWeather);
            CurrentConditionsReport();
        }

        // метод интерфейса для выполнения после запроса данных о погоде
        public void Update(IObservable sender, EventArgs info)
        {
            CheckWeatherEventArgs e = info as CheckWeatherEventArgs;
            curentWeather = $"{DateTime.Now.ToLongTimeString()} { WeatherCube.GetWeather(e.Pressure, e.Temperature, e.Humidity)}";
            statistics.Add(curentWeather);
            CurrentConditionsReport();
        }
    }
}
