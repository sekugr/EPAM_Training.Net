namespace ArrayLibrary.Classes
{
    using System.Collections.Generic;
    using ArrayLibrary.Interfaces;

    /// <summary>
    /// English dictionary for double transformation
    /// </summary>
    public sealed class EnDictionary : IDictionaryTransform
    {
        public Dictionary<double, string> GetSpeсialDoubles()
        {
            Dictionary<double, string> special = new Dictionary<double, string>()
            {
                [double.NaN] = "value is not a number",
                [double.PositiveInfinity] = "value is infinity",
                [double.NegativeInfinity] = "value is negativeinfinity"
            };
            return special;
        }

        public Dictionary<char, string> GetWords()
        {
            Dictionary<char, string> words = new Dictionary<char, string>()
            {
                ['0'] = "zero",
                ['1'] = "one",
                ['2'] = "two",
                ['3'] = "three",
                ['4'] = "four",
                ['5'] = "five",
                ['6'] = "six",
                ['7'] = "seven",
                ['8'] = "eight",
                ['9'] = "nine",
                [','] = "point",
                ['-'] = "minus"
            };

            return words;
        }
    }
}
