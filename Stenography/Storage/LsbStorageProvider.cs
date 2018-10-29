using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using Stenography.Utils;

namespace Stenography.Storage
{
    /// <summary>
    /// Provides storage by saving data in the least significant bit of pixel channels.
    /// </summary>
    public class LsbStorageProvider : IStorageProvider
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

        /// <summary>
        /// The number of bits that can be stored per pixel.
        /// </summary>
        protected const byte BitStoragePerPixel = BytesPerPixel - BytesPerChannel;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the dialog file filter to be used for browsing files to import.
        /// </summary>
        public string ImportFileDialogFilter { get; } =
            "Image Files (*.jpg, *.png, *.bmp, *.gif, *.tiff, *.exif)|*.jpg;*.png;*.bmp;*.gif;*.tiff;*.exif|All Files (*.*)|*.*";

        /// <summary>
        /// Gets the dialog file filter to be used for browsing exported files.
        /// </summary>
        public string ExportFileDialogFilter { get; } =
            "PNG Files (*.png)|*.png|All Files (*.*)|*.*";

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
            // Check original file path and save file path are not the same
            // (Otherwise ExternalException will occur on image.Save)
            if (file == newPath)
                throw new ArgumentException("Original file path cannot be same as save file path", nameof(file));

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

            // Check image is big enough to store all data
            if (image.Width * image.Height * BitStoragePerPixel < bitData.Length)
                throw new ArgumentException("Data too large to store in image", nameof(data));

            // Get bitmap data and lock in memory
            BitmapData bmpData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                                ImageLockMode.ReadWrite,
                                                PixelDataFormat);

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
            image.Save(newPath, ImageFormat.Png);

            // Free memory
            image.Dispose();
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
            BitmapData bmpData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                                ImageLockMode.ReadWrite,
                                                PixelDataFormat);

            // Store steg data from image
            byte[] byteData = new byte[bmpData.Width * bmpData.Width / 8 * (BytesPerPixel - 1) * BytesPerChannel];

            // Scan start position
            byte* scan0 = (byte*)bmpData.Scan0;

            // Number of bytes scanned
            uint byteCount = 0;

            // Number of bits stores
            int bitCount = 0;

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
                        if ((*scan).GetBit(0))
                            byteData[bitCount / 8] |= (byte)(1 << (bitCount % 8));

                        // Move to next bit
                        bitCount++;
                    }

                    // Increment byte counter
                    byteCount++;
                }
            }

            // Unlock memory
            image.UnlockBits(bmpData);
            image.Dispose();

            // Process data

            int length;
            if (BitConverter.IsLittleEndian)
                length = BitConverter.ToInt32(new[]
                                              {
                                                  byteData[3],
                                                  byteData[2],
                                                  byteData[1],
                                                  byteData[0]
                                              },
                                              0);
            else
                length = BitConverter.ToInt32(byteData, 0);

            // Check length is valid
            if (length + 4 > byteData.Length)
                throw new InvalidOperationException("Steg data is corrupt");

            // Get relevant data
            byte[] data = new byte[length];
            Buffer.BlockCopy(byteData, 4, data, 0, length);

            // Return data
            return data;
        }

        /// <summary>
        /// Returns the max number of bytes that could be encoded within the specified file.
        /// </summary>
        /// <param name="file">The file to test.</param>
        /// <returns>The max number of bytes that could be encoded within the specified file.</returns>
        /// <remarks>Returns 0 for invalid files.</remarks>
        public int GetStoragePotential(string file)
        {
            Bitmap image;
            try
            {
                image = new Bitmap(file);
            }
            catch
            {
                return 0;
            }

            return image.Width * image.Height * BitStoragePerPixel / 8 - 4;
        }

        #endregion
    }
}