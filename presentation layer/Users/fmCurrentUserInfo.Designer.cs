namespace DVLD.Users
{
    partial class fmCurrentUserInfo
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
            this.SuspendLayout();
            // 
            // ctrlShowUserInformation1
            // 
            this.ctrlShowUserInformation1.Location = new System.Drawing.Point(-9, -6);
            this.ctrlShowUserInformation1.Name = "ctrlShowUserInformation1";
            this.ctrlShowUserInformation1.Size = new System.Drawing.Size(847, 512);
            this.ctrlShowUserInformation1.TabIndex = 0;
            // 
            // fmCurrentUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 449);
            this.Controls.Add(this.ctrlShowUserInformation1);
            this.Name = "fmCurrentUserInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Current User Info";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowUserInformation ctrlShowUserInformation1;
    }
}