using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Spectrum.Classes;
using Spectrum.Forms;

namespace Spectrum {

    public partial class SpectrumFormMain : Form {

        ///
        /// <Init>
        ///     Starts Spectrum and starts the handlers
        /// </Init>
        /// 


        // Forms
        About aboutForm;
        SettingsForm settingsForm;

        logForm logForm;

        // Handlers/Classes
        SettingsHandler settingsHander;
        UpdateHandler updateHandler;
        SerialPortHandler serialPortHandler;

        LogsHandler.TextBoxLog log;

        // Strings
        string version = Application.ProductVersion;

        // Booleans
        bool userExit = false;
        
        public Dictionary<string, dynamic> settings;

        public SpectrumFormMain() {

            InitializeComponent();
            

            formsInit();
        }



        // Creates base forms and applies proper settings
        private void formsInit() {

            logForm = new logForm();

            log = new LogsHandler.TextBoxLog(logForm.richTextBox1);
            Console.SetOut(new LogsHandler(log, Console.Out));

            settingsHander = new SettingsHandler();

            // settings will be removed because of the new getSettings method //
            settings = settingsHander.settings;


            updateHandler = new UpdateHandler(settingsHander);

            serialPortHandler = new SerialPortHandler(this, settingsHander);

            settingsForm = new SettingsForm(this, settingsHander);

            aboutForm = new About(settingsHander.getSetting("Advanced", "devBuilds"));
        }



        ///
        /// <Forms>
        ///     This section builds the forms and shows them
        /// </Forms>
        /// 

        // Spectrum startup
        private void SpectrumFormMain_Shown(object sender, EventArgs e) {

            serialPortComboBox.SelectedIndex = 0;
            animationComboBox.SelectedIndex = 0;

            trayNotifyIcon.Visible = true;

            previewColorMaster();


            buildApp();

        }

        

        // Code to run when closing
        private void SpectrumFormMain_FormClosing(object sender, FormClosingEventArgs e) {
            // Closes to tray if conditions are met
            if (!userExit && settingsHander.getSetting("General", "closeToTray", settingsHander.currentProfile)) {
                e.Cancel = true;
                hideSpectrum();
                return;
            }

            // if turn off on exit true
            if (serialPortHandler.isConnected) {
                serialPortHandler.messageQueue.Clear();
                serialPortHandler.sendMessageHelper("turnOff");
            }

        }


        // Builds the app and applies correct settings
        internal void buildApp() {
            renameApp();


            redValue.Value = settingsHander.getSetting("Colors", "redValue",settingsHander.currentProfile);
            greenValue.Value = settingsHander.getSetting("Colors", "greenValue", settingsHander.currentProfile);
            blueValue.Value = settingsHander.getSetting("Colors", "blueValue", settingsHander.currentProfile);

            if(settingsHander.getSetting("Advanced", "advancedSettings", settingsHander.currentProfile)) {
                logSeperator.Visible = true;
                logToolStripMenuItem.Visible = true;
            }
        }




        // Changes Title
        private void renameApp() {
            // Sets title
            if (version[4] == '0') Text = "Spectrum " + version.Substring(0, 3);
            else Text = "Spectrum " + version.Substring(0, 5);
            if (settingsHander.getSetting("Advanced", "devBuilds")) Text += " || DevBuild ||";
        }


        // Hides Spectrum and changes proper elements
        private void hideSpectrum() {
            Hide();

            // Creates Balloon Tip
            trayNotifyIcon.BalloonTipTitle = "Spectrum";
            trayNotifyIcon.BalloonTipText = "Spectrum Has Been Minimized to Tray";
            trayNotifyIcon.ShowBalloonTip(0);
        }

        


        ///
        /// <Functions>
        ///     functions for operation of spectrum
        /// </Buttons>
        ///


        // Brings Spectrum To Font If Running
        protected override void WndProc(ref Message m) {
            if (m.Msg == NativeMethods.WM_SHOWME) {
                NativeMethods.BringToFront(this);
            }
            base.WndProc(ref m);
        }


        // Conects to Designated Serial Port
        private void connectToolStripMenuItem_Click(object sender, EventArgs e) { connectButton.PerformClick(); }
        

        // Checks For Updates
        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!updateHandler.checkConnection()) return;
            updateHandler.checkForUpdate(true);
        }

        private void documentationToolStripMenuItem_Click(object sender, EventArgs e) { Process.Start("https://github.com/DeanSellas/Spectrum/wiki"); }

        private void bugReportToolStripMenuItem_Click(object sender, EventArgs e) { Process.Start("https://github.com/DeanSellas/Spectrum/issues"); }

        private void githubToolStripMenuItem_Click(object sender, EventArgs e) { Process.Start("https://github.com/DeanSellas/Spectrum"); }

        

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


        ///
        /// <Colors>
        ///     All the colors of the rainbow
        ///     Seriously though. This Section contains the code that makes the color picker and animations work
        /// </Colors>
        /// 


        private void setSolidColor() {
            var red = redValue.Value.ToString();
            var green = greenValue.Value.ToString();
            var blue = blueValue.Value.ToString();

            // Red Value Hotfix
            if (redValue.Value < 10) red = "00" + red; if (redValue.Value >= 10 && redValue.Value < 100) red = "0" + red;
            // Green Value Hotfix
            if (greenValue.Value < 10) green = "00" + green; if (greenValue.Value >= 10 && greenValue.Value < 100) green = "0" + green;
            // Blue Value Hotfix
            if (blueValue.Value < 10) blue = "00" + blue; if (blueValue.Value >= 10 && blueValue.Value < 100) blue = "0" + blue;

            var message = "SolidColor" + red + green + blue;
            serialPortHandler.sendMessage(message);
        }

        private void setAnimation() {
            string message = "";
            if (animationComboBox.Text == "Cycle") message = "RainbowCycle";
            else if (animationComboBox.Text == "Full Rainbow") message = "RainbowFull";
            serialPortHandler.sendMessage(message);
        }

        

        private void previewColorMaster() {
            // sets background of preview box
            Color preview = Color.FromArgb(Convert.ToInt32(redValue.Value), Convert.ToInt32(greenValue.Value), Convert.ToInt32(blueValue.Value));
            // if color is 0 set to transparent
            if (preview == Color.FromArgb(0, 0, 0)) preview = Color.Transparent;
            colorPreviewPanel.BackColor = preview;
        }

        private void previewBoxColorValueChanged(object sender, EventArgs e) {
            previewColorMaster(); Console.WriteLine(sender);
        }

        // Highlights all items when box is selected
        private void numericUpDownClick(object sender, EventArgs e) {
            NumericUpDown selected = (NumericUpDown) sender; selected.Select(0, 3);
        }

        private void previewBoxColorKeyUp(object sender, KeyEventArgs e) {
            // sets value to 0 if empty
            NumericUpDown me = (NumericUpDown)sender;
            if (me.Text == "") me.Text = "0";
            previewColorMaster();
        }

        // Opens Color Picker and Sets Colors
        private void colorPickerClick(object sender, LinkLabelLinkClickedEventArgs e) {
            colorPicker.ShowDialog();
            Color color = colorPicker.Color;

            Console.WriteLine("RED: {0} GREEN: {1} BLUE: {2}", color.R, color.G, color.B);
            redValue.Value = color.R;
            greenValue.Value = color.G;
            blueValue.Value = color.B;

        }

        ///
        /// <Buttons>
        ///     DON'T PRESS THE RED BUTTON
        ///     I'M SERIOUS!
        /// 
        ///     Functions that handle button presses
        /// </Buttons>
        /// 
        
        private void solidColorButton_Click(object sender, EventArgs e) { setSolidColor(); }

        private void animationButton_Click(object sender, EventArgs e) { setAnimation(); }

        private void offButton_Click(object sender, EventArgs e) { serialPortHandler.sendMessage("turnOff"); }

        private void refreshButton_Click(object sender, EventArgs e) { serialPortHandler.listSerialPorts(); }



        ///
        /// <Menu>
        ///     Settings for Context Menu
        /// </Menu>
        /// 

        public void showSettings() { settingsForm.ShowDialog(); }

        public void showAbout() { aboutForm.ShowDialog(); }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) { showSettings(); }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) { showAbout(); }

        private void logToolStripMenuItem_Click(object sender, EventArgs e) {
            logForm.Show();
        }
    }
}
