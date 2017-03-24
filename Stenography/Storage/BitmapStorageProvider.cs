﻿using Stenography.Utils;
using System;
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
        /// <param name="path">The file to save the data to.</param>
        /// <param name="data">The data to save.</param>
        public unsafe void Save(string path, byte[] data)
        {
            // Load image from file
            Bitmap image = new Bitmap(path);

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
                        // Set LSB to next bit
                        *scan = (*scan).SetBit(0, false);
                    }

                    // Increment byte counter
                    byteCount++;
                }
            }

            // Store new data and unlock memory
            image.UnlockBits(bmpData);
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
