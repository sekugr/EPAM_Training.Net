namespace ExampleTimer
{
    using System;
    using TimerClock;

    public class Example
    {
        public static void Main()
        {
            Console.CursorVisible = false;
            Console.WriteLine("Ждем события!");
            Console.WindowWidth = 80;
            var t_time = new TClock(500, "Таймер 1: ");
            t_time.Ring += T_time_Ring;
            var t = new TClock(800, "Таймер 2: ");
            t.Ring += T_Ring;
            t.Start();
            Console.ReadLine();
            t.Dispose();
        }

        private static void T_time_Ring(object sender, TimerEventArgs e)
        {
            var left = Console.CursorLeft;
            var top = Console.CursorTop;
            Console.BackgroundColor = (ConsoleColor)(e.Time.Second % 15);
            Console.SetCursorPosition(40, 10);
            Console.Write($"{e.Message}{e.Time.ToUniversalTime()}  ");
            Console.SetCursorPosition(40, 11);
            Console.Write($"{((TClock)sender).ToString()} Интервал = { e.Interval}");

            Console.ResetColor();
        }

        private static void T_Ring(object sender, TimerEventArgs e)
        {
            var left = Console.CursorLeft;
            var top = Console.CursorTop;
            Console.BackgroundColor = (ConsoleColor)(e.Time.Second % 15);
            Console.SetCursorPosition(0, 10);
            Console.Write($"{e.Message}{e.Time.ToUniversalTime()}  ");
            Console.SetCursorPosition(0, 11);
            Console.Write($"{((TClock)sender).ToString()} Интервал = { e.Interval}");
            Console.ResetColor();
        }
    }
}
