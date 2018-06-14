using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Spectrum.Classes;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;

namespace Spectrum.Forms {
    public partial class UpdaterForm : Form {
        string installerName, downloadLocation, downloadLink;
        SettingsHandler settingsHandler;

        WebClient webClient = new WebClient();

        public UpdaterForm(string onlineVersion) {
            settingsHandler = new SettingsHandler();
            InitializeComponent();

            installerName = "spectrumv" + onlineVersion + "setup.exe";
            Text = String.Format("Updating to Spectrum {0}", onlineVersion);

            if(settingsHandler.settings[settingsHandler.settingsProfile]["Updater"].ContainsKey("devBuilds") && settingsHandler.settingsProfile != "Default")
                downloadLink = String.Format("https://github.com/DeanSellas/Spectrum/blob/DevBranch/Installer/DevBuild/{0}?raw=true", installerName);
            
            else
                downloadLink = String.Format("https://github.com/DeanSellas/Spectrum/blob/DevBranch/Installer/Public/{0}?raw=true", installerName);

            Console.WriteLine(downloadLink);

            downloadLocation = settingsHandler.settings[settingsHandler.settingsProfile]["Updater"]["downloadLocation"];
            installerName = downloadLocation + "\\" + installerName;


        }

        private void downloadButton_Click(object sender, EventArgs e) {
            // Checks to see if file exists and if it does dont download again
            if (File.Exists(installerName)) { downloadComplete(); return; }

            // Starts the download
            // allows for use of https
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webClient.DownloadFileAsync(new Uri(downloadLink), installerName);

            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);

            downloadButton.Text = "Downloading...";
            downloadButton.Enabled = false;
        }

        // Updates Progress Bar
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;

            // sets label and progress bar
            downloadLabel.Text = String.Format("{0}/{1} kb", bytesIn, totalBytes);
            downloadProgressBar.Value = int.Parse(Math.Truncate(percentage).ToString());
        }

        // When Download Is Complete
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e) {
            downloadButton.Text = "Download Complete";
            downloadComplete();
        }

        private void downloadComplete() {
            // Installs New Version
            DialogResult dialogResult = MessageBox.Show("Would you like to install the new version now?", "Download Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes) {
                Process.Start(installerName);
                Environment.Exit(1);
            }
            Close();
        }
    }
}
