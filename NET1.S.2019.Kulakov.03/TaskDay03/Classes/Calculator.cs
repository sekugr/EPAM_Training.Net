namespace TaskDay03
{
    using System;
    using System.Collections.Generic;

    public static class Calculator
    {
        /// <summary>
        /// Метод возвращает корень N - й степени из числа, с заданной точностью, рассчитанный методом Ньютона.
        /// </summary>
        /// <param name="number">Число, корень которого нужно найти.</param>
        /// <param name="power">Степень корня извлекаемого из числа.</param>
        /// <param name="accuracy">Точность с которой необходимо вычислить корень.</param>
        /// <returns>Число double, округленное до 3 знаков после запятой.</returns>
        public static double FindNthRoot(double number, int power, double accuracy)
        {
            if (power == 0)
            {
                throw new ArgumentException("Степень корня не должна быть 0");
            }

            if (accuracy < 0)
            {
                throw new ArgumentException("Точность корня не должна быть меньше 0");
            }

            if (number < 0 && (power % 2 == 0))
            {
                throw new ArgumentException("Нельзя взять корень четной степени из отрицательного числа.");
            }

            if (power == 1)
            {
                return number;
            }

            double res = accuracy;
            double next = (1.0 / power) * (((power - 1) * res) + (number / Math.Pow(res, power - 1)));
            while (Math.Abs(next - res) > accuracy / 10)
            {
                res = next;
                next = (1d / power) * (((power - 1) * res) + (number / Math.Pow(res, power - 1)));
            }

            return Math.Round(next, 3);
        }

        /// <summary>
        /// Возвращает ближайшее наибольшее целое, состоящее из цифр исходного числа, и null, если такого числа не существует.
        /// </summary>
        /// <param name="number">Исходное число</param>
        /// <returns>Число int, или null, если ближайшего целого не существует.</returns>
        public static int? NextBiggerThan(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Исходное число должно быть больше 0");
            }

            int[] inNum = IntToArray(number);
            List<int> rigth_num = new List<int>(inNum.Length);
            int separate_pos = 0;
            for (int i = inNum.Length - 1; i >= 1; i--)
            {
                if (inNum[i] > inNum[i - 1])
                {
                    separate_pos = i;
                    rigth_num.Add(inNum[i]);
                    break;
                }
                else
                {
                    rigth_num.Add(inNum[i]);
                }
            }

            int? result = 0;
            if (separate_pos != 0)
            {
                separate_pos--;
                for (int i = 0; i < rigth_num.Count; i++)
                {
                    if (inNum[separate_pos] < rigth_num[i])
                    {
                        int tmp = rigth_num[i];
                        rigth_num[i] = inNum[separate_pos];
                        inNum[separate_pos] = tmp;
                        break;
                    }
                }

                for (int k = 0; k < separate_pos + 1; k++)
                {
                    result = (result * 10) + inNum[k];
                }

                for (int k = 0; k < rigth_num.Count; k++)
                {
                    result = (result * 10) + rigth_num[k];
                }
            }
            else
            {
                result = null;
            }

            if (result < 0)
            {
                result = null;
            }

            return result;
        }

        private static int[] IntToArray(int number)
        {
            int tmp = number;
            int count = 0;
            while (tmp > 0)
            {
                tmp = tmp / 10;
                count++;
            }

            tmp = number;
            int[] result = new int[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = tmp % 10;
                tmp = tmp / 10;
            }

            Array.Reverse(result);
            return result;
        }
    }
}
