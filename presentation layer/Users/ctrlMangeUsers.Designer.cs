namespace DVLD.Users
{
    partial class ctrlMangeUsers
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
            this.dgUsers = new System.Windows.Forms.DataGridView();
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmActiveStatus = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeUserPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgUsers
            // 
            this.dgUsers.AllowUserToAddRows = false;
            this.dgUsers.AllowUserToDeleteRows = false;
            this.dgUsers.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUsers.ContextMenuStrip = this.contextMenuStrip1;
            this.dgUsers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgUsers.Location = new System.Drawing.Point(0, 185);
            this.dgUsers.Margin = new System.Windows.Forms.Padding(4);
            this.dgUsers.Name = "dgUsers";
            this.dgUsers.ReadOnly = true;
            this.dgUsers.RowHeadersWidth = 51;
            this.dgUsers.Size = new System.Drawing.Size(1071, 354);
            this.dgUsers.TabIndex = 0;
            // 
            // cmbFilterBy
            // 
            this.cmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterBy.FormattingEnabled = true;
            this.cmbFilterBy.Items.AddRange(new object[] {
            "None",
            "UserID",
            "PersonID",
            "Username",
            "Active"});
            this.cmbFilterBy.Location = new System.Drawing.Point(167, 65);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(161, 24);
            this.cmbFilterBy.TabIndex = 1;
            this.cmbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmbFilterBy_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(360, 67);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(150, 22);
            this.txtFilterValue.TabIndex = 2;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilterValue_KeyDown);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Filter By:";
            // 
            // cmActiveStatus
            // 
            this.cmActiveStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmActiveStatus.FormattingEnabled = true;
            this.cmActiveStatus.Items.AddRange(new object[] {
            "Not Active",
            "Active"});
            this.cmActiveStatus.Location = new System.Drawing.Point(360, 67);
            this.cmActiveStatus.Name = "cmActiveStatus";
            this.cmActiveStatus.Size = new System.Drawing.Size(150, 24);
            this.cmActiveStatus.TabIndex = 4;
            this.cmActiveStatus.SelectedIndexChanged += new System.EventHandler(this.cmActiveStatus_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.addNewToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.changeUserPasswordToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(195, 114);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPerson.Image = global::DVLD.Properties.Resources.AddPerson;
            this.btnAddPerson.Location = new System.Drawing.Point(927, 65);
            this.btnAddPerson.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(50, 42);
            this.btnAddPerson.TabIndex = 6;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::DVLD.Properties.Resources.copy;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit;
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Image = global::DVLD.Properties.Resources.add;
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.addNewToolStripMenuItem.Text = "Add New  User";
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.addNewToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::DVLD.Properties.Resources.delete2;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.deleteToolStripMenuItem.Text = "Delete User";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // changeUserPasswordToolStripMenuItem
            // 
            this.changeUserPasswordToolStripMenuItem.Image = global::DVLD.Properties.Resources.password;
            this.changeUserPasswordToolStripMenuItem.Name = "changeUserPasswordToolStripMenuItem";
            this.changeUserPasswordToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.changeUserPasswordToolStripMenuItem.Text = "Change User Password";
            this.changeUserPasswordToolStripMenuItem.Click += new System.EventHandler(this.changeUserPasswordToolStripMenuItem_Click);
            // 
            // ctrlMangeUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.cmActiveStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cmbFilterBy);
            this.Controls.Add(this.dgUsers);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlMangeUsers";
            this.Size = new System.Drawing.Size(1071, 539);
            ((System.ComponentModel.ISupportInitialize)(this.dgUsers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgUsers;
        private System.Windows.Forms.ComboBox cmbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmActiveStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.ToolStripMenuItem changeUserPasswordToolStripMenuItem;
    }
}
