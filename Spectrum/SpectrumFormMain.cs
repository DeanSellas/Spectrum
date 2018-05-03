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
        //public Dictionary<string, dynamic> currentSettings;
        Dictionary<string, dynamic> defaultSettings;
        SettingsHandler settingsHander;

        public SpectrumFormMain() {
            settingsHander = new SettingsHandler();
            InitializeComponent();
            
            defaultSettings = settingsHander.defaultSettings;
            Console.WriteLine("Current Profile: " + settingsHander.settingsProfile);

            // Prints Items in Settings
            foreach (string master in settingsHander.currentSettings.Keys)
                foreach (KeyValuePair<string, dynamic> kvp in settingsHander.currentSettings[master])
                   Console.WriteLine("Master = {2}, Key = {0}, Value = {1}", kvp.Key, kvp.Value, master);
            settingsHander.saveSettings();
        }
    }
}
