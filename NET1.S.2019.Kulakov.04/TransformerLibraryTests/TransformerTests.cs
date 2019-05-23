namespace TransformerLibrary.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class TransformerTests
    {
        [TestMethod()]
        public void TransformToWordsTest_254point654_twofivefourpointsixfivefour()
        {
            double number = 254.654;
            string expected = "two five four point six five four";
            Assert.AreEqual(expected, Transformer.TransformToWords(number));
        }

        [TestMethod()]
        public void TransformToWordsTest2()
        {
            double number = -23.809;
            string expected = "minus two three point eight zero nine";
            Assert.AreEqual(expected, Transformer.TransformToWords(number));
        }

        [TestMethod()]
        public void TransformToWordsTest3()
        {
            double number = 0.295;
            string expected = "zero point two nine five";
            Assert.AreEqual(expected, Transformer.TransformToWords(number));
        }
    }
}