using System;
using System.IO;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class ctrlUpdatePerson_UserInformation : UserControl
    {
        public ctrlUpdatePerson_UserInformation()
        {
            InitializeComponent();
            

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

        }
        public void LoadForms(long PersonID,long UserID)
        {
            ctrlUpdate_AddPerson1.UpdatePerson(PersonID);
            //ctrlAdd_UpdateUserInformation1.lbPersonID.Text = PersonID.ToString();
            ctrlAdd_UpdateUserInformation1.LoadUserInformation(UserID);
        }
        public void save()
        {
            ctrlUpdate_AddPerson1.Save();
            ctrlAdd_UpdateUserInformation1.Save();
        }

        private void ctrlAdd_UpdateUserInformation1_SaveResult(bool result, long UserID)
        {
           if(!result) { MessageBox.Show("Save Error!"); }
           else
                MessageBox.Show("Saved successfully");

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void ctrlUpdate_AddPerson1_onSaveFinished(bool result, long NatioinalID, string OldImagePath)
        {
            if(result==false)
            { MessageBox.Show("Save Error!"); }
            if(OldImagePath!=null)
                File.Delete(OldImagePath);

        }
    }
}
