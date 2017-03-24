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
            int len = data.Length;
            int bytes = len >> 3;
            if ((len & 0x07) != 0) ++bytes;
            byte[] arr2 = new byte[bytes];
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i])
                    arr2[i >> 3] |= (byte)(1 << (i & 0x07));
            }

            return arr2;
        }
    }
}
