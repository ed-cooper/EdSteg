using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stenography.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stenography.Encryption.Tests
{
    [TestClass()]
    public class XCryptTests
    {
        [TestMethod()]
        public void XCryptTest()
        {
            byte[] key = Encoding.UTF8.GetBytes("12345");
            XCrypt crypt = new XCrypt(key);

            Assert.AreEqual(crypt.Key, key);
        }
    }
}