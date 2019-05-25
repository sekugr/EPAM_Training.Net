namespace Task1Day07App
{
    using System;
    using ArrayLibrary;
    using ArrayLibrary.Classes;

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] source = new int[] { 545, 321, 142, 9686, 1477, -3664, 858, -474, 625, 924, 3672, 8415, 65256, 750, int.MaxValue };
            Console.WriteLine("Исходный массив");
            ToConsole(source);

            int num = 2;
            Console.WriteLine($"\nЧисла содержащие {num}");
            ToConsole(source.Filter(new Digit(num)));
                        
            Console.WriteLine($"\nЧетные числа");
            ToConsole(source.Filter(new Even()));

            Console.WriteLine($"\nПолиндромы");
            ToConsole(source.Filter(new Polindrom()));
    
            Console.WriteLine("\nИсходное чисто для Transform");
            double number = -654321.54654;
            Console.WriteLine(number);

            Console.WriteLine("\nTransform En");
            Console.WriteLine(number.Transform("en-EN"));
            Console.WriteLine("\nTransform Ru");
            Console.WriteLine(number.Transform("ru-RU"));

            string[] array = new string[] { "22222___9", "2222___7", "22___6", "222____8" };
            Console.WriteLine("\nИсходный массив строк");
            ToConsole(array);
            Console.WriteLine();

            Console.WriteLine("Сортировка по количеству символов 2");
            Transformer.Sort(array, new CountCharLeft('2'));
            ToConsole(array);
            Console.WriteLine();

            Console.WriteLine("Сортировка по длине строки");
            Transformer.Sort(array, new ShortRigth());
            ToConsole(array);
           
            Console.ReadKey();
        }

        private static void ToConsole(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        private static void ToConsole(string[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }
    }
}
