namespace Task11Library
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class TaskEleven
    {
        public static IEnumerable<BigInteger> Fibo(int count)
        {
            if (count < 1)
            {
                throw new ArgumentException($"Количенство членов последовательности Фиббоначи не может быть меньше 1, значение {count}");
            }

            BigInteger prev = 1;
            BigInteger next = 1;
            BigInteger tmp;
            int index = 1;
            while (index < count)
            {
                if (index < 2)
                {
                    index++;
                    yield return prev;
                    yield return next;
                }

                next = prev + (tmp = next);
                prev = tmp;
                index++;
                yield return next;
            }
        }

        /// <summary>
        /// Генератор последовательности чисел Фибоначчи
        /// </summary>
        /// <param name="items">Количество чисел в генерируемой последовательности</param>
        /// <returns>Коллекция чисео Фибоначчи</returns>
        public static IEnumerable<BigInteger> Fibonacci(int items)
        {
            if (items < 1)
            {
                throw new ArgumentException($"Количенство членов последовательности Фиббоначи не может быть меньше 1, значение {items}");
            }

            BigInteger prev = 1;
            BigInteger next = 1;
            BigInteger[] result = new BigInteger[items];
            for (int i = 0; i < items; i++)
            {
                if (i > 1)
                {
                    BigInteger tmp = next;
                    next = next + prev;
                    prev = tmp;
                    result[i] = next;
                }
                else
                {
                    result[i] = 1;
                }
            }

            return result as IEnumerable<BigInteger>;
        }

        /// <summary>
        /// Реализует обобщенный алгоритм бинарного поиска
        /// </summary>
        /// <typeparam name="T">Тип элементов массива для поиска элемента</typeparam>
        /// <param name="sortingArray">Отсортированный массив</param>
        /// <param name="findItem">Элемент массива который требуется найти</param>
        /// <returns>Индекс искомого элемента в массиве</returns>
        public static int BinarySearch<T>(IEnumerable<T> sortingArray, T findItem) where T : IComparable
        {
            List<T> temp = new List<T>(sortingArray);

            int left = 0;
            int right = temp.Count;
            int comparer;
            int mid;
            while (true)
            {
                if (left == right)
                {
                    return -1;
                }

                mid = left + (right - left) / 2;
                comparer = temp[mid].CompareTo(findItem);
                if (comparer == 0)
                    return mid;

                if (comparer == 1)
                    right = mid;
                else
                    left = mid + 1;
            }
        }
    }
}
