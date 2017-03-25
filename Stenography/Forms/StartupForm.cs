using Stenography.Encryption;
using Stenography.Storage;
using System;
using System.Text;
using System.Windows.Forms;

namespace Stenography.Forms
{
    public partial class StartupForm : Form
    {
        #region Constructor
        public StartupForm()
        {
            InitializeComponent();
        }
        #endregion
        #region Methods
        private void FormMain_Load(object sender, EventArgs e)
        {
            // Set defaults
            CmbEncryption.SelectedIndex = 0;
            CmbStorage.SelectedIndex = 0;
        }

        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            if (CheckInputs())
                new EncryptForm(GetEncrpytionProvider(), GetStorageProvder()).ShowDialog();
        }

        private void BtnDecrypt_Click(object sender, EventArgs e)
        {
            if (CheckInputs())
                new DecryptForm(GetEncrpytionProvider(), GetStorageProvder()).ShowDialog();
        }

        /// <summary>
        /// Checks if the inputs enterred are valid and displays any error messages.
        /// </summary>
        /// <returns>Whether the inputs were valid.</returns>
        protected virtual bool CheckInputs()
        {
            if (string.IsNullOrEmpty(TxtKey.Text))
            {
                // Key not entered
                MessageBox.Show("Please enter a key");
                return false;
            }
            else if (TxtKey.Text.Length < 8)
            {
                // Key not long enough (min 8 characters)
                MessageBox.Show("Keys must be longer than 8 characters for security");
                return false;
            }

            // Validation successful
            return true;
        }

        /// <summary>
        /// Returns the selected <see cref="IEncryptionProvider"/> object.
        /// </summary>
        /// <returns>The selected <see cref="IEncryptionProvider"/> object.</returns>
        protected virtual IEncryptionProvider GetEncrpytionProvider()
        {
            byte[] key = Encoding.UTF8.GetBytes(TxtKey.Text);

            switch (CmbEncryption.SelectedIndex)
            {
                case 0: // XOR Crypt (default)
                    return new XCrypt(key);
                default:
                    throw new ArgumentException("Unknown selected index for CmbEncryption");
            }
        }

        /// <summary>
        /// Returns the selected <see cref="IStorageProvider"/> object. 
        /// </summary>
        /// <returns>The selected <see cref="IStorageProvider"/> object.</returns>
        protected virtual IStorageProvider GetStorageProvder()
        {
            switch (CmbStorage.SelectedIndex)
            {
                case 0: // LSB (default)
                    return new LsbStorageProvider();
                default:
                    throw new ArgumentException("Unknown selected index for CmbStorage");
            }
        }
        #endregion
    }
}
