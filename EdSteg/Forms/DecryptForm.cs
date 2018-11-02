using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using EdSteg.Encryption;
using EdSteg.Storage;

namespace EdSteg.Forms
{
    /// <summary>
    /// Allows the user to read and decrypt messages.
    /// </summary>
    public partial class DecryptForm : Form
    {
        #region Fields

        /// <summary>
        /// The <see cref="IEncryptionProvider" /> used for decrypting data.
        /// </summary>
        private readonly IEncryptionProvider _encryptionProvider;

        /// <summary>
        /// The <see cref="IStorageProvider" /> used for reading files.
        /// </summary>
        private readonly IStorageProvider _storageProvider;

        #endregion

        #region Constructor

        public DecryptForm()
        {
            InitializeComponent();
        }

        public DecryptForm(IEncryptionProvider encryptionProvider, IStorageProvider storageProvider) : this()
        {
            _encryptionProvider = encryptionProvider;
            _storageProvider = storageProvider;
        }

        #endregion

        #region Methods

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = _storageProvider.ExportFileDialogFilter
            };

            // Show dialog
            if (dialog.ShowDialog() != DialogResult.OK) return;

            // Get file path
            string filePath = dialog.FileName;

            // Free memory
            dialog.Dispose();

            // Set file name label
            LblFilePath.Text = Path.GetFileName(filePath);

            // Create worker arguments
            Tuple<IEncryptionProvider, IStorageProvider, string> args =
                new Tuple<IEncryptionProvider, IStorageProvider, string>(_encryptionProvider,
                                                                         _storageProvider,
                                                                         filePath);

            // Run worker, disable button and start progress bar
            BtnBrowse.Enabled = false;
            Progress.Style = ProgressBarStyle.Marquee;
            Worker.RunWorkerAsync(args);
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get arguments
            Tuple<IEncryptionProvider, IStorageProvider, string> args =
                (Tuple<IEncryptionProvider, IStorageProvider, string>)e.Argument;

            IEncryptionProvider encryptionProvider = args.Item1;
            IStorageProvider storageProvider = args.Item2;
            string file = args.Item3;

            // Read cipher text from file
            byte[] cipherText;
            try
            {
                cipherText = storageProvider.Read(file);
            }
            catch (Exception ex)
            {
                // Exception occured whilst reading file, so wrap
                // exception nicely for display output
                throw new Exception($"An {ex.GetType().Name} occured whilst reading the file:\r\n{ex.Message}", ex);
            }

            // Decrypt back to plain text
            byte[] plainText;
            try
            {
                plainText = encryptionProvider.Decrypt(cipherText);
            }
            catch (Exception ex)
            {
                // Exception occured whilst decrypting text, so wrap
                // exception nicely for display output
                throw new Exception($"An {ex.GetType().Name} occured whilst decrypting the text:\r\n{ex.Message}", ex);
            }

            // Return string message
            e.Result = Encoding.UTF8.GetString(plainText);
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Re-enable browse button and stop progress bar
            BtnBrowse.Enabled = true;
            Progress.Style = ProgressBarStyle.Blocks;

            // Check an exception didn't occur
            if (e.Error == null)
            {
                // Display decrypted message
                TxtMessage.Text = (string)e.Result;
                TxtMessage.Enabled = true;
            }
            else
            {
                // Display error message
                MessageBox.Show(e.Error.Message);
            }
        }

        #endregion
    }
}