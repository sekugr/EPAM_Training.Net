namespace TaskDay03
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class EuclideanGcdAlgorithm : IGcdAlgorithm
    {
        /// <summary>
        /// Реализация интерфейся, расчет НОД методом Евклида.
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

            if (first == 0)
            {
                return second;
            }

            if (second == 0)
            {
                return first;
            }

            if (first == second)
            {
                return first;
            }

            first = Math.Abs(first);
            second = Math.Abs(second);
            int big = 0, small = 0;
            if (first > second)
            {
                big = first;
                small = second;
            }
            else
            {
                big = second;
                small = first;
            }

            if (big % small == 0)
            {
                return small;
            }

            int gcd = 0;
            int tmp = 0;
            do
            {
                gcd = big % small;
                tmp = small;
                small = gcd;
                big = tmp;
            }
            while (big % small != 0);

            return gcd;
        }
    }
}