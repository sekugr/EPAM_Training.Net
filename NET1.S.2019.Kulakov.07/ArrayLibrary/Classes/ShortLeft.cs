﻿namespace ArrayLibrary.Classes
{
    using System.Collections.Generic;

    public class ShortLeft : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.Length < y.Length)
            {
                return 1;
            }
            else
            {
                if (x.Length > y.Length)
                {
                    return -1;
                }
            }

            return 0;
        }
    }
}
