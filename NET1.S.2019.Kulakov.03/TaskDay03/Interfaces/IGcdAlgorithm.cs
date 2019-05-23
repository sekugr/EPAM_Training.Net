namespace TaskDay03
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    /// <summary>
    /// Интерфейс задающий алгоритм вычисления НОД.
    /// </summary>
    public interface IGcdAlgorithm
    {
        /// <summary>
        /// Вычисляет НОД заданным методом
        /// </summary>
        /// <param name="first">Первое число</param>
        /// <param name="second">Второе число</param>
        /// <returns>Наибольший общий делитель</returns>
        int Calculate(int first, int second);
    }
}