namespace DVLD.Applications
{
    partial class fmManageLocalDrivingLicense
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
            this.components = new System.ComponentModel.Container();
            this.dgLocalDrivingLicenses = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.cmLicenseClasses = new System.Windows.Forms.ComboBox();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tsApplicationDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsScheduleTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsVision = new System.Windows.Forms.ToolStripMenuItem();
            this.tsWritten = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPractical = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsIssueLocalDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsShowLicenseInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsShowLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgLocalDrivingLicenses)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgLocalDrivingLicenses
            // 
            this.dgLocalDrivingLicenses.AllowUserToAddRows = false;
            this.dgLocalDrivingLicenses.AllowUserToDeleteRows = false;
            this.dgLocalDrivingLicenses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgLocalDrivingLicenses.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgLocalDrivingLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLocalDrivingLicenses.ContextMenuStrip = this.contextMenuStrip1;
            this.dgLocalDrivingLicenses.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgLocalDrivingLicenses.Location = new System.Drawing.Point(0, 207);
            this.dgLocalDrivingLicenses.Margin = new System.Windows.Forms.Padding(4);
            this.dgLocalDrivingLicenses.Name = "dgLocalDrivingLicenses";
            this.dgLocalDrivingLicenses.ReadOnly = true;
            this.dgLocalDrivingLicenses.Size = new System.Drawing.Size(1041, 394);
            this.dgLocalDrivingLicenses.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsApplicationDetails,
            this.tsScheduleTest,
            this.tsDeleteApplication,
            this.tsCancel,
            this.tsIssueLocalDrivingLicense,
            this.tsShowLicenseInfo,
            this.tsShowLicenseHistory});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(234, 270);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(245, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Local Driving Licenses";
            // 
            // cmFilterBy
            // 
            this.cmFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmFilterBy.FormattingEnabled = true;
            this.cmFilterBy.Items.AddRange(new object[] {
            "None",
            "NationalID",
            "ApplicationID",
            "Class"});
            this.cmFilterBy.Location = new System.Drawing.Point(119, 154);
            this.cmFilterBy.Name = "cmFilterBy";
            this.cmFilterBy.Size = new System.Drawing.Size(124, 24);
            this.cmFilterBy.TabIndex = 4;
            this.cmFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filter By";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(277, 154);
            this.txtInput.MaxLength = 12;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(156, 22);
            this.txtInput.TabIndex = 6;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            this.txtInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInput_KeyPress);
            // 
            // cmLicenseClasses
            // 
            this.cmLicenseClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmLicenseClasses.FormattingEnabled = true;
            this.cmLicenseClasses.Location = new System.Drawing.Point(277, 154);
            this.cmLicenseClasses.Name = "cmLicenseClasses";
            this.cmLicenseClasses.Size = new System.Drawing.Size(192, 24);
            this.cmLicenseClasses.TabIndex = 7;
            this.cmLicenseClasses.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddNew.Image = global::DVLD.Properties.Resources.driving_licence64;
            this.btnAddNew.Location = new System.Drawing.Point(949, 136);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(64, 64);
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::DVLD.Properties.Resources.contract_128;
            this.pictureBox1.Location = new System.Drawing.Point(523, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(518, 207);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // tsApplicationDetails
            // 
            this.tsApplicationDetails.Image = global::DVLD.Properties.Resources.ApplicationDetails32;
            this.tsApplicationDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsApplicationDetails.Name = "tsApplicationDetails";
            this.tsApplicationDetails.Size = new System.Drawing.Size(233, 38);
            this.tsApplicationDetails.Text = "Show Application Details";
            this.tsApplicationDetails.Click += new System.EventHandler(this.tsApplicationDetails_Click);
            // 
            // tsScheduleTest
            // 
            this.tsScheduleTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsVision,
            this.tsWritten,
            this.tsPractical});
            this.tsScheduleTest.Image = global::DVLD.Properties.Resources.scheduleTest32;
            this.tsScheduleTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsScheduleTest.Name = "tsScheduleTest";
            this.tsScheduleTest.Size = new System.Drawing.Size(233, 38);
            this.tsScheduleTest.Text = "schedule Test";
            // 
            // tsVision
            // 
            this.tsVision.Image = global::DVLD.Properties.Resources.visionTest32;
            this.tsVision.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsVision.Name = "tsVision";
            this.tsVision.Size = new System.Drawing.Size(158, 38);
            this.tsVision.Text = "Vision Test";
            this.tsVision.Click += new System.EventHandler(this.tsVision_Click);
            // 
            // tsWritten
            // 
            this.tsWritten.Image = global::DVLD.Properties.Resources.written_test_32;
            this.tsWritten.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsWritten.Name = "tsWritten";
            this.tsWritten.Size = new System.Drawing.Size(158, 38);
            this.tsWritten.Text = "Written Test";
            this.tsWritten.Click += new System.EventHandler(this.tsWritten_Click);
            // 
            // tsPractical
            // 
            this.tsPractical.Image = global::DVLD.Properties.Resources.PracticalTest32;
            this.tsPractical.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsPractical.Name = "tsPractical";
            this.tsPractical.Size = new System.Drawing.Size(158, 38);
            this.tsPractical.Text = "Practical Test";
            this.tsPractical.Click += new System.EventHandler(this.tsPractical_Click);
            // 
            // tsDeleteApplication
            // 
            this.tsDeleteApplication.Image = global::DVLD.Properties.Resources.deleteApplication32;
            this.tsDeleteApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsDeleteApplication.Name = "tsDeleteApplication";
            this.tsDeleteApplication.Size = new System.Drawing.Size(233, 38);
            this.tsDeleteApplication.Text = "Delete Application";
            this.tsDeleteApplication.Click += new System.EventHandler(this.tsDeleteApplication_Click);
            // 
            // tsCancel
            // 
            this.tsCancel.Image = global::DVLD.Properties.Resources.cancel32;
            this.tsCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsCancel.Name = "tsCancel";
            this.tsCancel.Size = new System.Drawing.Size(233, 38);
            this.tsCancel.Text = "Cancel Application";
            this.tsCancel.Click += new System.EventHandler(this.tsCancel_Click);
            // 
            // tsIssueLocalDrivingLicense
            // 
            this.tsIssueLocalDrivingLicense.Image = global::DVLD.Properties.Resources.driving_school_IssueLocalDrivingLicense;
            this.tsIssueLocalDrivingLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsIssueLocalDrivingLicense.Name = "tsIssueLocalDrivingLicense";
            this.tsIssueLocalDrivingLicense.Size = new System.Drawing.Size(233, 38);
            this.tsIssueLocalDrivingLicense.Text = "Issue Local  Driving License";
            this.tsIssueLocalDrivingLicense.Click += new System.EventHandler(this.tsIssueLocalDrivingLicense_Click);
            // 
            // tsShowLicenseInfo
            // 
            this.tsShowLicenseInfo.Image = global::DVLD.Properties.Resources.driving_license_Global_32;
            this.tsShowLicenseInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsShowLicenseInfo.Name = "tsShowLicenseInfo";
            this.tsShowLicenseInfo.Size = new System.Drawing.Size(233, 38);
            this.tsShowLicenseInfo.Text = "Show License Info";
            this.tsShowLicenseInfo.Click += new System.EventHandler(this.tsShowLicenseInfo_Click);
            // 
            // tsShowLicenseHistory
            // 
            this.tsShowLicenseHistory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsShowLicenseHistory.Image = global::DVLD.Properties.Resources.history64;
            this.tsShowLicenseHistory.Name = "tsShowLicenseHistory";
            this.tsShowLicenseHistory.Size = new System.Drawing.Size(233, 38);
            this.tsShowLicenseHistory.Text = "Show License History";
            this.tsShowLicenseHistory.Click += new System.EventHandler(this.showLicenseHistoryToolStripMenuItem_Click);
            // 
            // fmManageLocalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 601);
            this.Controls.Add(this.cmLicenseClasses);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmFilterBy);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgLocalDrivingLicenses);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fmManageLocalDrivingLicense";
            this.Text = "fmManageLocalDrivingLicense";
            ((System.ComponentModel.ISupportInitialize)(this.dgLocalDrivingLicenses)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgLocalDrivingLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.ComboBox cmFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.ComboBox cmLicenseClasses;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsScheduleTest;
        private System.Windows.Forms.ToolStripMenuItem tsVision;
        private System.Windows.Forms.ToolStripMenuItem tsWritten;
        private System.Windows.Forms.ToolStripMenuItem tsPractical;
        private System.Windows.Forms.ToolStripMenuItem tsApplicationDetails;
        private System.Windows.Forms.ToolStripMenuItem tsDeleteApplication;
        private System.Windows.Forms.ToolStripMenuItem tsCancel;
        private System.Windows.Forms.ToolStripMenuItem tsIssueLocalDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem tsShowLicenseInfo;
        private System.Windows.Forms.ToolStripMenuItem tsShowLicenseHistory;
    }
}