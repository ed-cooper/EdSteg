using System;
using System.Threading.Tasks;

namespace Stenography.Encryption
{
    /// <summary>
    /// Provides encryption using the XOR cipher algorithm.
    /// </summary>
    public class XCrypt : IEncryptionProvider
    {

        #region Properties

        /// <summary>
        /// Gets or sets the key used for encryption.
        /// </summary>
        public byte[] Key { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the <see cref="XCrypt" /> class.
        /// </summary>
        /// <param name="key">The key to use for encryption.</param>
        public XCrypt(byte[] key)
        {
            Key = key;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plainText">The plain text to encrypt.</param>
        /// <returns>The encrypted version of the plain text.</returns>
        public byte[] Encrypt(byte[] plainText) => Crypt(plainText);

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text to decrypt.</param>
        /// <returns>The original plain text.</returns>
        public byte[] Decrypt(byte[] cipherText) => Crypt(cipherText);

        /// <summary>
        /// Encrypts or decrypts the data.
        /// </summary>
        /// <param name="data">The data to crypt.</param>
        /// <returns>The crypted data.</returns>
        /// <remarks>Use parallelism for efficiency.</remarks>
        protected virtual byte[] Crypt(byte[] data)
        {
            if ((Key != null) && (Key.Length > 0))
            {
                byte[] cipher = new byte[data.Length];

                // Make each processor carry out a portion of the work
                int degreeOfParallelism = Environment.ProcessorCount;
                Task[] tasks = new Task[degreeOfParallelism];

                // For each task
                for (int currentTask = 0; currentTask < degreeOfParallelism; currentTask++)
                {
                    // Prevents access issues of taskNumber from the lamba
                    int currentTaskCopy = currentTask;

                    tasks[currentTask] = Task.Factory.StartNew(() =>
                    {
                        // Cacha upper limit
                        int max = data.Length * (currentTaskCopy + 1) / degreeOfParallelism;

                        // Do work portion
                        for (int i = data.Length * currentTaskCopy / degreeOfParallelism; i < max; i++)
                            // Use XOR with key
                            cipher[i] = (byte)(data[i] ^ Key[i % Key.Length]);
                    });
                }

                // Wait for all tasks to complete
                Task.WaitAll(tasks);

                // Return output
                return cipher;
            }

            throw new InvalidOperationException("Invalid key");
        }

        #endregion
    }
}