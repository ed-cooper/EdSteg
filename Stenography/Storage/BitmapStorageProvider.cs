using Stenography.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
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
        protected const PixelFormat PixelDataFormat = PixelFormat.Format32bppArgb;

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

            // Create random number generator
            Random rand = new Random();

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

                    // Check current byte isn't alpha channel (last channel)
                    if (byteCount % BytesPerPixel != BytesPerPixel - 1)
                    {
                        // Get value to store
                        bool value;
                        if (dataPos < bitData.Length)
                        {
                            value = bitData[dataPos];

                            // Increment data pos
                            dataPos++;
                        }
                        else
                        {
                            // Use random value (to disguise end of data)
                            value = rand.NextDouble() > 0.5;
                        }

                        // Set LSB to value
                        *scan = (*scan).SetBit(0, value);
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
            // Load image from file
            Bitmap image = new Bitmap(path);
            
            // Get bitmap data and lock in memory
            BitmapData bmpData = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadWrite,
                PixelDataFormat
            );

            // Store raw data from image
            List<bool> rawData = new List<bool>();

            // Scan start position
            byte* scan0 = (byte*)bmpData.Scan0;

            // Number of bytes scanned
            uint byteCount = 0;

            // For each row
            for (int i = 0; i < bmpData.Height; i++)
            {
                // For each byte in each column (that contains data)
                for (int j = 0; j < bmpData.Width * BytesPerPixel; j++)
                {
                    // Get pointer to current byte
                    byte* scan = scan0 + i * bmpData.Stride + j * BytesPerChannel;

                    // Check current byte isn't alpha channel (last channel)
                    if (byteCount % BytesPerPixel != BytesPerPixel - 1)
                    {
                        // Store current bit
                        rawData.Add((*scan).GetBit(0));
                    }

                    // Increment byte counter
                    byteCount++;
                }
            }

            // Unlock memory
            image.UnlockBits(bmpData);

            // Process data

            // Convert bool data to byte array
            byte[] byteData = ConvertToByteArray(rawData.ToArray());

            int length;
            if (BitConverter.IsLittleEndian)
            {
                length = BitConverter.ToInt32(new byte[4] {
                    byteData[3],
                    byteData[2],
                    byteData[1],
                    byteData[0]
                }, 0);
            }
            else
            {
                length = BitConverter.ToInt32(byteData, 0);
            }
            
            // Return data
            return null;
        }

        /// <summary>
        /// Bit-packs an array of booleans into bytes, one bit per boolean.
        /// </summary>
        /// <param name="data">An array of booleans to pack into bytes.</param>
        /// <returns>
        /// An IEnumerable&lt;byte&gt; of bytes each containing (up to) eight
        /// bit-packed booleans.
        /// </returns>
        /// <remarks>
        /// Booleans are bit-packed into bytes, in order, from least significant
        /// bit to most significant bit of each byte.<br/>
        /// If the length of the input array isn't a multiple of eight, then one
        /// or more of the most significant bits in the last byte returned will
        /// be unused. Unused bits are zero / unset.
        /// </remarks>
        byte[] ConvertToByteArray(bool[] data)
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
        #endregion
    }
}
