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
        public string Key { get; set; }
        #endregion
        #region Constructor
        public XCrypt(string key)
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
