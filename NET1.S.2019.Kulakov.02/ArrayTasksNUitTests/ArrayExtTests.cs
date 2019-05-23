/// <summary>
/// Tests
/// </summary>
namespace ArrayTasksNUitTests
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayTasks;
using NUnit.Framework;

    [TestFixture]
    public class ArrayExtTests
    {
        #region Testing_MaxValueItems
        [Test]
        public void MaxValueItems_Null_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExt.MaxValueItems(null));
        }

        [Test]
        public void MaxValueItems_Length10001_ArgumentOutOfRangeException()
        {
            int[] sourceArray = new int[10001];
            Assert.Throws<ArgumentOutOfRangeException>(() => ArrayExt.MaxValueItems(sourceArray));
        }

        [Test]
        public void MaxValueItems_Empty_ArgumentException()
        {
            int[] sourceArray = new int[0];
            Assert.Throws<ArgumentException>(() => ArrayExt.MaxValueItems(sourceArray));
        }
             
        [TestCase(new int[] { -12, -5, -6, -8, -2, -4 }, ExpectedResult = -2)]
        [TestCase(new int[] { 21, -4, 5, 87, 65, -121, 41, -57, 36, 98, -157, 21, 35 }, ExpectedResult = 98)]
        [TestCase(new int[] { 12, 5, 6, 8, 68, 2, 4 }, ExpectedResult = 68)]
        [TestCase(new int[] { 12, 5, 6, 8, 2, 4 }, ExpectedResult = 12)]
        public int MaxValueItems_Test(int[] array) => ArrayExt.MaxValueItems(array);
     
        [Test]
        public void MaxValueItems_ReturnIntMaxVal()
        {
            int[] sourceArray = new int[5] { 3, 4565, int.MaxValue, 654, 12 };
            Assert.AreEqual(int.MaxValue, ArrayExt.MaxValueItems(sourceArray));
        }

        #endregion

        #region FindIndex_Test
        [TestCase(new double[5] { 25.65467, 65.6546587, 42.654654, 45.654654, 7.65498 }, 0.001, ExpectedResult = null)]
        [TestCase(new double[5] { 25.65467, 61.6546587, 42.65, 45.654654, 7.65498 }, 0.001, ExpectedResult = null)]
        [TestCase(new double[5] { double.MinValue, double.MaxValue, 45.654654, double.MinValue, double.MaxValue }, 0.001, ExpectedResult = 2)]
        public int? FindIndex_Test(double[] array, double accuracy) => ArrayExt.FindIndex(array, accuracy);

        [Test]
        public void FindIndex_ArgumentOutOfRangeException_Test()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ArrayExt.FindIndex(new double[5] { 25.65467, 65.6546587, 42.654654, 45.654654, 7.65498 }, -0.0001));
            Assert.Throws<ArgumentOutOfRangeException>(() => ArrayExt.FindIndex(new double[5] { 25.65467, 65.6546587, 42.654654, 45.654654, 7.65498 }, 2));
        }

        [Test]
        public void FindIndex_ArgumentNullException_Test()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExt.FindIndex(null, 0.0001));
        }

        [Test]
        public void FindIndex_ArgumentException_Test()
        {
            Assert.Throws<ArgumentException>(() => ArrayExt.FindIndex(new double[0], 0.0001));
        }
        #endregion

        #region Testing_FilterArrayByKey
        [Test]
        public void FilterArrayByKey1()
        {
            var arr = new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            CollectionAssert.AreEqual(new[] { 1, 15, 17 }, ArrayExt.FilterArrayByKey(arr, 1));
        }

        [Test]
        public void FilterArrayByKey6()
        {
            var arr = new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            CollectionAssert.AreEqual(new[] { 6, 68, 69 }, ArrayExt.FilterArrayByKey(arr, 6));
        }

        [Test]
        public void FilterArrayByKey7()
        {
            var arr = new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            CollectionAssert.AreEqual(new[] { 7, 7, 70, 17 }, ArrayExt.FilterArrayByKey(arr, 7));
        }

        #endregion
    }
}
