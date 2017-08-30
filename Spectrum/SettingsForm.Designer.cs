namespace Spectrum {
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
            this.startMinCheckbox = new System.Windows.Forms.CheckBox();
            this.updateComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // applySettingsButton
            // 
            this.applySettingsButton.Enabled = false;
            this.applySettingsButton.Location = new System.Drawing.Point(82, 207);
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
            this.startupConnectCheckBox.Location = new System.Drawing.Point(82, 64);
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
            this.closeToTrayCheckbox.Location = new System.Drawing.Point(82, 87);
            this.closeToTrayCheckbox.Name = "closeToTrayCheckbox";
            this.closeToTrayCheckbox.Size = new System.Drawing.Size(92, 17);
            this.closeToTrayCheckbox.TabIndex = 15;
            this.closeToTrayCheckbox.Tag = "";
            this.closeToTrayCheckbox.Text = "Close To Tray";
            this.closeToTrayCheckbox.UseVisualStyleBackColor = true;
            this.closeToTrayCheckbox.CheckedChanged += new System.EventHandler(this.settingsCheckboxes_CheckedChanged);
            // 
            // startMinCheckbox
            // 
            this.startMinCheckbox.AutoSize = true;
            this.startMinCheckbox.Location = new System.Drawing.Point(82, 110);
            this.startMinCheckbox.Name = "startMinCheckbox";
            this.startMinCheckbox.Size = new System.Drawing.Size(97, 17);
            this.startMinCheckbox.TabIndex = 19;
            this.startMinCheckbox.Tag = "";
            this.startMinCheckbox.Text = "Start Minimized";
            this.startMinCheckbox.UseVisualStyleBackColor = true;
            this.startMinCheckbox.CheckedChanged += new System.EventHandler(this.settingsCheckboxes_CheckedChanged);
            // 
            // updateComboBox
            // 
            this.updateComboBox.FormattingEnabled = true;
            this.updateComboBox.Items.AddRange(new object[] {
            "Never",
            "On Startup",
            "On Startup Daily",
            "On Startup Weekly",
            "On Startup Monthly"});
            this.updateComboBox.Location = new System.Drawing.Point(126, 166);
            this.updateComboBox.Name = "updateComboBox";
            this.updateComboBox.Size = new System.Drawing.Size(117, 21);
            this.updateComboBox.TabIndex = 20;
            this.updateComboBox.SelectedIndexChanged += new System.EventHandler(this.updateComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Check Updates Every:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updateComboBox);
            this.Controls.Add(this.startMinCheckbox);
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
        private System.Windows.Forms.CheckBox startMinCheckbox;
        private System.Windows.Forms.ComboBox updateComboBox;
        private System.Windows.Forms.Label label1;
    }
}