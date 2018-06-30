namespace Spectrum.Forms {
    partial class UpdaterForm {
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.downloadLabel = new System.Windows.Forms.Label();
            this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.changelogLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 55);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(111, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(370, 55);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(111, 23);
            this.downloadButton.TabIndex = 2;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // downloadLabel
            // 
            this.downloadLabel.BackColor = System.Drawing.Color.Transparent;
            this.downloadLabel.Location = new System.Drawing.Point(12, 38);
            this.downloadLabel.Name = "downloadLabel";
            this.downloadLabel.Size = new System.Drawing.Size(469, 23);
            this.downloadLabel.TabIndex = 3;
            this.downloadLabel.Text = "0 kb/0 kb";
            this.downloadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // downloadProgressBar
            // 
            this.downloadProgressBar.Location = new System.Drawing.Point(12, 12);
            this.downloadProgressBar.Name = "downloadProgressBar";
            this.downloadProgressBar.Size = new System.Drawing.Size(469, 23);
            this.downloadProgressBar.TabIndex = 4;
            // 
            // changelogLink
            // 
            this.changelogLink.AutoSize = true;
            this.changelogLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.changelogLink.Location = new System.Drawing.Point(213, 65);
            this.changelogLink.Name = "changelogLink";
            this.changelogLink.Size = new System.Drawing.Size(65, 13);
            this.changelogLink.TabIndex = 5;
            this.changelogLink.TabStop = true;
            this.changelogLink.Text = "Change Log";
            this.changelogLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.changelogLink_LinkClicked);
            // 
            // UpdaterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 90);
            this.Controls.Add(this.changelogLink);
            this.Controls.Add(this.downloadProgressBar);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.downloadLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdaterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdaterForm";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        public System.Windows.Forms.Label downloadLabel;
        public System.Windows.Forms.ProgressBar downloadProgressBar;
        private System.Windows.Forms.LinkLabel changelogLink;
        public System.Windows.Forms.Button downloadButton;
    }
}