namespace ArrayLibrary.Classes
{
    using System.Collections.Generic;
    using ArrayLibrary.Interfaces;

    /// <summary>
    /// Russian dictionary for double transformation
    /// </summary>
    public sealed class RuDictionary : IDictionaryTransform
    {
        /// <summary>
        /// Russian dictionary for double transformation
        /// </summary>
        /// <returns>Dictionary of text representations of numbers</returns>
        public Dictionary<double, string> GetSpeсialDoubles()
        {
            Dictionary<double, string> special = new Dictionary<double, string>()
            {
                [double.NaN] = "значение не является числом",
                [double.PositiveInfinity] = "значение бесконечность",
                [double.NegativeInfinity] = "значение отрицательная бесконечность"
            };
            return special;
        }

        public Dictionary<char, string> GetWords()
        {
            Dictionary<char, string> words = new Dictionary<char, string>()
            {
                ['0'] = "ноль",
                ['1'] = "один",
                ['2'] = "два",
                ['3'] = "три",
                ['4'] = "четыре",
                ['5'] = "пять",
                ['6'] = "шесть",
                ['7'] = "семь",
                ['8'] = "восемь",
                ['9'] = "девять",
                [','] = "точка",
                ['-'] = "минус"
            };

            return words;
        }
    }
}
