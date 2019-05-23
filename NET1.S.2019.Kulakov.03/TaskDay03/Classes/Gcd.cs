namespace TaskDay03
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public static class Gcd
    {
        /// <summary>
        /// Вычисляет НОД двух целых чисел, по заданному алгоритму.
        /// </summary>
        /// <param name="algorithm">Задает алгоритм вычисления НОД</param>
        /// <param name="first">Первое число для вычисления</param>
        /// <param name="second">Второе число для вычисления</param>
        /// <returns>Значение НОД для заданных чисел</returns>
        public static int Calculate(IGcdAlgorithm algorithm, int first, int second)
        {
            return algorithm.Calculate(first, second);
        }

        /// <summary>
        /// Вычисляет НОД двух целых чисел, по заданному алгоритму. Измеряет время выполнения операции.
        /// </summary>
        /// <param name="algorithm">Задает алгоритм вычисления НОД</param>
        /// <param name="time">Время выполнения операции.</param>
        /// <param name="first">Первое число для вычисления</param>
        /// <param name="second">Второе число для вычисления</param>
        /// <returns>Значение НОД для заданных чисел</returns>
        public static int Calculate(IGcdAlgorithm algorithm, out long time, int first, int second)
        {
            Timer timer = new Timer();
            timer.Start();
            int result = algorithm.Calculate(first, second);
            timer.Stop();
            time = timer.GetTime();
            return result;
        }

        /// <summary>
        /// Вычисляет НОД целых чисел из массива numbers, по заданному алгоритму.
        /// </summary>
        /// <param name="algorithm">Задает алгоритм вычисления НОД</param>
        /// <param name="numbers">Массив чисел для вычисления НОД</param>
        /// <returns>Значение НОД для заданных чисел</returns>
        public static int Calculate(IGcdAlgorithm algorithm, params int[] numbers)
        {
            if (numbers.Length < 2)
            {
                throw new ArgumentException("Входных чисел должно быть 2 или больше.");
            }

            int result = algorithm.Calculate(numbers[0], numbers[1]);
            if (numbers.Length > 2)
            {
                for (int i = 2; i < numbers.Length; i++)
                {
                    result = algorithm.Calculate(result, numbers[i]);
                }
            }

            return result;
        }

        /// <summary>
        /// Вычисляет НОД целых чисел из массива numbers, по заданному алгоритму. Измеряет время выполнения операции.
        /// </summary>
        /// <param name="algorithm">Задает алгоритм вычисления НОД.</param>
        /// <param name="time">Время выполнения операции.</param>
        /// <param name="numbers">Массив чисел для вычисления НОД.</param>
        /// <returns>Значение НОД для заданных чисел.</returns>
        public static int Calculate(IGcdAlgorithm algorithm, out long time, params int[] numbers)
        {
            if (numbers.Length < 2)
            {
                throw new ArgumentException("Входных чисел должно быть 2 или больше.");
            }

            Timer timer = new Timer();
            timer.Start();
            int result = algorithm.Calculate(numbers[0], numbers[1]);
            if (numbers.Length > 2)
            {
                for (int i = 2; i < numbers.Length; i++)
                {
                    result = algorithm.Calculate(result, numbers[i]);
                }
            }

            timer.Stop();
            time = timer.GetTime();

            return result;
        }
    }
}