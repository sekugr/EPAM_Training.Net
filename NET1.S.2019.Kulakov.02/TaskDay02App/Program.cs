namespace TaskDay02App
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayTasks;

    /// <summary>
    /// entry point to the program
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var arr2 = new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            int[] arr = new int[10];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-100000, 100000);
            }

            Console.WriteLine($"max item {ArrayExt.MaxValueItems(arr)}");
            Console.WriteLine();

            Console.ReadKey();
        }

    }
}
