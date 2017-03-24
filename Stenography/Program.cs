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
using Stenography.Storage;

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

                IStorageProvider storageProvider = new BitmapStorageProvider();

                storageProvider.Save(openFile.FileName, "test.png", cipher);
            }
            else
            {
                Console.WriteLine("Operation cancelled");
            }
        }
    }
}
