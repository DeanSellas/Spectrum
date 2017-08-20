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
            this.closeToTrayCheckbox = new System.Windows.Forms.CheckBox();
            this.spectrumTrayItem = new System.Windows.Forms.NotifyIcon(this.components);
            this.solidColorButton = new System.Windows.Forms.Button();
            this.portConnectButton = new System.Windows.Forms.Button();
            this.serialComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rainbowButton = new System.Windows.Forms.Button();
            this.delayValue = new System.Windows.Forms.NumericUpDown();
            this.delayLabel = new System.Windows.Forms.Label();
            this.connectedStatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.redValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueValue)).BeginInit();
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
            this.greenValue.Location = new System.Drawing.Point(356, 140);
            this.greenValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.greenValue.Name = "greenValue";
            this.greenValue.Size = new System.Drawing.Size(60, 20);
            this.greenValue.TabIndex = 3;
            // 
            // blueLabel
            // 
            this.blueLabel.AutoSize = true;
            this.blueLabel.Location = new System.Drawing.Point(422, 142);
            this.blueLabel.Name = "blueLabel";
            this.blueLabel.Size = new System.Drawing.Size(61, 13);
            this.blueLabel.TabIndex = 6;
            this.blueLabel.Text = "Blue Value:";
            // 
            // blueValue
            // 
            this.blueValue.InterceptArrowKeys = false;
            this.blueValue.Location = new System.Drawing.Point(488, 140);
            this.blueValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.blueValue.Name = "blueValue";
            this.blueValue.Size = new System.Drawing.Size(60, 20);
            this.blueValue.TabIndex = 5;
            // 
            // closeToTrayCheckbox
            // 
            this.closeToTrayCheckbox.AutoSize = true;
            this.closeToTrayCheckbox.Location = new System.Drawing.Point(219, 343);
            this.closeToTrayCheckbox.Name = "closeToTrayCheckbox";
            this.closeToTrayCheckbox.Size = new System.Drawing.Size(92, 17);
            this.closeToTrayCheckbox.TabIndex = 7;
            this.closeToTrayCheckbox.Text = "Close To Tray";
            this.closeToTrayCheckbox.UseVisualStyleBackColor = true;
            // 
            // spectrumTrayItem
            // 
            this.spectrumTrayItem.Icon = ((System.Drawing.Icon)(resources.GetObject("spectrumTrayItem.Icon")));
            this.spectrumTrayItem.Text = "Spectrum";
            this.spectrumTrayItem.Visible = true;
            this.spectrumTrayItem.DoubleClick += new System.EventHandler(this.spectrumTrayItem_DoubleClick);
            // 
            // solidColorButton
            // 
            this.solidColorButton.Location = new System.Drawing.Point(68, 135);
            this.solidColorButton.Name = "solidColorButton";
            this.solidColorButton.Size = new System.Drawing.Size(75, 23);
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
            this.helpToolStripMenuItem});
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
            this.settingsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // rainbowButton
            // 
            this.rainbowButton.Location = new System.Drawing.Point(68, 191);
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
            this.delayValue.Location = new System.Drawing.Point(288, 194);
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
            this.delayLabel.Location = new System.Drawing.Point(149, 196);
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
            // spectrumFormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(559, 372);
            this.Controls.Add(this.connectedStatusLabel);
            this.Controls.Add(this.rainbowButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serialComboBox);
            this.Controls.Add(this.portConnectButton);
            this.Controls.Add(this.solidColorButton);
            this.Controls.Add(this.closeToTrayCheckbox);
            this.Controls.Add(this.blueLabel);
            this.Controls.Add(this.blueValue);
            this.Controls.Add(this.greenLabel);
            this.Controls.Add(this.greenValue);
            this.Controls.Add(this.delayLabel);
            this.Controls.Add(this.redLabel);
            this.Controls.Add(this.delayValue);
            this.Controls.Add(this.redValue);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "spectrumFormMain";
            this.Text = "Spectrum";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.spectrumFormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.redValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueValue)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delayValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.NumericUpDown redValue;
        private System.Windows.Forms.Label redLabel;
        private System.Windows.Forms.Label greenLabel;
        private System.Windows.Forms.NumericUpDown greenValue;
        private System.Windows.Forms.Label blueLabel;
        private System.Windows.Forms.NumericUpDown blueValue;
        private System.Windows.Forms.CheckBox closeToTrayCheckbox;
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
    }
}

