using Stenography.Encryption;
using Stenography.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        }
        #endregion
    }
}
