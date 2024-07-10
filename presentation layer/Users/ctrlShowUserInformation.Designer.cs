namespace DVLD.Users
{
    partial class ctrlShowUserInformation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.LoginInformation = new System.Windows.Forms.GroupBox();
            this.lbIsActive = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbUserID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlPersonInformation2 = new DVLD.ctrlPersonInformation();
            this.LoginInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(281, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Information";
            // 
            // LoginInformation
            // 
            this.LoginInformation.Controls.Add(this.lbIsActive);
            this.LoginInformation.Controls.Add(this.lbUserName);
            this.LoginInformation.Controls.Add(this.lbUserID);
            this.LoginInformation.Controls.Add(this.label4);
            this.LoginInformation.Controls.Add(this.label3);
            this.LoginInformation.Controls.Add(this.label2);
            this.LoginInformation.Location = new System.Drawing.Point(14, 370);
            this.LoginInformation.Name = "LoginInformation";
            this.LoginInformation.Size = new System.Drawing.Size(697, 64);
            this.LoginInformation.TabIndex = 2;
            this.LoginInformation.TabStop = false;
            this.LoginInformation.Text = "Login Information";
            // 
            // lbIsActive
            // 
            this.lbIsActive.AutoSize = true;
            this.lbIsActive.Location = new System.Drawing.Point(584, 33);
            this.lbIsActive.Name = "lbIsActive";
            this.lbIsActive.Size = new System.Drawing.Size(35, 13);
            this.lbIsActive.TabIndex = 5;
            this.lbIsActive.Text = "label7";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(353, 34);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(35, 13);
            this.lbUserName.TabIndex = 4;
            this.lbUserName.Text = "label6";
            // 
            // lbUserID
            // 
            this.lbUserID.AutoSize = true;
            this.lbUserID.Location = new System.Drawing.Point(141, 33);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(35, 13);
            this.lbUserID.TabIndex = 3;
            this.lbUserID.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(501, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Is Active:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "User Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "UserID:";
            // 
            // ctrlPersonInformation2
            // 
            this.ctrlPersonInformation2.IsSuccessfullyLoad = false;
            this.ctrlPersonInformation2.Location = new System.Drawing.Point(14, 49);
            this.ctrlPersonInformation2.Name = "ctrlPersonInformation2";
            this.ctrlPersonInformation2.Size = new System.Drawing.Size(697, 316);
            this.ctrlPersonInformation2.TabIndex = 3;
            // 
            // ctrlShowUserInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlPersonInformation2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginInformation);
            this.Name = "ctrlShowUserInformation";
            this.Size = new System.Drawing.Size(728, 442);
            this.LoginInformation.ResumeLayout(false);
            this.LoginInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox LoginInformation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbIsActive;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbUserID;
        private ctrlPersonInformation ctrlPersonInformation2;
    }
}
