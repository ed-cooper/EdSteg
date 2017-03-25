using Stenography.Encryption;
using Stenography.Storage;
using System;
using System.Text;
using System.Windows.Forms;

namespace Stenography.Forms
{
    public partial class DecryptForm : Form
    {
        #region Fields
        /// <summary>
        /// The <see cref="IEncryptionProvider"/> used for decrypting data. 
        /// </summary>
        IEncryptionProvider EncryptionProvider;

        /// <summary>
        /// The <see cref="IStorageProvider"/> used for reading files. 
        /// </summary>
        IStorageProvider StorageProvider;
        #endregion
        #region Constructor
        public DecryptForm()
        {
            InitializeComponent();
        }

        public DecryptForm(IEncryptionProvider encryptionProvider, IStorageProvider storageProvider) : this()
        {
            EncryptionProvider = encryptionProvider;
            StorageProvider = storageProvider;
        }
        #endregion
        #region Methods
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Read cipher text from file
                byte[] cipherText = StorageProvider.Read(dialog.FileName);

                // Decrypt back to plain text
                byte[] plainText = EncryptionProvider.Decrypt(cipherText);

                // Display message
                TxtMessage.Text = Encoding.Default.GetString(plainText);
            }
        }
        #endregion
    }
}
