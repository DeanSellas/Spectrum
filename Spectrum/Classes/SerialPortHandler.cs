using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace Spectrum.Classes {
    class SerialPortHandler {

        SettingsHandler settingsHandler;
        SpectrumFormMain spectrumForm;

        SerialPort comPort = new SerialPort();

        public List<string> serialPortList = new List<string>();
        public bool isConnected = false;
        public SerialPortHandler(SpectrumFormMain sf, SettingsHandler sh) {
            settingsHandler = sh;
            spectrumForm = sf;

            listSerialPorts();
        }

        public void listSerialPorts() {
            serialPortList.Clear();
            spectrumForm.serialPortComboBox.Items.Clear();

            Console.WriteLine("Serial Ports Available:");

            foreach (string port in SerialPort.GetPortNames()) {
                serialPortList.Add(port);
                spectrumForm.serialPortComboBox.Items.Add(port);
                Console.WriteLine("Port: " + port);
            }
            if (serialPortList.Count == 0) {
                MessageBox.Show("No Serial Ports were found please make sure your Arduino is plugged in and powered and try again", "No Serial Ports Found.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spectrumForm.serialPortComboBox.Enabled = false;
            }
            else {
                spectrumForm.serialPortComboBox.SelectedIndex = 0;
                spectrumForm.serialPortComboBox.Enabled = true;
            }
                
        }

        public void Connect() {

            // sets port to connect to
            string portName = spectrumForm.serialPortComboBox.SelectedItem.ToString();
            
            // trys to connect to port and if successful assigns proper settings
            try {
                comPort.PortName = portName;
                comPort.Open();
                spectrumForm.serialPortComboBox.Enabled = false;
                spectrumForm.connectButton.Text = "Disconnect";
                isConnected = true;
            }
            catch {
                MessageBox.Show("Could not connect to serial port make sure it is not in use and try again.","Something Went Wrong!", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }

        // disconnects from port
        public void Disconnect() {
            comPort.Close();
            spectrumForm.serialPortComboBox.Enabled = true;
            spectrumForm.connectButton.Text = "Connect";
            isConnected = false;
        }

    }
}
