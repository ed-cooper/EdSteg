using System;
using System.Drawing;
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
            string inputFile = Path.Combine(TestContext.CurrentContext.TestDirectory, $"Resources{Path.DirectorySeparatorChar}TestImage0.png");
            string outputFile = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.png");
            string expectedFile = Path.Combine(TestContext.CurrentContext.TestDirectory, $"Resources{Path.DirectorySeparatorChar}TestImage1.png");
            byte[] saveData = { 66, 83, 94, 68, 89, 84 };

            provider.Save(inputFile, outputFile, saveData);

            // Travis test:
            Console.WriteLine(outputFile);
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(File.ReadAllBytes(outputFile)));
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(File.ReadAllBytes(expectedFile)));

            // Load images
            Bitmap expected = new Bitmap(expectedFile);
            Bitmap actual = new Bitmap(outputFile);

            try
            {
                bool fail = (expected.Width != actual.Width) || (expected.Height != actual.Height);

                if (!fail)
                {
                    // Compare pixel by pixel (due to encoding differences on Mono)
                    for (int i = 0; i < expected.Width; i++)
                    {
                        for (int j = 0; j < expected.Height; j++)
                        {
                            if (expected.GetPixel(i, j) != actual.GetPixel(i, j))
                            {
                                fail = true;
                            }
                        }
                    }
                }

                Assert.AreEqual(false, fail);
            }
            finally
            {
                expected.Dispose();
                actual.Dispose();
                File.Delete(outputFile);
            }
        }

        [Test]
        public void SaveTest_DataTooLarge()
        {
            LsbStorageProvider provider = new LsbStorageProvider();
            string inputFile = Path.Combine(TestContext.CurrentContext.TestDirectory, $"Resources{Path.DirectorySeparatorChar}TestImage0.png");
            string outputFile = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.png");
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
            string filename = Path.Combine(TestContext.CurrentContext.TestDirectory, $"Resources{Path.DirectorySeparatorChar}TestImage1.png");
            byte[] expected = { 66, 83, 94, 68, 89, 84 };

            byte[] actual = provider.Read(filename);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ReadTest_Corrupt()
        {
            LsbStorageProvider provider = new LsbStorageProvider();
            string filename = Path.Combine(TestContext.CurrentContext.TestDirectory, $"Resources{Path.DirectorySeparatorChar}TestImage2.png");

            Assert.Throws<InvalidOperationException>(() => provider.Read(filename));
        }

        [Test]
        public void GetStoragePotentialTest()
        {
            LsbStorageProvider provider = new LsbStorageProvider();
            string filename = Path.Combine(TestContext.CurrentContext.TestDirectory, $"Resources{Path.DirectorySeparatorChar}TestImage0.png");
            int expected = 9;

            int actual = provider.GetStoragePotential(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}