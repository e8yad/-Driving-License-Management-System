namespace DVLD.Applications.InternationalApplications
{
    partial class fmIssueInternationalLicense
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtPerson_LLN = new System.Windows.Forms.TextBox();
            this.cmFilterBY = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbExpirationDate = new System.Windows.Forms.Label();
            this.lbLLN = new System.Windows.Forms.Label();
            this.lbILN = new System.Windows.Forms.Label();
            this.lbFees = new System.Windows.Forms.Label();
            this.lbIssueDate = new System.Windows.Forms.Label();
            this.lbApplicationDate = new System.Windows.Forms.Label();
            this.lbApplicationID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.llbShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.llbShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.ctrlLocalDrivingLicenseInfo1 = new DVLD.Applications.ctrlLocalDrivingLicenseInfo();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(122, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "International Driving License";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.txtPerson_LLN);
            this.groupBox1.Controls.Add(this.cmFilterBY);
            this.groupBox1.Location = new System.Drawing.Point(13, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 59);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FilterBy";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(420, 21);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtPerson_LLN
            // 
            this.txtPerson_LLN.Location = new System.Drawing.Point(209, 23);
            this.txtPerson_LLN.MaxLength = 12;
            this.txtPerson_LLN.Name = "txtPerson_LLN";
            this.txtPerson_LLN.Size = new System.Drawing.Size(175, 22);
            this.txtPerson_LLN.TabIndex = 1;
            // 
            // cmFilterBY
            // 
            this.cmFilterBY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmFilterBY.FormattingEnabled = true;
            this.cmFilterBY.Items.AddRange(new object[] {
            "NationalID",
            "License Number Class3"});
            this.cmFilterBY.Location = new System.Drawing.Point(58, 21);
            this.cmFilterBY.Name = "cmFilterBY";
            this.cmFilterBY.Size = new System.Drawing.Size(121, 24);
            this.cmFilterBY.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbUserName);
            this.groupBox2.Controls.Add(this.lbExpirationDate);
            this.groupBox2.Controls.Add(this.lbLLN);
            this.groupBox2.Controls.Add(this.lbILN);
            this.groupBox2.Controls.Add(this.lbFees);
            this.groupBox2.Controls.Add(this.lbIssueDate);
            this.groupBox2.Controls.Add(this.lbApplicationDate);
            this.groupBox2.Controls.Add(this.lbApplicationID);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(13, 557);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(605, 195);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Info";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(416, 154);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(49, 16);
            this.lbUserName.TabIndex = 15;
            this.lbUserName.Text = "- - - - - - ";
            // 
            // lbExpirationDate
            // 
            this.lbExpirationDate.AutoSize = true;
            this.lbExpirationDate.Location = new System.Drawing.Point(416, 113);
            this.lbExpirationDate.Name = "lbExpirationDate";
            this.lbExpirationDate.Size = new System.Drawing.Size(49, 16);
            this.lbExpirationDate.TabIndex = 14;
            this.lbExpirationDate.Text = "- - - - - - ";
            // 
            // lbLLN
            // 
            this.lbLLN.AutoSize = true;
            this.lbLLN.Location = new System.Drawing.Point(416, 75);
            this.lbLLN.Name = "lbLLN";
            this.lbLLN.Size = new System.Drawing.Size(49, 16);
            this.lbLLN.TabIndex = 13;
            this.lbLLN.Text = "- - - - - - ";
            // 
            // lbILN
            // 
            this.lbILN.AutoSize = true;
            this.lbILN.Location = new System.Drawing.Point(416, 35);
            this.lbILN.Name = "lbILN";
            this.lbILN.Size = new System.Drawing.Size(49, 16);
            this.lbILN.TabIndex = 12;
            this.lbILN.Text = "- - - - - - ";
            // 
            // lbFees
            // 
            this.lbFees.AutoSize = true;
            this.lbFees.Location = new System.Drawing.Point(137, 154);
            this.lbFees.Name = "lbFees";
            this.lbFees.Size = new System.Drawing.Size(49, 16);
            this.lbFees.TabIndex = 11;
            this.lbFees.Text = "- - - - - - ";
            // 
            // lbIssueDate
            // 
            this.lbIssueDate.AutoSize = true;
            this.lbIssueDate.Location = new System.Drawing.Point(137, 113);
            this.lbIssueDate.Name = "lbIssueDate";
            this.lbIssueDate.Size = new System.Drawing.Size(49, 16);
            this.lbIssueDate.TabIndex = 10;
            this.lbIssueDate.Text = "- - - - - - ";
            // 
            // lbApplicationDate
            // 
            this.lbApplicationDate.AutoSize = true;
            this.lbApplicationDate.Location = new System.Drawing.Point(137, 75);
            this.lbApplicationDate.Name = "lbApplicationDate";
            this.lbApplicationDate.Size = new System.Drawing.Size(49, 16);
            this.lbApplicationDate.TabIndex = 9;
            this.lbApplicationDate.Text = "- - - - - - ";
            // 
            // lbApplicationID
            // 
            this.lbApplicationID.AutoSize = true;
            this.lbApplicationID.Location = new System.Drawing.Point(137, 37);
            this.lbApplicationID.Name = "lbApplicationID";
            this.lbApplicationID.Size = new System.Drawing.Size(49, 16);
            this.lbApplicationID.TabIndex = 8;
            this.lbApplicationID.Text = "- - - - - - ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(280, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "CreatedBy:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "ApplicationDate:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "IssueDate:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Fees:";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(280, 35);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(27, 16);
            this.label.TabIndex = 3;
            this.label.Text = "ILN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Local License Nuber:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "ExpirationDate:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "ApplicationID:";
            // 
            // btnIssue
            // 
            this.btnIssue.Location = new System.Drawing.Point(518, 768);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(75, 32);
            this.btnIssue.TabIndex = 4;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(403, 768);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // llbShowLicenseHistory
            // 
            this.llbShowLicenseHistory.AutoSize = true;
            this.llbShowLicenseHistory.Location = new System.Drawing.Point(12, 776);
            this.llbShowLicenseHistory.Name = "llbShowLicenseHistory";
            this.llbShowLicenseHistory.Size = new System.Drawing.Size(143, 16);
            this.llbShowLicenseHistory.TabIndex = 6;
            this.llbShowLicenseHistory.TabStop = true;
            this.llbShowLicenseHistory.Text = "Show License Historey";
            this.llbShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbShowLicenseHistory_LinkClicked);
            // 
            // llbShowLicenseInfo
            // 
            this.llbShowLicenseInfo.AutoSize = true;
            this.llbShowLicenseInfo.Location = new System.Drawing.Point(194, 776);
            this.llbShowLicenseInfo.Name = "llbShowLicenseInfo";
            this.llbShowLicenseInfo.Size = new System.Drawing.Size(114, 16);
            this.llbShowLicenseInfo.TabIndex = 7;
            this.llbShowLicenseInfo.TabStop = true;
            this.llbShowLicenseInfo.Text = "Show License Info";
            // 
            // ctrlLocalDrivingLicenseInfo1
            // 
            this.ctrlLocalDrivingLicenseInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlLocalDrivingLicenseInfo1.Location = new System.Drawing.Point(13, 165);
            this.ctrlLocalDrivingLicenseInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlLocalDrivingLicenseInfo1.Name = "ctrlLocalDrivingLicenseInfo1";
            this.ctrlLocalDrivingLicenseInfo1.Size = new System.Drawing.Size(605, 385);
            this.ctrlLocalDrivingLicenseInfo1.TabIndex = 1;
            // 
            // fmIssueInternationalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 839);
            this.Controls.Add(this.llbShowLicenseInfo);
            this.Controls.Add(this.llbShowLicenseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlLocalDrivingLicenseInfo1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fmIssueInternationalLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Issue International Licnese";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ctrlLocalDrivingLicenseInfo ctrlLocalDrivingLicenseInfo1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPerson_LLN;
        private System.Windows.Forms.ComboBox cmFilterBY;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel llbShowLicenseHistory;
        private System.Windows.Forms.LinkLabel llbShowLicenseInfo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbIssueDate;
        private System.Windows.Forms.Label lbApplicationDate;
        private System.Windows.Forms.Label lbApplicationID;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbExpirationDate;
        private System.Windows.Forms.Label lbLLN;
        private System.Windows.Forms.Label lbILN;
        private System.Windows.Forms.Label lbFees;
    }
}