﻿namespace EdSteg.Forms
{
    partial class DecryptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DecryptForm));
            this.LblFilePath = new System.Windows.Forms.Label();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.TxtMessage = new System.Windows.Forms.TextBox();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // LblFilePath
            // 
            this.LblFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblFilePath.AutoEllipsis = true;
            this.LblFilePath.Location = new System.Drawing.Point(73, 17);
            this.LblFilePath.Name = "LblFilePath";
            this.LblFilePath.Size = new System.Drawing.Size(281, 13);
            this.LblFilePath.TabIndex = 6;
            this.LblFilePath.Text = "No file selected";
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Location = new System.Drawing.Point(12, 12);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(55, 23);
            this.BtnBrowse.TabIndex = 5;
            this.BtnBrowse.Text = "Browse";
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // TxtMessage
            // 
            this.TxtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtMessage.Enabled = false;
            this.TxtMessage.Location = new System.Drawing.Point(12, 41);
            this.TxtMessage.Multiline = true;
            this.TxtMessage.Name = "TxtMessage";
            this.TxtMessage.ReadOnly = true;
            this.TxtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtMessage.Size = new System.Drawing.Size(342, 166);
            this.TxtMessage.TabIndex = 7;
            // 
            // Worker
            // 
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_RunWorkerCompleted);
            // 
            // Progress
            // 
            this.Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Progress.Location = new System.Drawing.Point(12, 213);
            this.Progress.MarqueeAnimationSpeed = 50;
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(342, 16);
            this.Progress.TabIndex = 11;
            // 
            // DecryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 241);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.TxtMessage);
            this.Controls.Add(this.LblFilePath);
            this.Controls.Add(this.BtnBrowse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(382, 280);
            this.Name = "DecryptForm";
            this.Text = "Decrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblFilePath;
        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.TextBox TxtMessage;
        private System.ComponentModel.BackgroundWorker Worker;
        private System.Windows.Forms.ProgressBar Progress;
    }
}