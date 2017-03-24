﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stenography.Forms
{
    public partial class EncryptForm : Form
    {
        #region Constructor
        public EncryptForm()
        {
            InitializeComponent();
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
            if (CheckInputs())
            {

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

            // Validation successful
            return true;
        }
        #endregion
    }
}
