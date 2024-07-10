namespace DVLD.Applications
{
    partial class fmDrivingLicenseHistory
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
            this.ctrlPersonInformation1 = new DVLD.ctrlPersonInformation();
            this.tabIDL = new System.Windows.Forms.TabControl();
            this.tabLDL = new System.Windows.Forms.TabPage();
            this.dgLDL = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgIDL = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tabIDL.SuspendLayout();
            this.tabLDL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLDL)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgIDL)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlPersonInformation1
            // 
            this.ctrlPersonInformation1.IsSuccessfullyLoad = false;
            this.ctrlPersonInformation1.Location = new System.Drawing.Point(0, 89);
            this.ctrlPersonInformation1.Name = "ctrlPersonInformation1";
            this.ctrlPersonInformation1.Size = new System.Drawing.Size(696, 335);
            this.ctrlPersonInformation1.TabIndex = 0;
            // 
            // tabIDL
            // 
            this.tabIDL.Controls.Add(this.tabLDL);
            this.tabIDL.Controls.Add(this.tabPage2);
            this.tabIDL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabIDL.Location = new System.Drawing.Point(0, 430);
            this.tabIDL.Name = "tabIDL";
            this.tabIDL.SelectedIndex = 0;
            this.tabIDL.Size = new System.Drawing.Size(696, 308);
            this.tabIDL.TabIndex = 1;
            // 
            // tabLDL
            // 
            this.tabLDL.Controls.Add(this.dgLDL);
            this.tabLDL.Location = new System.Drawing.Point(4, 22);
            this.tabLDL.Name = "tabLDL";
            this.tabLDL.Padding = new System.Windows.Forms.Padding(3);
            this.tabLDL.Size = new System.Drawing.Size(688, 282);
            this.tabLDL.TabIndex = 0;
            this.tabLDL.Text = "Local Driving License";
            this.tabLDL.UseVisualStyleBackColor = true;
            // 
            // dgLDL
            // 
            this.dgLDL.AllowUserToAddRows = false;
            this.dgLDL.AllowUserToDeleteRows = false;
            this.dgLDL.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgLDL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLDL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgLDL.Location = new System.Drawing.Point(3, 3);
            this.dgLDL.Name = "dgLDL";
            this.dgLDL.ReadOnly = true;
            this.dgLDL.Size = new System.Drawing.Size(682, 276);
            this.dgLDL.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgIDL);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(688, 282);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Internatinal Driving License";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgIDL
            // 
            this.dgIDL.AllowUserToAddRows = false;
            this.dgIDL.AllowUserToDeleteRows = false;
            this.dgIDL.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgIDL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgIDL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgIDL.Location = new System.Drawing.Point(3, 3);
            this.dgIDL.Name = "dgIDL";
            this.dgIDL.ReadOnly = true;
            this.dgIDL.Size = new System.Drawing.Size(682, 276);
            this.dgIDL.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(174, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Driving License History";
            // 
            // fmDrivingLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 738);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabIDL);
            this.Controls.Add(this.ctrlPersonInformation1);
            this.Name = "fmDrivingLicenseHistory";
            this.Text = "Driving Licese History";
            this.tabIDL.ResumeLayout(false);
            this.tabLDL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgLDL)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgIDL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlPersonInformation ctrlPersonInformation1;
        private System.Windows.Forms.TabControl tabIDL;
        private System.Windows.Forms.TabPage tabLDL;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgLDL;
        private System.Windows.Forms.DataGridView dgIDL;
        private System.Windows.Forms.Label label1;
    }
}