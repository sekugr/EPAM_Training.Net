namespace ArrayLibrary.Classes
{
    using System.Collections.Generic;

    public class CountCharLeft : IComparer<string>
    {
        private readonly char _symbol;

        public CountCharLeft(char symbol)
        {
            _symbol = symbol;
        }

        public int Compare(string x, string y)
        {
            if (x.CountCharInString(_symbol) < y.CountCharInString(_symbol))
            {
                return 1;
            }
            else
            {
                if (x.CountCharInString(_symbol) > y.CountCharInString(_symbol))
                {
                    return -1;
                }
            }

            return 0;
        }
    }
}
