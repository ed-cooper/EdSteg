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
        public byte[] Key { get; set; }
        #endregion
        #region Constructor
        public XCrypt(byte[] key)
        {
            Key = key;
        }
        #endregion
        #region Methods

        public byte[] Encrypt(byte[] plainText)
        {

        }

        public string Decrypt(byte[] cipherText)
        {

        }
    }
}
