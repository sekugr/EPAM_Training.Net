namespace BitOperations.MSTests
{
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
    public class MoveBitsTest
    {
        [TestMethod]
        public void TestInsertNumber_Source15_insert15_pos_0_0_exp15()
        #region   InsertNumber_Source15_insert15_pos_0_0_exp15
        {
            // Arrange
            int sourceNum = 15;
            int insertNum = 15;
            int startBit = 0;
            int endBit = 0;
            int expected = 15;

            // Act
            // Assert
            Assert.AreEqual(expected, BitOperation.MoveBits.InsertNumber(sourceNum, insertNum, startBit, endBit));
        }
        #endregion
        [TestMethod]
        public void TestInsertNumber_Source8_insert15_pos_0_0_exp9()
        #region InsertNumber_Source8_insert15_pos_0_0_exp9
        {
            // Arrange
            int sourceNum = 8;
            int insertNum = 15;
            int startBit = 0;
            int endBit = 0;
            int expected = 9;

            // Act
            // Assert
            Assert.AreEqual(expected, BitOperation.MoveBits.InsertNumber(sourceNum, insertNum, startBit, endBit));
        }
        #endregion
        [TestMethod]
        public void TestInsertNumber_Source8_insert15_pos_3_8_exp120()
        #region InsertNumber_Source8_insert15_pos_3_8_exp120
        {
            // Arrange
            int sourceNum = 8;
            int insertNum = 15;
            int startBit = 3;
            int endBit = 8;
            int expected = 120;

            // Act
            // Assert
            Assert.AreEqual(expected, BitOperation.MoveBits.InsertNumber(sourceNum, insertNum, startBit, endBit));
        }
        #endregion
        [TestMethod]
        public void TestInsertNumber_Source8191_insert42_pos_3_8_exp8023()
        #region InsertNumber_Source8191_insert42_pos_3_8_exp8023
        {
            // Arrange
            int sourceNum = 0b1111111111111;
            int insertNum = 0b101010;
            int expected = 0b1111101010111;
            int startBit = 3;
            int endBit = 8;

            // Act
            // Assert
            Assert.AreEqual(expected, BitOperation.MoveBits.InsertNumber(sourceNum, insertNum, startBit, endBit));
        }
        #endregion
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInsertNumber_StartBit8_more_EndBit3_ThrowArgumentException()
        #region InsertNumber_StartBit8_more_EndBit3_ThrowArgumentException
        {
            // Arrange
            int sourceNum = 0b1111111111111;
            int insertNum = 0b101010;
            int expected = 0b1111101010111;
            int startBit = 8;
            int endBit = 3;

            // Act
            // Assert
        Assert.AreEqual(expected, BitOperation.MoveBits.InsertNumber(sourceNum, insertNum, startBit, endBit));
        }
        #endregion
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInsertNumber_StartBit_more_EndBit_ThrowArgumentException() => BitOperation.MoveBits.InsertNumber(8, 15, 10, 2);
    }
}
