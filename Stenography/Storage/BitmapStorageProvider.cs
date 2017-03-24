using Stenography.Utils;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;

namespace Stenography.Storage
{
    public class BitmapStorageProvider : IStorageProvider
    {
        #region Constants
        /// <summary>
        /// The format pixels should be read in.
        /// </summary>
        /// <remarks>Actual data is stored as BGRA.</remarks>
        protected const PixelFormat PixelDataFormat = PixelFormat.Format32bppPArgb;

        /// <summary>
        /// The number of bytes used to store a single channel.
        /// </summary>
        protected const byte BytesPerChannel = 1;

        /// <summary>
        /// The number of bytes used to store a single pixel.
        /// </summary>
        protected const byte BytesPerPixel = 4;
        #endregion
        #region Methods
        /// <summary>
        /// Saves the specified data to the specified file.
        /// </summary>
        /// <param name="file">The file to use as the base.</param>
        /// <param name="newPath">The path of the file to create.</param>
        /// <param name="data">The data to save.</param>
        public unsafe void Save(string file, string newPath, byte[] data)
        {
            // Create file header (stores data length)
            byte[] header = BitConverter.GetBytes(data.Length);

            // If on big endian system, switch to little endian
            if (BitConverter.IsLittleEndian)
                Array.Reverse(header);

            // Get raw save data
            byte[] allData = new byte[header.Length + data.Length];
            header.CopyTo(allData, 0);
            data.CopyTo(allData, header.Length);

            // Get individual bits from bit data
            BitArray bitData = new BitArray(allData);

            // Load image from file
            Bitmap image = new Bitmap(file);

            // Get bitmap data and lock in memory
            BitmapData bmpData = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadWrite,
                PixelDataFormat
            );
            
            // Scan start position
            byte* scan0 = (byte*)bmpData.Scan0;

            // Number of bytes scanned
            uint byteCount = 0;

            // Data position
            int dataPos = 0;

            // For each row
            for (int i = 0; i < bmpData.Height; i++)
            {
                // For each byte in each column (that contains data)
                for (int j = 0; j < bmpData.Width * BytesPerPixel; j++)
                {
                    // Get pointer to current byte
                    byte* scan = scan0 + i * bmpData.Stride + j * BytesPerChannel;

                    // Check not alpha channel (last channel)
                    if (byteCount % BytesPerPixel != BytesPerPixel)
                    {
                        // Get value to store
                        bool value = bitData[dataPos];

                        // Set LSB to value
                        *scan = (*scan).SetBit(0, value);

                        // Increment data pos
                        dataPos++;
                    }

                    // Increment byte counter
                    byteCount++;
                }
            }

            // Store new data and unlock memory
            image.UnlockBits(bmpData);

            // Save bitmap
            image.Save(newPath);
        }

        /// <summary>
        /// Reads the data from the specified file.
        /// </summary>
        /// <param name="path">The file to read the data from.</param>
        /// <returns>The data from the speciied file.</returns>
        public unsafe byte[] Read(string path)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
