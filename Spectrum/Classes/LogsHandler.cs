using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spectrum.Classes {
    

    public class LogsHandler : TextWriter {

        // properies for log textbox
        public class TextBoxLog : TextWriter {
            public Control textbox;
            public TextBoxLog(Control log) {
                textbox = log;
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


        // logs everything to the console
        private IEnumerable<TextWriter> logs;
        public LogsHandler(params TextWriter[] items) {
            logs = items;
        }


        public override void Write(char val) {
            foreach(var i in logs) {
                i.Write(val);
            }
        }
        public override void Write(string val) {
            foreach (var i in logs) {
                i.Write(val);
            }
        }


        public override Encoding Encoding {
            get { return Encoding.ASCII; }
        }

    }

}
