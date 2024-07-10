namespace DVLD.Applications.Tests
{
    partial class fmTestAppointment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlTestAppointment1 = new DVLD.Applications.ctrlTestAppointment();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlTestAppointment1
            // 
            this.ctrlTestAppointment1.Location = new System.Drawing.Point(12, 0);
            this.ctrlTestAppointment1.Name = "ctrlTestAppointment1";
            this.ctrlTestAppointment1.Size = new System.Drawing.Size(608, 673);
            this.ctrlTestAppointment1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Image = global::DVLD.Properties.Resources.close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(420, 694);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 43);
            this.button1.TabIndex = 16;
            this.button1.Text = "              Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fmTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 749);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlTestAppointment1);
            this.Name = "fmTestAppointment";
            this.Text = "Test Applointments";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlTestAppointment ctrlTestAppointment1;
        private System.Windows.Forms.Button button1;
    }
}