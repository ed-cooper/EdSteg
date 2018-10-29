using System;
using System.IO;
using NUnit.Framework;
using Stenography.Noise;

namespace Stenography.Storage.Tests
{
    [TestFixture]
    public class LsbStorageProviderTests
    {
        [Test]
        public void ConstructorTest()
        {
            INoiseProvider noiseProvider = new ConstantNoiseProvider();

            LsbStorageProvider storageProvider = new LsbStorageProvider(noiseProvider);

            Assert.AreEqual(noiseProvider, storageProvider.NoiseProvider);
        }

        [Test]
        public void SaveTest()
        {
            LsbStorageProvider provider = new LsbStorageProvider(new ConstantNoiseProvider());
            string inputFile = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Resources\TestImage0.png");
            string outputFile = Path.GetTempFileName();
            string expectedFile = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Resources\TestImage1.png");
            byte[] saveData = { 66, 83, 94, 68, 89, 84 };

            provider.Save(inputFile, outputFile, saveData);

            try
            {
                FileAssert.AreEqual(expectedFile, outputFile);
            }
            finally
            {
                File.Delete(outputFile);
            }
        }

        [Test]
        public void SaveTest_DataTooLarge()
        {
            LsbStorageProvider provider = new LsbStorageProvider();
            string inputFile = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Resources\TestImage0.png");
            string outputFile = Path.GetTempFileName();
            byte[] saveData = { 66, 83, 94, 68, 89, 84, 66, 83, 94, 68, 89, 84 };

            try
            {
                Assert.Throws<ArgumentException>(() => provider.Save(inputFile, outputFile, saveData));
            }
            finally
            {
                File.Delete(outputFile);
            }
        }

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