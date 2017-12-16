using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spectrum {
    public partial class AboutForm : Form {
        public AboutForm() {
            InitializeComponent();
            currentVersionLabel.Text = "Current Version: " + Application.ProductVersion;
        }

        private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            githubLink.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/DeanSellas/Spectrum");
        }

        private void websiteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            websiteLinkLabel.LinkVisited = true;
            System.Diagnostics.Process.Start("http://deansellas.com/spectrum");
        }
    }
}
