using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stenography.Encryption;
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
            Console.WriteLine("Decrypted: " + Encoding.Default.GetString(crypt.Decrypt(cipher)));
            Console.Read();

        }
    }
}
