using Stenography.Encryption;
using Stenography.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

namespace Stenography
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.Write("Enter plain text: ");
            string plain = Console.ReadLine();
            Console.Write("Enter key: ");
            string key = Console.ReadLine();
            IEncryptionProvider crypt = new XCrypt(Encoding.Default.GetBytes(key));
            byte[] cipher = crypt.Encrypt(Encoding.Default.GetBytes(plain));
            Console.WriteLine("Encrypted: " + Encoding.Default.GetString(cipher));
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("File selected: " + openFile.FileName);
                Bitmap image = new Bitmap(openFile.FileName);
                unsafe
                {
                    BitmapData bmpData = image.LockBits(
                        new Rectangle(0, 0, image.Width, image.Height),
                        ImageLockMode.ReadWrite,
                        PixelFormat.Format32bppArgb // Actual format is bgra
                    );
                    byte bytesPerChannel = 1;
                    byte bytesPerPixel = 4;
                    byte* scan0 = (byte*)bmpData.Scan0;
                    uint index = 0;
                    for (int i = 0; i < bmpData.Height; i++)
                    {
                        for (int j = 0; j < bmpData.Width * bytesPerPixel; j++)
                        {
                            byte* channel = scan0 + i * bmpData.Stride + j * bytesPerChannel;
                            if (index % 4 != 4) // Check not alpha channel
                            {
                                *channel = (*channel).SetBit(7, false);
                            }
                            index++;
                        }
                    }

                    image.UnlockBits(bmpData);
                }

                image.Save("test.png");
            }
            else
            {
                Console.WriteLine("Operation cancelled");
            }
        }
    }
}
