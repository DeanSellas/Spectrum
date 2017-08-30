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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Hide");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.applySettingsButton = new System.Windows.Forms.Button();
            this.windowsCheckbox = new System.Windows.Forms.CheckBox();
            this.startupConnectCheckBox = new System.Windows.Forms.CheckBox();
            this.closeToTrayCheckbox = new System.Windows.Forms.CheckBox();
            this.startMinCheckbox = new System.Windows.Forms.CheckBox();
            this.updateComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.generalSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.generalSettingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // applySettingsButton
            // 
            this.applySettingsButton.Enabled = false;
            this.applySettingsButton.Location = new System.Drawing.Point(289, 368);
            this.applySettingsButton.Name = "applySettingsButton";
            this.applySettingsButton.Size = new System.Drawing.Size(79, 23);
            this.applySettingsButton.TabIndex = 18;
            this.applySettingsButton.Tag = "";
            this.applySettingsButton.Text = "Apply";
            this.applySettingsButton.UseVisualStyleBackColor = true;
            this.applySettingsButton.Click += new System.EventHandler(this.applySettingsButton_Click);
            // 
            // windowsCheckbox
            // 
            this.windowsCheckbox.AutoSize = true;
            this.windowsCheckbox.Location = new System.Drawing.Point(80, 99);
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
            this.startupConnectCheckBox.Location = new System.Drawing.Point(80, 33);
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
            this.closeToTrayCheckbox.Location = new System.Drawing.Point(80, 56);
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
            this.startMinCheckbox.Location = new System.Drawing.Point(80, 79);
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
            this.updateComboBox.Location = new System.Drawing.Point(124, 163);
            this.updateComboBox.Name = "updateComboBox";
            this.updateComboBox.Size = new System.Drawing.Size(117, 21);
            this.updateComboBox.TabIndex = 20;
            this.updateComboBox.SelectedIndexChanged += new System.EventHandler(this.updateComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Check Updates Every:";
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Location = new System.Drawing.Point(12, 34);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "generalNode";
            treeNode1.Text = "General";
            treeNode2.Name = "hideNode";
            treeNode2.Text = "Hide";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treeView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(73, 208);
            this.treeView1.TabIndex = 22;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // generalSettingsGroupBox
            // 
            this.generalSettingsGroupBox.Controls.Add(this.startupConnectCheckBox);
            this.generalSettingsGroupBox.Controls.Add(this.closeToTrayCheckbox);
            this.generalSettingsGroupBox.Controls.Add(this.label1);
            this.generalSettingsGroupBox.Controls.Add(this.windowsCheckbox);
            this.generalSettingsGroupBox.Controls.Add(this.updateComboBox);
            this.generalSettingsGroupBox.Controls.Add(this.startMinCheckbox);
            this.generalSettingsGroupBox.Location = new System.Drawing.Point(111, 34);
            this.generalSettingsGroupBox.Name = "generalSettingsGroupBox";
            this.generalSettingsGroupBox.Size = new System.Drawing.Size(257, 208);
            this.generalSettingsGroupBox.TabIndex = 23;
            this.generalSettingsGroupBox.TabStop = false;
            this.generalSettingsGroupBox.Text = "General Settings";
            this.generalSettingsGroupBox.Visible = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(204, 368);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(79, 23);
            this.cancelButton.TabIndex = 24;
            this.cancelButton.Tag = "";
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(119, 368);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(79, 23);
            this.okButton.TabIndex = 25;
            this.okButton.Tag = "";
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 396);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.generalSettingsGroupBox);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.applySettingsButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.generalSettingsGroupBox.ResumeLayout(false);
            this.generalSettingsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button applySettingsButton;
        private System.Windows.Forms.CheckBox windowsCheckbox;
        private System.Windows.Forms.CheckBox closeToTrayCheckbox;
        public System.Windows.Forms.CheckBox startupConnectCheckBox;
        private System.Windows.Forms.CheckBox startMinCheckbox;
        private System.Windows.Forms.ComboBox updateComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox generalSettingsGroupBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}