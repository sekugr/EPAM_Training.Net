namespace TimerClock
{
    using System;
    using System.Timers;

    public class TClock
    {
        private System.Timers.Timer aTimer;

        private string message;

        /// <summary>
        /// инициализирует новый экземпляр класса, задает интервал и сообщение при срабатывании таймера
        /// </summary>
        /// <param name="interval">Интервал в мс</param>
        /// <param name="message">Сообщение</param>
        public TClock(double interval, string message = "")
        {
            aTimer = new System.Timers.Timer(interval);
            aTimer.Interval = interval;
            this.message = message;
            aTimer.Elapsed += Notify;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        public event EventHandler<TimerEventArgs> Ring;

        public double Interval { get => aTimer.Interval; set => aTimer.Interval = value; }

        public string Message { get => message; }

        public bool Enable { get => aTimer.Enabled; set => aTimer.Enabled = value; }

        public void Dispose()
        {
            aTimer.Stop();
            aTimer.Dispose();
        }

        /// <summary>
        /// Запуск таймера
        /// </summary>
        public void Start()
        {
            aTimer.Start();
        }

        /// <summary>
        /// Остановка таймера
        /// </summary>
        public void Stop()
        {
            aTimer.Stop();
        }

        private void OnRing()
        {
            var notify = Ring;
            notify?.Invoke(this, new TimerEventArgs(DateTime.Now, Message, Interval));
        }

        private void Notify(Object source, ElapsedEventArgs e)
        {
            OnRing();
        }
    }
}
