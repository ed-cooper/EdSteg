﻿namespace Stenography.Forms
{
    partial class EncryptForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncryptForm));
            this.LblMessage = new System.Windows.Forms.Label();
            this.TxtMessage = new System.Windows.Forms.TextBox();
            this.LblOriginal = new System.Windows.Forms.Label();
            this.BtnOriginalBrowse = new System.Windows.Forms.Button();
            this.LblOriginalPath = new System.Windows.Forms.Label();
            this.BtnSaveBrowse = new System.Windows.Forms.Button();
            this.LblSave = new System.Windows.Forms.Label();
            this.LblSavePath = new System.Windows.Forms.Label();
            this.BtnGo = new System.Windows.Forms.Button();
            this.PnlAction = new System.Windows.Forms.Panel();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.PnlAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblMessage
            // 
            this.LblMessage.AutoSize = true;
            this.LblMessage.Location = new System.Drawing.Point(12, 15);
            this.LblMessage.Name = "LblMessage";
            this.LblMessage.Size = new System.Drawing.Size(50, 13);
            this.LblMessage.TabIndex = 0;
            this.LblMessage.Text = "Message";
            // 
            // TxtMessage
            // 
            this.TxtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtMessage.Location = new System.Drawing.Point(98, 12);
            this.TxtMessage.Multiline = true;
            this.TxtMessage.Name = "TxtMessage";
            this.TxtMessage.Size = new System.Drawing.Size(228, 117);
            this.TxtMessage.TabIndex = 1;
            // 
            // LblOriginal
            // 
            this.LblOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblOriginal.AutoSize = true;
            this.LblOriginal.Location = new System.Drawing.Point(12, 140);
            this.LblOriginal.Name = "LblOriginal";
            this.LblOriginal.Size = new System.Drawing.Size(61, 13);
            this.LblOriginal.TabIndex = 2;
            this.LblOriginal.Text = "Original file:";
            // 
            // BtnOriginalBrowse
            // 
            this.BtnOriginalBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnOriginalBrowse.Location = new System.Drawing.Point(98, 135);
            this.BtnOriginalBrowse.Name = "BtnOriginalBrowse";
            this.BtnOriginalBrowse.Size = new System.Drawing.Size(55, 23);
            this.BtnOriginalBrowse.TabIndex = 3;
            this.BtnOriginalBrowse.Text = "Browse";
            this.BtnOriginalBrowse.UseVisualStyleBackColor = true;
            this.BtnOriginalBrowse.Click += new System.EventHandler(this.BtnOriginalBrowse_Click);
            // 
            // LblOriginalPath
            // 
            this.LblOriginalPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblOriginalPath.AutoEllipsis = true;
            this.LblOriginalPath.Location = new System.Drawing.Point(159, 140);
            this.LblOriginalPath.Name = "LblOriginalPath";
            this.LblOriginalPath.Size = new System.Drawing.Size(167, 13);
            this.LblOriginalPath.TabIndex = 4;
            this.LblOriginalPath.Text = "No file selected";
            // 
            // BtnSaveBrowse
            // 
            this.BtnSaveBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnSaveBrowse.Location = new System.Drawing.Point(98, 164);
            this.BtnSaveBrowse.Name = "BtnSaveBrowse";
            this.BtnSaveBrowse.Size = new System.Drawing.Size(55, 23);
            this.BtnSaveBrowse.TabIndex = 5;
            this.BtnSaveBrowse.Text = "Browse";
            this.BtnSaveBrowse.UseVisualStyleBackColor = true;
            this.BtnSaveBrowse.Click += new System.EventHandler(this.BtnSaveBrowse_Click);
            // 
            // LblSave
            // 
            this.LblSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblSave.AutoSize = true;
            this.LblSave.Location = new System.Drawing.Point(12, 169);
            this.LblSave.Name = "LblSave";
            this.LblSave.Size = new System.Drawing.Size(59, 13);
            this.LblSave.TabIndex = 6;
            this.LblSave.Text = "Save path:";
            // 
            // LblSavePath
            // 
            this.LblSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblSavePath.AutoEllipsis = true;
            this.LblSavePath.Location = new System.Drawing.Point(159, 169);
            this.LblSavePath.Name = "LblSavePath";
            this.LblSavePath.Size = new System.Drawing.Size(167, 13);
            this.LblSavePath.TabIndex = 7;
            this.LblSavePath.Text = "No file selected";
            // 
            // BtnGo
            // 
            this.BtnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGo.Location = new System.Drawing.Point(271, 13);
            this.BtnGo.Name = "BtnGo";
            this.BtnGo.Size = new System.Drawing.Size(55, 23);
            this.BtnGo.TabIndex = 8;
            this.BtnGo.Text = "Go";
            this.BtnGo.UseVisualStyleBackColor = true;
            this.BtnGo.Click += new System.EventHandler(this.BtnGo_Click);
            // 
            // PnlAction
            // 
            this.PnlAction.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PnlAction.Controls.Add(this.BtnGo);
            this.PnlAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlAction.Location = new System.Drawing.Point(0, 205);
            this.PnlAction.Name = "PnlAction";
            this.PnlAction.Size = new System.Drawing.Size(338, 52);
            this.PnlAction.TabIndex = 9;
            // 
            // Worker
            // 
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_RunWorkerCompleted);
            // 
            // EncryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 257);
            this.Controls.Add(this.PnlAction);
            this.Controls.Add(this.LblSavePath);
            this.Controls.Add(this.LblSave);
            this.Controls.Add(this.BtnSaveBrowse);
            this.Controls.Add(this.LblOriginalPath);
            this.Controls.Add(this.BtnOriginalBrowse);
            this.Controls.Add(this.LblOriginal);
            this.Controls.Add(this.TxtMessage);
            this.Controls.Add(this.LblMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(354, 296);
            this.Name = "EncryptForm";
            this.Text = "Encrypt";
            this.PnlAction.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblMessage;
        private System.Windows.Forms.TextBox TxtMessage;
        private System.Windows.Forms.Label LblOriginal;
        private System.Windows.Forms.Button BtnOriginalBrowse;
        private System.Windows.Forms.Label LblOriginalPath;
        private System.Windows.Forms.Button BtnSaveBrowse;
        private System.Windows.Forms.Label LblSave;
        private System.Windows.Forms.Label LblSavePath;
        private System.Windows.Forms.Button BtnGo;
        private System.Windows.Forms.Panel PnlAction;
        private System.ComponentModel.BackgroundWorker Worker;
    }
}