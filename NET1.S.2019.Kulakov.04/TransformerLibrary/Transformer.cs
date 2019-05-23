namespace TransformerLibrary
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    public static class Transformer
    {
        public static string TransformToWords(double number)
        {
            string str = number.ToString(CultureInfo.InvariantCulture);
            Dictionary<char, string> words = new Dictionary<char, string>();
            words.Add('-', "minus");
            words.Add('.', "point");
            words.Add(',', "comma");
            words.Add('0', "zero");
            words.Add('1', "one");
            words.Add('2', "two");
            words.Add('3', "three");
            words.Add('4', "four");
            words.Add('5', "five");
            words.Add('6', "six");
            words.Add('7', "seven");
            words.Add('8', "eight");
            words.Add('9', "nine");
            StringBuilder sb = new StringBuilder(str.Length * 5);
            foreach (char ch in str)
            {
                sb.Append(words[ch] + " ");
            }

            return sb.ToString().Trim();
        }
    }
}
