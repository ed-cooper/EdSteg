using Stenography.Encryption;
using Stenography.Storage;
using System;
using System.ComponentModel;
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
                // Create worker arguments
                Tuple<IEncryptionProvider, IStorageProvider, string, string, string> args
                    = new Tuple<IEncryptionProvider, IStorageProvider, string, string, string>(
                        EncryptionProvider, 
                        StorageProvider, 
                        TxtMessage.Text,
                        (string)LblOriginalPath.Tag,
                        (string)LblSavePath.Tag
                    );

                // Run worker and disable go button
                BtnGo.Enabled = false;
                Worker.RunWorkerAsync(args);
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
            else if (Worker.IsBusy)
            {
                // Worker already busy
                // (This case should be prevented by having BtnGo disabled whilst busy)
                MessageBox.Show("Please wait for the current action to complete");
                return false;
            }

            // Validation successful
            return true;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get arguments
            Tuple<IEncryptionProvider, IStorageProvider, string, string, string> args =
                (Tuple<IEncryptionProvider, IStorageProvider, string, string, string>)e.Argument;

            IEncryptionProvider encryptionProvider = args.Item1;
            IStorageProvider storageProvider = args.Item2;
            string message = args.Item3;
            string originalPath = args.Item4;
            string savePath = args.Item5;

            // Get plain text as byte array
            byte[] plainText = Encoding.Default.GetBytes(message);

            // Encrypt text
            byte[] cipherText = encryptionProvider.Encrypt(plainText);

            // Store cipher text
            storageProvider.Save(originalPath, savePath, cipherText);
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Re-enable go button
            BtnGo.Enabled = true;

            // Open file explorer at saved file
            Process.Start("explorer.exe", $"/select, \"{LblSavePath.Tag}\"");
        }
        #endregion
    }
}
