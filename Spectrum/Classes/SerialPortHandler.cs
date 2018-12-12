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

        SerialPort arduinoPort = new SerialPort();

        Timer sendTimer = new Timer();
        public Queue<string> messageQueue = new Queue<string>(); 

        public List<string> serialPortList = new List<string>();
        public bool isConnected = false;
        public string portName = "";

        public SerialPortHandler(SpectrumFormMain sf, SettingsHandler sh) {
            settingsHandler = sh;
            spectrumForm = sf;
            
            listSerialPorts();

            sendTimer.Enabled = false;
            sendTimer.Tick += new EventHandler(sendTimer_Tick);
            sendTimer.Interval = 1250;

            // sendMessage("RainbowFull100");
            // sendMessage("turnOff");
        }

        // Adds message to Queue so it can be sent
        public void sendMessage(string message) {
            messageQueue.Enqueue(message);
            sendTimer.Enabled = true;
            sendTimer.Start();
        }

        // Lists Serial Ports
        public void listSerialPorts() {
            // Clears List and Combobox
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

                spectrumForm.serialPortComboBox.Items.Add("No Ports Found");

                spectrumForm.serialPortComboBox.Enabled = false;
                spectrumForm.connectButton.Enabled = false;
                spectrumForm.connectToolStripMenuItem.Enabled = false;
            }
            else {
                
                spectrumForm.serialPortComboBox.Enabled = true;
                spectrumForm.connectButton.Enabled = true;
                spectrumForm.connectToolStripMenuItem.Enabled = true;
            }


            Console.WriteLine("--------------------------------");

        }

        // Connects to Selected Serial Port
        public void Connect() {
            
            // trys to connect to port and if successful assigns proper settings
            try {
                arduinoPort.PortName = portName;
                arduinoPort.Open();
                spectrumForm.serialPortComboBox.Enabled = false;
                spectrumForm.connectButton.Text = "Disconnect";
                spectrumForm.connectToolStripMenuItem.Text = "Disconnect";

                spectrumForm.solidColorButton.Enabled = true;
                spectrumForm.animationButton.Enabled = true;

                isConnected = true;
            }
            catch {
                MessageBox.Show("Could not connect to serial port make sure it is not in use and try again.","Something Went Wrong!", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }

        // Disconnects From Port
        public void Disconnect() {
            arduinoPort.Close();
            spectrumForm.serialPortComboBox.Enabled = true;
            spectrumForm.connectButton.Text = "Connect";
            spectrumForm.connectToolStripMenuItem.Text = "Connect To: " + portName;

            spectrumForm.solidColorButton.Enabled = false;
            spectrumForm.animationButton.Enabled = false;

            isConnected = false;
        }


        // Sends Message On Timer Tick
        private void sendTimer_Tick(object sender, EventArgs e) {
            if (isConnected) {
                if (messageQueue.Count > 0)
                    sendMessageHelper(messageQueue.Dequeue());
                // stops timer if there is no need for it to run
                else if (sendTimer.Enabled) { sendTimer.Stop(); sendTimer.Enabled = false; }
            }
            
        }
        protected internal void sendMessageHelper(string message) {
            arduinoPort.WriteLine(message);
            Console.WriteLine("Sent Message: " + message);
        }
    }
}
