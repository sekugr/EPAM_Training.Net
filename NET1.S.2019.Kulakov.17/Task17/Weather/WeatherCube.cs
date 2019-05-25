namespace WeatherSpace
{
    using System;

    /// <summary>
    /// Сопоставляет значения показателей погоды и выдает строку с описанием погоды.
    /// Диапазон обрабатываемых значений
    /// давление от 730 до 760
    /// температура от -30 до 30
    /// влажность от 20 до 100
    /// </summary>
    public static class WeatherCube
    {
        // солнечно, переменная облачность, пасмурно, туман, кратковременные дожди, дождь, снег
        // температура - от -30 до 30 - 60 значений Temperature
        private static readonly int temperatureMin = -30;

        private static readonly int temperatureMax = 41;

        // давление от 730 - 760 - 30 значений Pressure
        private static readonly int pressureMin = 730;

        private static readonly int pressureMax = 761;

        // влажность от 20% до 100% - 60 +- 40 - 80 значения Humidity
        private static readonly int humidityMin = 20;

        private static readonly int humidityMax = 101;

        private static int PCount; // = PressureMax - PressureMin;

        private static int TCount; // = temperatureMax - temperatureMin;

        private static int HCount; // = HumidityMax - HumidityMin;

        /// <summary>
        /// массив описаний погоды
        /// </summary>
        private static string[,,] cube_pth;

        /// <summary>
        /// Преобразует параметры погоды в текстовое представление(осадки, снег, туман)
        /// </summary>
        static WeatherCube()
        {
            TCount = temperatureMax - temperatureMin;
            PCount = PressureMax - PressureMin;
            HCount = HumidityMax - HumidityMin;
            string weather = string.Empty;
            cube_pth = new string[PCount, TCount, HCount];
            for (int p = PressureMin; p < PressureMax; p++)
            {
                for (int t = TemperatureMin; t < TemperatureMax; t++)
                {
                    for (int h = HumidityMin; h < HumidityMax; h++)
                    {
                        weather = $"давление {p }, температура {t}, влажность {h}";
                        if (p < 742 && p > 735)
                        {
                            weather = weather + ", слабая облачность";
                            if (h > 80 && h < 90)
                            {
                                weather = weather + ", временами осадки";
                                if (t < 2 && t > -2)
                                {
                                    weather = weather + ", мокрый снег";
                                }
                                else
                                {
                                    if (t < -2)
                                    {
                                        weather = weather + ", снег";
                                    }

                                    if (t > 2)
                                    {
                                        weather = weather + ", дождь";
                                    }
                                }
                            }
                        }

                        if (p < 736)
                        {
                            weather = weather + ", облачность";
                            if (h > 89)
                            {
                                weather = weather + ", осадки";
                                if (t < 2 && t > -2)
                                {
                                    weather = weather + ", мокрый снег";
                                }
                                else
                                {
                                    if (t < -2)
                                    {
                                        weather = weather + ", снег";
                                    }

                                    if (t > 2)
                                    {
                                        weather = weather + ", дождь";
                                    }
                                }
                            }
                        }

                        if (p > 741)
                        {
                            weather = weather + ", солнечно";
                        }

                        cube_pth[IndexP(p), IndexT(t), IndexH(h)] = weather;
                        weather = string.Empty;
                    }
                }
            }
        }

        public static int TemperatureMin => temperatureMin;

        public static int TemperatureMax => temperatureMax;

        public static int PressureMin => pressureMin;

        public static int PressureMax => pressureMax;

        public static int HumidityMin => humidityMin;

        public static int HumidityMax => humidityMax;

        /// <summary>
        /// на основании входных параметров погоды выдает описание.
        /// </summary>
        /// <param name="pressure">давление</param>
        /// <param name="temperature">температура</param>
        /// <param name="humidity">влажность</param>
        /// <returns>строка с параметрами и описанием погоды</returns>
        public static string GetWeather(int pressure, int temperature, int humidity)
        {
            if (pressure > PressureMax || pressure < PressureMin || temperature > TemperatureMax || temperature < TemperatureMin || humidity > HumidityMax || humidity < HumidityMin)
            {
                string ex = $"Входные параметры: давление {pressure}, температура {temperature}, влажность {humidity}, не соответствуют диапазону обрабатываемых значений!";
                throw new ArithmeticException(ex);
            }

            return cube_pth[IndexP(pressure), IndexT(temperature), IndexH(humidity)];
        }

        private static void SetWeather(int pressure, int temperature, int humidity, string weather)
        {
            cube_pth[IndexP(pressure), IndexT(temperature), IndexH(humidity)] = weather;
        }

        // методы пересчитывают параметры в индексы массива с описаниями погоды
        private static int IndexP(int pressure)
        {
            return pressure - PressureMin;
        }

        private static int IndexT(int temperature)
        {
            return temperature - TemperatureMin;
        }

        private static int IndexH(int humidity)
        {
            return humidity - HumidityMin;
        }
    }
}
