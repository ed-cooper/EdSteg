namespace Stenography.Encryption
{
    interface IEncryptionProvider
    {
        #region Properties
        /// <summary>
        /// Gets or sets the key used for encryption.
        /// </summary>
        byte[] Key { get; set; }
        #endregion
        #region Functions
        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plainText">The plain text to encrypt.</param>
        /// <returns>The encrypted version of the plain text.</returns>
        byte[] Encrypt(byte[] plainText);

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text to decrypt.</param>
        /// <returns>The original plain text.</returns>
        string Decrypt(byte[] cipherText);
        #endregion
    }
}
