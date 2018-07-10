using System;
using System.Diagnostics;
using System.Windows.Forms;
using Spectrum.Classes;

namespace Spectrum {

    public partial class SpectrumFormMain : Form {


        // Brings Spectrum To Font If Running
        protected override void WndProc(ref Message m) {
            if (m.Msg == NativeMethods.WM_SHOWME) {
                NativeMethods.BringToFront(this);
            }
            base.WndProc(ref m);
        }



        SettingsHandler settingsHander;
        UpdateHandler updateHandler;
        SerialPortHandler serialPortHandler;
        string version = Application.ProductVersion;

        bool userExit = false;

        public SpectrumFormMain() {
            InitializeComponent();
            
            settingsHander = new SettingsHandler();

            updateHandler = new UpdateHandler(settingsHander);

            serialPortHandler = new SerialPortHandler(this, settingsHander); 
        }


        private void SpectrumFormMain_Shown(object sender, EventArgs e) {
            renameApp();

            serialPortComboBox.SelectedIndex = 0;

            trayNotifyIcon.Visible = true;
        }

        // Changes Title
        private void renameApp() {
            // Sets title
            if (version[4] == '0') Text = "Spectrum " + version.Substring(0, 3);
            else Text = "Spectrum " + version.Substring(0, 5);
            if (settingsHander.settings["Default"]["Advanced"]["devBuilds"]) Text += " || DevBuild ||";
        }

        // Hides Spectrum and changes proper elements
        private void hideSpectrum() {
            Hide();
            
            // Creates Balloon Tip
            trayNotifyIcon.BalloonTipTitle = "Spectrum";
            trayNotifyIcon.BalloonTipText = "Spectrum Has Been Minimized to Tray";
            trayNotifyIcon.ShowBalloonTip(3);
        }

        // Conects to Designated Serial Port
        private void connectToolStripMenuItem_Click(object sender, EventArgs e) { connectButton.PerformClick(); }
        private void refreshButton_Click(object sender, EventArgs e) { serialPortHandler.listSerialPorts(); }

        // Checks For Updates
        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!updateHandler.checkConnection()) return;
            updateHandler.checkForUpdate();
            if (!updateHandler.updateAvalible) MessageBox.Show("No Updates Avalible", "No Updates Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void documentationToolStripMenuItem_Click(object sender, EventArgs e) { Process.Start("https://github.com/DeanSellas/Spectrum/wiki"); }

        private void bugReportToolStripMenuItem_Click(object sender, EventArgs e) { Process.Start("https://github.com/DeanSellas/Spectrum/issues"); }

        private void githubToolStripMenuItem_Click(object sender, EventArgs e) { Process.Start("https://github.com/DeanSellas/Spectrum"); }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }

        // dont tell anyone its a secret!!
        private void superSecretFeatureToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Sorry the feature you are looking for is in another castle", "Totally Not A Secret Feature", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            // not a hint to what the feature may be...
            // really dont try to convert it to text
            // i am serious
            Console.WriteLine("01101000 01110100 01110100 01110000 01110011 00111010 00101111 00101111 01100111 01101111 01101111 00101110 01100111 01101100 00101111 00110011 01010001 01010001 00110110 01101111 01100010");
        }

        // Forces spectrum to close
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) { userExit = true; Close(); }
        private void trayNotifyIcon_DoubleClick(object sender, EventArgs e) { Show(); }

        // Code to run when closing
        private void SpectrumFormMain_FormClosing(object sender, FormClosingEventArgs e) {
            // Closes to tray if conditions are met
            if (!userExit && settingsHander.settingsProfile != "Default" && settingsHander.settings[settingsHander.settingsProfile]["General"].ContainsKey("closeToTray")) {
                e.Cancel = true;
                hideSpectrum();
            }
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e) {
            // if visable hide spectrum
            if (Visible) { hideSpectrum();  }
            else { Show();  }
        }

        private void SpectrumFormMain_VisibleChanged(object sender, EventArgs e) {
            if(Visible) hideToolStripMenuItem.Text = "Hide";
            else hideToolStripMenuItem.Text = "Show";
        }

        private void connectButton_Click(object sender, EventArgs e) {
            if (!serialPortHandler.isConnected) serialPortHandler.Connect();
            else serialPortHandler.Disconnect();
        }

        private void serialPortComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            serialPortHandler.portName = serialPortComboBox.SelectedItem.ToString();
            connectToolStripMenuItem.Text = "Connect To: " + serialPortHandler.portName;
        }

        
    }
}
