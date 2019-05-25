namespace WeatherSpace
{
using System;

    /// <summary>
    /// Хранит показатели погоды для передачи в событии
    /// </summary>
    public class CheckWeatherEventArgs : EventArgs
    {
        /// <summary>
        /// Класс для обмена информацией при использовании сообщений
        /// </summary>
        /// <param name="humidity">Влажность</param>
        /// <param name="pressure">Давление</param>
        /// <param name="temperature">Температура</param>
        public CheckWeatherEventArgs(int humidity, int pressure, int temperature)
        {
            Humidity = humidity;
            Pressure = pressure;
            Temperature = temperature;
        }

        public int Humidity { get; set; }

        public int Pressure { get; set; }

        public int Temperature { get; set; }
    }
}