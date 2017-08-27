﻿namespace Spectrum {
    partial class SettingsForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.applySettingsButton = new System.Windows.Forms.Button();
            this.windowsCheckbox = new System.Windows.Forms.CheckBox();
            this.startupConnectCheckBox = new System.Windows.Forms.CheckBox();
            this.closeToTrayCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // applySettingsButton
            // 
            this.applySettingsButton.Enabled = false;
            this.applySettingsButton.Location = new System.Drawing.Point(86, 153);
            this.applySettingsButton.Name = "applySettingsButton";
            this.applySettingsButton.Size = new System.Drawing.Size(116, 23);
            this.applySettingsButton.TabIndex = 18;
            this.applySettingsButton.Tag = "";
            this.applySettingsButton.Text = "Apply Settings";
            this.applySettingsButton.UseVisualStyleBackColor = true;
            this.applySettingsButton.Click += new System.EventHandler(this.applySettingsButton_Click);
            // 
            // windowsCheckbox
            // 
            this.windowsCheckbox.AutoSize = true;
            this.windowsCheckbox.Location = new System.Drawing.Point(82, 130);
            this.windowsCheckbox.Name = "windowsCheckbox";
            this.windowsCheckbox.Size = new System.Drawing.Size(120, 17);
            this.windowsCheckbox.TabIndex = 17;
            this.windowsCheckbox.Tag = "";
            this.windowsCheckbox.Text = "Start With Windows";
            this.windowsCheckbox.UseVisualStyleBackColor = true;
            this.windowsCheckbox.CheckedChanged += new System.EventHandler(this.settingsCheckboxes_CheckedChanged);
            // 
            // startupConnectCheckBox
            // 
            this.startupConnectCheckBox.AutoSize = true;
            this.startupConnectCheckBox.Enabled = false;
            this.startupConnectCheckBox.Location = new System.Drawing.Point(82, 84);
            this.startupConnectCheckBox.Name = "startupConnectCheckBox";
            this.startupConnectCheckBox.Size = new System.Drawing.Size(120, 17);
            this.startupConnectCheckBox.TabIndex = 16;
            this.startupConnectCheckBox.Tag = "";
            this.startupConnectCheckBox.Text = "Connect On Startup";
            this.startupConnectCheckBox.UseVisualStyleBackColor = true;
            this.startupConnectCheckBox.CheckedChanged += new System.EventHandler(this.settingsCheckboxes_CheckedChanged);
            // 
            // closeToTrayCheckbox
            // 
            this.closeToTrayCheckbox.AutoSize = true;
            this.closeToTrayCheckbox.Location = new System.Drawing.Point(82, 107);
            this.closeToTrayCheckbox.Name = "closeToTrayCheckbox";
            this.closeToTrayCheckbox.Size = new System.Drawing.Size(92, 17);
            this.closeToTrayCheckbox.TabIndex = 15;
            this.closeToTrayCheckbox.Tag = "";
            this.closeToTrayCheckbox.Text = "Close To Tray";
            this.closeToTrayCheckbox.UseVisualStyleBackColor = true;
            this.closeToTrayCheckbox.CheckedChanged += new System.EventHandler(this.settingsCheckboxes_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.applySettingsButton);
            this.Controls.Add(this.windowsCheckbox);
            this.Controls.Add(this.startupConnectCheckBox);
            this.Controls.Add(this.closeToTrayCheckbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button applySettingsButton;
        private System.Windows.Forms.CheckBox windowsCheckbox;
        private System.Windows.Forms.CheckBox closeToTrayCheckbox;
        public System.Windows.Forms.CheckBox startupConnectCheckBox;
    }
}