namespace EdSteg.Forms
{
    partial class StartupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupForm));
            this.LblKey = new System.Windows.Forms.Label();
            this.TxtKey = new System.Windows.Forms.TextBox();
            this.LblEncryption = new System.Windows.Forms.Label();
            this.LblStorage = new System.Windows.Forms.Label();
            this.CmbEncryption = new System.Windows.Forms.ComboBox();
            this.CmbStorage = new System.Windows.Forms.ComboBox();
            this.BtnEncrypt = new System.Windows.Forms.Button();
            this.BtnDecrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblKey
            // 
            this.LblKey.AutoSize = true;
            this.LblKey.Location = new System.Drawing.Point(12, 15);
            this.LblKey.Name = "LblKey";
            this.LblKey.Size = new System.Drawing.Size(28, 13);
            this.LblKey.TabIndex = 0;
            this.LblKey.Text = "Key:";
            // 
            // TxtKey
            // 
            this.TxtKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtKey.Location = new System.Drawing.Point(124, 12);
            this.TxtKey.Name = "TxtKey";
            this.TxtKey.Size = new System.Drawing.Size(148, 20);
            this.TxtKey.TabIndex = 1;
            // 
            // LblEncryption
            // 
            this.LblEncryption.AutoSize = true;
            this.LblEncryption.Location = new System.Drawing.Point(12, 41);
            this.LblEncryption.Name = "LblEncryption";
            this.LblEncryption.Size = new System.Drawing.Size(98, 13);
            this.LblEncryption.TabIndex = 2;
            this.LblEncryption.Text = "Encryption method:";
            // 
            // LblStorage
            // 
            this.LblStorage.AutoSize = true;
            this.LblStorage.Location = new System.Drawing.Point(12, 68);
            this.LblStorage.Name = "LblStorage";
            this.LblStorage.Size = new System.Drawing.Size(85, 13);
            this.LblStorage.TabIndex = 3;
            this.LblStorage.Text = "Storage method:";
            // 
            // CmbEncryption
            // 
            this.CmbEncryption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbEncryption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEncryption.FormattingEnabled = true;
            this.CmbEncryption.Items.AddRange(new object[] {
            "XOR cipher (default)"});
            this.CmbEncryption.Location = new System.Drawing.Point(124, 38);
            this.CmbEncryption.Name = "CmbEncryption";
            this.CmbEncryption.Size = new System.Drawing.Size(148, 21);
            this.CmbEncryption.TabIndex = 4;
            // 
            // CmbStorage
            // 
            this.CmbStorage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbStorage.FormattingEnabled = true;
            this.CmbStorage.Items.AddRange(new object[] {
            "LSB (default)"});
            this.CmbStorage.Location = new System.Drawing.Point(124, 65);
            this.CmbStorage.Name = "CmbStorage";
            this.CmbStorage.Size = new System.Drawing.Size(148, 21);
            this.CmbStorage.TabIndex = 5;
            // 
            // BtnEncrypt
            // 
            this.BtnEncrypt.Location = new System.Drawing.Point(124, 92);
            this.BtnEncrypt.Name = "BtnEncrypt";
            this.BtnEncrypt.Size = new System.Drawing.Size(71, 23);
            this.BtnEncrypt.TabIndex = 7;
            this.BtnEncrypt.Text = "Encrypt";
            this.BtnEncrypt.UseVisualStyleBackColor = true;
            this.BtnEncrypt.Click += new System.EventHandler(this.BtnEncrypt_Click);
            // 
            // BtnDecrypt
            // 
            this.BtnDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDecrypt.Location = new System.Drawing.Point(201, 92);
            this.BtnDecrypt.Name = "BtnDecrypt";
            this.BtnDecrypt.Size = new System.Drawing.Size(71, 23);
            this.BtnDecrypt.TabIndex = 8;
            this.BtnDecrypt.Text = "Decrypt";
            this.BtnDecrypt.UseVisualStyleBackColor = true;
            this.BtnDecrypt.Click += new System.EventHandler(this.BtnDecrypt_Click);
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 129);
            this.Controls.Add(this.BtnDecrypt);
            this.Controls.Add(this.BtnEncrypt);
            this.Controls.Add(this.CmbStorage);
            this.Controls.Add(this.CmbEncryption);
            this.Controls.Add(this.LblStorage);
            this.Controls.Add(this.LblEncryption);
            this.Controls.Add(this.TxtKey);
            this.Controls.Add(this.LblKey);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 168);
            this.Name = "StartupForm";
            this.Text = "Ed Steg";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblKey;
        private System.Windows.Forms.TextBox TxtKey;
        private System.Windows.Forms.Label LblEncryption;
        private System.Windows.Forms.Label LblStorage;
        private System.Windows.Forms.ComboBox CmbEncryption;
        private System.Windows.Forms.ComboBox CmbStorage;
        private System.Windows.Forms.Button BtnEncrypt;
        private System.Windows.Forms.Button BtnDecrypt;
    }
}