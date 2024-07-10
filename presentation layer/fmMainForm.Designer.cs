using System.Windows.Forms;

namespace DVLD
{
    partial class fmMainForm
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
            Application.Exit();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMainForm));
            this.mangePeoplePicList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewLocalDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueNewInternationalDrivingLiceseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRenewLocalDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsReplacementForDamage_Lost = new System.Windows.Forms.ToolStripMenuItem();
            this.detaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsManageDetainedLicenses = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDetainLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsReleaseDetainedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.manageLocalDrivingLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPeopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mangePeoplePicList
            // 
            this.mangePeoplePicList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mangePeoplePicList.ImageStream")));
            this.mangePeoplePicList.TransparentColor = System.Drawing.Color.Transparent;
            this.mangePeoplePicList.Images.SetKeyName(0, "copy.png");
            this.mangePeoplePicList.Images.SetKeyName(1, "AddPerson.png");
            this.mangePeoplePicList.Images.SetKeyName(2, "PersonInformation.png");
            this.mangePeoplePicList.Images.SetKeyName(3, "edit.png");
            this.mangePeoplePicList.Images.SetKeyName(4, "DeletePerson.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1152, 80);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationTypesToolStripMenuItem,
            this.testTypesToolStripMenuItem,
            this.testToolStripMenuItem,
            this.detaToolStripMenuItem,
            this.manageLocalDrivingLicensesToolStripMenuItem});
            this.applicationsToolStripMenuItem.Image = global::DVLD.Properties.Resources.Application;
            this.applicationsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(208, 76);
            this.applicationsToolStripMenuItem.Text = "Applications";
            // 
            // applicationTypesToolStripMenuItem
            // 
            this.applicationTypesToolStripMenuItem.Image = global::DVLD.Properties.Resources.Application;
            this.applicationTypesToolStripMenuItem.Name = "applicationTypesToolStripMenuItem";
            this.applicationTypesToolStripMenuItem.Size = new System.Drawing.Size(401, 38);
            this.applicationTypesToolStripMenuItem.Text = "ApplicationTypes";
            this.applicationTypesToolStripMenuItem.Click += new System.EventHandler(this.applicationTypesToolStripMenuItem_Click);
            // 
            // testTypesToolStripMenuItem
            // 
            this.testTypesToolStripMenuItem.Image = global::DVLD.Properties.Resources.test;
            this.testTypesToolStripMenuItem.Name = "testTypesToolStripMenuItem";
            this.testTypesToolStripMenuItem.Size = new System.Drawing.Size(401, 38);
            this.testTypesToolStripMenuItem.Text = "Test Types";
            this.testTypesToolStripMenuItem.Click += new System.EventHandler(this.testTypesToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewLocalDrivingLicenseToolStripMenuItem,
            this.issueNewInternationalDrivingLiceseToolStripMenuItem,
            this.tsRenewLocalDrivingLicense,
            this.tsReplacementForDamage_Lost});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(401, 38);
            this.testToolStripMenuItem.Text = "Applications";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // addNewLocalDrivingLicenseToolStripMenuItem
            // 
            this.addNewLocalDrivingLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.driving_licence64;
            this.addNewLocalDrivingLicenseToolStripMenuItem.Name = "addNewLocalDrivingLicenseToolStripMenuItem";
            this.addNewLocalDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(474, 38);
            this.addNewLocalDrivingLicenseToolStripMenuItem.Text = "Issue New Local Driving License";
            this.addNewLocalDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.addNewLocalDrivingLicenseToolStripMenuItem_Click);
            // 
            // issueNewInternationalDrivingLiceseToolStripMenuItem
            // 
            this.issueNewInternationalDrivingLiceseToolStripMenuItem.Image = global::DVLD.Properties.Resources.internationalLicese32;
            this.issueNewInternationalDrivingLiceseToolStripMenuItem.Name = "issueNewInternationalDrivingLiceseToolStripMenuItem";
            this.issueNewInternationalDrivingLiceseToolStripMenuItem.Size = new System.Drawing.Size(474, 38);
            this.issueNewInternationalDrivingLiceseToolStripMenuItem.Text = "Issue New International Driving Licese";
            this.issueNewInternationalDrivingLiceseToolStripMenuItem.Click += new System.EventHandler(this.issueNewInternationalDrivingLiceseToolStripMenuItem_Click);
            // 
            // tsRenewLocalDrivingLicense
            // 
            this.tsRenewLocalDrivingLicense.Image = global::DVLD.Properties.Resources.history64;
            this.tsRenewLocalDrivingLicense.Name = "tsRenewLocalDrivingLicense";
            this.tsRenewLocalDrivingLicense.Size = new System.Drawing.Size(474, 38);
            this.tsRenewLocalDrivingLicense.Text = "Renew Local Driving License";
            this.tsRenewLocalDrivingLicense.Click += new System.EventHandler(this.tsRenewLocalDrivingLicense_Click);
            // 
            // tsReplacementForDamage_Lost
            // 
            this.tsReplacementForDamage_Lost.Image = global::DVLD.Properties.Resources.Damage32;
            this.tsReplacementForDamage_Lost.Name = "tsReplacementForDamage_Lost";
            this.tsReplacementForDamage_Lost.Size = new System.Drawing.Size(474, 38);
            this.tsReplacementForDamage_Lost.Text = "Replacement For Damage Or Lost";
            this.tsReplacementForDamage_Lost.Click += new System.EventHandler(this.replacementForDamageOrLostToolStripMenuItem_Click);
            // 
            // detaToolStripMenuItem
            // 
            this.detaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsManageDetainedLicenses,
            this.tsDetainLicense,
            this.tsReleaseDetainedLicense});
            this.detaToolStripMenuItem.Image = global::DVLD.Properties.Resources.Detain_641;
            this.detaToolStripMenuItem.Name = "detaToolStripMenuItem";
            this.detaToolStripMenuItem.Size = new System.Drawing.Size(401, 38);
            this.detaToolStripMenuItem.Text = "Detain Licenses";
            // 
            // tsManageDetainedLicenses
            // 
            this.tsManageDetainedLicenses.Image = global::DVLD.Properties.Resources.Detain_641;
            this.tsManageDetainedLicenses.Name = "tsManageDetainedLicenses";
            this.tsManageDetainedLicenses.Size = new System.Drawing.Size(362, 38);
            this.tsManageDetainedLicenses.Text = "Manage Detained Licenses";
            this.tsManageDetainedLicenses.Click += new System.EventHandler(this.tsManageDetainedLicenses_Click);
            // 
            // tsDetainLicense
            // 
            this.tsDetainLicense.Image = global::DVLD.Properties.Resources.Detain_641;
            this.tsDetainLicense.Name = "tsDetainLicense";
            this.tsDetainLicense.Size = new System.Drawing.Size(362, 38);
            this.tsDetainLicense.Text = "Detain License";
            this.tsDetainLicense.Click += new System.EventHandler(this.tsDetainLicense_Click);
            // 
            // tsReleaseDetainedLicense
            // 
            this.tsReleaseDetainedLicense.Image = global::DVLD.Properties.Resources.Release_Detained_License_32;
            this.tsReleaseDetainedLicense.Name = "tsReleaseDetainedLicense";
            this.tsReleaseDetainedLicense.Size = new System.Drawing.Size(362, 38);
            this.tsReleaseDetainedLicense.Text = "Release Detained License";
            this.tsReleaseDetainedLicense.Click += new System.EventHandler(this.tsReleaseDetainedLicense_Click);
            // 
            // manageLocalDrivingLicensesToolStripMenuItem
            // 
            this.manageLocalDrivingLicensesToolStripMenuItem.Image = global::DVLD.Properties.Resources.contract_128;
            this.manageLocalDrivingLicensesToolStripMenuItem.Name = "manageLocalDrivingLicensesToolStripMenuItem";
            this.manageLocalDrivingLicensesToolStripMenuItem.Size = new System.Drawing.Size(401, 38);
            this.manageLocalDrivingLicensesToolStripMenuItem.Text = "Manage Local Driving Licenses";
            this.manageLocalDrivingLicensesToolStripMenuItem.Click += new System.EventHandler(this.manageLocalDrivingLicensesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.addNewPeopleToolStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Image = global::DVLD.Properties.Resources.People64;
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(156, 76);
            this.toolStripMenuItem1.Text = "People";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(257, 32);
            this.toolStripMenuItem7.Text = "Manage People";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // addNewPeopleToolStripMenuItem
            // 
            this.addNewPeopleToolStripMenuItem.Name = "addNewPeopleToolStripMenuItem";
            this.addNewPeopleToolStripMenuItem.Size = new System.Drawing.Size(257, 32);
            this.addNewPeopleToolStripMenuItem.Text = "Add New Person";
            this.addNewPeopleToolStripMenuItem.Click += new System.EventHandler(this.addNewPeopleToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.addNewUserToolStripMenuItem});
            this.toolStripMenuItem2.Image = global::DVLD.Properties.Resources.Users;
            this.toolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(155, 76);
            this.toolStripMenuItem2.Text = "Users ";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(233, 32);
            this.toolStripMenuItem6.Text = "Manage Users";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // addNewUserToolStripMenuItem
            // 
            this.addNewUserToolStripMenuItem.Name = "addNewUserToolStripMenuItem";
            this.addNewUserToolStripMenuItem.Size = new System.Drawing.Size(233, 32);
            this.addNewUserToolStripMenuItem.Text = "Add New User";
            this.addNewUserToolStripMenuItem.Click += new System.EventHandler(this.addNewUserToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.logOutToolStripMenuItem,
            this.currentUserInfoToolStripMenuItem});
            this.toolStripMenuItem3.Image = global::DVLD.Properties.Resources.currentUser;
            this.toolStripMenuItem3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(209, 76);
            this.toolStripMenuItem3.Text = "Current User";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(311, 32);
            this.toolStripMenuItem4.Text = "Change User Password";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(311, 32);
            this.toolStripMenuItem5.Text = "Update User";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(311, 32);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // currentUserInfoToolStripMenuItem
            // 
            this.currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            this.currentUserInfoToolStripMenuItem.Size = new System.Drawing.Size(311, 32);
            this.currentUserInfoToolStripMenuItem.Text = "Current User Info";
            this.currentUserInfoToolStripMenuItem.Click += new System.EventHandler(this.currentUserInfoToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::DVLD.Properties.Resources.images;
            this.pictureBox1.Location = new System.Drawing.Point(0, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1152, 687);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // fmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1152, 767);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList mangePeoplePicList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem addNewUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewPeopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewLocalDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageLocalDrivingLicensesToolStripMenuItem;
        private ToolStripMenuItem issueNewInternationalDrivingLiceseToolStripMenuItem;
        private ToolStripMenuItem tsRenewLocalDrivingLicense;
        private ToolStripMenuItem tsReplacementForDamage_Lost;
        private ToolStripMenuItem detaToolStripMenuItem;
        private ToolStripMenuItem tsManageDetainedLicenses;
        private ToolStripMenuItem tsDetainLicense;
        private ToolStripMenuItem tsReleaseDetainedLicense;
        private PictureBox pictureBox1;
    }
}