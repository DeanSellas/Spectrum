namespace Spectrum {
    partial class spectrumFormMain {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(spectrumFormMain));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.redValue = new System.Windows.Forms.NumericUpDown();
            this.redLabel = new System.Windows.Forms.Label();
            this.greenLabel = new System.Windows.Forms.Label();
            this.greenValue = new System.Windows.Forms.NumericUpDown();
            this.blueLabel = new System.Windows.Forms.Label();
            this.blueValue = new System.Windows.Forms.NumericUpDown();
            this.spectrumTrayItem = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solidColorButton = new System.Windows.Forms.Button();
            this.portConnectButton = new System.Windows.Forms.Button();
            this.serialComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportBugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rainbowButton = new System.Windows.Forms.Button();
            this.delayValue = new System.Windows.Forms.NumericUpDown();
            this.delayLabel = new System.Windows.Forms.Label();
            this.connectedStatusLabel = new System.Windows.Forms.Label();
            this.rainbowTypeComboBox = new System.Windows.Forms.ComboBox();
            this.offButton = new System.Windows.Forms.Button();
            this.colorPreview = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.responsiveLightingCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.redValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueValue)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delayValue)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "0";
            // 
            // redValue
            // 
            this.redValue.InterceptArrowKeys = false;
            this.redValue.Location = new System.Drawing.Point(215, 138);
            this.redValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.redValue.Name = "redValue";
            this.redValue.Size = new System.Drawing.Size(60, 20);
            this.redValue.TabIndex = 1;
            this.redValue.ValueChanged += new System.EventHandler(this.color_ValueChanged_event);
            this.redValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.color_ValueChanged);
            // 
            // redLabel
            // 
            this.redLabel.AutoSize = true;
            this.redLabel.Location = new System.Drawing.Point(149, 140);
            this.redLabel.Name = "redLabel";
            this.redLabel.Size = new System.Drawing.Size(60, 13);
            this.redLabel.TabIndex = 2;
            this.redLabel.Text = "Red Value:";
            // 
            // greenLabel
            // 
            this.greenLabel.AutoSize = true;
            this.greenLabel.Location = new System.Drawing.Point(281, 140);
            this.greenLabel.Name = "greenLabel";
            this.greenLabel.Size = new System.Drawing.Size(69, 13);
            this.greenLabel.TabIndex = 4;
            this.greenLabel.Text = "Green Value:";
            // 
            // greenValue
            // 
            this.greenValue.InterceptArrowKeys = false;
            this.greenValue.Location = new System.Drawing.Point(356, 138);
            this.greenValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.greenValue.Name = "greenValue";
            this.greenValue.Size = new System.Drawing.Size(60, 20);
            this.greenValue.TabIndex = 3;
            this.greenValue.ValueChanged += new System.EventHandler(this.color_ValueChanged_event);
            this.greenValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.color_ValueChanged);
            // 
            // blueLabel
            // 
            this.blueLabel.AutoSize = true;
            this.blueLabel.Location = new System.Drawing.Point(422, 140);
            this.blueLabel.Name = "blueLabel";
            this.blueLabel.Size = new System.Drawing.Size(61, 13);
            this.blueLabel.TabIndex = 6;
            this.blueLabel.Text = "Blue Value:";
            // 
            // blueValue
            // 
            this.blueValue.InterceptArrowKeys = false;
            this.blueValue.Location = new System.Drawing.Point(489, 138);
            this.blueValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.blueValue.Name = "blueValue";
            this.blueValue.Size = new System.Drawing.Size(60, 20);
            this.blueValue.TabIndex = 5;
            this.blueValue.ValueChanged += new System.EventHandler(this.color_ValueChanged_event);
            this.blueValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.color_ValueChanged);
            // 
            // spectrumTrayItem
            // 
            this.spectrumTrayItem.ContextMenuStrip = this.contextMenuStrip1;
            this.spectrumTrayItem.Icon = ((System.Drawing.Icon)(resources.GetObject("spectrumTrayItem.Icon")));
            this.spectrumTrayItem.Text = "Spectrum: Disconnected";
            this.spectrumTrayItem.Visible = true;
            this.spectrumTrayItem.DoubleClick += new System.EventHandler(this.spectrumTrayItem_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.toolStripSeparator1,
            this.showToolStripMenuItem,
            this.settingsToolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(120, 98);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(116, 6);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.settingsToolStripMenuItem1.Text = "Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.settingsToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.exitToolStripMenuItem.Text = "EXIT";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // solidColorButton
            // 
            this.solidColorButton.Location = new System.Drawing.Point(68, 135);
            this.solidColorButton.Name = "solidColorButton";
            this.solidColorButton.Size = new System.Drawing.Size(75, 25);
            this.solidColorButton.TabIndex = 8;
            this.solidColorButton.Text = "Solid Color";
            this.solidColorButton.UseVisualStyleBackColor = true;
            this.solidColorButton.Click += new System.EventHandler(this.solidColorButton_Click);
            // 
            // portConnectButton
            // 
            this.portConnectButton.Location = new System.Drawing.Point(236, 92);
            this.portConnectButton.Name = "portConnectButton";
            this.portConnectButton.Size = new System.Drawing.Size(75, 23);
            this.portConnectButton.TabIndex = 0;
            this.portConnectButton.Text = "Connect";
            this.portConnectButton.UseVisualStyleBackColor = true;
            this.portConnectButton.Click += new System.EventHandler(this.portConnectButton_Click);
            // 
            // serialComboBox
            // 
            this.serialComboBox.Location = new System.Drawing.Point(219, 65);
            this.serialComboBox.Name = "serialComboBox";
            this.serialComboBox.Size = new System.Drawing.Size(121, 21);
            this.serialComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Select The Correct COM Port";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.donateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(559, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator2,
            this.checkForUpdatesToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check For Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.reportBugToolStripMenuItem,
            this.githubToolStripMenuItem,
            this.resetSettingsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            this.documentationToolStripMenuItem.Click += new System.EventHandler(this.documentationToolStripMenuItem_Click);
            // 
            // reportBugToolStripMenuItem
            // 
            this.reportBugToolStripMenuItem.Name = "reportBugToolStripMenuItem";
            this.reportBugToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.reportBugToolStripMenuItem.Text = "Report Bug";
            this.reportBugToolStripMenuItem.Click += new System.EventHandler(this.reportBugToolStripMenuItem_Click);
            // 
            // githubToolStripMenuItem
            // 
            this.githubToolStripMenuItem.Name = "githubToolStripMenuItem";
            this.githubToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.githubToolStripMenuItem.Text = "Github";
            this.githubToolStripMenuItem.Click += new System.EventHandler(this.githubToolStripMenuItem_Click);
            // 
            // resetSettingsToolStripMenuItem
            // 
            this.resetSettingsToolStripMenuItem.Name = "resetSettingsToolStripMenuItem";
            this.resetSettingsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.resetSettingsToolStripMenuItem.Text = "Reset Settings";
            this.resetSettingsToolStripMenuItem.Click += new System.EventHandler(this.resetSettingsToolStripMenuItem_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // rainbowButton
            // 
            this.rainbowButton.Location = new System.Drawing.Point(68, 275);
            this.rainbowButton.Name = "rainbowButton";
            this.rainbowButton.Size = new System.Drawing.Size(75, 23);
            this.rainbowButton.TabIndex = 10;
            this.rainbowButton.Text = "Rainbow";
            this.rainbowButton.UseVisualStyleBackColor = true;
            this.rainbowButton.Click += new System.EventHandler(this.rainbowButton_Click);
            // 
            // delayValue
            // 
            this.delayValue.InterceptArrowKeys = false;
            this.delayValue.Location = new System.Drawing.Point(385, 278);
            this.delayValue.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.delayValue.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.delayValue.Name = "delayValue";
            this.delayValue.Size = new System.Drawing.Size(89, 20);
            this.delayValue.TabIndex = 1;
            this.delayValue.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(246, 280);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(133, 13);
            this.delayLabel.TabIndex = 2;
            this.delayLabel.Text = "Delay Value (Milliseconds):";
            // 
            // connectedStatusLabel
            // 
            this.connectedStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.connectedStatusLabel.BackColor = System.Drawing.Color.Red;
            this.connectedStatusLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.connectedStatusLabel.Location = new System.Drawing.Point(466, 350);
            this.connectedStatusLabel.Name = "connectedStatusLabel";
            this.connectedStatusLabel.Size = new System.Drawing.Size(90, 20);
            this.connectedStatusLabel.TabIndex = 11;
            this.connectedStatusLabel.Text = "Not Connected";
            this.connectedStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rainbowTypeComboBox
            // 
            this.rainbowTypeComboBox.FormattingEnabled = true;
            this.rainbowTypeComboBox.Items.AddRange(new object[] {
            "Cycle",
            "Full Rainbow"});
            this.rainbowTypeComboBox.Location = new System.Drawing.Point(149, 275);
            this.rainbowTypeComboBox.Name = "rainbowTypeComboBox";
            this.rainbowTypeComboBox.Size = new System.Drawing.Size(91, 21);
            this.rainbowTypeComboBox.TabIndex = 12;
            // 
            // offButton
            // 
            this.offButton.Location = new System.Drawing.Point(236, 322);
            this.offButton.Name = "offButton";
            this.offButton.Size = new System.Drawing.Size(75, 38);
            this.offButton.TabIndex = 13;
            this.offButton.Text = "Off";
            this.offButton.UseVisualStyleBackColor = true;
            this.offButton.Click += new System.EventHandler(this.offButton_Click);
            // 
            // colorPreview
            // 
            this.colorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPreview.Cursor = System.Windows.Forms.Cursors.Help;
            this.colorPreview.Location = new System.Drawing.Point(215, 164);
            this.colorPreview.Name = "colorPreview";
            this.colorPreview.Size = new System.Drawing.Size(113, 78);
            this.colorPreview.TabIndex = 14;
            this.toolTip1.SetToolTip(this.colorPreview, "This is a preview of the color that the strip will display.\r\nNote that color accu" +
        "racy is different on every strip so this will not be 100% accurate.");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Color Preview";
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Color Preview";
            // 
            // responsiveLightingCheckbox
            // 
            this.responsiveLightingCheckbox.AutoSize = true;
            this.responsiveLightingCheckbox.Location = new System.Drawing.Point(68, 166);
            this.responsiveLightingCheckbox.Name = "responsiveLightingCheckbox";
            this.responsiveLightingCheckbox.Size = new System.Drawing.Size(122, 17);
            this.responsiveLightingCheckbox.TabIndex = 16;
            this.responsiveLightingCheckbox.Text = "Responsive Lighting";
            this.responsiveLightingCheckbox.UseVisualStyleBackColor = true;
            this.responsiveLightingCheckbox.CheckedChanged += new System.EventHandler(this.responsiveLightingCheckbox_CheckedChanged);
            // 
            // spectrumFormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(559, 372);
            this.Controls.Add(this.responsiveLightingCheckbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.colorPreview);
            this.Controls.Add(this.offButton);
            this.Controls.Add(this.rainbowTypeComboBox);
            this.Controls.Add(this.connectedStatusLabel);
            this.Controls.Add(this.rainbowButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serialComboBox);
            this.Controls.Add(this.portConnectButton);
            this.Controls.Add(this.solidColorButton);
            this.Controls.Add(this.blueLabel);
            this.Controls.Add(this.blueValue);
            this.Controls.Add(this.greenLabel);
            this.Controls.Add(this.greenValue);
            this.Controls.Add(this.delayLabel);
            this.Controls.Add(this.redLabel);
            this.Controls.Add(this.delayValue);
            this.Controls.Add(this.redValue);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "spectrumFormMain";
            this.Text = "Spectrum";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.spectrumFormMain_FormClosing);
            this.Shown += new System.EventHandler(this.spectrumFormMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.redValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueValue)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delayValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown redValue;
        private System.Windows.Forms.Label redLabel;
        private System.Windows.Forms.Label greenLabel;
        private System.Windows.Forms.NumericUpDown greenValue;
        private System.Windows.Forms.Label blueLabel;
        private System.Windows.Forms.NumericUpDown blueValue;
        private System.Windows.Forms.NotifyIcon spectrumTrayItem;
        private System.Windows.Forms.Button solidColorButton;
        private System.Windows.Forms.Button portConnectButton;
        private System.Windows.Forms.ComboBox serialComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button rainbowButton;
        private System.Windows.Forms.NumericUpDown delayValue;
        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.Label connectedStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem githubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reportBugToolStripMenuItem;
        private System.Windows.Forms.ComboBox rainbowTypeComboBox;
        private System.Windows.Forms.Button offButton;
        private System.Windows.Forms.FlowLayoutPanel colorPreview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.CheckBox responsiveLightingCheckbox;
    }
}

