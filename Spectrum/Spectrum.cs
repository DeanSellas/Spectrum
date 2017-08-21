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

        //Bool
        bool isConnected = false;


        public spectrumFormMain() {
            InitializeComponent();

            listSerialPorts();

            if (!isConnected) startupConnectCheckBox.Enabled = false;

            //serialPort1.Open();

            // Sets Check Box
            if (Properties.Settings.Default.closeToTrayBool) closeToTrayCheckbox.Checked = true;
            if (Properties.Settings.Default.connectOnStartupBool) startupConnectCheckBox.Checked = true;

        }

        // Connects to Port
        private void portConnectButton_Click(object sender, EventArgs e) {
            string port = serialComboBox.SelectedItem.ToString();

            if (serialPort1.IsOpen) portConnect(false);

            try {
                serialPort1.PortName = port;
                portConnect(true);
                Properties.Settings.Default.port = port;
                
            }
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

        private void rainbowButton_Click(object sender, EventArgs e) {
            var delay = delayValue.Value.ToString();
            serialPort1.WriteLine("Rainbow" + delay);
            Console.WriteLine("Rainbow" + delay);
        }


        private void spectrumFormMain_FormClosing(object sender, FormClosingEventArgs e) {
            // Close App To Tray
            if (Properties.Settings.Default.closeToTrayBool) {
                e.Cancel = true;
                Hide();
            }
        }
        private void spectrumTrayItem_DoubleClick(object sender, EventArgs e) {
            Show();
        }


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

        // Port Connect and Disconnect
        private void portConnect(bool open) {
            if (open) {
                serialPort1.Open();
                Console.WriteLine("Connected to port: " + serialPort1.PortName);
                //MessageBox.Show("Connected to: " + port, "Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connectedStatusLabel.Text = "Connected";
                connectedStatusLabel.BackColor = Color.Green;
                isConnected = true;
                startupConnectCheckBox.Enabled = true;
            }
            else {
                serialPort1.Close();
                connectedStatusLabel.Text = "Not Connected";
                connectedStatusLabel.BackColor = Color.Red;
                isConnected = false;
                startupConnectCheckBox.Enabled = false;
            }
        }

        // Save Settings
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            Properties.Settings.Default.Save();
        }

        private void closeToTrayCheckbox_CheckedChanged(object sender, EventArgs e) {
            // If Checkbox is Checked Change Bool
            if (closeToTrayCheckbox.Checked) Properties.Settings.Default.closeToTrayBool = true;
            else Properties.Settings.Default.closeToTrayBool = false;
        }

        private void startupConnectCheckBox_CheckedChanged(object sender, EventArgs e) {
            // If Checkbox is Checked Change Bool
            if (startupConnectCheckBox.Checked) Properties.Settings.Default.connectOnStartupBool = true;
            else Properties.Settings.Default.connectOnStartupBool = false;
        }

        private void spectrumFormMain_Load(object sender, EventArgs e) {
            if (Properties.Settings.Default.connectOnStartupBool && Properties.Settings.Default.port != "") {
                serialPort1.PortName = Properties.Settings.Default.port;
                portConnect(true);
            }
        }

        private void resetSettingsToolStripMenuItem_Click(object sender, EventArgs e) {
            Properties.Settings.Default.Reset();
        }
    }


}
