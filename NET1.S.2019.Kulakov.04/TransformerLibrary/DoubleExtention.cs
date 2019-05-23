namespace TransformerLibrary
{
    public static class DoubleExtention
    {
        public static string Transform(this double number)
        {
            return Transformer.TransformToWords(number);
        }

        public static string[] Transform(this double[] number)
        {
            string[] result = new string[number.Length];
            for (int i = 0; i < number.Length; i++)
            {
                result[i] = Transformer.TransformToWords(number[i]);
            }

            return result;
        }
    }
}
