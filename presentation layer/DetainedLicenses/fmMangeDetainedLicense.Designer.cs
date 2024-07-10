namespace DVLD.DetainedLicenses
{
    partial class fmMangeDetainedLicense
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgManageDetainedLicenses = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsReleaseLicesne = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilterBY = new System.Windows.Forms.TextBox();
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnDetain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgManageDetainedLicenses)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(304, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Detained Licenses";
            // 
            // dgManageDetainedLicenses
            // 
            this.dgManageDetainedLicenses.AllowUserToAddRows = false;
            this.dgManageDetainedLicenses.AllowUserToDeleteRows = false;
            this.dgManageDetainedLicenses.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgManageDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgManageDetainedLicenses.ContextMenuStrip = this.contextMenuStrip1;
            this.dgManageDetainedLicenses.Location = new System.Drawing.Point(3, 196);
            this.dgManageDetainedLicenses.Name = "dgManageDetainedLicenses";
            this.dgManageDetainedLicenses.ReadOnly = true;
            this.dgManageDetainedLicenses.RowHeadersWidth = 51;
            this.dgManageDetainedLicenses.Size = new System.Drawing.Size(975, 359);
            this.dgManageDetainedLicenses.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsShowLicense,
            this.tsReleaseLicesne});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(227, 108);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // tsShowLicense
            // 
            this.tsShowLicense.Image = global::DVLD.Properties.Resources.driving_license_Global_32;
            this.tsShowLicense.Name = "tsShowLicense";
            this.tsShowLicense.Size = new System.Drawing.Size(226, 38);
            this.tsShowLicense.Text = "Show License Info";
            this.tsShowLicense.Click += new System.EventHandler(this.tsShowLicense_Click);
            // 
            // tsReleaseLicesne
            // 
            this.tsReleaseLicesne.Image = global::DVLD.Properties.Resources.Release_Detained_License_32;
            this.tsReleaseLicesne.Name = "tsReleaseLicesne";
            this.tsReleaseLicesne.Size = new System.Drawing.Size(226, 38);
            this.tsReleaseLicesne.Text = "Release License";
            this.tsReleaseLicesne.Click += new System.EventHandler(this.tsReleaseLicesne_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter By License Number:";
            // 
            // txtFilterBY
            // 
            this.txtFilterBY.Location = new System.Drawing.Point(199, 161);
            this.txtFilterBY.MaxLength = 12;
            this.txtFilterBY.Name = "txtFilterBY";
            this.txtFilterBY.Size = new System.Drawing.Size(79, 26);
            this.txtFilterBY.TabIndex = 3;
            this.txtFilterBY.TextChanged += new System.EventHandler(this.txtFilterBY_TextChanged);
            this.txtFilterBY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterBY_KeyPress);
            // 
            // btnRelease
            // 
            this.btnRelease.Image = global::DVLD.Properties.Resources.Release_Detained_License_64;
            this.btnRelease.Location = new System.Drawing.Point(882, 126);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(64, 64);
            this.btnRelease.TabIndex = 5;
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // btnDetain
            // 
            this.btnDetain.Image = global::DVLD.Properties.Resources.Detain_64;
            this.btnDetain.Location = new System.Drawing.Point(796, 126);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(64, 64);
            this.btnDetain.TabIndex = 4;
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // fmMangeDetainedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 553);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.txtFilterBY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgManageDetainedLicenses);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fmMangeDetainedLicense";
            this.Text = "fmMangeDetainedLicense";
            ((System.ComponentModel.ISupportInitialize)(this.dgManageDetainedLicenses)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgManageDetainedLicenses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilterBY;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsShowLicense;
        private System.Windows.Forms.ToolStripMenuItem tsReleaseLicesne;
    }
}