namespace TimerClock
{
    using System;

    public class TimerEventArgs : EventArgs
    {
        private DateTime time;

        private string message;

        private double interval;

        public TimerEventArgs(DateTime time, string message, double interval)
        {
            this.time = time;
            this.message = message;
            this.interval = interval;
        }

        public DateTime Time { get => time; }

        public string Message { get => message; }

        public double Interval { get => interval; }
    }
}