namespace ArrayLibrary
{
    using System;

    public class Digit : IPredicate
    {
        private int _number;

        public Digit(int digit)
        {
            this.Number = digit;
        }

        internal int Number
        {
            get => _number; set
            {
                if ((value < 0) && (value > 9))
                {
                    throw new ArithmeticException();
                }

                _number = value;
            }
        }

        public bool IsMath(int num)
        {
            int[] temp = Helper.IntToArray(num);
            foreach (var item in temp)
            {
                if (item == this.Number)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
