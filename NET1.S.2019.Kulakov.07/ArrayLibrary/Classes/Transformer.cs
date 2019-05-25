namespace ArrayLibrary
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using ArrayLibrary.Classes;

    public static class Transformer
    {
        /// <summary>
        /// converts a double to a word representation
        /// </summary>
        /// <param name="number">double number for transfom</param>
        /// <param name="cultureName">selects the output options, can take the values "ru-RU", "en-EN". default value is "en-EN"</param>
        /// <returns>String representation of the number according to the selected culture</returns>
        public static string Transform(this double number, string cultureName = "ru-RU")
        {
            DictionaryCreator dictionary = new DictionaryCreator(new CultureInfo(cultureName));

            string result;
            dictionary.GetSpeсialDoubles().TryGetValue(number, out result);

            if (result == null)
            {
                string str = number.ToString();

                StringBuilder sb = new StringBuilder(str.Length * 5);
                foreach (char ch in str)
                {
                    sb.Append($"{dictionary.GetWords()[ch]} ");
                }

                return sb.ToString().Trim();
            }
            else
            {
                return result;
            }
        }

        public static int CountCharInString(this string str, char symbol)
        {
            char[] array = str.ToCharArray();
            int result = 0;
            foreach (var item in array)
            {
                if (item == symbol)
                {
                    result++;
                }
            }

            return result;
        }

        public static string[] Sort(this string[] array, IComparer<string> comparer)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comparer.Compare(array[i], array[j]) < 0)
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }

            return null;
        }

        private static void Swap(ref string left, ref string rigth)
        {
            string tmp = left;
            left = rigth;
            rigth = tmp;
        }
    }
}
