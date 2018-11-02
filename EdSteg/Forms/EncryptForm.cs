using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using EdSteg.Encryption;
using EdSteg.Storage;

namespace EdSteg.Forms
{
    /// <summary>
    /// Allows the user to save and encrpyt messages.
    /// </summary>
    public partial class EncryptForm : Form
    {
        #region Fields

        /// <summary>
        /// The <see cref="IEncryptionProvider" /> used for encrypting data.
        /// </summary>
        private readonly IEncryptionProvider _encryptionProvider;

        /// <summary>
        /// The <see cref="IStorageProvider" /> used for saving files.
        /// </summary>
        private readonly IStorageProvider _storageProvider;

        /// <summary>
        /// The maximum potential storage in bytes of the current file.
        /// </summary>
        private int _storagePotential;

        #endregion

        #region Constructor

        public EncryptForm()
        {
            InitializeComponent();
        }

        public EncryptForm(IEncryptionProvider encryptionProvider, IStorageProvider storageProvider) : this()
        {
            _encryptionProvider = encryptionProvider;
            _storageProvider = storageProvider;
        }

        #endregion

        #region Methods

        private void TxtMessage_TextChanged(object sender, EventArgs e)
        {
            UpdateStorageLabel();
        }

        private void BtnOriginalBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = _storageProvider.ImportFileDialogFilter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Store file path and free memory
                string filePath = dialog.FileName;
                dialog.Dispose();

                int storagePotential = _storageProvider.GetStoragePotential(filePath);
                if (storagePotential != 0)
                {
                    // File is valid
                    LblOriginalPath.Text = Path.GetFileName(filePath);
                    LblOriginalPath.Tag = filePath;
                    TxtMessage.MaxLength = storagePotential;
                    _storagePotential = storagePotential;
                    UpdateStorageLabel();
                }
                else
                {
                    // Invalid file
                    MessageBox.Show("Invalid file format");
                }
            }
        }

        private void BtnSaveBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = _storageProvider.ExportFileDialogFilter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LblSavePath.Text = Path.GetFileName(dialog.FileName);
                LblSavePath.Tag = dialog.FileName;
            }
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            // Check inputs are valid
            if (!CheckInputs()) return;

            // Create worker arguments
            Tuple<IEncryptionProvider, IStorageProvider, string, string, string> args
                = new Tuple<IEncryptionProvider, IStorageProvider, string, string, string>(_encryptionProvider,
                                                                                           _storageProvider,
                                                                                           TxtMessage.Text,
                                                                                           (string)LblOriginalPath.Tag,
                                                                                           (string)LblSavePath.Tag);

            // Run worker, disable go button and show progress bar
            Progress.Show();
            BtnGo.Enabled = false;
            Worker.RunWorkerAsync(args);
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

            if (string.IsNullOrEmpty((string)LblOriginalPath.Tag))
            {
                // No original file
                MessageBox.Show("Please select the original file to hide the data inside");
                return false;
            }

            if (string.IsNullOrEmpty((string)LblSavePath.Tag))
            {
                // No save file
                MessageBox.Show("Please select a path to save the new file to");
                return false;
            }

            if (string.Equals((string)LblOriginalPath.Tag,
                              (string)LblSavePath.Tag,
                              StringComparison.CurrentCultureIgnoreCase))
            {
                // Original file path and save file path are the same
                MessageBox.Show("The original file path and save file path must be different");
                return false;
            }

            if (Worker.IsBusy)
            {
                // Worker already busy
                // (This case should be prevented by having BtnGo disabled whilst busy)
                MessageBox.Show("Please wait for the current action to complete");
                return false;
            }

            // Validation successful
            return true;
        }

        /// <summary>
        /// Main encryption and storage work.
        /// </summary>
        /// <remarks>Use worker to keep UI thread responsive.</remarks>
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
            byte[] plainText = Encoding.UTF8.GetBytes(message);

            // Encrypt text
            byte[] cipherText;
            try
            {
                cipherText = encryptionProvider.Encrypt(plainText);
            }
            catch (Exception ex)
            {
                // Exception occured whilst encrypting text, so wrap
                // exception nicely for display output
                throw new Exception($"An {ex.GetType().Name} occured whilst encrypting the text:\r\n{ex.Message}", ex);
            }

            // Store cipher text
            try
            {
                storageProvider.Save(originalPath, savePath, cipherText);
            }
            catch (Exception ex)
            {
                // Exception occured whilst storing file, so wrap
                // exception nicely for display output
                throw new Exception($"An {ex.GetType().Name} occured whilst storing the file:\r\n{ex.Message}", ex);
            }
        }

        /// <summary>
        /// Occurs when the action is complete (or failed).
        /// </summary>
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Re-enable go button and hide progress bar
            BtnGo.Enabled = true;
            Progress.Hide();

            // Check there wasn't an error
            if (e.Error == null)
            {
                // Ask user if they want to view the file
                if (MessageBox.Show("Task completed. Do you want to view the file in File Explorer?",
                                    "Ed Steg",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Process.Start("explorer.exe", $"/select, \"{LblSavePath.Tag}\"");
                }
            }
            else
            {
                // Display error message
                MessageBox.Show(e.Error.Message);
            }
        }

        /// <summary>
        /// Updates <see cref="LblStorage" />.
        /// </summary>
        protected virtual void UpdateStorageLabel()
        {
            // Get number of bytes in textbox (using UTF8 encoding)
            int byteCount = Encoding.UTF8.GetByteCount(TxtMessage.Text);
            if (LblOriginalPath.Tag != null)
            {
                // Byte limit is known
                LblStorage.Text = $"{byteCount} / {_storagePotential} bytes";
                LblStorage.ForeColor = byteCount + 20 > _storagePotential ? Color.Red : Color.Gray;
            }
            else
            {
                // Byte limit unknown
                LblStorage.ForeColor = Color.Gray;
                string byteDisplay = "byte" + (byteCount != 1 ? "s" : "");
                LblStorage.Text = $"{byteCount} {byteDisplay}";
            }
        }

        #endregion
    }
}