using System;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class fmChangeUserPassword : Form
    {
  
        public fmChangeUserPassword(long UserID)
        {
            InitializeComponent();

             ctrlUpdate_AddUser1.LoadUserInformation(UserID);
            ctrlPersonInformation1.LoadPersonByPersonID(ctrlUpdate_AddUser1.PersonID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ctrlUpdate_AddUser1.SaveResult += SaveFinished;
            ctrlUpdate_AddUser1.Save();
           
        }
        private void SaveFinished(bool Result ,long UserID)
        {
            if(Result)
            {
                MessageBox.Show($"user:{UserID} his password changed successfully");
            }
            else
            {
                MessageBox.Show($"Error in Change Password!");
            }
            ctrlUpdate_AddUser1.SaveResult -= SaveFinished;
        }

    }
}
