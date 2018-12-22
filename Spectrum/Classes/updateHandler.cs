using System;
using System.IO;
using System.Windows.Forms;
using System.Net;
using Spectrum.Forms;
using System.ComponentModel;
using System.Diagnostics;

namespace Spectrum.Classes {
    public class UpdateHandler {

        SettingsHandler settingsHandler;
        UpdaterForm updateForm;

        WebClient webClient;

        string downloadLocation;
        string currentVersion = Application.ProductVersion;
        string onlineVersion;
        
        public bool updateAvalible = false, devBuilds = false;

        public UpdateHandler(SettingsHandler s) {
            settingsHandler = s;
            webClient = new WebClient();

            // sets download location
            downloadLocation = settingsHandler.getSetting("Updates", "downloadPath", settingsHandler.currentProfile);

            bool hasInternet = checkConnection();
            if(hasInternet) getOnlineVersion();

            //Console.WriteLine(downloadLocation);
            Console.WriteLine("Current Version: {0} || Online Version: {1}", currentVersion, onlineVersion);

            // sets lastcheck and check data
            string check, lastCheck;
            lastCheck = settingsHandler.settings["Default"]["Updates"]["lastCheck"];
            try { check = settingsHandler.settings[settingsHandler.currentProfile]["Updates"]["checkForUpdate"]; }
            catch { check = "launch"; }

            Console.WriteLine("Check For Update: " + check + "\n--------------------------------");

            if (hasInternet) {
                // when does spectrum check for updates
                if (check == "launch") checkForUpdate();
                else if (check == "daily" && (DateTime.Now - Convert.ToDateTime(lastCheck)).TotalDays >= 1) checkForUpdate();
                else if (check == "weekly" && (DateTime.Now - Convert.ToDateTime(lastCheck)).TotalDays >= 7) checkForUpdate();
                else if (check == "biweekly" && (DateTime.Now - Convert.ToDateTime(lastCheck)).TotalDays >= 14) checkForUpdate();
                else if (check == "monthly" && (DateTime.Now - Convert.ToDateTime(lastCheck)).TotalDays >= 30) checkForUpdate();
            }

        }

        // Checks if user can connect to the server
        public bool checkConnection() {
            try {
                using (webClient.OpenRead("https://raw.githubusercontent.com/DeanSellas/Spectrum/master/version.txt"))
                    return true;
            }
            catch {
                MessageBox.Show("Could not esstablish a connection to the update server. Please Check your Internet and try again.", "No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine("-- WARNING! --\nCould not connect to Github to recieve updates!\n--------------------------------");
                return false;
            }
        }

        // Gets the most recent version number
        private void getOnlineVersion() {
            // enables dev builds if current build is one or setting is enabled
            if(((settingsHandler.settings[settingsHandler.currentProfile].ContainsKey("Advanced") && settingsHandler.settings[settingsHandler.currentProfile]["Advanced"].ContainsKey("devBuilds")) && settingsHandler.currentProfile != "Default") || settingsHandler.settings["Default"]["Advanced"]["devBuilds"]) devBuilds = true;

            // reads version from github
            StreamReader reader;
            // Checks to see if dev builds are enabled
            if(!devBuilds) reader = new StreamReader(webClient.OpenRead("https://raw.githubusercontent.com/DeanSellas/Spectrum/master/version.txt"));
            else reader = new StreamReader(webClient.OpenRead("https://raw.githubusercontent.com/DeanSellas/Spectrum/DevBranch/version.txt"));
            onlineVersion = reader.ReadLine();
        }

        // Checks for update
        public void checkForUpdate(bool user = false) {
            // checks to see if online version is higher than current version
            if (!updateAvalible) {
                for (int i = 0; i < currentVersion.Length; i++) {
                    if (currentVersion[i] != '.' && Convert.ToInt32(currentVersion[i]) > Convert.ToInt32(onlineVersion[i]))
                        break;
                    else if (currentVersion[i] != '.' && currentVersion[i] != onlineVersion[i])
                        updateAvalible = true;
                }
            }
            
            // saves last check time
            settingsHandler.settings["Default"]["Updates"]["lastCheck"] = DateTime.Now.ToString();
            //settingsHandler.saveSettings();

            // prompt user if update is avalible
            if (updateAvalible) {
                DialogResult dialogResult = MessageBox.Show("Would you like to update Spectrum to: " + onlineVersion + "?", "Update Spectrum", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes) {
                    updateForm = new UpdaterForm(this, settingsHandler, devBuilds, onlineVersion);
                    updateForm.ShowDialog();
                }
            }
            else if(user) MessageBox.Show("No Updates Avalible", "No Updates Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Starts Download
        public void startDownload() {
            // Starts the download
            // allows for use of https
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.DownloadFileAsync(new Uri(updateForm.downloadLink), updateForm.installerName);

            // increments download bar
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
        }

        // Updates Progress Bar
        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            // changes download bar info
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;

            // sets label and progress bar
            updateForm.downloadLabel.Text = String.Format("{0} kb/{1} kb", bytesIn, totalBytes);
            updateForm.downloadProgressBar.Value = int.Parse(Math.Truncate(percentage).ToString());
        }

        // When Download Is Complete
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e) { downloadComplete(); }

        public void downloadComplete() {
            updateForm.downloadButton.Text = "Download Complete";
            // Installs New Version
            DialogResult dialogResult = MessageBox.Show("Would you like to install the new version now?", "Download Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes) {
                // needs try except if user does not grant permissions || not exactly sure why but this works
                try {
                    Process.Start(updateForm.installerName);
                    Environment.Exit(1);
                }
                catch { /* Do Nothing */ }
            }
            updateForm.Close();
        }

    }
}
