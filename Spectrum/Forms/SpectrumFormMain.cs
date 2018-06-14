using System;
using System.Diagnostics;
using System.Windows.Forms;
using Spectrum.Classes;

namespace Spectrum {

    public partial class SpectrumFormMain : Form {
        SettingsHandler settingsHander;
        UpdateHandler updateHandler;
        string version = Application.ProductVersion;
        public SpectrumFormMain() {
            settingsHander = new SettingsHandler();

            updateHandler = new UpdateHandler(settingsHander);

            InitializeComponent();
            
            // Sets title
            if (version[4] == '0') Text = "Spectrum " + version.Substring(0, 3);
            else Text = "Spectrum " + version.Substring(0, 5);

            Console.WriteLine("Current Profile: " + settingsHander.settingsProfile + "\n--------------------------------");

            // Prints Items in Settings
            foreach (string one in settingsHander.settings.Keys)
                foreach (string two in settingsHander.settings[one].Keys)
                    foreach (string three in settingsHander.settings[one][two].Keys)
                        Console.WriteLine("Profile: {0} -- Master: {1} -- Settings: {2} -- Value: {3}", one, two, three, settingsHander.settings[one][two][three]);
            Console.WriteLine("---Profiles Avaliable---");
            foreach(string profile in settingsHander.profileList) Console.WriteLine("Profile: {0}", profile);
            
            
        }

        // user check for updates
        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e) {
            updateHandler.checkForUpdate();
            if (!updateHandler.updateAvalible) MessageBox.Show("No Updates Avalible", "No Updates Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void documentationToolStripMenuItem_Click(object sender, EventArgs e) { Process.Start("https://github.com/DeanSellas/Spectrum/wiki"); }

        private void bugReportToolStripMenuItem_Click(object sender, EventArgs e) { Process.Start("https://github.com/DeanSellas/Spectrum/issues"); }

        private void githubToolStripMenuItem_Click(object sender, EventArgs e) { Process.Start("https://github.com/DeanSellas/Spectrum"); }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }

        
    }
}
