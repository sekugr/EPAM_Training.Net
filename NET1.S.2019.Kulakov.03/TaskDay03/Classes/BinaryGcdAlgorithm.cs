namespace TaskDay03
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class BinaryGcdAlgorithm : IGcdAlgorithm
    {
        /// <summary>
        /// Реализация интерфейся, расчет НОД Бинарным методом.
        /// </summary>
        /// <param name="first">Первое число</param>
        /// <param name="second">Второе число</param>
        /// <returns>Наибольший общий делитель</returns>
        public int Calculate(int first, int second)
        {
            if (first == 0 && second == 0)
            {
                throw new ArgumentException("Оба числа не должны равняться 0");
            }

            first = Math.Abs(first);
            second = Math.Abs(second);
            if (second == first)
            {
                return second;
            }

            if (second == 0)
            {
                return first;
            }

            if (first == 0)
            {
                return second;
            }

            if ((second & 1) == 0) // second четное
            {
                if ((first & 1) != 0) // first не четное   
                {
                    return Calculate(second >> 1, first);
                }
                else // оба second и first четные
                {
                    return Calculate(second >> 1, first >> 1) << 1;
                }
            }

            if ((~first & 1) != 0) // second не четное, first четное
                return Calculate(second, first >> 1);

            if (second > first)
                return Calculate((second - first) >> 1, first);

            return Calculate((first - second) >> 1, second);
        }
    }
}