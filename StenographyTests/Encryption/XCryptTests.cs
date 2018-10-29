using System;
using System.Text;
using NUnit.Framework;

namespace Stenography.Encryption.Tests
{
    [TestFixture]
    public class XCryptTests
    {
        [Test]
        public void XCryptTest()
        {
            byte[] key = Encoding.UTF8.GetBytes("12345");

            XCrypt crypt = new XCrypt(key);

            Assert.AreEqual(key, crypt.Key);
        }

        [Test]
        public void EncryptTest()
        {
            byte[] key = Encoding.UTF8.GetBytes("12345");
            XCrypt crypt = new XCrypt(key);
            byte[] plainText = Encoding.UTF8.GetBytes("sample");
            byte[] expected = Encoding.UTF8.GetBytes("BS^DYT");

            byte[] actual = crypt.Encrypt(plainText);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void EncryptTest_EmptyKey()
        {
            byte[] key = new byte[0];
            XCrypt crypt = new XCrypt(key);
            byte[] plainText = Encoding.UTF8.GetBytes("sample");

            Assert.Throws<InvalidOperationException>(() => crypt.Encrypt(plainText));
        }

        [Test]
        public void DecryptTest()
        {
            byte[] key = Encoding.UTF8.GetBytes("12345");
            XCrypt crypt = new XCrypt(key);
            byte[] cipherText = Encoding.UTF8.GetBytes("BS^DYT");
            byte[] expected = Encoding.UTF8.GetBytes("sample");

            byte[] actual = crypt.Decrypt(cipherText);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void DecryptTest_EmptyKey()
        {
            byte[] key = new byte[0];
            XCrypt crypt = new XCrypt(key);
            byte[] cipherText = Encoding.UTF8.GetBytes("BS^DYT");

            Assert.Throws<InvalidOperationException>(() => crypt.Decrypt(cipherText));
        }
    }
}