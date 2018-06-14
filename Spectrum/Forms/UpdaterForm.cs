﻿using System;
using System.Threading;
using System.ComponentModel;
using System.IO;
using Spectrum.Classes;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;

namespace Spectrum.Forms {
    public partial class UpdaterForm : Form {
        string installerName, downloadLink;
        SettingsHandler settingsHandler;

        WebClient webClient = new WebClient();

        public UpdaterForm(string onlineVersion) {
            settingsHandler = new SettingsHandler();

            // if dev builds enabled download from dev branch
            if (settingsHandler.settings[settingsHandler.settingsProfile]["Updater"].ContainsKey("devBuilds") && settingsHandler.settingsProfile != "Default")
                downloadLink = String.Format("https://github.com/DeanSellas/Spectrum/blob/DevBranch/Installer/DevBuild/spectrumv{0}setup.exe?raw=true", onlineVersion);

            else
                downloadLink = String.Format("https://github.com/DeanSellas/Spectrum/blob/DevBranch/Installer/Public/spectrumv{0}setup.exe?raw=true", onlineVersion);

            // sets download location
            installerName = String.Format("{0}\\spectrumv{1}setup.exe", settingsHandler.settings[settingsHandler.settingsProfile]["Updater"]["downloadLocation"], onlineVersion);

            InitializeComponent();

            Text = String.Format("Update to {0}", onlineVersion);

            Console.WriteLine(downloadLink);
            Console.WriteLine(installerName);
        }

        private void downloadButton_Click(object sender, EventArgs e) {
            downloadButton.Text = "Downloading...";
            downloadButton.Enabled = false;

            // Checks to see if file exists and if it does dont download again
            if (File.Exists(installerName)) { downloadProgressBar.Value = 100; downloadComplete(); return; }

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
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            // changes download bar info
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;

            // sets label and progress bar
            downloadLabel.Text = String.Format("{0} kb/{1} kb", bytesIn, totalBytes);
            downloadProgressBar.Value = int.Parse(Math.Truncate(percentage).ToString());
        }

        // When Download Is Complete
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e) {
            downloadComplete();
        }

        private void downloadComplete() {
            downloadButton.Text = "Download Complete";
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
