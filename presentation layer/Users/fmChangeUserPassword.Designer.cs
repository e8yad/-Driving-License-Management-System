namespace DVLD.Users
{
    partial class fmChangeUserPassword
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
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrlPersonInformation1 = new DVLD.ctrlPersonInformation();
            this.ctrlUpdate_AddUser1 = new DVLD.Users.ctrlUpdate_AddUser();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Image = global::DVLD.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(697, 648);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(161, 53);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "              Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrlPersonInformation1
            // 
            this.ctrlPersonInformation1.AutoSize = true;
            this.ctrlPersonInformation1.IsSuccessfullyLoad = false;
            this.ctrlPersonInformation1.Location = new System.Drawing.Point(-2, 30);
            this.ctrlPersonInformation1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlPersonInformation1.Name = "ctrlPersonInformation1";
            this.ctrlPersonInformation1.Size = new System.Drawing.Size(900, 387);
            this.ctrlPersonInformation1.TabIndex = 5;
            // 
            // ctrlUpdate_AddUser1
            // 
            this.ctrlUpdate_AddUser1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlUpdate_AddUser1.Location = new System.Drawing.Point(-2, 332);
            this.ctrlUpdate_AddUser1.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlUpdate_AddUser1.Name = "ctrlUpdate_AddUser1";
            this.ctrlUpdate_AddUser1.PersonID = ((long)(-1));
            this.ctrlUpdate_AddUser1.Size = new System.Drawing.Size(424, 390);
            this.ctrlUpdate_AddUser1.TabIndex = 0;
            // 
            // fmChangeUserPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 714);
            this.Controls.Add(this.ctrlPersonInformation1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctrlUpdate_AddUser1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "fmChangeUserPassword";
            this.Text = "Change User Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlUpdate_AddUser ctrlUpdate_AddUser1;
        private System.Windows.Forms.Button btnSave;
        private ctrlPersonInformation ctrlPersonInformation1;
    }
}