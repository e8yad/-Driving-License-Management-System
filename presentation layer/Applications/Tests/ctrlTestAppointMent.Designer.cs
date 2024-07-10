namespace DVLD.Applications
{
    partial class ctrlTestAppointment
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgAppointments = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsEditTestDate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlLocalDrivingLicenseApplicationInfo1 = new DVLD.Applications.ctrlLocalDrivingLicenseApplicationInfo();
            this.btnAddNewAppointment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAppointments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgAppointments);
            this.groupBox1.Location = new System.Drawing.Point(0, 538);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(807, 287);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Appointments";
            // 
            // dgAppointments
            // 
            this.dgAppointments.AllowUserToAddRows = false;
            this.dgAppointments.AllowUserToDeleteRows = false;
            this.dgAppointments.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAppointments.ContextMenuStrip = this.contextMenuStrip1;
            this.dgAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAppointments.GridColor = System.Drawing.SystemColors.Control;
            this.dgAppointments.Location = new System.Drawing.Point(4, 19);
            this.dgAppointments.Margin = new System.Windows.Forms.Padding(4);
            this.dgAppointments.Name = "dgAppointments";
            this.dgAppointments.ReadOnly = true;
            this.dgAppointments.RowHeadersWidth = 51;
            this.dgAppointments.Size = new System.Drawing.Size(799, 264);
            this.dgAppointments.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsEditTestDate,
            this.tsTakeTest});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 80);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // tsEditTestDate
            // 
            this.tsEditTestDate.Image = global::DVLD.Properties.Resources.UpdateTestDate32;
            this.tsEditTestDate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsEditTestDate.Name = "tsEditTestDate";
            this.tsEditTestDate.Size = new System.Drawing.Size(186, 38);
            this.tsEditTestDate.Text = "Edit Test Date";
            this.tsEditTestDate.Click += new System.EventHandler(this.tsEditTestDate_Click);
            // 
            // tsTakeTest
            // 
            this.tsTakeTest.Image = global::DVLD.Properties.Resources.pass32;
            this.tsTakeTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsTakeTest.Name = "tsTakeTest";
            this.tsTakeTest.Size = new System.Drawing.Size(186, 38);
            this.tsTakeTest.Text = "Take Test";
            this.tsTakeTest.Click += new System.EventHandler(this.tsTakeTest_Click);
            // 
            // ctrlLocalDrivingLicenseApplicationInfo1
            // 
            this.ctrlLocalDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(4, 4);
            this.ctrlLocalDrivingLicenseApplicationInfo1.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlLocalDrivingLicenseApplicationInfo1.Name = "ctrlLocalDrivingLicenseApplicationInfo1";
            this.ctrlLocalDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(803, 539);
            this.ctrlLocalDrivingLicenseApplicationInfo1.TabIndex = 0;
            // 
            // btnAddNewAppointment
            // 
            this.btnAddNewAppointment.Image = global::DVLD.Properties.Resources.AddTest32;
            this.btnAddNewAppointment.Location = new System.Drawing.Point(680, 481);
            this.btnAddNewAppointment.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNewAppointment.Name = "btnAddNewAppointment";
            this.btnAddNewAppointment.Size = new System.Drawing.Size(85, 62);
            this.btnAddNewAppointment.TabIndex = 2;
            this.btnAddNewAppointment.UseVisualStyleBackColor = true;
            this.btnAddNewAppointment.Click += new System.EventHandler(this.btnAddNewAppointment_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(386, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Trails";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(527, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // ctrlTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddNewAppointment);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlLocalDrivingLicenseApplicationInfo1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlTestAppointment";
            this.Size = new System.Drawing.Size(811, 828);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAppointments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlLocalDrivingLicenseApplicationInfo ctrlLocalDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgAppointments;
        private System.Windows.Forms.Button btnAddNewAppointment;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsEditTestDate;
        private System.Windows.Forms.ToolStripMenuItem tsTakeTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
