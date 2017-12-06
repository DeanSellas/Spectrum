using Spectrum.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Spectrum {
    public partial class UpdateForm : Form {

        UpdateForm updateForm;

        string installerName, downloadLocation, fileLoaction, onlineVersion;

        WebClient webClient = new WebClient();

        public UpdateForm(string installer, string download, string version) {
            InitializeComponent();

            fileLoaction = Settings.Default.fileLocation;

            installerName = installer;
            downloadLocation = download;
            onlineVersion = version; 
            postponeCombobox.SelectedIndex = 0;

            Text = "Update To " + onlineVersion;
        }

        // Check For Product Updates
        public void SpectrumUpdate(bool updateAvailable, bool userCheck) {

            // Open Update Form
            if (updateAvailable) {
                updateForm = new UpdateForm(installerName, downloadLocation, onlineVersion);
                updateForm.ShowDialog();
                
            }
            else if(userCheck) MessageBox.Show("You already have the latest version of Spectrum.", "No Updates Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Starts Download
        public void downloadButton_Click(object sender, EventArgs e) {

            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);

            // Starts the download
            webClient.DownloadFileAsync(new Uri(downloadLocation), fileLoaction + installerName);

            downloadButton.Text = "Downloading...";
            downloadButton.Enabled = false;

        }

        // Updates Progress Bar
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;

            downloadProgressBar.Value = int.Parse(Math.Truncate(percentage).ToString());
        }

        // When Download Is Complete
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e) {

            // Installs New Version
            DialogResult dialogResult = MessageBox.Show("Download Complete! Would you like to install the new version now?", "Download Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogResult == DialogResult.Yes) {
                Process.Start(fileLoaction + installerName);
                Environment.Exit(1);
            }
            downloadButton.Text = "Download Complete";
        }

        // Postpone Update
        private void postponeButton_Click(object sender, EventArgs e) {
            if (postponeCombobox.SelectedIndex == 0) Settings.Default.postponeUpdateDate = DateTime.Today.AddDays(1);
            if (postponeCombobox.SelectedIndex == 1) Settings.Default.postponeUpdateDate = DateTime.Today.AddDays(2);
            if (postponeCombobox.SelectedIndex == 2) Settings.Default.postponeUpdateDate = DateTime.Today.AddDays(3);
            if (postponeCombobox.SelectedIndex == 3) Settings.Default.postponeUpdateDate = DateTime.Today.AddDays(4);
            if (postponeCombobox.SelectedIndex == 4) Settings.Default.postponeUpdateDate = DateTime.Today.AddDays(7);
            if (postponeCombobox.SelectedIndex == 5) Settings.Default.postponeUpdateDate = DateTime.Today.AddDays(14);
            Settings.Default.postponeUpdateBool = true;
            Settings.Default.Save();
            Console.WriteLine(Settings.Default.postponeUpdateDate - DateTime.Today);
            Close();
        }

    }
}
