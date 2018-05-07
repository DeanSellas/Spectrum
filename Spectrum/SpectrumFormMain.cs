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

namespace Spectrum {

    public partial class SpectrumFormMain : Form {
        SettingsHandler settingsHander;

        public SpectrumFormMain() {
            settingsHander = new SettingsHandler();
            InitializeComponent();
            
            Console.WriteLine("Current Profile: " + settingsHander.settingsProfile);
            
            // Prints Items in Settings
            foreach (string master in settingsHander.currentSettings.Keys)
                foreach (KeyValuePair<string, dynamic> kvp in settingsHander.currentSettings[master])
                   Console.WriteLine("Master = {2}, Key = {0}, Value = {1}", kvp.Key, kvp.Value, master);
            for (int i = 0; i < settingsHander.settingsProfilesList.Count; i++) Console.WriteLine("Profile: {0}", settingsHander.settingsProfilesList[i]);
            settingsHander.saveSettings();
        }
    }
}
