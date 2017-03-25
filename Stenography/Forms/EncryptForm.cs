using Stenography.Encryption;
using Stenography.Storage;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Stenography.Forms
{
    public partial class EncryptForm : Form
    {
        #region Fields
        /// <summary>
        /// The <see cref="IEncryptionProvider"/> used for encrypting data. 
        /// </summary>
        IEncryptionProvider EncryptionProvider;

        /// <summary>
        /// The <see cref="IStorageProvider"/> used for saving files. 
        /// </summary>
        IStorageProvider StorageProvider;
        #endregion
        #region Constructor
        public EncryptForm()
        {
            InitializeComponent();
        }

        public EncryptForm(IEncryptionProvider encryptionProvider, IStorageProvider storageProvider) : this()
        {
            EncryptionProvider = encryptionProvider;
            StorageProvider = storageProvider;
        }
        #endregion
        #region Methods
        private void BtnOriginalBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LblOriginalPath.Text = Path.GetFileName(dialog.FileName);
                LblOriginalPath.Tag = dialog.FileName;
            }
        }

        private void BtnSaveBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LblSavePath.Text = Path.GetFileName(dialog.FileName);
                LblSavePath.Tag = dialog.FileName;
            }
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            // Check inputs are valid
            if (CheckInputs())
            {
                // Get plain text as byte array
                byte[] plainText = Encoding.Default.GetBytes(TxtMessage.Text);

                // Encrypt text
                byte[] cipherText = EncryptionProvider.Encrypt(plainText);

                // Store cipher text
                StorageProvider.Save((string)LblOriginalPath.Tag, (string)LblSavePath.Tag, cipherText);

                // Select file in file explorer
                Process.Start("explorer.exe", $"/select, \"{LblSavePath.Tag}\"");
            }
        }
        
        /// <summary>
        /// Checks if the inputs submitted are valid and displays any error messages.
        /// </summary>
        /// <returns>Whether the inputs were valid.</returns>
        protected virtual bool CheckInputs()
        {
            if (string.IsNullOrEmpty(TxtMessage.Text))
            {
                // No message
                MessageBox.Show("Please enter a message to show");
                return false;
            }
            else if (string.IsNullOrEmpty((string)LblOriginalPath.Tag))
            {
                // No original file
                MessageBox.Show("Please select the original file to hide the data inside");
                return false;
            }
            else if (string.IsNullOrEmpty((string)LblSavePath.Tag))
            {
                // No save file
                MessageBox.Show("Please select a path to save the new file to");
                return false;
            }
            else if (string.Equals((string)LblOriginalPath.Tag, (string)LblSavePath.Tag, StringComparison.CurrentCultureIgnoreCase))
            {
                // Original file path and save file path are the same
                MessageBox.Show("The original file path and save file path must be different");
                return false;
            }

            // Validation successful
            return true;
        }
        #endregion
    }
}
