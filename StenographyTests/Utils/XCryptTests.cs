using System;
using System.Text;
using NUnit.Framework;

namespace Stenography.Utils.Tests
{
    [TestFixture]
    public class BinaryUtilsTests
    {
        [Test]
        public void SetBitTest_High()
        {
            const byte original = 0b00001000;
            const byte expected = 0b00001100;

            Assert.AreEqual(BinaryUtils.SetBit(original, 2, true), expected);
        }

        [Test]
        public void SetBitTest_Low()
        {
            const byte original = 0b11110111;
            const byte expected = 0b11110011;

            Assert.AreEqual(BinaryUtils.SetBit(original, 2, false), expected);
        }
    }
}