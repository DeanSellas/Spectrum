using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spectrum.Classes {
    public class LogsHandler : TextWriter {
        public Control textbox;
        public LogsHandler(Control log) {
            this.textbox = log;
        }

        public override void Write(char value) {
            textbox.Text += value;
        }

        public override void Write(string value) {
            textbox.Text += value;
        }

        public override Encoding Encoding {
            get { return Encoding.ASCII; }
        }
    }
}
