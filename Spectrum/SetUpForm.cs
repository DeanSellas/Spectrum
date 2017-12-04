using System;
using Spectrum.Properties;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spectrum {
    public partial class SetUpForm : Form {

        spectrumFormMain spectrumForm;

        bool settingsReady = false;

        public SetUpForm(spectrumFormMain openForm) {
            InitializeComponent();
            spectrumForm = openForm;
            Settings.Default.FirstLaunch = false;

        }

        private void SetUpForm_FormClosed(object sender, FormClosedEventArgs e) {
            if(!settingsReady && !Settings.Default.FirstLaunch) {
                Settings.Default.FirstLaunch = true;
                Settings.Default.Save();
                spectrumForm.Close();
            }
            
        }

        private void SetUpForm_Load(object sender, EventArgs e) {

            int portsVal = 0;

            // Display each port name to the console.
            foreach (string port in spectrumForm.ports) {
                Console.WriteLine(port);
                serialComboBox.Items.Add(port);
                portsVal++;
            }
            serialComboBox.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e) {
            Settings.Default.stripLength = Convert.ToInt32(stripLengthValue.Value);
            string selectedPort = serialComboBox.SelectedItem.ToString();
            Settings.Default.port = selectedPort;

            settingsReady = true;
            Settings.Default.Save();
            Close();
        }
    }
}
