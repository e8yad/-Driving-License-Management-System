using System;
using System.Windows.Forms;
using UserControl = System.Windows.Forms.UserControl;
using BusinessLayer;
namespace DVLD.Users
{
    public partial class ctrlAddNewUser : UserControl
    {
        private bool IsFoundPerson=false;
        private long PersonID = default;
       private long NationalID=default;
        public ctrlAddNewUser()
        {
            InitializeComponent();
            ctrlFindPerson1.OnFindPerson += AfterFindPerson;
            btnNext.Enabled= false;
        }
        private void AfterFindPerson(bool result ,long NationalID, long PersonID)
        {
            btnNext.Enabled = result;
            if (!result)
            {
                IsFoundPerson = false;
                this.PersonID = default;
                this.NationalID=default;
                return;
            }
            IsFoundPerson=true;
            this.PersonID = PersonID;
            this.NationalID = NationalID;
            ctrlFindPerson1.OnFindPerson -= AfterFindPerson;

        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            //if(txtInput.Text==string.Empty)
            //{ errorProvider1.SetError(txtInput, "National LDLApplicationID Can Not Be Empty");return; }
            ctrlUpdate_AddUser1.PersonID =PersonID;
            //btnSave.Enabled = clsPerson.IsPersonExist(NationalID); 

            // you saved connection with data base and fast you program 
            btnSave.Enabled =(ctrlFindPerson1.SelectedPerson!=null); 
            tabControl1.SelectedIndex = 1;
          

        }
        private void _AddNewUser()
        {
            ctrlUpdate_AddUser1.SaveResult += SaveResult;
            ctrlUpdate_AddUser1.Save();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _AddNewUser();
        }

      

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                return;
            if (!IsFoundPerson)
            { tabControl1.SelectedIndex = 0; MessageBox.Show("You Must Enter Correct NationalID");  return; }

            btnSave.Enabled = clsPerson.IsPersonExist(NationalID);
        }


        private void SaveResult(bool Result,long UserID)
        {
            if (!Result&& UserID==-111) 
            {
                MessageBox.Show("user Name Is Olready Exists");
                return;
            }
            if (Result)
                MessageBox.Show("User Added Successfully");
            else
            {
                MessageBox.Show("Check NationalID");
            }
            ctrlUpdate_AddUser1.SaveResult -= SaveResult;
        }
    }
}
