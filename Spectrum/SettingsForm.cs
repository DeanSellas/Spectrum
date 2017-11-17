using Microsoft.Win32;
using Spectrum.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spectrum {
    public partial class SettingsForm : Form {

        // CODE REQUIRES CLEANUP

        int originalComboBoxVal = Settings.Default.updateComboBoxInt;

        bool checkChanged = false;

        string currentLocation = AppDomain.CurrentDomain.BaseDirectory;

        public SettingsForm() {

            InitializeComponent();

            // Sets Window Properties
            int defaultTop = generalSettingsGroupBox.Top;
            int defaultLeft = generalSettingsGroupBox.Left;
            Size = new Size(391, 320);

            // Sets Check Box
            if (Settings.Default.isConnected) startupConnectCheckBox.Enabled = true;
            if (Settings.Default.closeToTrayBool) closeToTrayCheckbox.Checked = true;
            if (Settings.Default.connectOnStartupBool) startupConnectCheckBox.Checked = true;
            if (Settings.Default.startMinimizedBool) startMinCheckbox.Checked = true;
            if (Settings.Default.windowsStartupBool) windowsCheckbox.Checked = true;
            if (Settings.Default.turnOffOnClose) offOnClose.Checked = true;

            // Update Group Box Settings
            updateComboBox.SelectedIndex = Settings.Default.updateComboBoxInt;
            updatesGroupBox.Left = defaultLeft;
            updatesGroupBox.Top = defaultTop;
            
            // Update Settings
            fileExplorerTextBox.Text = Settings.Default.fileLocation;
            if (Settings.Default.fileLocation == "") {
                Settings.Default.fileLocation = currentLocation;
            }

            // Treeview Settings
            treeView1.TabIndex = 0;
        }

        // Check Box Settings
        private void settingsCheckboxes_CheckedChanged(object sender, EventArgs e) {
            // Connect At Startup
            if (Settings.Default.connectOnStartupBool != startupConnectCheckBox.Checked) checkChanged = true;
            // Close To Tray
            else if (Settings.Default.closeToTrayBool != closeToTrayCheckbox.Checked) checkChanged = true;
            // Start Minimized
            else if (Settings.Default.startMinimizedBool != startMinCheckbox.Checked) checkChanged = true;
            // Start With Windows
            else if (Settings.Default.windowsStartupBool != windowsCheckbox.Checked) checkChanged = true;
            // Turn Off On Close
            else if (Settings.Default.turnOffOnClose != offOnClose.Checked) checkChanged = true;
            // Else
            else checkChanged = false;

            // Apply Settings Enabled
            if (checkChanged || Settings.Default.updateComboBoxInt != originalComboBoxVal) applySettingsButton.Enabled = true;
            else applySettingsButton.Enabled = false;
        }


        

        // Update ComboBox
        private void updateComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            Settings.Default.updateComboBoxInt = updateComboBox.SelectedIndex;

            if (updateComboBox.SelectedIndex == 0) Settings.Default.startupUpdateDate = false;



            if(Settings.Default.updateComboBoxInt != originalComboBoxVal || checkChanged) applySettingsButton.Enabled = true;
            else applySettingsButton.Enabled = false;
            
        }

        // Tree View
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            if (treeView1.SelectedNode.Name == "generalNode") {
                updatesGroupBox.Visible = false;
                generalSettingsGroupBox.Visible = true;
            }
            else if (treeView1.SelectedNode.Name == "updatesNode") {
                generalSettingsGroupBox.Visible = false;
                updatesGroupBox.Visible = true;
            }
        }

        // Cancel Button
        private void cancelButton_Click(object sender, EventArgs e) {

            if (applySettingsButton.Enabled) {
                DialogResult dialogResult = MessageBox.Show("You have unsaved settings are you sure you want to exit settings without saving?", "Exit Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes) Close();
            }
            else Close();
            
        }

        // Apply Button
        private void applySettingsButton_Click(object sender, EventArgs e) {
            saveSettings();

            applySettingsButton.Enabled = false;
        }
        
        // Ok Button
        private void okButton_Click(object sender, EventArgs e) {
            saveSettings();
            Close();
        }

        // Save Settings
        void saveSettings() {
            // Connect at Startup Settings
            if (startupConnectCheckBox.Checked) Settings.Default.connectOnStartupBool = true;
            else Settings.Default.connectOnStartupBool = false;

            // Close to Tray Settings
            if (closeToTrayCheckbox.Checked) Settings.Default.closeToTrayBool = true;
            else Settings.Default.closeToTrayBool = false;

            // Start Minimized
            if (startMinCheckbox.Checked) Settings.Default.startMinimizedBool = true;
            else Settings.Default.startMinimizedBool = false;

            // Turn Off On Close
            if (offOnClose.Checked) Settings.Default.turnOffOnClose = true;
            else Settings.Default.turnOffOnClose = false;

            // Start With Windows
            if (windowsCheckbox.Checked) {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true)) {
                    key.SetValue("Spectrum", "\"" + Application.ExecutablePath + "\"");
                    Settings.Default.windowsStartupBool = true;
                }
            }
            else {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true)) {
                    key.DeleteValue("Spectrum", false);
                    Settings.Default.windowsStartupBool = false;
                }
            }
            Settings.Default.fileLocation = fileExplorerTextBox.Text;

            Settings.Default.Save();
        }

        // File Explorer Button
        private void fileExplorerButton_Click(object sender, EventArgs e) {
            folderBrowserDialog1.ShowDialog();
            fileExplorerTextBox.Text = folderBrowserDialog1.SelectedPath.ToString()+ '\\' ;
        }

        // File Location Text Box
        private void fileExplorerTextBox_TextChanged(object sender, EventArgs e) {
            if (fileExplorerTextBox.Text != Settings.Default.fileLocation || Settings.Default.updateComboBoxInt != originalComboBoxVal || checkChanged) {
                applySettingsButton.Enabled = true;
            }
            else applySettingsButton.Enabled = false;
        }
        
        // File Explorer Default Location
        private void defaultLocationButton_Click(object sender, EventArgs e) {
            fileExplorerTextBox.Text = currentLocation;
        }
    }
}
