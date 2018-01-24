using Microsoft.Win32;
using Spectrum.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Spectrum {

    public partial class spectrumFormMain : Form {

        // Variables
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Boolin
        public bool userExit = false;
        bool checkForUpdate = false;
        bool waitFor = true;

        // Int
        int firstPixel, lastPixel;

        // Date Time
        DateTime currentTime = DateTime.Now.Date;

        // Forms
        SettingsForm settingsForm;
        UpdateForm updateForm;
        SetUpForm setUpForm;
        AboutForm aboutForm;

        // String
        public string[] ports;
        string currentVersion = Application.ProductVersion;
        string installerName, downloadLocation, firstLast, message;


        WebClient webClient = new WebClient();

        List<string> messageQueue = new List<string>();


        // In The Begining...
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        public spectrumFormMain() {

            AppDomain.CurrentDomain.SetData("Spectrum.exe.config", Application.StartupPath + "/common");


            InitializeComponent();

            settingsForm = new SettingsForm(this);

            // Sets Current Form | Used for Context Menu
            //spectrumForm = this;

            if (Settings.Default.connectOnStartupBool) Settings.Default.isConnected = true;
            else Settings.Default.isConnected = false;
            //if (!Settings.Default.isConnected) startupConnectCheckBox.Enabled = false;


            redValue.Value = Settings.Default.redColor;
            greenValue.Value = Settings.Default.greenColor;
            blueValue.Value = Settings.Default.blueColor;


            // Sets Title
            if (currentVersion.Substring(5) == "0") Text = "Spectrum " + currentVersion.Substring(0, 3);
            else Text = "Spectrum " + currentVersion.Substring(0, 5);
            Console.WriteLine("Current Version: " + currentVersion);

            listSerialPorts();

            rainbowTypeComboBox.SelectedIndex = 0;

            if (Settings.Default.FirstLaunch) {
                setUpForm = new SetUpForm(this);
                setUpForm.ShowDialog();
            }

        }


        // On Form Load
        private void spectrumFormMain_Shown(object sender, EventArgs e) {

            settingsForm = new SettingsForm(this);

            if (Settings.Default.startMinimizedBool) Hide();

            if (Settings.Default.connectOnStartupBool && Settings.Default.port != "") {
                serialPort1.PortName = Settings.Default.port;
                portConnect(true);
            }

            lastNeoPixelUpDown.Value = Settings.Default.stripLength;

            advancedLightingPanel.Visible = Settings.Default.advancedLighting;

            if (!Settings.Default.advancedLighting) {
                colorPreviewBox.Location = new Point(215, 177);
                colorPreviewLabel.Location = new Point(239, 258);
            }

            if (serialComboBox.FindString(Settings.Default.port) != -1) {
                serialComboBox.Text = Settings.Default.port;
            }

            buttonEnableAsync();

            color_ValueChanged(sender, e);

            checkForUpdatesVoid(false, false);

        }

        // On Form Close
        private async void spectrumFormMain_FormClosing(object sender, FormClosingEventArgs e) {
            if (!userExit) {
                e.Cancel = true;
            }

            // Close App To Tray
            if (Settings.Default.closeToTrayBool && !userExit) {

                // Hides all Open Forms
                foreach (Form frm in Application.OpenForms) {
                    frm.Hide();
                }

                // Creates Balloon Tip
                spectrumTrayItem.BalloonTipTitle = "Spectrum";
                spectrumTrayItem.BalloonTipText = "Spectrum Has Been Minimized to Tray";
                spectrumTrayItem.ShowBalloonTip(1000);
                return;
            }

            // Clears Message Queue
            messageQueue.Clear();

            // Closes the Port and Turns off Lights
            portConnect(false);
            Hide();

            // Needed so the program doesnt crash. unsure what causes this?
            await Task.Delay(250);

            userExit = true;
            Close();

        }

        // Open From Tray
        private void spectrumTrayItem_DoubleClick(object sender, EventArgs e) { Show(); }

        // Connects to Port
        private void portConnectButton_Click(object sender, EventArgs e) {
            try {
                //if (serialPort1.IsOpen) portConnect(false);
                if (!serialPort1.IsOpen) portConnect(true);
                else portConnect(false);
            }
            catch {
                MessageBox.Show("Could not connect please make sure the arduino is plugged in and that you have selected the correct port", "Could Not Connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Button Settings
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        // Sets Solid Color
        private void solidColorButton_Click(object sender, EventArgs e) {

            var red = redValue.Value.ToString();
            var green = greenValue.Value.ToString();
            var blue = blueValue.Value.ToString();

            // Red Value Hotfix
            if (redValue.Value < 10) red = "00" + red; if (redValue.Value >= 10 && redValue.Value < 100) red = "0" + red;
            // Green Value Hotfix
            if (greenValue.Value < 10) green = "00" + green; if (greenValue.Value >= 10 && greenValue.Value < 100) green = "0" + green;
            // Blue Value Hotfix
            if (blueValue.Value < 10) blue = "00" + blue; if (blueValue.Value >= 10 && blueValue.Value < 100) blue = "0" + blue;

            message = "SolidColor" + red + green + blue + firstLast;

            if (Settings.Default.rememberLightProfile) Settings.Default.lastCommand = message;

            // Resets Responsive Lighting Wait
            if (!waitFor) waitFor = true;

            // Adds Message to Message Queue
            messageQueue.Add(message);

        }

        // Color Preview
        private async void color_KeyDown(object sender, KeyEventArgs e) {

            // Color Preview
            if (redValue.Text == "") redValue.Text = "0";
            if (greenValue.Text == "") greenValue.Text = "0";
            if (blueValue.Text == "") blueValue.Text = "0";

            var red = Convert.ToInt32(redValue.Value);
            var green = Convert.ToInt32(greenValue.Value);
            var blue = Convert.ToInt32(blueValue.Value);
            colorPreviewBox.BackColor = Color.FromArgb(red, green, blue);
            if (red == 0 && green == 0 && blue == 0) colorPreviewBox.BackColor = Color.Transparent;

            // Responsive Lighting
            if (Settings.Default.isConnected && Settings.Default.responsiveLighting && waitFor) {
                waitFor = false;
                await Task.Delay(1250);
                solidColorButton_Click(this, null);
            }

        }

        private void color_ValueChanged(object sender, EventArgs e) { color_KeyDown(this, null); }


        // Used for more in depth solid color lighting
        private void neoPixelUpDown_ValueChanged(object sender, EventArgs e) {
            //neoPixelUpDown_KeyDown(sender, null);
            firstNeoPixelUpDown.Maximum = Settings.Default.stripLength;
            lastNeoPixelUpDown.Maximum = Settings.Default.stripLength;

            lastNeoPixelUpDown.Minimum = firstNeoPixelUpDown.Value;

            firstPixel = Convert.ToInt32(firstNeoPixelUpDown.Value);
            lastPixel = Convert.ToInt32(lastNeoPixelUpDown.Value);

            firstLast = "-" + firstPixel + "-" + lastPixel;
        }

        // Rainbow Animation Button
        private void animationButton_Click(object sender, EventArgs e) {

            string rainbowType = "";
            if (rainbowTypeComboBox.SelectedIndex == 0) {
                rainbowType = "RainbowCycle";
            }
            if (rainbowTypeComboBox.SelectedIndex == 1) {
                rainbowType = "RainbowFull";
            }

            var delay = delayValue.Value.ToString();
            message = rainbowType + delay;

            if (Settings.Default.rememberLightProfile) Settings.Default.lastCommand = message;
            //Console.WriteLine(Settings.Default.lastCommand);
            messageQueue.Add(message);
        }

        private void offButton_Click(object sender, EventArgs e) { messageQueue.Add("turnOff"); }

        // Sends Message To Arduino
        private void sendMessage() {
            if (messageQueue.Count > 0) {
                // Gets First Sent Message
                message = messageQueue[0];

                // Debugging Output
                Console.WriteLine("Message Queue Length: " + messageQueue.Count);
                Console.WriteLine("Message: " + message);

                // Sends Message To Arduino
                serialPort1.WriteLine(message);

                // Removes Message From List
                messageQueue.RemoveAt(0);
            }
        }



        // CUSTOM FUNCTIONS
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        // Lists Serial Ports for Combobox and Debugging
        public void listSerialPorts() {
            // Get a list of serial port names.
            ports = SerialPort.GetPortNames();
            int portsVal = 0;
            Console.WriteLine("The following serial ports were found:");



            // Display each port name to the console.
            foreach (string port in ports) {
                Console.WriteLine(port);
                serialComboBox.Items.Add(port);
                portsVal++;
            }

            // Sets Combo Box to First COM Port
            try {
                int index = serialComboBox.Items.IndexOf(Settings.Default.port);

                if (index < 0) index = 0;

                serialComboBox.SelectedIndex = index;
            }
            catch {
                MessageBox.Show("No serial ports found please make sure your arduino is plugged in. If the problem presits please submit a support ticket", "No Serial Ports Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Port Connect/Disconnect
        private async void portConnect(bool open) {
            string selectedPort = serialComboBox.SelectedItem.ToString();

            // Opens Serial Port
            if (open) {

                // Sets Connect On Startup Port
                if (Settings.Default.connectOnStartupBool) serialPort1.PortName = Settings.Default.port;
                else serialPort1.PortName = selectedPort;

                serialPort1.Open();
                Console.WriteLine("Connected to port: " + serialPort1.PortName);

                connectedStatusLabel.Text = "Connecting...";
                portConnectButton.Text = "Connecting...";
                portConnectButton.Enabled = false;

                settingsForm.startupConnectCheckBox.Enabled = true;
                settingsForm.defaultPortComboBox.Enabled = false;
                settingsForm.stripLengthUpDown.Enabled = false;

                if (Settings.Default.defaultStripLength != Settings.Default.stripLength) {
                    serialPort1.WriteLine("ChangeStripLength" + Settings.Default.stripLength);
                    Settings.Default.defaultStripLength = Settings.Default.stripLength;
                }
                Settings.Default.isConnected = true;
            }

            // Closes Serial Port
            else if (serialPort1.IsOpen) {

                // Turns off Strip on Disconnect
                if (Settings.Default.turnOffOnClose) {
                    messageQueue.Add("turnOff");
                    sendMessage();
                }

                await Task.Delay(500);
                serialPort1.Close();

                Settings.Default.isConnected = false;
                settingsForm.startupConnectCheckBox.Enabled = false;
                settingsForm.defaultPortComboBox.Enabled = true;
                settingsForm.stripLengthUpDown.Enabled = true;
            }

            Settings.Default.Save();
            buttonEnableAsync();
        }

        // Enables/Disables Buttons
        private async void buttonEnableAsync() {
            if (Settings.Default.isConnected) {

                await Task.Delay(1100);

                if (!Settings.Default.responsiveLighting) solidColorButton.Enabled = true;
                animationButton.Enabled = true;
                offButton.Enabled = true;
                portConnectButton.Text = "Disconnect";
                portConnectButton.Enabled = true;

                serialComboBox.Enabled = false;

                connectedStatusLabel.Text = "Connected";
                connectedStatusLabel.BackColor = Color.Green;

                spectrumTrayItem.Text = "Spectrum: Connected";

                if (Settings.Default.rememberLightProfile) {
                    Console.WriteLine(Settings.Default.lastCommand);
                    serialPort1.WriteLine(Settings.Default.lastCommand);
                }

            }
            else {
                solidColorButton.Enabled = false;
                animationButton.Enabled = false;
                offButton.Enabled = false;
                portConnectButton.Text = "Connect";

                serialComboBox.Enabled = true;

                connectedStatusLabel.Text = "Disconnected";
                connectedStatusLabel.BackColor = Color.Red;

                spectrumTrayItem.Text = "Spectrum: Disconnected";
            }
        }

        // Updates Void
        public void checkForUpdatesVoid(bool updateAvailable, bool userCheck) {
            string onlineVersion;
            // Reads Version.txt

            System.IO.Stream stream = webClient.OpenRead("https://raw.githubusercontent.com/DeanSellas/Spectrum/master/version.txt");
            using (System.IO.StreamReader reader = new System.IO.StreamReader(stream)) {
                String version = reader.ReadToEnd();
                Console.WriteLine(version);

                if (version.Substring(3, 4) == "0") {
                    onlineVersion = version.Substring(0, 3);
                }
                else onlineVersion = version.Substring(0, 5);

                // Sets Proper Variables
                // Change != to == for testing purposes
                if (currentVersion != version) {

                    updateAvailable = true;
                    installerName = "spectrumv" + onlineVersion + "setup.exe";
                    Console.WriteLine(installerName);
                    downloadLocation = "https://github.com/DeanSellas/Spectrum/blob/master/Installer/" + installerName + "?raw=true";
                }
            }

            if (Settings.Default.postponeUpdateDate == DateTime.Today) Settings.Default.postponeUpdateBool = false;

            // If Postpone Update
            if (!Settings.Default.postponeUpdateBool) {

                // If Update At Startup Not Applied
                if (Settings.Default.updateComboBoxInt != 1) Console.Write("");
                else {
                    Settings.Default.lastUpdateCheck = DateTime.Now.Date;
                    Settings.Default.nextUpdateCheck = DateTime.Now.Date;
                    checkForUpdate = true;
                }


                if (Settings.Default.updateComboBoxInt == 2) Settings.Default.nextUpdateCheck = Settings.Default.lastUpdateCheck.AddDays(1);
                if (Settings.Default.updateComboBoxInt == 3) Settings.Default.nextUpdateCheck = Settings.Default.lastUpdateCheck.AddDays(7);
                if (Settings.Default.updateComboBoxInt == 4) Settings.Default.nextUpdateCheck = Settings.Default.lastUpdateCheck.AddMonths(1);
                Console.WriteLine(Settings.Default.nextUpdateCheck);
                if (Settings.Default.nextUpdateCheck == DateTime.Today && Settings.Default.updateComboBoxInt != 0) checkForUpdate = true;


                // Check For Updates
                if (checkForUpdate && updateAvailable) {
                    if (!userCheck) {
                        DialogResult dialogResult = MessageBox.Show("New Version Of Spectrum Is Avaliable Do You Want to Download it?", "Update to " + onlineVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialogResult == DialogResult.Yes) {
                            updateForm = new UpdateForm(installerName, downloadLocation, onlineVersion);
                            updateForm.SpectrumUpdate(updateAvailable, false);
                        }
                        Settings.Default.lastUpdateCheck = DateTime.Now.Date;
                    }

                }
                if (userCheck) {
                    updateForm = new UpdateForm(installerName, downloadLocation, onlineVersion);
                    updateForm.SpectrumUpdate(updateAvailable, true);
                }

                Settings.Default.Save();

            }
        }



        // MENU BAR SETTINGS
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // Save Settings
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {

            Settings.Default.redColor = (int)redValue.Value;
            Settings.Default.greenColor = (int)greenValue.Value;
            Settings.Default.blueColor = (int)blueValue.Value;

            Settings.Default.Save();
        }

        // Show Settings
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
            //settingsForm = new SettingsForm(this);
            settingsForm.Show();
        }

        // Check For Updates
        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e) {
            checkForUpdatesVoid(false, true);
        }

        // Exit Spectrum
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e) {
            if (Settings.Default.closeToTrayBool) {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit Spectrum?", "Close Spectrum", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes) {
                    userExit = true;
                    Close();
                }
            }
            else Close();
        }

        // Link to Documentation
        private void documentationToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/DeanSellas/Spectrum/wiki");
        }

        // Link to Github
        private void githubToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/DeanSellas/Spectrum");
        }

        // Report Bug
        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/DeanSellas/Spectrum/issues");
        }

        // Donate Button
        private void donateToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=RVNJATCSR7FGC&lc=US&item_name=Specturm%20Donation&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donate_SM%2egif%3aNonHosted");
        }



        // CONTEXT MENU
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        // Defines Context Menu Options
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
            if (Settings.Default.isConnected) connectToolStripMenuItem.Text = "Disconnect"; else connectToolStripMenuItem.Text = "Connect to " + serialComboBox.SelectedItem;
            if (Visible) showToolStripMenuItem.Text = "Hide"; else showToolStripMenuItem.Text = "Show";
        }

        // Context Menu Connect/Disconnect
        private void connectToolStripMenuItem_Click(object sender, EventArgs e) {
            if (Settings.Default.isConnected) portConnect(false); else portConnect(true);
        }

        // Context Menu Show/Hide
        private void showToolStripMenuItem_Click(object sender, EventArgs e) {
            if (Visible) Hide(); else Show();
        }



        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            aboutForm = new AboutForm();
            aboutForm.Show();
        }

        // Context Menu Settings
        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e) {
            //settingsForm = new SettingsForm(this);
            settingsForm.Show();
        }



        private void redValue_ValueChanged(object sender, EventArgs e) {
            var red = Convert.ToInt32(redValue.Value);
            var green = Convert.ToInt32(greenValue.Value);
            var blue = Convert.ToInt32(blueValue.Value);
            colorPreviewBox.BackColor = Color.FromArgb(red, green, blue);
        }

        // Context Menu Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            if (Settings.Default.closeToTrayBool) {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit Spectrum?", "Close Spectrum", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes) {
                    userExit = true;
                    Close();
                }
            }
            else Close();
        }






        // BACKGROUND TASKS
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timer1_Tick(object sender, EventArgs e) { sendMessage(); }



        // THE END
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
