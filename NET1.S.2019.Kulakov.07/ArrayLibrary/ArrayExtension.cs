namespace ArrayLibrary
{
    using System.Collections.Generic;

    /// <summary>
    /// Класс расширения массива
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Отбор из массива элементов по параметрам в предикате
        /// </summary>
        /// <param name="array">Исходный массив для фильтрации элементов</param>
        /// <param name="predicat">Предикат определяющий фильтрацию</param>
        /// <returns>Новый отфильтрованный массив</returns>
        public static int[] Filter(this int[] array, IPredicate predicat)
        {
            List<int> result = new List<int>();
            foreach (int el in array)
            {
                if (predicat.IsMath(el))
                {
                    result.Add(el);
                }
            }

            return Helper.ListToArray(result);
        }
    }
}
