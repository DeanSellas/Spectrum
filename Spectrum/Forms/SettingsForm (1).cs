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

        public SettingsForm(SpectrumFormMain main, SettingsHandler settings) {
            spectrumMain = main;
            settingsHander = settings;
            InitializeComponent();

            buildProfiles();
        }

        public void buildProfiles() {
            foreach (string item in settingsHander.getSettingProfiles())
                profileComboBox.Items.Add(item);

            profileComboBox.SelectedIndex = 0;
        }
    }
}
