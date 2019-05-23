namespace TaskDay03
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Реализует возможность измерения времени какого либо процесса. 
    /// </summary>
    public class Timer : ITimer
    {
        private long _time = 0;

        private TimeSpan _ts;

        private long _ms;

        private Stopwatch sw;

        public Timer()
        {
            sw = new Stopwatch();    
        }

        /// <summary>
        /// Получение времени работы таймера
        /// </summary>
        /// <returns>Время работы таймера в миллисекундах</returns>
        public long GetMilliseconds()
        {
            return _ms;
        }

        /// <summary>
        /// Получение времени работы таймера
        /// </summary>
        /// <returns>Время работы таймера в tick</returns>
        public long GetTime()
        {
            return _time;
        }
        
        /// <summary>
        /// Получение времени работы таймера
        /// </summary>
        /// <returns>Время работы таймера в форматированном виде TimeSpan</returns>
        public TimeSpan GetTimeSpan()
        {
            return _ts;
        }

        /// <summary>
        /// Запуск таймера
        /// </summary>
        public void Start()
        {
            sw.Start();
        }
        
        /// <summary>
        /// Остановка таймера
        /// </summary>
        public void Stop()
        {
            sw.Stop();
            _time = sw.ElapsedTicks;
            _ts = sw.Elapsed;
            _ms = sw.ElapsedMilliseconds;
            sw.Reset();
        }
    }
}