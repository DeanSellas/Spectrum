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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Arduino");
            this.general = new System.Windows.Forms.GroupBox();
            this.minimizeToTray = new System.Windows.Forms.CheckBox();
            this.closeToTray = new System.Windows.Forms.CheckBox();
            this.startMinimized = new System.Windows.Forms.CheckBox();
            this.connectOnStart = new System.Windows.Forms.CheckBox();
            this.startWithWindows = new System.Windows.Forms.CheckBox();
            this.profileComboBox = new System.Windows.Forms.ComboBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.arduino = new System.Windows.Forms.GroupBox();
            this.turnOffOnClose = new System.Windows.Forms.CheckBox();
            this.responsiveLighting = new System.Windows.Forms.CheckBox();
            this.turnOnWithApp = new System.Windows.Forms.CheckBox();
            this.portComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.general.SuspendLayout();
            this.arduino.SuspendLayout();
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
            treeNode3.Name = "generalNode";
            treeNode3.Text = "General";
            treeNode3.ToolTipText = "General Settings";
            treeNode4.Name = "arduinoNode";
            treeNode4.Text = "Arduino";
            treeNode4.ToolTipText = "Arduino Settings";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.treeView1.ShowLines = false;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(113, 538);
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
            // turnOffOnClose
            // 
            this.turnOffOnClose.AutoSize = true;
            this.turnOffOnClose.Location = new System.Drawing.Point(63, 106);
            this.turnOffOnClose.Name = "turnOffOnClose";
            this.turnOffOnClose.Size = new System.Drawing.Size(109, 17);
            this.turnOffOnClose.TabIndex = 5;
            this.turnOffOnClose.Text = "Turn Off on Close";
            this.turnOffOnClose.UseVisualStyleBackColor = true;
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
            // 
            // portComboBox
            // 
            this.portComboBox.FormattingEnabled = true;
            this.portComboBox.Location = new System.Drawing.Point(63, 19);
            this.portComboBox.Name = "portComboBox";
            this.portComboBox.Size = new System.Drawing.Size(121, 21);
            this.portComboBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(642, 504);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(734, 504);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Apply";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(549, 504);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "OK";
            this.button3.UseVisualStyleBackColor = true;
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
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 538);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.arduino);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.general);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.Text = "SettingsForm";
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.general.ResumeLayout(false);
            this.general.PerformLayout();
            this.arduino.ResumeLayout(false);
            this.arduino.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button refreshButton;
    }
}