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
    public partial class SettingsForm : Form {

        SpectrumFormMain spectrumMain;

        SettingsHandler settingsHander;

        string activeProfile;


        public SettingsForm(SpectrumFormMain main, SettingsHandler settings) {
            spectrumMain = main;
            settingsHander = settings;
            InitializeComponent();

            // will be used later
            // MaximumSize = new Size(435, 295);
        }

        // builds settings form when shown
        private void SettingsForm_Shown(object sender, EventArgs e) {
            // since visual studio only using Shown once I needed to reasing this to Visablility changed event
            // this prevents code from running on close
            if (!Visible) return;
            buildProfiles();
            buildPorts();
            buildSettings();
        }

        public void buildProfiles() {
            int index = 0;
            
            foreach (string item in settingsHander.getSettingProfiles()) {

                // sets proper index for profile
                if (item == settingsHander.currentProfile)
                    index = profileComboBox.Items.Count;

                profileComboBox.Items.Add(item);
            }

            profileComboBox.SelectedIndex = index;
        }

        private void buildPorts() {
            foreach(string i in spectrumMain.serialPortComboBox.Items) {
                portComboBox.Items.Add(i);
            }
            portComboBox.SelectedIndex = 0;

            portComboBox.Enabled = spectrumMain.serialPortComboBox.Enabled;

        }


        // builds settings for current profile
        private void buildSettings() {
            activeProfile = profileComboBox.SelectedItem.ToString();

            buildSettingsRecusion(this.Controls, this);

            Console.WriteLine("--------------------------------");
        }
        private void buildSettingsRecusion(Control.ControlCollection controls, Control parent) {
            // goes through controls
            foreach(Control item in controls) {
                // if item is control is a checkbox set it
                if(item is CheckBox) {
                    setCheckbox((CheckBox)item, (GroupBox)parent);
                    continue;
                }
                // recurisve call if no checkboxes
                buildSettingsRecusion(item.Controls, item);
            }
        }

        // sets checkboxes
        private void setCheckbox(CheckBox check, GroupBox parent) {
            bool val;

            val = settingsHander.getSetting(parent.Text, check.Name, activeProfile);

            check.Checked = val;

            Console.WriteLine(String.Format("{0} was set to {1}", check.Name, val));
        }

        private void refreshButton_Click(object sender, EventArgs e) { spectrumMain.refreshButton.PerformClick(); }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            Hide();
        }
    }
}
