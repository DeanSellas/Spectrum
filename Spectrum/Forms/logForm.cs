using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spectrum.Classes;

namespace Spectrum.Forms {
    public partial class logForm : Form {
        LogsHandler logHandler;
        internal SettingsHandler settings;
        public logForm(LogsHandler l) {
            InitializeComponent();

            logHandler = l;
        }

        private void logForm_Shown(object sender, EventArgs e) {
            path.Text = settings.getSetting("Logs", "logPath") +"\\log.txt";
        }

        private void button2_Click(object sender, EventArgs e) {
            Console.WriteLine("\n-- Log Saved --");
            logHandler.saveLog(path.Text, log.Lines);
        }

        private void saveFileButton_Click(object sender, EventArgs e) {
            saveFileDialog1.InitialDirectory = path.Text;
            saveFileDialog1.ShowDialog();
            path.Text = saveFileDialog1.FileName;
        }

        private void logForm_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            Hide();
        }
    }
}
