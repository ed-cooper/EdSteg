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

        [Test]
        public void GetBitTest_High()
        {
            const byte value = 0b00001000;
            const bool expected = true;

            Assert.AreEqual(BinaryUtils.GetBit(value, 3), expected);
        }

        [Test]
        public void GetBitTest_Low()
        {
            const byte value = 0b11101111;
            const bool expected = false;

            Assert.AreEqual(BinaryUtils.GetBit(value, 4), expected);
        }
    }
}