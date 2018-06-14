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
            this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.cancelButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.downloadLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // downloadProgressBar
            // 
            this.downloadProgressBar.Location = new System.Drawing.Point(12, 12);
            this.downloadProgressBar.Name = "downloadProgressBar";
            this.downloadProgressBar.Size = new System.Drawing.Size(469, 23);
            this.downloadProgressBar.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 55);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(111, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
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
            this.downloadLabel.Location = new System.Drawing.Point(189, 38);
            this.downloadLabel.Name = "downloadLabel";
            this.downloadLabel.Size = new System.Drawing.Size(100, 23);
            this.downloadLabel.TabIndex = 3;
            this.downloadLabel.Text = "0/0 kb";
            this.downloadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpdaterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 90);
            this.Controls.Add(this.downloadLabel);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.downloadProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdaterForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdaterForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar downloadProgressBar;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Label downloadLabel;
    }
}