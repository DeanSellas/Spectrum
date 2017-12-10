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

        bool checkChanged = false, comboChanged = false;

        string currentLocation = AppDomain.CurrentDomain.BaseDirectory;

        Point defaultLocation = new Point(82, 34);

        spectrumFormMain spectrumForm;

        public SettingsForm(spectrumFormMain openForm) {

            InitializeComponent();

            spectrumForm = openForm;

            Size = new Size(391, 320);

            okButton.Location = new Point(119, 248);
            cancelButton.Location = new Point(204, 248);
            applySettingsButton.Location = new Point(289, 248);


            updatesGroupBox.Location = defaultLocation;

            arduinoSettingsGroupBox.Location = defaultLocation;

            advancedSettingsGroupBox.Location = defaultLocation;

        }


        private void SettingsForm_Shown(object sender, EventArgs e) {
            arduinoSettings();
            defaultSettings(false);
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
            // Responsive Lighting
            else if (Settings.Default.responsiveLighting != responsiveLightingCheckbox.Checked) checkChanged = true;
            // Remember Lighting
            else if (Settings.Default.rememberLightProfile != rememberLightCheckbox.Checked) checkChanged = true;
            // Advanced Lighting
            else if (Settings.Default.advancedLighting != advancedLightingCheckbox.Checked) checkChanged = true;
            // Else
            else checkChanged = false;

            // Apply Settings Enabled
            if (checkChanged || comboChanged) applySettingsButton.Enabled = true;
            else applySettingsButton.Enabled = false;
        }

        // Combo Box Settings
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e) {
            
            if (Settings.Default.updateComboBoxInt != updateComboBox.SelectedIndex) comboChanged = true;
            else if (Settings.Default.port != defaultPortComboBox.Text) comboChanged = true;
            else comboChanged = false;

            // Apply Settings Enabled
            if (checkChanged || comboChanged) applySettingsButton.Enabled = true;
            else applySettingsButton.Enabled = false;
        }

        private void arduinoSettings() {
            
            // Display each port name to the console.
            foreach (string port in spectrumForm.ports) {
                Console.WriteLine(port);
                defaultPortComboBox.Items.Add(port);
            }

            stripLengthUpDown.Value = Settings.Default.stripLength;

            int index = defaultPortComboBox.Items.IndexOf(Settings.Default.port);
            defaultPortComboBox.SelectedIndex = index;
        }

        private void stripLengthUpDown_ValueChanged(object sender, EventArgs e) {
            stripLengthUpDown_KeyUp(sender, null);
        }

        private void stripLengthUpDown_KeyUp(object sender, KeyEventArgs e) {
            if (stripLengthUpDown.Value != Settings.Default.stripLength || checkChanged) applySettingsButton.Enabled = true;
            else applySettingsButton.Enabled = false;
        }

        // Tree View
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            if (treeView1.SelectedNode.Name == "generalNode") {
                generalSettingsGroupBox.Visible = true;

                updatesGroupBox.Visible = false;
                arduinoSettingsGroupBox.Visible = false;
                advancedSettingsGroupBox.Visible = false;
            }
            else if (treeView1.SelectedNode.Name == "arduinoNode") {
                arduinoSettingsGroupBox.Visible = true;

                updatesGroupBox.Visible = false;
                generalSettingsGroupBox.Visible = false;
                advancedSettingsGroupBox.Visible = false;
            }
            else if (treeView1.SelectedNode.Name == "updatesNode") {
                updatesGroupBox.Visible = true;

                generalSettingsGroupBox.Visible = false;
                arduinoSettingsGroupBox.Visible = false;
                advancedSettingsGroupBox.Visible = false;
            }
            else if (treeView1.SelectedNode.Name == "advancedNode") {
                advancedSettingsGroupBox.Visible = true;

                generalSettingsGroupBox.Visible = false;
                arduinoSettingsGroupBox.Visible = false;
                updatesGroupBox.Visible = false;
            }
        }

        // Cancel Button
        private void cancelButton_Click(object sender, EventArgs e) { Close(); }

        // Apply Button
        private void applySettingsButton_Click(object sender, EventArgs e) { saveSettings(); }
        
        // Ok Button
        private void okButton_Click(object sender, EventArgs e) {
            saveSettings();
            Close();
        }

        private void defaultSettingsButton_Click(object sender, EventArgs e) { defaultSettings(true); }

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

            // Remember Lighting Profile
            if (rememberLightCheckbox.Checked) Settings.Default.rememberLightProfile = true;
            else Settings.Default.rememberLightProfile = false;

            

            // Turn Off On Close
            if (offOnClose.Checked) Settings.Default.turnOffOnClose = true;
            else Settings.Default.turnOffOnClose = false;

            // Responsive Lighting
            if (responsiveLightingCheckbox.Checked) {
                Settings.Default.responsiveLighting = true;
                if(Settings.Default.isConnected) spectrumForm.solidColorButton.Enabled = false;
            }
            else {
                Settings.Default.responsiveLighting = false;
                if (Settings.Default.isConnected) spectrumForm.solidColorButton.Enabled = true;
            }

            // Advanced Lighting
            if (advancedLightingCheckbox.Checked) {
                Settings.Default.advancedLighting = true;
                spectrumForm.advancedLightingPanel.Visible = true;
                spectrumForm.colorPreview.Location = new Point(215, 207);
                spectrumForm.colorPreviewLabel.Location = new Point(239, 288);
            }
            else {
                Settings.Default.advancedLighting = false;
                spectrumForm.advancedLightingPanel.Visible = false;
                spectrumForm.colorPreview.Location = new Point(215, 177);
                spectrumForm.colorPreviewLabel.Location = new Point(239, 258);
            }

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

            Settings.Default.updateComboBoxInt = updateComboBox.SelectedIndex;
            Settings.Default.fileLocation = fileExplorerTextBox.Text;

            Settings.Default.port = defaultPortComboBox.Text;
            Settings.Default.stripLength = Convert.ToInt32(stripLengthUpDown.Value);

            Settings.Default.Save();

            applySettingsButton.Enabled = false;
        }

        // File Explorer Button
        private void fileExplorerButton_Click(object sender, EventArgs e) {

            DialogResult ok = new DialogResult();

            ok = folderBrowserDialog1.ShowDialog();
            if(ok == DialogResult.OK) fileExplorerTextBox.Text = folderBrowserDialog1.SelectedPath.ToString()+ '\\' ;
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

        

        // Prevents Form from closing by hiding it || Used to fix bug
        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e) {

            e.Cancel = true;

            if (applySettingsButton.Enabled) {
                DialogResult dialogResult = MessageBox.Show("You have unsaved settings are you sure you want to exit?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult != DialogResult.Yes) return;
            }

            
            Hide();
            defaultSettings(false);
        }

        // Reset Settings
        private void resetSettingsButton_Click(object sender, EventArgs e) {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to reset all your settings? This setting is meant for debugging, and it will completely wipe the program.", "RESET SETTINGS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            // If Yes
            if (dialogResult == DialogResult.Yes) {

                // Delete Startup Reg Key
                try {
                    Settings.Default.Reset();
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true)) {
                        key.DeleteValue("Spectrum", false);
                    }

                }
                // Reset Settings
                finally { spectrumForm.Close(); }
            }
        }

        private void defaultSettings(bool user) {

            // Treeview Settings
            treeView1.SelectedNode = treeView1.Nodes[0];
            treeView1.Focus();

            if (user) {

                // Checkboxes
                startupConnectCheckBox.Checked = false;
                closeToTrayCheckbox.Checked = false;
                startMinCheckbox.Checked = false;
                windowsCheckbox.Checked = false;
                offOnClose.Checked = true;
                responsiveLightingCheckbox.Checked = false;
                rememberLightCheckbox.Checked = false;

                advancedLightingCheckbox.Checked = false;

                // Comboboxes
                updateComboBox.SelectedIndex = 1;

                defaultLocationButton_Click(null, null);

                return;
            }

            // Sets Check Box
            startupConnectCheckBox.Checked = Settings.Default.connectOnStartupBool;
            closeToTrayCheckbox.Checked = Settings.Default.closeToTrayBool;
            startMinCheckbox.Checked = Settings.Default.startMinimizedBool;
            windowsCheckbox.Checked = Settings.Default.windowsStartupBool;
            offOnClose.Checked = Settings.Default.turnOffOnClose;
            responsiveLightingCheckbox.Checked = Settings.Default.responsiveLighting;
            rememberLightCheckbox.Checked = Settings.Default.rememberLightProfile;

            advancedLightingCheckbox.Checked = Settings.Default.advancedLighting;

            // Update Group Box Settings
            updateComboBox.SelectedIndex = Settings.Default.updateComboBoxInt;

            // Update Settings
            fileExplorerTextBox.Text = Settings.Default.fileLocation;
            if (Settings.Default.fileLocation == "") {
                defaultLocationButton_Click(null, null);
                applySettingsButton.Enabled = false;
            }

        }


    }
}
