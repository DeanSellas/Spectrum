using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spectrum {

    public partial class spectrumFormMain : Form {

        // Variables
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        //Boolin
        bool isConnected = false;

        // Forms
        Form spectrumForm;


        // In The Begining...
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public spectrumFormMain() {
            InitializeComponent();
            
            listSerialPorts();

            // Sets Current Form | Used for Context Menu
            spectrumForm = this;


            if (!isConnected) startupConnectCheckBox.Enabled = false;
            
            // Sets Check Box
            if (Properties.Settings.Default.closeToTrayBool) closeToTrayCheckbox.Checked = true;
            if (Properties.Settings.Default.connectOnStartupBool) startupConnectCheckBox.Checked = true;

        }

        // On Form Load
        private void spectrumFormMain_Load(object sender, EventArgs e) {
            if (Properties.Settings.Default.connectOnStartupBool && Properties.Settings.Default.port != "") {
                serialPort1.PortName = Properties.Settings.Default.port;
                portConnect(true);
            }
            buttonEnable();
        }
        
        // On Form Close
        private void spectrumFormMain_FormClosing(object sender, FormClosingEventArgs e) {
            // Close App To Tray
            if (Properties.Settings.Default.closeToTrayBool) {
                e.Cancel = true;
                Hide();
            }
        }

        // Open From Tray
        private void spectrumTrayItem_DoubleClick(object sender, EventArgs e) {
            Show();
        }

        // Connects to Port
        private void portConnectButton_Click(object sender, EventArgs e) {
            if (serialPort1.IsOpen) portConnect(false);

            try {portConnect(true);}
            catch {
                MessageBox.Show("Could not connect please make sure the arduino is plugged in and that you have selected the correct port", "Could Not Connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

            serialPort1.WriteLine("SolidColor" + red + green + blue);
            Console.WriteLine("SolidColor"+red + green + blue);
        }

        // Rainbow Animation Button
        private void rainbowButton_Click(object sender, EventArgs e) {
            var delay = delayValue.Value.ToString();
            serialPort1.WriteLine("Rainbow" + delay);
            Console.WriteLine("Rainbow" + delay);
        }



        // CUSTOM FUNCTIONS
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Lists Serial Ports for Combobox and Debugging
        private void listSerialPorts() {
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();

            Console.WriteLine("The following serial ports were found:");

            // Display each port name to the console.
            foreach (string port in ports) {
                Console.WriteLine(port);
                serialComboBox.Items.Add(port);
            }
            
            // Sets Combo Box to First COM Port
            serialComboBox.SelectedIndex = 0;
        }

        // Port Connect/Disconnect
        private void portConnect(bool open) {
            string port = serialComboBox.SelectedItem.ToString();
            if (open) {
                serialPort1.PortName = port;
                serialPort1.Open();
                Console.WriteLine("Connected to port: " + serialPort1.PortName);
                //MessageBox.Show("Connected to: " + port, "Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connectedStatusLabel.Text = "Connected";
                connectedStatusLabel.BackColor = Color.Green;
                isConnected = true;
                startupConnectCheckBox.Enabled = true;
                Properties.Settings.Default.port = port;
            }
            else {
                serialPort1.Close();
                connectedStatusLabel.Text = "Not Connected";
                connectedStatusLabel.BackColor = Color.Red;
                isConnected = false;
                startupConnectCheckBox.Enabled = false;
            }
            buttonEnable();
        }

        // Enables/Disables Buttons
        private void buttonEnable() {
            if (isConnected) {
                solidColorButton.Enabled = true;
                rainbowButton.Enabled = true;
            }
            else {
                solidColorButton.Enabled = false;
                rainbowButton.Enabled = false;
            }
        }



        // CHECKBOX SETTINGS -- WILL BE MOVING TO ANOTHER FORM SOON
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Close to Tray
        private void closeToTrayCheckbox_CheckedChanged(object sender, EventArgs e) {
            // If Checkbox is Checked Change Bool
            if (closeToTrayCheckbox.Checked) Properties.Settings.Default.closeToTrayBool = true;
            else Properties.Settings.Default.closeToTrayBool = false;
        }

        // Connect at Startup
        private void startupConnectCheckBox_CheckedChanged(object sender, EventArgs e) {
            // If Checkbox is Checked Change Bool
            if (startupConnectCheckBox.Checked) Properties.Settings.Default.connectOnStartupBool = true;
            else Properties.Settings.Default.connectOnStartupBool = false;
        }


        // MENU BAR SETTINGS
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Save Settings
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            Properties.Settings.Default.Save();
        }

        // Link to Documentation
        private void documentationToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Documentation is not ready at this time");
        }

        // Reset Settings
        private void resetSettingsToolStripMenuItem_Click(object sender, EventArgs e) {
            Properties.Settings.Default.Reset();
        }

        // Link to Github
        private void githubToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/DeanSellas/Spectrum");
        }

        // Donate Button
        private void donateToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=RVNJATCSR7FGC&lc=US&item_name=Specturm%20Donation&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donate_SM%2egif%3aNonHosted");
        }



        // CONTEXT MENUE
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Defines Context Menu Options
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
            if (isConnected) connectToolStripMenuItem.Text = "Disconnect"; else connectToolStripMenuItem.Text = "Connect";
            if (spectrumForm.Visible) showToolStripMenuItem.Text = "Hide"; else showToolStripMenuItem.Text = "Show";
        }

        // Context Menu Connect/Disconnect
        private void connectToolStripMenuItem_Click(object sender, EventArgs e) {
            if (isConnected) portConnect(false); else portConnect(true);
        }
        // Context Menu Show/Hide
        private void showToolStripMenuItem_Click(object sender, EventArgs e) {
            if (spectrumForm.Visible) Hide(); else Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }
    }



    // THE END
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
