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
    public partial class FormMain : Form
    {
        #region Constructor
        public FormMain()
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

        }

        private void BtnDecrypt_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
