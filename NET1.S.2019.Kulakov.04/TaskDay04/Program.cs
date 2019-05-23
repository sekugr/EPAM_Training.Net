namespace TaskDay04
{
    using System;
    using TransformerLibrary;

    public class Program
    {
        public static void Main(string[] args)
        {

            string str = "-1235";
            double dec = double.Parse(str);// -0.295;
            Console.WriteLine(dec);
            Console.WriteLine(dec.Transform());
            double[] array = new double[] { -23.809, 0.295, 15.17 };
            foreach (var el in array.Transform())
            {
                Console.WriteLine(el);
            }

            Polynomial pol = new Polynomial(new double[] { 12.65, 458.321, 58.36 });
            Polynomial pol2 = new Polynomial(new double[] { 12.65, 458.321, 58.6 });

            foreach (var el in pol.GetCoefficients())
            {
                Console.WriteLine(el);
            }

            Console.ReadKey();
        }
    }
}
