namespace TaskDay03NuTest
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TaskDay03;

    [TestFixture]
    public class CalculatorTests
    {
        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]

        public double FindNthRootTest(double num, int pow, double accuracy) => Calculator.FindNthRoot(num, pow, accuracy);

        [TestCase(0.01, 0, 0.0001)]
        [TestCase(-0.01, -2, 0.0001)]
        [TestCase(0.01, 2, -1)]
        public void extBigger_ArgumentException_Test(double num, int pow, double accuracy)
        {
            Assert.Throws<ArgumentException>(() => Calculator.FindNthRoot(num, pow, accuracy));
        }

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(124121133, ExpectedResult = 124121313)]
        [TestCase(int.MaxValue, ExpectedResult = null)]
        [TestCase(2000, ExpectedResult = null)]
        [TestCase(111111111, ExpectedResult = null)]

        public int? NextBiggerThanTest(int number) => Calculator.NextBiggerThan(number);

        [TestCase(-1)]

        public void NextBiggerThan_ArgumentException_Test(int number)
        {
            Assert.Throws<ArgumentException>(() => Calculator.NextBiggerThan(number));
        }
    }

    [TestFixture]
    public class GcdTest
    {
        [TestCase( 10, 5, ExpectedResult = 5)]
        [TestCase(654987, 321654, ExpectedResult = 3)]
        [TestCase(654987, -321654, ExpectedResult = 3)]
        [TestCase(-654987, 321654, ExpectedResult = 3)]
        [TestCase(0, 70, ExpectedResult = 70)]
        public int GcdEuclidianTest( int n1, int n2)
        {
            return (Gcd.Calculate(new EuclideanGcdAlgorithm(), n1, n2));
        }

        [TestCase(0, 0)]
        public void GcdEuclidian_ArgumentExeption_Test(int n1, int n2) => Assert.Throws<ArgumentException>(() => Gcd.Calculate(new EuclideanGcdAlgorithm(), n1, n2));

        [TestCase(10, 5, ExpectedResult = 5)]
        [TestCase(654987, 321654, ExpectedResult = 3)]
        [TestCase(654987, -321654, ExpectedResult = 3)]
        [TestCase(-654987, 321654, ExpectedResult = 3)]
        [TestCase(0, 70, ExpectedResult = 70)]
        public int GcdBinaryTest(int n1, int n2)
        {
            return (Gcd.Calculate(new BinaryGcdAlgorithm(), n1, n2));
        }

        [TestCase(0, 0)]
        public void GcdBinary_ArgumentExeption_Test(int n1, int n2) => Assert.Throws<ArgumentException>(() => Gcd.Calculate(new BinaryGcdAlgorithm(), n1, n2));
    }
}
