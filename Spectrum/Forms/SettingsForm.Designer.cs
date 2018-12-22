namespace Spectrum.Forms {
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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Arduino");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Updates");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Logs");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Advanced");
            this.general = new System.Windows.Forms.GroupBox();
            this.minimizeToTray = new System.Windows.Forms.CheckBox();
            this.closeToTray = new System.Windows.Forms.CheckBox();
            this.startMinimized = new System.Windows.Forms.CheckBox();
            this.connectOnStart = new System.Windows.Forms.CheckBox();
            this.startWithWindows = new System.Windows.Forms.CheckBox();
            this.profileComboBox = new System.Windows.Forms.ComboBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.arduino = new System.Windows.Forms.GroupBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.turnOffOnClose = new System.Windows.Forms.CheckBox();
            this.responsiveLighting = new System.Windows.Forms.CheckBox();
            this.turnOnWithApp = new System.Windows.Forms.CheckBox();
            this.portComboBox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.updater = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.checkForUpdate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.downloadPath = new System.Windows.Forms.TextBox();
            this.logs = new System.Windows.Forms.GroupBox();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.logPathLabel = new System.Windows.Forms.Label();
            this.logPath = new System.Windows.Forms.TextBox();
            this.reportErrors = new System.Windows.Forms.CheckBox();
            this.autoScroll = new System.Windows.Forms.CheckBox();
            this.enableLogs = new System.Windows.Forms.CheckBox();
            this.advanced = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.general.SuspendLayout();
            this.arduino.SuspendLayout();
            this.updater.SuspendLayout();
            this.logs.SuspendLayout();
            this.SuspendLayout();
            // 
            // general
            // 
            this.general.Controls.Add(this.minimizeToTray);
            this.general.Controls.Add(this.closeToTray);
            this.general.Controls.Add(this.startMinimized);
            this.general.Controls.Add(this.connectOnStart);
            this.general.Controls.Add(this.startWithWindows);
            this.general.Controls.Add(this.profileComboBox);
            this.general.Location = new System.Drawing.Point(131, 12);
            this.general.Name = "general";
            this.general.Size = new System.Drawing.Size(252, 191);
            this.general.TabIndex = 0;
            this.general.TabStop = false;
            this.general.Text = "General";
            // 
            // minimizeToTray
            // 
            this.minimizeToTray.AutoSize = true;
            this.minimizeToTray.Location = new System.Drawing.Point(63, 106);
            this.minimizeToTray.Name = "minimizeToTray";
            this.minimizeToTray.Size = new System.Drawing.Size(112, 17);
            this.minimizeToTray.TabIndex = 5;
            this.minimizeToTray.Text = "Minimized To Tray";
            this.minimizeToTray.UseVisualStyleBackColor = true;
            this.minimizeToTray.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // closeToTray
            // 
            this.closeToTray.AutoSize = true;
            this.closeToTray.Location = new System.Drawing.Point(63, 152);
            this.closeToTray.Name = "closeToTray";
            this.closeToTray.Size = new System.Drawing.Size(92, 17);
            this.closeToTray.TabIndex = 4;
            this.closeToTray.Text = "Close To Tray";
            this.closeToTray.UseVisualStyleBackColor = true;
            this.closeToTray.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // startMinimized
            // 
            this.startMinimized.AutoSize = true;
            this.startMinimized.Location = new System.Drawing.Point(63, 129);
            this.startMinimized.Name = "startMinimized";
            this.startMinimized.Size = new System.Drawing.Size(97, 17);
            this.startMinimized.TabIndex = 3;
            this.startMinimized.Text = "Start Minimized";
            this.startMinimized.UseVisualStyleBackColor = true;
            this.startMinimized.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // connectOnStart
            // 
            this.connectOnStart.AutoSize = true;
            this.connectOnStart.Location = new System.Drawing.Point(63, 83);
            this.connectOnStart.Name = "connectOnStart";
            this.connectOnStart.Size = new System.Drawing.Size(120, 17);
            this.connectOnStart.TabIndex = 2;
            this.connectOnStart.Text = "Connect On Startup";
            this.connectOnStart.UseVisualStyleBackColor = true;
            this.connectOnStart.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // startWithWindows
            // 
            this.startWithWindows.AutoSize = true;
            this.startWithWindows.Location = new System.Drawing.Point(63, 60);
            this.startWithWindows.Name = "startWithWindows";
            this.startWithWindows.Size = new System.Drawing.Size(120, 17);
            this.startWithWindows.TabIndex = 1;
            this.startWithWindows.Text = "Start With Windows";
            this.startWithWindows.UseVisualStyleBackColor = true;
            this.startWithWindows.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // profileComboBox
            // 
            this.profileComboBox.FormattingEnabled = true;
            this.profileComboBox.Location = new System.Drawing.Point(63, 19);
            this.profileComboBox.Name = "profileComboBox";
            this.profileComboBox.Size = new System.Drawing.Size(121, 21);
            this.profileComboBox.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.FullRowSelect = true;
            this.treeView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.treeView1.Indent = 5;
            this.treeView1.ItemHeight = 20;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "generalNode";
            treeNode1.Text = "General";
            treeNode1.ToolTipText = "General Settings";
            treeNode2.Name = "arduinoNode";
            treeNode2.Text = "Arduino";
            treeNode2.ToolTipText = "Arduino Settings";
            treeNode3.Name = "updaterNode";
            treeNode3.Text = "Updates";
            treeNode3.ToolTipText = "Update Settings";
            treeNode4.Name = "logsNode";
            treeNode4.Text = "Logs";
            treeNode4.ToolTipText = "Logs Settings";
            treeNode5.Name = "advancedNode";
            treeNode5.Text = "Advanced";
            treeNode5.ToolTipText = "Advanced Settings";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.treeView1.ShowLines = false;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(113, 718);
            this.treeView1.TabIndex = 0;
            // 
            // arduino
            // 
            this.arduino.Controls.Add(this.refreshButton);
            this.arduino.Controls.Add(this.turnOffOnClose);
            this.arduino.Controls.Add(this.responsiveLighting);
            this.arduino.Controls.Add(this.turnOnWithApp);
            this.arduino.Controls.Add(this.portComboBox);
            this.arduino.Location = new System.Drawing.Point(428, 12);
            this.arduino.Name = "arduino";
            this.arduino.Size = new System.Drawing.Size(252, 191);
            this.arduino.TabIndex = 6;
            this.arduino.TabStop = false;
            this.arduino.Text = "Arduino";
            // 
            // refreshButton
            // 
            this.refreshButton.BackgroundImage = global::Spectrum.Properties.Resources.refresh;
            this.refreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshButton.Location = new System.Drawing.Point(190, 19);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(21, 21);
            this.refreshButton.TabIndex = 6;
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // turnOffOnClose
            // 
            this.turnOffOnClose.AutoSize = true;
            this.turnOffOnClose.Location = new System.Drawing.Point(63, 106);
            this.turnOffOnClose.Name = "turnOffOnClose";
            this.turnOffOnClose.Size = new System.Drawing.Size(109, 17);
            this.turnOffOnClose.TabIndex = 5;
            this.turnOffOnClose.Text = "Turn Off on Close";
            this.turnOffOnClose.UseVisualStyleBackColor = true;
            this.turnOffOnClose.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // responsiveLighting
            // 
            this.responsiveLighting.AutoSize = true;
            this.responsiveLighting.Location = new System.Drawing.Point(63, 152);
            this.responsiveLighting.Name = "responsiveLighting";
            this.responsiveLighting.Size = new System.Drawing.Size(122, 17);
            this.responsiveLighting.TabIndex = 4;
            this.responsiveLighting.Text = "Responsive Lighting";
            this.responsiveLighting.UseVisualStyleBackColor = true;
            this.responsiveLighting.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // turnOnWithApp
            // 
            this.turnOnWithApp.AutoSize = true;
            this.turnOnWithApp.Location = new System.Drawing.Point(63, 129);
            this.turnOnWithApp.Name = "turnOnWithApp";
            this.turnOnWithApp.Size = new System.Drawing.Size(112, 17);
            this.turnOnWithApp.TabIndex = 3;
            this.turnOnWithApp.Text = "Turn On With App";
            this.turnOnWithApp.UseVisualStyleBackColor = true;
            this.turnOnWithApp.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // portComboBox
            // 
            this.portComboBox.FormattingEnabled = true;
            this.portComboBox.Location = new System.Drawing.Point(63, 19);
            this.portComboBox.Name = "portComboBox";
            this.portComboBox.Size = new System.Drawing.Size(121, 21);
            this.portComboBox.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(642, 684);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Enabled = false;
            this.applyButton.Location = new System.Drawing.Point(734, 684);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 8;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(549, 684);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // updater
            // 
            this.updater.Controls.Add(this.button4);
            this.updater.Controls.Add(this.checkForUpdate);
            this.updater.Controls.Add(this.label2);
            this.updater.Controls.Add(this.label1);
            this.updater.Controls.Add(this.downloadPath);
            this.updater.Location = new System.Drawing.Point(131, 254);
            this.updater.Name = "updater";
            this.updater.Size = new System.Drawing.Size(252, 191);
            this.updater.TabIndex = 6;
            this.updater.TabStop = false;
            this.updater.Text = "Updates";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(216, 43);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(30, 20);
            this.button4.TabIndex = 5;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // checkForUpdate
            // 
            this.checkForUpdate.FormattingEnabled = true;
            this.checkForUpdate.Items.AddRange(new object[] {
            "Launch",
            "Daily",
            "Weekly",
            "Biweekly",
            "Monthly"});
            this.checkForUpdate.Location = new System.Drawing.Point(114, 74);
            this.checkForUpdate.Name = "checkForUpdate";
            this.checkForUpdate.Size = new System.Drawing.Size(115, 21);
            this.checkForUpdate.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Check For Updates:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Download Path:";
            // 
            // downloadPath
            // 
            this.downloadPath.Location = new System.Drawing.Point(9, 43);
            this.downloadPath.Name = "downloadPath";
            this.downloadPath.Size = new System.Drawing.Size(201, 20);
            this.downloadPath.TabIndex = 1;
            // 
            // logs
            // 
            this.logs.Controls.Add(this.saveFileButton);
            this.logs.Controls.Add(this.logPathLabel);
            this.logs.Controls.Add(this.logPath);
            this.logs.Controls.Add(this.reportErrors);
            this.logs.Controls.Add(this.autoScroll);
            this.logs.Controls.Add(this.enableLogs);
            this.logs.Location = new System.Drawing.Point(428, 254);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(252, 191);
            this.logs.TabIndex = 6;
            this.logs.TabStop = false;
            this.logs.Text = "Logs";
            // 
            // saveFileButton
            // 
            this.saveFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveFileButton.Location = new System.Drawing.Point(216, 43);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(30, 20);
            this.saveFileButton.TabIndex = 5;
            this.saveFileButton.Text = "...";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // logPathLabel
            // 
            this.logPathLabel.AutoSize = true;
            this.logPathLabel.Location = new System.Drawing.Point(6, 23);
            this.logPathLabel.Name = "logPathLabel";
            this.logPathLabel.Size = new System.Drawing.Size(53, 13);
            this.logPathLabel.TabIndex = 2;
            this.logPathLabel.Text = "Log Path:";
            // 
            // logPath
            // 
            this.logPath.Location = new System.Drawing.Point(9, 43);
            this.logPath.Name = "logPath";
            this.logPath.Size = new System.Drawing.Size(201, 20);
            this.logPath.TabIndex = 1;
            // 
            // reportErrors
            // 
            this.reportErrors.AutoSize = true;
            this.reportErrors.Location = new System.Drawing.Point(63, 122);
            this.reportErrors.Name = "reportErrors";
            this.reportErrors.Size = new System.Drawing.Size(88, 17);
            this.reportErrors.TabIndex = 0;
            this.reportErrors.Text = "Report Errors";
            this.reportErrors.UseVisualStyleBackColor = true;
            this.reportErrors.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // autoScroll
            // 
            this.autoScroll.AutoSize = true;
            this.autoScroll.Location = new System.Drawing.Point(63, 99);
            this.autoScroll.Name = "autoScroll";
            this.autoScroll.Size = new System.Drawing.Size(77, 17);
            this.autoScroll.TabIndex = 0;
            this.autoScroll.Text = "Auto Scroll";
            this.autoScroll.UseVisualStyleBackColor = true;
            this.autoScroll.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // enableLogs
            // 
            this.enableLogs.AutoSize = true;
            this.enableLogs.Location = new System.Drawing.Point(63, 76);
            this.enableLogs.Name = "enableLogs";
            this.enableLogs.Size = new System.Drawing.Size(85, 17);
            this.enableLogs.TabIndex = 0;
            this.enableLogs.Text = "Enable Logs";
            this.enableLogs.UseVisualStyleBackColor = true;
            this.enableLogs.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // advanced
            // 
            this.advanced.Location = new System.Drawing.Point(131, 489);
            this.advanced.Name = "advanced";
            this.advanced.Size = new System.Drawing.Size(252, 191);
            this.advanced.TabIndex = 6;
            this.advanced.TabStop = false;
            this.advanced.Text = "Advanced";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.FileName = "log.txt";
            this.saveFileDialog1.Filter = " Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.saveFileDialog1.Title = "Choose Log File Location";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 718);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.advanced);
            this.Controls.Add(this.updater);
            this.Controls.Add(this.arduino);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.general);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.Text = "SettingsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.SettingsForm_Shown);
            this.general.ResumeLayout(false);
            this.general.PerformLayout();
            this.arduino.ResumeLayout(false);
            this.arduino.PerformLayout();
            this.updater.ResumeLayout(false);
            this.updater.PerformLayout();
            this.logs.ResumeLayout(false);
            this.logs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox general;
        private System.Windows.Forms.ComboBox profileComboBox;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.CheckBox startWithWindows;
        private System.Windows.Forms.CheckBox connectOnStart;
        private System.Windows.Forms.CheckBox startMinimized;
        private System.Windows.Forms.CheckBox minimizeToTray;
        private System.Windows.Forms.CheckBox closeToTray;
        private System.Windows.Forms.GroupBox arduino;
        private System.Windows.Forms.CheckBox turnOffOnClose;
        private System.Windows.Forms.CheckBox responsiveLighting;
        private System.Windows.Forms.CheckBox turnOnWithApp;
        private System.Windows.Forms.ComboBox portComboBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button okButton;
        public System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.GroupBox updater;
        private System.Windows.Forms.ComboBox checkForUpdate;
        private System.Windows.Forms.GroupBox logs;
        private System.Windows.Forms.GroupBox advanced;
        private System.Windows.Forms.CheckBox autoScroll;
        private System.Windows.Forms.CheckBox enableLogs;
        private System.Windows.Forms.TextBox logPath;
        private System.Windows.Forms.Label logPathLabel;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox downloadPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox reportErrors;
    }
}