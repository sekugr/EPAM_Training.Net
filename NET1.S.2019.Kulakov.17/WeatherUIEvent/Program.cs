namespace WeatherUIEvent
{
    using System;
    using WeatherSpace;

    public class Program
    {
        public static void Main(string[] args)
        {
            WeatherData wdata = new WeatherData();
            WeatherStation weatherStation = new WeatherStation();
            Console.WriteLine("Параметры погоды");
            wdata.NewWeatherEvent += weatherStation.WeatherCheckEvent;
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Статистика");
                wdata.Stop();
                weatherStation.StatisticReport();
            }

            Console.ReadKey();
        }
    }
}
