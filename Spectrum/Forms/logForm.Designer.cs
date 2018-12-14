namespace Spectrum.Forms {
    partial class logForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.path = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.autoScrollCheckBox = new System.Windows.Forms.CheckBox();
            this.log = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // path
            // 
            this.path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.path.Location = new System.Drawing.Point(13, 418);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(536, 20);
            this.path.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(679, 413);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(99, 29);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save Log";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // saveFileButton
            // 
            this.saveFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveFileButton.Location = new System.Drawing.Point(555, 418);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(30, 20);
            this.saveFileButton.TabIndex = 4;
            this.saveFileButton.Text = "...";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.FileName = "log.txt";
            this.saveFileDialog1.Filter = " Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.saveFileDialog1.Title = "Choose Log File Location";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // autoScrollCheckBox
            // 
            this.autoScrollCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.autoScrollCheckBox.AutoSize = true;
            this.autoScrollCheckBox.Location = new System.Drawing.Point(591, 420);
            this.autoScrollCheckBox.Name = "autoScrollCheckBox";
            this.autoScrollCheckBox.Size = new System.Drawing.Size(72, 17);
            this.autoScrollCheckBox.TabIndex = 5;
            this.autoScrollCheckBox.Text = "Autoscroll";
            this.autoScrollCheckBox.UseVisualStyleBackColor = true;
            this.autoScrollCheckBox.CheckedChanged += new System.EventHandler(this.log_TextChanged);
            // 
            // log
            // 
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.log.Location = new System.Drawing.Point(2, 1);
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.Size = new System.Drawing.Size(776, 407);
            this.log.TabIndex = 0;
            this.log.Text = "";
            this.log.WordWrap = false;
            this.log.TextChanged += new System.EventHandler(this.log_TextChanged);
            // 
            // logForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 450);
            this.Controls.Add(this.autoScrollCheckBox);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.path);
            this.Controls.Add(this.log);
            this.MinimumSize = new System.Drawing.Size(603, 489);
            this.Name = "logForm";
            this.Text = "logForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.logForm_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.logForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox autoScrollCheckBox;
        public System.Windows.Forms.RichTextBox log;
    }
}