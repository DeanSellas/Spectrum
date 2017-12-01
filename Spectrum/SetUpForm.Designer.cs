namespace Spectrum {
    partial class SetUpForm {
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
            this.serialComboBox = new System.Windows.Forms.ComboBox();
            this.stripLengthValue = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stripLengthValue)).BeginInit();
            this.SuspendLayout();
            // 
            // serialComboBox
            // 
            this.serialComboBox.FormattingEnabled = true;
            this.serialComboBox.Location = new System.Drawing.Point(204, 122);
            this.serialComboBox.Name = "serialComboBox";
            this.serialComboBox.Size = new System.Drawing.Size(121, 21);
            this.serialComboBox.TabIndex = 0;
            // 
            // stripLengthValue
            // 
            this.stripLengthValue.InterceptArrowKeys = false;
            this.stripLengthValue.Location = new System.Drawing.Point(234, 164);
            this.stripLengthValue.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.stripLengthValue.Name = "stripLengthValue";
            this.stripLengthValue.Size = new System.Drawing.Size(60, 20);
            this.stripLengthValue.TabIndex = 2;
            this.stripLengthValue.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(219, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SetUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 293);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.stripLengthValue);
            this.Controls.Add(this.serialComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetUpForm";
            this.ShowIcon = false;
            this.Text = "Set Up";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SetUpForm_FormClosed);
            this.Load += new System.EventHandler(this.SetUpForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stripLengthValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ComboBox serialComboBox;
        private System.Windows.Forms.NumericUpDown stripLengthValue;
        private System.Windows.Forms.Button button1;
    }
}