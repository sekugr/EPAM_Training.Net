/// <summary>
/// Tasks of the day02? bit operations
/// </summary>
namespace BitOperation
{
    using System;

    /// <summary>
    /// class with method for working with bit operations
    /// </summary>
    public static class MoveBits
    {
        /// <summary>
        /// Inserting numberInsert in to numberSource, between startBit to endBit positions
        /// </summary>
        /// <param name="numberSource">Source number</param>
        /// <param name="numberInsert">Insert number</param>
        /// <param name="startBit">Start bit position </param>
        /// <param name="endBit">End Bit position</param>
        /// <returns>Returns the initial number of inserted bits to be inserted, with the position of the startBit to endBit</returns>
        public static int InsertNumber(int numberSource, int numberInsert, int startBit, int endBit)
        {
            if (startBit > endBit)
            {
                throw new ArgumentException("startBit cannot be greater than endBit");
            }

            int mask = SetMask(endBit - startBit);
            int temp = numberInsert & mask; 
            temp = temp << startBit; 
            mask = mask << startBit; 
            numberSource = numberSource & ~mask;
            numberSource = numberSource | temp;
            return numberSource;
        }

        private static int SetMask(int count)
        {
            int mask = 0;
            for (int k = 0; k < (count + 1); k++)
            {
                mask = mask | (1 << k);
            }

            return mask;
        }
    }
}
