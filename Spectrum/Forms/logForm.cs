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

        // builds settings form when shown
        private void logForm_Shown(object sender, EventArgs e) {
            // since visual studio only using Shown once I needed to reasing this to Visablility changed event
            // this prevents code from running on close
            if (!Visible) return;
            path.Text = settings.getSetting("Logs", "logPath");

            autoScrollCheckBox.Checked = settings.getSetting("Logs", "autoScroll", settings.currentProfile);


        }

        private void button2_Click(object sender, EventArgs e) {
            Console.WriteLine("-- Log Saved --\n--------------------------------");
            logHandler.saveLog(path.Text, log.Lines);
        }

        private void saveFileButton_Click(object sender, EventArgs e) {
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = path.Text;
            saveFileDialog1.ShowDialog();
            path.Text = saveFileDialog1.FileName;
        }

        private void logForm_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            Hide();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            log.SelectionStart = log.Text.Length;
            log.ScrollToCaret();
            timer1.Enabled = false;
        }

        private void log_TextChanged(object sender, EventArgs e) {

            if(autoScrollCheckBox.Checked)
                timer1.Enabled = true;
        }

    }
}
