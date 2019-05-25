namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using Task11Library;

    public class Program
    {
        public static void Main(string[] args)
        {
            StreamWriter file = new StreamWriter($"fibo.txt", false, Encoding.UTF8);
            int index = 0;
            int fiboCount = 500;
            string str = $"Генерация первых {fiboCount} чисел Фибоначчи\n";
            file.Write(str);
            foreach (var item in TaskEleven.Fibonacci(fiboCount))
            {
                index++;
                str = $"число {index} = {item}\n";
                file.Write(str);
                Console.Out.Write(str);
            }

            str = $"Конец генерации. Сгенерировано {index} чисел.";
            Console.Out.Write(str);
            file.Write(str);
            file.Close();

            int count = 1000;

            Console.WriteLine($"\nДобавление в очередь {count} элементов. (Ticks)");

            CustomQueue<MyPoint> customQ = new CustomQueue<MyPoint>();
            Queue<MyPoint> qq = new Queue<MyPoint>();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < count; i++)
            {
                qq.Enqueue(new MyPoint(1, 3));
            }

            sw.Stop();
            Console.WriteLine($"\nQueue {sw.ElapsedTicks}\n");
            sw.Reset();

            sw.Start();
            for (int i = 0; i < count; i++)
            {
                customQ.Enqueue(new MyPoint(1, 3));
            }

            sw.Stop();
            Console.WriteLine($"CustomQueue {sw.ElapsedTicks}\n");
            Console.ReadKey();
        }
    }
}
