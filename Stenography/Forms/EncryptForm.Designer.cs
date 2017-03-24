namespace Stenography.Forms
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
            this.LblMessage = new System.Windows.Forms.Label();
            this.TxtMessage = new System.Windows.Forms.TextBox();
            this.LblBase = new System.Windows.Forms.Label();
            this.BtnBaseBrowse = new System.Windows.Forms.Button();
            this.LblBasePath = new System.Windows.Forms.Label();
            this.BtnSaveBrowse = new System.Windows.Forms.Button();
            this.LblSave = new System.Windows.Forms.Label();
            this.LblSavePath = new System.Windows.Forms.Label();
            this.BtnGo = new System.Windows.Forms.Button();
            this.PnlAction = new System.Windows.Forms.Panel();
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
            // LblBase
            // 
            this.LblBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblBase.AutoSize = true;
            this.LblBase.Location = new System.Drawing.Point(12, 140);
            this.LblBase.Name = "LblBase";
            this.LblBase.Size = new System.Drawing.Size(50, 13);
            this.LblBase.TabIndex = 2;
            this.LblBase.Text = "Base file:";
            // 
            // BtnBaseBrowse
            // 
            this.BtnBaseBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnBaseBrowse.Location = new System.Drawing.Point(98, 135);
            this.BtnBaseBrowse.Name = "BtnBaseBrowse";
            this.BtnBaseBrowse.Size = new System.Drawing.Size(55, 23);
            this.BtnBaseBrowse.TabIndex = 3;
            this.BtnBaseBrowse.Text = "Browse";
            this.BtnBaseBrowse.UseVisualStyleBackColor = true;
            // 
            // LblBasePath
            // 
            this.LblBasePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblBasePath.AutoSize = true;
            this.LblBasePath.Location = new System.Drawing.Point(159, 140);
            this.LblBasePath.Name = "LblBasePath";
            this.LblBasePath.Size = new System.Drawing.Size(80, 13);
            this.LblBasePath.TabIndex = 4;
            this.LblBasePath.Text = "No file selected";
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
            this.LblSavePath.AutoSize = true;
            this.LblSavePath.Location = new System.Drawing.Point(159, 169);
            this.LblSavePath.Name = "LblSavePath";
            this.LblSavePath.Size = new System.Drawing.Size(80, 13);
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
            // EncryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 257);
            this.Controls.Add(this.PnlAction);
            this.Controls.Add(this.LblSavePath);
            this.Controls.Add(this.LblSave);
            this.Controls.Add(this.BtnSaveBrowse);
            this.Controls.Add(this.LblBasePath);
            this.Controls.Add(this.BtnBaseBrowse);
            this.Controls.Add(this.LblBase);
            this.Controls.Add(this.TxtMessage);
            this.Controls.Add(this.LblMessage);
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
        private System.Windows.Forms.Label LblBase;
        private System.Windows.Forms.Button BtnBaseBrowse;
        private System.Windows.Forms.Label LblBasePath;
        private System.Windows.Forms.Button BtnSaveBrowse;
        private System.Windows.Forms.Label LblSave;
        private System.Windows.Forms.Label LblSavePath;
        private System.Windows.Forms.Button BtnGo;
        private System.Windows.Forms.Panel PnlAction;
    }
}