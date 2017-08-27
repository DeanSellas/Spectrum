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
    public partial class UpdateForm : Form {

        bool updateAvailable = false;
        UpdateForm updateForm;
        
        public UpdateForm() {
            InitializeComponent();
        }

       public void SpectrumUpdate(string currentVersion) {
            




            if (updateAvailable) {
                updateForm = new UpdateForm();
                updateForm.ShowDialog();
            }
            else MessageBox.Show("You already have the latest version of Spectrum.");
        }




    }
}
