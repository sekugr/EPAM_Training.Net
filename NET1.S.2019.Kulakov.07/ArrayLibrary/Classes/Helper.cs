namespace ArrayLibrary
{
    using System;
    using System.Collections.Generic;

    public static class Helper
    {
        public static int[] ListToArray(List<int> list)
        {
            int[] result = new int[list.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = list[i];
            }

            return result;
        }

        public static int ArrayToInt(int[] array)
        {
            int result = 0;
            int pos = 1;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    pos = pos * 10;
                }

                result = result + (array[i] * pos);
                pos = 1;
            }

            return result;
        }

        public static int[] IntToArray(int number)
        {
            int tmp = Math.Abs(number);
            int count = 0;
            while (tmp > 0)
            {
                tmp = tmp / 10;
                count++;
            }

            tmp = Math.Abs(number);
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
