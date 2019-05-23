namespace TransformerLibrary.Tests
{
using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class DoubleExtentionTests
    {
        [TestMethod()]
        public void TransformTest_DoubleArray_StringArray()
        {
            double[] nums = new double[] { -23.809, 0.295, 15.17 };
            string[] expected = new string[] { "minus two three point eight zero nine", "zero point two nine five", "one five point one seven" };
            CollectionAssert.AreEqual(expected, nums.Transform());
        }
    }
}