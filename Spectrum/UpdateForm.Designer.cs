namespace Spectrum {
    partial class UpdateForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.downloadButton = new System.Windows.Forms.Button();
            this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.postponeButton = new System.Windows.Forms.Button();
            this.postponeCombobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowNavigation = false;
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(12, 12);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(435, 317);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("https://raw.githubusercontent.com/DeanSellas/Spectrum/master/changelog.txt", System.UriKind.Absolute);
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(12, 363);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(111, 23);
            this.downloadButton.TabIndex = 1;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // downloadProgressBar
            // 
            this.downloadProgressBar.Location = new System.Drawing.Point(12, 392);
            this.downloadProgressBar.Name = "downloadProgressBar";
            this.downloadProgressBar.Size = new System.Drawing.Size(435, 23);
            this.downloadProgressBar.TabIndex = 2;
            // 
            // postponeButton
            // 
            this.postponeButton.Location = new System.Drawing.Point(253, 363);
            this.postponeButton.Name = "postponeButton";
            this.postponeButton.Size = new System.Drawing.Size(112, 23);
            this.postponeButton.TabIndex = 3;
            this.postponeButton.Text = "Postpone Update";
            this.postponeButton.UseVisualStyleBackColor = true;
            this.postponeButton.Click += new System.EventHandler(this.postponeButton_Click);
            // 
            // postponeCombobox
            // 
            this.postponeCombobox.DisplayMember = "0";
            this.postponeCombobox.FormattingEnabled = true;
            this.postponeCombobox.Items.AddRange(new object[] {
            "1 Day",
            "2 Days",
            "3 Days",
            "4 Days",
            "1 Week",
            "2 Weeks"});
            this.postponeCombobox.Location = new System.Drawing.Point(371, 363);
            this.postponeCombobox.Name = "postponeCombobox";
            this.postponeCombobox.Size = new System.Drawing.Size(76, 21);
            this.postponeCombobox.TabIndex = 4;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 427);
            this.Controls.Add(this.postponeCombobox);
            this.Controls.Add(this.postponeButton);
            this.Controls.Add(this.downloadProgressBar);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            this.Text = "Update";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.ProgressBar downloadProgressBar;
        private System.Windows.Forms.Button postponeButton;
        private System.Windows.Forms.ComboBox postponeCombobox;
    }
}