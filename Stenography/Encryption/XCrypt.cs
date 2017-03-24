using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stenography.Encryption
{
    public class XCrypt : IEncryptionProvider
    {
        #region Properties
        /// <summary>
        /// Gets or sets the key used for encryption.
        /// </summary>
        public byte[] Key { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="XCrypt"/> class. 
        /// </summary>
        /// <param name="key">The key to use for encryption.</param>
        public XCrypt(byte[] key)
        {
            Key = key;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plainText">The plain text to encrypt.</param>
        /// <returns>The encrypted version of the plain text.</returns>
        public byte[] Encrypt(byte[] plainText)
        {
            
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text to decrypt.</param>
        /// <returns>The original plain text.</returns>
        public string Decrypt(byte[] cipherText)
        {

        }

        /// <summary>
        /// Encrypts or decrypts the data.
        /// </summary>
        /// <param name="data">The data to crypt.</param>
        /// <returns>The crypted data.</returns>
        protected virtual byte[] Crypt(byte[] data)
        {
            if (Key != null && Key.Length > 0)
            {

            }
            else
            {
                throw new InvalidOperationException("Invalid key");
            }
        }
        #endregion
    }
}
