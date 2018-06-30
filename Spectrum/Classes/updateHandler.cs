using System;
using System.IO;
using System.Windows.Forms;
using System.Net;
using Spectrum.Forms;
using System.ComponentModel;

namespace Spectrum.Classes {
    public class UpdateHandler {

        SettingsHandler settingsHandler;
        UpdaterForm updateForm;

        string downloadLocation;
        string currentVersion = Application.ProductVersion;
        string onlineVersion;

        public bool updateAvalible = false, devBuilds = false;

        public UpdateHandler(SettingsHandler s) {
            settingsHandler = s;

            // sets download location
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
            
            // enables dev builds
            if (settingsHandler.settings[settingsHandler.settingsProfile]["Updater"].ContainsKey("devBuilds") && settingsHandler.settingsProfile != "Default") devBuilds = true;

            // reads version from github
            StreamReader reader;
            WebClient web = new WebClient();
            // Checks to see if dev builds are enabled
            if(!devBuilds) reader = new StreamReader(web.OpenRead("https://raw.githubusercontent.com/DeanSellas/Spectrum/master/version.txt"));
            else reader = new StreamReader(web.OpenRead("https://raw.githubusercontent.com/DeanSellas/Spectrum/DevBranch/version.txt"));
            onlineVersion = reader.ReadLine();

            
        }

        public void checkForUpdate() {
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
            settingsHandler.settings["Default"]["Updater"]["lastCheck"] = DateTime.Now.ToString();
            settingsHandler.saveSettings();

            // prompt user if update is avalible
            if (updateAvalible) {
                DialogResult dialogResult = MessageBox.Show("Would you like to update Spectrum to: " + onlineVersion + "?", "Update Spectrum", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes) {
                    // needs try except if user does not grant permissions || not exactly sure why but this works
                    try {
                        updateForm = new UpdaterForm(this, settingsHandler, devBuilds, onlineVersion);
                        updateForm.ShowDialog();
                    }
                    catch { }
                }
            }
        }

        // Starts Download
        public void startDownload(string downloadLink, string installerName) {
            WebClient webClient = new WebClient();

            // Starts the download
            // allows for use of https
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.DownloadFileAsync(new Uri(downloadLink), installerName);

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
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e) {
            updateForm.downloadComplete();
        }

    }
}
