namespace WeatherUI
{
    using System;
    using WeatherSpace;

    public class Program
    {
        public static void Main(string[] args)
        {
            WeatherData wd = new WeatherData();
            WeatherStation weatherStation = new WeatherStation();
            wd.Register(weatherStation);

            // работа интерфейсов
            Console.WriteLine("Текущая погода - интерфейсы");

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                wd.Notify();
            }

            Console.WriteLine("Статистика");
            weatherStation.StatisticReport();
            Console.ReadKey();
        }
    }
}
