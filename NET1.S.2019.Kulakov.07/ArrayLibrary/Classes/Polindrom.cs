namespace ArrayLibrary
{
    using System;

    public sealed class Polindrom : IPredicate
    {
        public bool IsMath(int number)
        {
            int[] array = Helper.IntToArray(Math.Abs(number));
            if (Helper.ArrayToInt(array) == Math.Abs(number))
            {
                return true;
            }

            return false;
        }
    }
}
