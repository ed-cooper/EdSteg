using NUnit.Framework;

namespace Stenography.Noise.Tests
{
    [TestFixture]
    public class RandomNoiseProviderTests
    {
        [Test]
        public void NextTest()
        {
            RandomNoiseProvider noiseProvider = new RandomNoiseProvider();
            int trueCount = 0;

            for (int i = 0; i < 200; i++)
                if (noiseProvider.Next()) trueCount++;

            Assert.That(trueCount, Is.InRange(80, 120));
        }
    }
}