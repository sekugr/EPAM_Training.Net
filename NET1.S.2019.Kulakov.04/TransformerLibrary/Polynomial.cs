namespace TransformerLibrary
{
    using System;
    using System.Linq;
    using System.Text;

    public class Polynomial
    {
        private readonly double[] coeffs;

        public Polynomial(params double[] coeffs)
        {
            if (coeffs == null)
            {
                throw new ArgumentNullException();
            }

            if (coeffs.Length == 0)
            {
                throw new ArgumentException("coeffs count must be greater than zero");
            }

            this.coeffs = new double[coeffs.Length];
            coeffs.CopyTo(this.coeffs, 0);
        }

        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= coeffs.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return coeffs[index];
            }
        }

        public static bool operator ==(Polynomial pol1, Polynomial pol2)
        {
            if (ReferenceEquals((object)pol1, (object)pol2))
            {
                return true;
            }

            if ((object)pol1 == null || (object)pol2 == null)
            {
                return false;
            }

            return pol1.GetCoefficients().SequenceEqual(pol2.GetCoefficients());
        }

        public static bool operator !=(Polynomial pol1, Polynomial pol2)
        {
            return !(pol1 == pol2);
        }

        public double[] GetCoefficients()
        {
            double[] result = new double[coeffs.Length];
            coeffs.CopyTo(result, 0);
            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (double el in coeffs)
            {
                result.Append(el.ToString() + " ");
            }

            return result.ToString().Trim();
        }

        public override bool Equals(Object pol)
        {
            if ((pol as Polynomial) == null)
            {
                return false;
            }

            return GetCoefficients().SequenceEqual((pol as Polynomial).GetCoefficients());
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
