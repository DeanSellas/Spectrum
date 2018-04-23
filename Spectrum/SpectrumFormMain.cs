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
        Dictionary<string, dynamic> currentSettings, defaultSettings;
        SettingsHandler settings = new SettingsHandler();

        public SpectrumFormMain() {
            InitializeComponent();
            
            defaultSettings = settings.defaultSettings;
            Console.WriteLine(settings.settingsProfile);

            if (settings.settingsProfile == "default") currentSettings = defaultSettings;
            else currentSettings = settings.createSettings(settings.settingsProfile);

            // Prints Items in Settings
            foreach (KeyValuePair<string, dynamic> kvp in currentSettings) { Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value); }
        }
    }
}
