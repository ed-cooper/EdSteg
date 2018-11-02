using NUnit.Framework;

namespace EdSteg.Noise.Tests
{
    [TestFixture]
    public class ConstantNoiseProviderTests
    {
        [Test]
        public void NextTest_High()
        {
            ConstantNoiseProvider noiseProvider = new ConstantNoiseProvider(true);
            int trueCount = 0;

            for (int i = 0; i < 200; i++)
                if (noiseProvider.Next()) trueCount++;

            Assert.AreEqual(200, trueCount);
        }

        [Test]
        public void NextTest_Low()
        {
            ConstantNoiseProvider noiseProvider = new ConstantNoiseProvider(false);
            int trueCount = 0;

            for (int i = 0; i < 200; i++)
                if (noiseProvider.Next()) trueCount++;

            Assert.AreEqual(0, trueCount);
        }
    }
}