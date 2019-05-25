namespace ArrayLibrary
{
    public sealed class Even : IPredicate
    {
        public bool IsMath(int number)
        {
            if (number % 2 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
