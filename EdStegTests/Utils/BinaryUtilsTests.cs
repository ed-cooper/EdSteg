using NUnit.Framework;

namespace EdSteg.Utils.Tests
{
    [TestFixture]
    public class BinaryUtilsTests
    {
        [Test]
        public void SetBitTest_High()
        {
            const byte original = 0b00001000;
            const byte expected = 0b00001100;

            byte actual = BinaryUtils.SetBit(original, 2, true);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetBitTest_Low()
        {
            const byte original = 0b11110111;
            const byte expected = 0b11110011;

            byte actual = BinaryUtils.SetBit(original, 2, false);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetBitTest_High()
        {
            const byte value = 0b00001000;
            const bool expected = true;

            bool actual = BinaryUtils.GetBit(value, 3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetBitTest_Low()
        {
            const byte value = 0b11101111;
            const bool expected = false;

            bool actual = BinaryUtils.GetBit(value, 4);

            Assert.AreEqual(expected, actual);
        }
    }
}