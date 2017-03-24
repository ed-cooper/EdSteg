namespace Stenography.Utils
{
    static class Converters
    {
        /// <summary>
        /// Converts the specified boolean array into a byte array, where each boolean is 1 bit.
        /// </summary>
        /// <param name="data">The array to convert into a byte array.</param>
        /// <returns>
        /// The byte array containing all the boolean values as bits.
        /// </returns>
        public static byte[] ToByteArray(this bool[] data)
        {
            // Cache data length
            int len = data.Length;

            // Get number of bytes needed (len >> 3 is len / 8)
            int bytes = len >> 3;

            // Check there is a whole number of bytes, if not, add 1 to bytes
            if ((len & 0x07) != 0)
                bytes++;

            // Create blank output array
            byte[] output = new byte[bytes];

            // For each bit
            for (int i = 0; i < data.Length; i++)
            {
                // Bits default to 0, so only set where the value is 1
                if (data[i])
                    output[i >> 3] |= (byte)(1 << (i & 0x07));
            }

            // Return output
            return output;
        }
    }
}
