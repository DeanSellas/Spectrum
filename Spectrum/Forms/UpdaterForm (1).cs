using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Spectrum.Classes;


namespace Spectrum.Forms {
    public partial class UpdaterForm : Form {
        
        SettingsHandler settingsHandler;
        UpdateHandler updateHandler;

        public string installerName, downloadLink;
        bool devBuilds;

        public UpdaterForm(UpdateHandler u, SettingsHandler s, bool dev, string onlineVersion) {
            settingsHandler = s;
            updateHandler = u;
            devBuilds = dev;

            // formats online version
            string tmpVersion = "";
            for (int i = 0; i < onlineVersion.Length; i++) {
                if (i > 1 && onlineVersion[i + 1] != '0') tmpVersion += onlineVersion[i];
                else if (i <= 1) tmpVersion += onlineVersion[i];
                else break;
            }

            onlineVersion = tmpVersion;

            // if dev builds enabled download from dev branch
            if (!devBuilds)
                downloadLink = String.Format("https://github.com/DeanSellas/Spectrum/blob/DevBranch/Installer/Public/spectrumv{0}setup.exe?raw=true", onlineVersion);
            else
                downloadLink = String.Format("https://github.com/DeanSellas/Spectrum/blob/DevBranch/Installer/DevBuild/spectrumv{0}setup.exe?raw=true", onlineVersion);

            // sets download location
            installerName = String.Format("{0}\\spectrumv{1}setup.exe", settingsHandler.settings[settingsHandler.settingsProfile]["Updater"]["downloadLocation"], onlineVersion);

            InitializeComponent();

            Text = String.Format("Update to {0}", onlineVersion);

            Console.WriteLine(downloadLink);
            Console.WriteLine(installerName);
        }

        // Start Download
        private void downloadButton_Click(object sender, EventArgs e) {
            downloadButton.Text = "Downloading...";
            downloadButton.Enabled = false;

            // Checks to see if file exists and if it does dont download again
            if (File.Exists(installerName)) { downloadProgressBar.Value = 100; updateHandler.downloadComplete(); return; }

            updateHandler.startDownload();
        }

        // Closes Form 
        private void cancelButton_Click(object sender, EventArgs e) { Close(); }

        // Changelog Link
        private void changelogLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (!devBuilds) Process.Start("https://raw.githubusercontent.com/DeanSellas/Spectrum/master/changelog.txt");
            else Process.Start("https://raw.githubusercontent.com/DeanSellas/Spectrum/DevBranch/changelog.txt");
            changelogLink.LinkVisited = true;
        }
        
    }
}
