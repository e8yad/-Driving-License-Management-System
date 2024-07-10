namespace DVLD.Users
{
    partial class fmUserInformation
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
            this.ctrlShowUserInformation1 = new DVLD.Users.ctrlShowUserInformation();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlShowUserInformation1
            // 
            this.ctrlShowUserInformation1.Location = new System.Drawing.Point(-3, 15);
            this.ctrlShowUserInformation1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctrlShowUserInformation1.Name = "ctrlShowUserInformation1";
            this.ctrlShowUserInformation1.Size = new System.Drawing.Size(962, 591);
            this.ctrlShowUserInformation1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(544, 590);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 38);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // fmUserInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 642);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlShowUserInformation1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "fmUserInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fmUserInformation";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowUserInformation ctrlShowUserInformation1;
        private System.Windows.Forms.Button btnClose;
    }
}