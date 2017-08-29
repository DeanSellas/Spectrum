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

        bool updateAvailable = false;

        UpdateForm updateForm;
        spectrumFormMain spectrumForm;

        string installerName, downloadLocation, fileLoaction;

        WebClient webClient = new WebClient();

        public UpdateForm(string installer, string download) {
            InitializeComponent();

            fileLoaction = AppDomain.CurrentDomain.BaseDirectory;

            installerName = installer;
            downloadLocation = download;

            postponeCombobox.SelectedIndex = 0;

        }

        // Check For Product Updates
        public void SpectrumUpdate(string currentVersion) {

            // Reads Version.txt
            
            System.IO.Stream stream = webClient.OpenRead("https://raw.githubusercontent.com/DeanSellas/Spectrum/master/version.txt");
            using (System.IO.StreamReader reader = new System.IO.StreamReader(stream)) {
                String onlineVersion = reader.ReadToEnd();
                Console.WriteLine(onlineVersion);

                // Sets Proper Variables
                // Change != to == for testing purposes
                if (currentVersion == onlineVersion) {
                    updateAvailable = true;
                    installerName = "spectrumv" + onlineVersion + "setup.exe";
                    Console.WriteLine(installerName);
                    downloadLocation = "https://github.com/DeanSellas/Spectrum/blob/master/Installer/" + installerName + "?raw=true";
                }
            }


            // Open Update Form
            if (updateAvailable) {
                updateForm = new UpdateForm(installerName, downloadLocation);
                updateForm.ShowDialog();
                
            }
            else MessageBox.Show("You already have the latest version of Spectrum.", "No Updates Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Starts Download
        private void downloadButton_Click(object sender, EventArgs e) {

            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);

            // Starts the download
            webClient.DownloadFileAsync(new Uri(downloadLocation), fileLoaction + installerName);

            downloadButton.Text = "Downloading...";
            downloadButton.Enabled = false;

        }

        private void postponeButton_Click(object sender, EventArgs e) {
            Close();
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


    }
}
