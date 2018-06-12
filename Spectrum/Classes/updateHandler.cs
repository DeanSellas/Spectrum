using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Net;

namespace Spectrum.Classes {
    class UpdateHandler {

        SettingsHandler settingsHandler;

        private string downloadLocation;
        private string currentVersion = Application.ProductVersion;
        private string onlineVersion;

        public bool updateAvalible = false;
        public UpdateHandler(SettingsHandler s) {
            settingsHandler = s;

            try { downloadLocation = settingsHandler.settings[settingsHandler.settingsProfile]["Updater"]["downloadLocation"]; }
            catch { downloadLocation = settingsHandler.settings["Default"]["Updater"]["downloadLocation"]; }

            Console.WriteLine("Updater is online");
            
            getOnlineVersion();
            Console.WriteLine(downloadLocation);
            Console.WriteLine("Current Version: {0} || Online Version: {1}", currentVersion, onlineVersion);


            string check, lastCheck;
            lastCheck = settingsHandler.settings["Default"]["Updater"]["lastCheck"];
            try { check = settingsHandler.settings[settingsHandler.settingsProfile]["Updater"]["checkForUpdate"]; }
            catch { check = "launch"; }

            Console.WriteLine(check);
            if (check == "launch") checkForUpdate();
            else if (check == "daily" && (DateTime.Now - Convert.ToDateTime(lastCheck)).TotalDays >= 1) checkForUpdate();
            else if (check == "weekly" && (DateTime.Now - Convert.ToDateTime(lastCheck)).TotalDays >= 7) checkForUpdate();
            else if (check == "biweekly" && (DateTime.Now - Convert.ToDateTime(lastCheck)).TotalDays >= 14) checkForUpdate();
            else if (check == "monthly" && (DateTime.Now - Convert.ToDateTime(lastCheck)).TotalDays >= 30) checkForUpdate();

        }

        private void getOnlineVersion() {
            bool devBuilds = false;
            StreamReader reader;
            if (settingsHandler.settings[settingsHandler.settingsProfile]["Updater"].ContainsKey("devBuilds") && settingsHandler.settingsProfile != "Default") devBuilds = true;

            WebClient web = new WebClient();
            if(!devBuilds) reader = new StreamReader(web.OpenRead("https://raw.githubusercontent.com/DeanSellas/Spectrum/master/version.txt"));
            else reader = new StreamReader(web.OpenRead("https://raw.githubusercontent.com/DeanSellas/Spectrum/DevBranch/version.txt"));
            onlineVersion = reader.ReadLine();
        }

        public void checkForUpdate() {
            
            for(int i = 0; i < currentVersion.Length; i++) 
                if (currentVersion[i] != '.' && Convert.ToInt32(currentVersion[i]) < Convert.ToInt32(onlineVersion[i])) { updateAvalible = true; break; }

            settingsHandler.settings["Default"]["Updater"]["lastCheck"] = DateTime.Now.ToString();
            settingsHandler.saveSettings();

            if (updateAvalible) {
                DialogResult dialogResult = MessageBox.Show("Would you like to update Spectrum to: " + onlineVersion + "?", "Update Spectrum", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes) downloadUpdate();
            }
        }

        private void downloadUpdate() {

        }

    }
}
