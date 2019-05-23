/// <summary>
/// Tasks Day02
/// </summary>
namespace ArrayTasks
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// class containing methods of working with arrays to the tasks of the 2 day
    /// </summary>
    public class ArrayExt
    {
        /// <summary>
        /// This method, finds value maximum item in source array recursively
        /// </summary>
        /// <param name="array">Unsorted source array, maximum 80000 items</param>
        /// <returns>Value maximum item in source array</returns>
        /// <exception cref="ArgumentNullException">Thrown when source array is null</exception>
        /// <exception cref="ArgumentException">Thrown when source array is empty</exception>
        public static int MaxValueItems(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException("Array is NULL");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array is Empty");
            }

            if (array.Length > 10000)
            {
                throw new ArgumentOutOfRangeException($"Maximum array.Length = 10000. In this {array.Length} items");
            }

            return MaxValue(array, array.Length);
        }

        /// <summary>
        /// Returns the number of an array element whose sum of elements on the right is equal to the sum of elements on the left
        /// </summary>
        /// <param name="array">Source array</param>
        /// <param name="accuracy">the accuracy of the comparison of amounts of elements</param>
        /// <returns>int number, or null</returns>
        public static int? FindIndex(double[] array, double accuracy)
        {
            if ((accuracy < 0) || (accuracy > 1))
            {
                throw new ArgumentOutOfRangeException("Accuracy must not be less than zero and greater than 1");
            }

            if (array is null)
            {
                throw new ArgumentNullException("Source array is null");
            }

            if (array.Length < 1)
            {
                throw new ArgumentException("Length source array is empty");
            }

            int? index = null;
            for (int i = 0; i < array.Length; i++)
            {
                if (Math.Abs(SumL(array, i) - SumR(array, i)) <= accuracy)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        /// <summary>
        /// Selects of array elements contains the number
        /// </summary>
        /// <param name="array">Source integer array</param>
        /// <param name="number">digit to filtering</param>
        /// <returns>filtered array, all elements of which contain a "number"</returns>
        public static int[] FilterArrayByKey(int[] array, int number)
        {
            if (number > 9 || number < 0)
            {
                throw new ArgumentOutOfRangeException("Number outside the 0 - 9");
            }

            string[] numArray = new string[array.Length];
            for (int i = 0; i < numArray.Length; i++)
            {
                numArray[i] = array[i].ToString();
            }

            string numStr = number.ToString();
            List<string> resStrArr = new List<string>();
            int count = 0;
            foreach (var item in numArray)
            {
                if (item.Contains(numStr))
                {
                    resStrArr.Add(item);
                    count++;
                }
            }

            int[] result = new int[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = Convert.ToInt32(resStrArr[i]);
            }
            
            return result;
        }

        private static int MaxValue(int[] array, int i)
        {
            if (i == 0)
            {
                return array[0];
            }

            int bigItem = MaxValue(array, --i);
            return array[i] > bigItem ? array[i] : bigItem;
        }

        private static double SumL(double[] arr, int index)
        {
            double sum = 0;
            for (int i = 0; i < index; i++)
            {
                sum = sum + arr[i];
            } 

            return sum;
        }

        private static double SumR(double[] arr, int index)
        {
            double sum = 0;
            for (int i = index + 1; i < arr.Length; i++)
            {
                sum = sum + arr[i];
            }

            return sum;
        }
    }
}
