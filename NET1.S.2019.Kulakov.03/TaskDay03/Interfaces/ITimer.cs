namespace TaskDay03
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    /// <summary>
    /// Задает интерфейс таймера для измерения времени выполнения методаю
    /// </summary>
    public interface ITimer
    {
        void Start();

        void Stop();

        long GetTime();

        TimeSpan GetTimeSpan();

        long GetMilliseconds();
    }
}