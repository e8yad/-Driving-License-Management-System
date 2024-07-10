namespace DVLD.Users
{
    partial class ctrlUpdatePerson_UserInformation
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPersonInformation = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlUpdate_AddPerson1 = new DVLD.Persons.ctrlUpdate_AddPerson();
            this.tabUserInformation = new System.Windows.Forms.TabPage();
            this.ctrlAdd_UpdateUserInformation1 = new DVLD.Users.ctrlUpdate_AddUser();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPersonInformation.SuspendLayout();
            this.tabUserInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPersonInformation);
            this.tabControl1.Controls.Add(this.tabUserInformation);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(978, 504);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPersonInformation
            // 
            this.tabPersonInformation.Controls.Add(this.btnNext);
            this.tabPersonInformation.Controls.Add(this.ctrlUpdate_AddPerson1);
            this.tabPersonInformation.Location = new System.Drawing.Point(4, 22);
            this.tabPersonInformation.Name = "tabPersonInformation";
            this.tabPersonInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersonInformation.Size = new System.Drawing.Size(970, 478);
            this.tabPersonInformation.TabIndex = 0;
            this.tabPersonInformation.Text = "Update Person";
            this.tabPersonInformation.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(776, 440);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(110, 32);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlUpdate_AddPerson1
            // 
            this.ctrlUpdate_AddPerson1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlUpdate_AddPerson1.Location = new System.Drawing.Point(47, 8);
            this.ctrlUpdate_AddPerson1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlUpdate_AddPerson1.Name = "ctrlUpdate_AddPerson1";
            this.ctrlUpdate_AddPerson1.Size = new System.Drawing.Size(839, 424);
            this.ctrlUpdate_AddPerson1.TabIndex = 0;
            this.ctrlUpdate_AddPerson1.onSaveFinished += new DVLD.Persons.ctrlUpdate_AddPerson.SaveFinished(this.ctrlUpdate_AddPerson1_onSaveFinished);
            // 
            // tabUserInformation
            // 
            this.tabUserInformation.Controls.Add(this.btnSave);
            this.tabUserInformation.Controls.Add(this.ctrlAdd_UpdateUserInformation1);
            this.tabUserInformation.Location = new System.Drawing.Point(4, 22);
            this.tabUserInformation.Name = "tabUserInformation";
            this.tabUserInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserInformation.Size = new System.Drawing.Size(970, 478);
            this.tabUserInformation.TabIndex = 1;
            this.tabUserInformation.Text = "Update User";
            this.tabUserInformation.UseVisualStyleBackColor = true;
            // 
            // ctrlAdd_UpdateUserInformation1
            // 
            this.ctrlAdd_UpdateUserInformation1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAdd_UpdateUserInformation1.Location = new System.Drawing.Point(54, 51);
            this.ctrlAdd_UpdateUserInformation1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlAdd_UpdateUserInformation1.Name = "ctrlAdd_UpdateUserInformation1";
            this.ctrlAdd_UpdateUserInformation1.Size = new System.Drawing.Size(821, 356);
            this.ctrlAdd_UpdateUserInformation1.TabIndex = 0;
            this.ctrlAdd_UpdateUserInformation1.SaveResult += new DVLD.Users.ctrlUpdate_AddUser.OnSaveFinish(this.ctrlAdd_UpdateUserInformation1_SaveResult);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::DVLD.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(754, 364);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 43);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "              Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrlUpdatePerson_UserInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ctrlUpdatePerson_UserInformation";
            this.Size = new System.Drawing.Size(978, 504);
            this.tabControl1.ResumeLayout(false);
            this.tabPersonInformation.ResumeLayout(false);
            this.tabUserInformation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPersonInformation;
        private Persons.ctrlUpdate_AddPerson ctrlUpdate_AddPerson1;
        private System.Windows.Forms.TabPage tabUserInformation;
        private ctrlUpdate_AddUser ctrlAdd_UpdateUserInformation1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSave;
    }
}
