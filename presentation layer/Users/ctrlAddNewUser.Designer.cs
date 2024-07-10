namespace DVLD.Users
{
    partial class ctrlAddNewUser
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPersoninfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlFindPerson1 = new DVLD.Persons.ctrlFindPerson();
            this.tabUserInfo = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrlUpdate_AddUser1 = new DVLD.Users.ctrlUpdate_AddUser();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPersoninfo.SuspendLayout();
            this.tabUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPersoninfo);
            this.tabControl1.Controls.Add(this.tabUserInfo);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1228, 670);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPersoninfo
            // 
            this.tabPersoninfo.Controls.Add(this.btnNext);
            this.tabPersoninfo.Controls.Add(this.ctrlFindPerson1);
            this.tabPersoninfo.Location = new System.Drawing.Point(4, 29);
            this.tabPersoninfo.Margin = new System.Windows.Forms.Padding(4);
            this.tabPersoninfo.Name = "tabPersoninfo";
            this.tabPersoninfo.Padding = new System.Windows.Forms.Padding(4);
            this.tabPersoninfo.Size = new System.Drawing.Size(1220, 637);
            this.tabPersoninfo.TabIndex = 0;
            this.tabPersoninfo.Text = "PersonInfo";
            this.tabPersoninfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Image = global::DVLD.Properties.Resources.arrow_right;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(964, 562);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(121, 43);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "              Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlFindPerson1
            // 
            this.ctrlFindPerson1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlFindPerson1.Location = new System.Drawing.Point(87, 8);
            this.ctrlFindPerson1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlFindPerson1.Name = "ctrlFindPerson1";
            this.ctrlFindPerson1.Size = new System.Drawing.Size(1037, 597);
            this.ctrlFindPerson1.TabIndex = 3;
            // 
            // tabUserInfo
            // 
            this.tabUserInfo.Controls.Add(this.btnSave);
            this.tabUserInfo.Controls.Add(this.ctrlUpdate_AddUser1);
            this.tabUserInfo.Location = new System.Drawing.Point(4, 29);
            this.tabUserInfo.Margin = new System.Windows.Forms.Padding(4);
            this.tabUserInfo.Name = "tabUserInfo";
            this.tabUserInfo.Padding = new System.Windows.Forms.Padding(4);
            this.tabUserInfo.Size = new System.Drawing.Size(1220, 637);
            this.tabUserInfo.TabIndex = 1;
            this.tabUserInfo.Text = "UserInfo";
            this.tabUserInfo.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::DVLD.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(943, 442);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 43);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "              Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrlUpdate_AddUser1
            // 
            this.ctrlUpdate_AddUser1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlUpdate_AddUser1.Location = new System.Drawing.Point(94, 8);
            this.ctrlUpdate_AddUser1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlUpdate_AddUser1.Name = "ctrlUpdate_AddUser1";
            this.ctrlUpdate_AddUser1.Size = new System.Drawing.Size(1084, 528);
            this.ctrlUpdate_AddUser1.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlAddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlAddNewUser";
            this.Size = new System.Drawing.Size(1232, 674);
            this.tabControl1.ResumeLayout(false);
            this.tabPersoninfo.ResumeLayout(false);
            this.tabUserInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPersoninfo;
        private System.Windows.Forms.TabPage tabUserInfo;
        private System.Windows.Forms.Button btnNext;
        private ctrlUpdate_AddUser ctrlUpdate_AddUser1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Persons.ctrlFindPerson ctrlFindPerson1;
    }
}
