using System;
using System.IO;
using System.Windows.Forms;
using System.Net;
using Spectrum.Forms;

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
            
            getOnlineVersion();

            //Console.WriteLine(downloadLocation);
            Console.WriteLine("Current Version: {0} || Online Version: {1}", currentVersion, onlineVersion);

            // sets lastcheck and check data
            string check, lastCheck;
            lastCheck = settingsHandler.settings["Default"]["Updater"]["lastCheck"];
            try { check = settingsHandler.settings[settingsHandler.settingsProfile]["Updater"]["checkForUpdate"]; }
            catch { check = "launch"; }

            Console.WriteLine(check);
            // when does spectrum check for updates
            if (check == "launch") checkForUpdate();
            else if (check == "daily" && (DateTime.Now - Convert.ToDateTime(lastCheck)).TotalDays >= 1) checkForUpdate();
            else if (check == "weekly" && (DateTime.Now - Convert.ToDateTime(lastCheck)).TotalDays >= 7) checkForUpdate();
            else if (check == "biweekly" && (DateTime.Now - Convert.ToDateTime(lastCheck)).TotalDays >= 14) checkForUpdate();
            else if (check == "monthly" && (DateTime.Now - Convert.ToDateTime(lastCheck)).TotalDays >= 30) checkForUpdate();

        }

        private void getOnlineVersion() {
            bool devBuilds = false;
            // enables dev builds
            if (settingsHandler.settings[settingsHandler.settingsProfile]["Updater"].ContainsKey("devBuilds") && settingsHandler.settingsProfile != "Default") devBuilds = true;

            // reads version from github
            StreamReader reader;
            WebClient web = new WebClient();
            // Checks to see if dev builds are enabled
            if(!devBuilds) reader = new StreamReader(web.OpenRead("https://raw.githubusercontent.com/DeanSellas/Spectrum/master/version.txt"));
            else reader = new StreamReader(web.OpenRead("https://raw.githubusercontent.com/DeanSellas/Spectrum/DevBranch/version.txt"));
            onlineVersion = reader.ReadLine();

            // formats online version
            string tmpVersion = "";
            for (int i = 0; i < onlineVersion.Length; i++) {
                if (i > 1 && onlineVersion[i + 1] != '0') tmpVersion += onlineVersion[i];
                else if (i <= 1) tmpVersion += onlineVersion[i];
                else break;
            }
            onlineVersion = tmpVersion;
        }

        public void checkForUpdate() {

            // checks to see if online version is higher than current version
            for (int i = 0; i < currentVersion.Length; i++)
                if (currentVersion[i] != '.' && Convert.ToInt32(currentVersion[i]) < Convert.ToInt32(onlineVersion[i])) { updateAvalible = true; break; }

            settingsHandler.settings["Default"]["Updater"]["lastCheck"] = DateTime.Now.ToString();
            settingsHandler.saveSettings();

            // prompt user if update is avalible
            if (updateAvalible) {
                DialogResult dialogResult = MessageBox.Show("Would you like to update Spectrum to: " + onlineVersion + "?", "Update Spectrum", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes) {
                    // needs try except if user does not grant permissions
                    try {
                        UpdaterForm updater = new UpdaterForm(onlineVersion);
                        updater.ShowDialog();
                    }
                    catch { }
                }
            }
        }

    }
}
