using Stenography.Encryption;
using System;
using System.Windows.Forms;
using System.Text;
using Stenography.Storage;
using Stenography.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartupForm());
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
                Console.WriteLine("File saved");
                Console.WriteLine("Reading file");
                cipher = storageProvider.Read("test.png");
                Console.WriteLine("Read cipher text: " + Encoding.Default.GetString(cipher));
                Console.WriteLine("Decrypted: " + Encoding.Default.GetString(crypt.Decrypt(cipher)));
            }
            else
            {
                Console.WriteLine("Operation cancelled");
            }

            Console.Read();
        }
    }
}
