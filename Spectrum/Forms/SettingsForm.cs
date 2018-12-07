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
            

            //MaximumSize = new Size(435, 295);
        }


        private void SettingsForm_Shown(object sender, EventArgs e) {
            buildProfiles();
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

        // builds settings for current profile
        private void buildSettings() {
            activeProfile = profileComboBox.SelectedItem.ToString();

            buildSettingsRecusion(this.Controls, this);
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

            val = spectrumMain.getSetting(activeProfile, parent.Text, check.Name);

            check.Checked = val;

            Console.WriteLine(String.Format("{0} was set to {1}", check.Name, val));
        }

        
    }
}
