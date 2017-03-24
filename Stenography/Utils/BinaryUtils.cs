namespace Stenography.Utils
{
    static class BinaryUtils
    {
        #region Methods
        /// <summary>
        /// Sets the bit at the specified position to the specified value.
        /// </summary>
        /// <param name="original">The byte to set the bit in.</param>
        /// <param name="pos">The position of the bit to set. (0 based)</param>
        /// <param name="value">The value to set the bit to.</param>
        /// <returns>The modified byte.</returns>
        public static byte SetBit(this byte original, int pos, bool value)
        {
            if (value)
                return (byte)(original | 1 << pos);

            return (byte)(original & ~(1 << pos));
        }

        /// <summary>
        /// Returns the bit at the specified position.
        /// </summary>
        /// <param name="value">The byte to get the bit from.</param>
        /// <param name="pos">The position of the bit to get. (0 based)</param>
        /// <returns>The bit at the specified position.</returns>
        public static bool GetBit(this byte value, int pos)
        {
            return (value & 1 << pos) != 0;
        }
        #endregion
    }
}
