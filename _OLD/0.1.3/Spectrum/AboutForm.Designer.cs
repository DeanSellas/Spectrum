namespace Spectrum {
    partial class AboutForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.currentVersionLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.githubLink = new System.Windows.Forms.LinkLabel();
            this.websiteLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Spectrum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Created By: Dean Sellas";
            // 
            // currentVersionLabel
            // 
            this.currentVersionLabel.AutoSize = true;
            this.currentVersionLabel.Location = new System.Drawing.Point(110, 91);
            this.currentVersionLabel.Name = "currentVersionLabel";
            this.currentVersionLabel.Size = new System.Drawing.Size(85, 13);
            this.currentVersionLabel.TabIndex = 2;
            this.currentVersionLabel.Text = "Current Version: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(319, 65);
            this.label3.TabIndex = 3;
            this.label3.Text = "Spectrum is a Windows Application designed to control NeoPixels.\r\n\r\nTHE SOFTWARE " +
    "IS PROVIDED AS IS\r\n WITHOUT WARRANTY OF ANY KIND\r\n\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // githubLink
            // 
            this.githubLink.AutoSize = true;
            this.githubLink.Location = new System.Drawing.Point(110, 114);
            this.githubLink.Name = "githubLink";
            this.githubLink.Size = new System.Drawing.Size(40, 13);
            this.githubLink.TabIndex = 4;
            this.githubLink.TabStop = true;
            this.githubLink.Text = "GitHub";
            this.githubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLink_LinkClicked);
            // 
            // websiteLinkLabel
            // 
            this.websiteLinkLabel.AutoSize = true;
            this.websiteLinkLabel.Location = new System.Drawing.Point(186, 114);
            this.websiteLinkLabel.Name = "websiteLinkLabel";
            this.websiteLinkLabel.Size = new System.Drawing.Size(46, 13);
            this.websiteLinkLabel.TabIndex = 5;
            this.websiteLinkLabel.TabStop = true;
            this.websiteLinkLabel.Text = "Website";
            this.websiteLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.websiteLinkLabel_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 210);
            this.Controls.Add(this.websiteLinkLabel);
            this.Controls.Add(this.githubLink);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.currentVersionLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label currentVersionLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel githubLink;
        private System.Windows.Forms.LinkLabel websiteLinkLabel;
    }
}