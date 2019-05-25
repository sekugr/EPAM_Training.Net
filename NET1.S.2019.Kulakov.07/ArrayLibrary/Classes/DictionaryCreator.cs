namespace ArrayLibrary.Classes
{
    using System.Collections.Generic;
    using System.Globalization;
    using ArrayLibrary.Interfaces;

    public class DictionaryCreator : IDictionaryTransform
    {
        private IDictionaryTransform dictionary;

        public DictionaryCreator(CultureInfo culture)
        {
            switch (culture.Name)
            {
                case "ru-RU":
                    dictionary = new RuDictionary();
                    break;
                default:
                    dictionary = new EnDictionary();
                    break;
            }
        }

        public Dictionary<double, string> GetSpeсialDoubles()
        {
            return dictionary.GetSpeсialDoubles();
        }

        public Dictionary<char, string> GetWords()
        {
            return dictionary.GetWords();
        }
    }
}
