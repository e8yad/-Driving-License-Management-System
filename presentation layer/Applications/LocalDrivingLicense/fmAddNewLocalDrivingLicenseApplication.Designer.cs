namespace DVLD.Applications
{
    partial class fmAddNewLocalDrivingLicenseApplication
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPersoninfo = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabApplicationInfo = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbTotalFees = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbClassFees = new System.Windows.Forms.Label();
            this.cmbLicenseClass = new System.Windows.Forms.ComboBox();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbApplicationID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrlFindPerson1 = new DVLD.Persons.ctrlFindPerson();
            this.tabControl1.SuspendLayout();
            this.tabPersoninfo.SuspendLayout();
            this.tabApplicationInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPersoninfo);
            this.tabControl1.Controls.Add(this.tabApplicationInfo);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1012, 540);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPersoninfo
            // 
            this.tabPersoninfo.Controls.Add(this.button1);
            this.tabPersoninfo.Controls.Add(this.btnNext);
            this.tabPersoninfo.Controls.Add(this.ctrlFindPerson1);
            this.tabPersoninfo.Location = new System.Drawing.Point(4, 29);
            this.tabPersoninfo.Margin = new System.Windows.Forms.Padding(4);
            this.tabPersoninfo.Name = "tabPersoninfo";
            this.tabPersoninfo.Padding = new System.Windows.Forms.Padding(4);
            this.tabPersoninfo.Size = new System.Drawing.Size(1004, 507);
            this.tabPersoninfo.TabIndex = 0;
            this.tabPersoninfo.Text = "PersonInfo";
            this.tabPersoninfo.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = global::DVLD.Properties.Resources.close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(641, 456);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 43);
            this.button1.TabIndex = 11;
            this.button1.Text = "              Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = global::DVLD.Properties.Resources.arrow_right;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(820, 456);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(121, 43);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "              Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tabApplicationInfo
            // 
            this.tabApplicationInfo.Controls.Add(this.btnClose);
            this.tabApplicationInfo.Controls.Add(this.groupBox1);
            this.tabApplicationInfo.Controls.Add(this.btnSave);
            this.tabApplicationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabApplicationInfo.Location = new System.Drawing.Point(4, 29);
            this.tabApplicationInfo.Margin = new System.Windows.Forms.Padding(4);
            this.tabApplicationInfo.Name = "tabApplicationInfo";
            this.tabApplicationInfo.Padding = new System.Windows.Forms.Padding(4);
            this.tabApplicationInfo.Size = new System.Drawing.Size(1004, 507);
            this.tabApplicationInfo.TabIndex = 1;
            this.tabApplicationInfo.Text = "ApplicationInfo";
            this.tabApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD.Properties.Resources.close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(692, 444);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 43);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "              Exit";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbTotalFees);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lbUserName);
            this.groupBox1.Controls.Add(this.lbClassFees);
            this.groupBox1.Controls.Add(this.cmbLicenseClass);
            this.groupBox1.Controls.Add(this.lbDate);
            this.groupBox1.Controls.Add(this.lbApplicationID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(806, 375);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Info";
            // 
            // lbTotalFees
            // 
            this.lbTotalFees.AutoSize = true;
            this.lbTotalFees.Location = new System.Drawing.Point(237, 254);
            this.lbTotalFees.Name = "lbTotalFees";
            this.lbTotalFees.Size = new System.Drawing.Size(88, 20);
            this.lbTotalFees.TabIndex = 15;
            this.lbTotalFees.Text = "Total Fees";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Total Application Fees:";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(231, 309);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(53, 20);
            this.lbUserName.TabIndex = 13;
            this.lbUserName.Text = "label6";
            // 
            // lbClassFees
            // 
            this.lbClassFees.AutoSize = true;
            this.lbClassFees.Location = new System.Drawing.Point(234, 195);
            this.lbClassFees.Name = "lbClassFees";
            this.lbClassFees.Size = new System.Drawing.Size(53, 20);
            this.lbClassFees.TabIndex = 12;
            this.lbClassFees.Text = "label6";
            // 
            // cmbLicenseClass
            // 
            this.cmbLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLicenseClass.FormattingEnabled = true;
            this.cmbLicenseClass.Location = new System.Drawing.Point(234, 140);
            this.cmbLicenseClass.Name = "cmbLicenseClass";
            this.cmbLicenseClass.Size = new System.Drawing.Size(175, 28);
            this.cmbLicenseClass.TabIndex = 11;
            this.cmbLicenseClass.SelectedIndexChanged += new System.EventHandler(this.cmbLicenseClass_SelectedIndexChanged);
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Location = new System.Drawing.Point(231, 85);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(75, 20);
            this.lbDate.TabIndex = 10;
            this.lbDate.Text = "- - - - - - ";
            // 
            // lbApplicationID
            // 
            this.lbApplicationID.AutoSize = true;
            this.lbApplicationID.Location = new System.Drawing.Point(231, 30);
            this.lbApplicationID.Name = "lbApplicationID";
            this.lbApplicationID.Size = new System.Drawing.Size(75, 20);
            this.lbApplicationID.TabIndex = 9;
            this.lbApplicationID.Text = "- - - - - - ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "D.LApplicaionID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "License Class";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "ApplicationDate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "License Class Fees:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Created By:";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::DVLD.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(838, 444);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 43);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "         Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrlFindPerson1
            // 
            this.ctrlFindPerson1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlFindPerson1.Location = new System.Drawing.Point(9, 17);
            this.ctrlFindPerson1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlFindPerson1.Name = "ctrlFindPerson1";
            this.ctrlFindPerson1.Size = new System.Drawing.Size(988, 432);
            this.ctrlFindPerson1.TabIndex = 3;
            // 
            // fmAddNewLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 540);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fmAddNewLocalDrivingLicenseApplication";
            this.Text = "Add New Local Driving License";
            this.tabControl1.ResumeLayout(false);
            this.tabPersoninfo.ResumeLayout(false);
            this.tabApplicationInfo.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPersoninfo;
        private Persons.ctrlFindPerson ctrlFindPerson1;
        private System.Windows.Forms.TabPage tabApplicationInfo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbClassFees;
        private System.Windows.Forms.ComboBox cmbLicenseClass;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lbApplicationID;
        private System.Windows.Forms.Label lbTotalFees;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
    }
}