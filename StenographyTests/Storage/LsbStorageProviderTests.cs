using System;
using System.IO;
using NUnit.Framework;

namespace Stenography.Storage.Tests
{
    [TestFixture]
    public class LsbStorageProviderTests
    {
        [Test]
        public void ReadTest()
        {
            LsbStorageProvider provider = new LsbStorageProvider();
            string filename = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Resources\TestImage1.png");
            byte[] expected = { 66, 83, 94, 68, 89, 84 };

            byte[] actual = provider.Read(filename);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ReadTest_Corrupt()
        {
            LsbStorageProvider provider = new LsbStorageProvider();
            string filename = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Resources\TestImage2.png");

            Assert.Throws<InvalidOperationException>(() => provider.Read(filename));
        }

        [Test]
        public void GetStoragePotentialTest()
        {
            LsbStorageProvider provider = new LsbStorageProvider();
            string filename = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Resources\TestImage0.png");
            int expected = 9;

            int actual = provider.GetStoragePotential(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}