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
        public spectrumFormMain() {
            InitializeComponent();

            listSerialPorts();

            //serialPort1.Open();
        }

        // Connects to Port
        private void portConnectButton_Click(object sender, EventArgs e) {
            string port = serialComboBox.SelectedItem.ToString();

            if (serialPort1.IsOpen) portOptions(false);

            try {
                serialPort1.PortName = port;
                portOptions(true);
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
            var delay = delayValue.ToString();
            serialPort1.WriteLine("Rainbow" + delay);
            Console.WriteLine("Rainbow" + delay);
        }


        private void spectrumFormMain_FormClosing(object sender, FormClosingEventArgs e) {
            // Close App To Tray
            if (closeToTrayCheckbox.Checked) {
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

        private void portOptions(bool open) {
            if (open) {
                serialPort1.Open();
                Console.WriteLine("Connected to port: " + serialPort1.PortName);
                //MessageBox.Show("Connected to: " + port, "Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connectedStatusLabel.Text = "Connected";
                connectedStatusLabel.BackColor = Color.Green;
            }
            else {
                serialPort1.Close();
                connectedStatusLabel.Text = "Not Connected";
                connectedStatusLabel.BackColor = Color.Red;
            }
        }

        
    }


}
