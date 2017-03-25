using Stenography.Encryption;
using Stenography.Storage;
using System;
using System.ComponentModel;
using System.IO;
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
            dialog.Filter = StorageProvider.ExportFileDialogFilter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Set file name label
                LblFilePath.Text = Path.GetFileName(dialog.FileName);

                // Create worker arguments
                Tuple<IEncryptionProvider, IStorageProvider, string> args =
                    new Tuple<IEncryptionProvider, IStorageProvider, string>(
                        EncryptionProvider,
                        StorageProvider,
                        dialog.FileName
                    );

                // Run worker and disable button
                BtnBrowse.Enabled = false;
                Worker.RunWorkerAsync(args);
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get arguments
            Tuple<IEncryptionProvider, IStorageProvider, string> args =
                (Tuple< IEncryptionProvider, IStorageProvider, string>)e.Argument;

            IEncryptionProvider encryptionProvider = args.Item1;
            IStorageProvider storageProvider = args.Item2;
            string file = args.Item3;

            // Read cipher text from file
            byte[] cipherText = storageProvider.Read(file);

            // Decrypt back to plain text
            byte[] plainText = encryptionProvider.Decrypt(cipherText);

            // Return string message
            e.Result = Encoding.Default.GetString(plainText);
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Re-enable browse button
            BtnBrowse.Enabled = true;

            // Display decrypted message
            TxtMessage.Text = (string)e.Result;
        }
        #endregion
    }
}
