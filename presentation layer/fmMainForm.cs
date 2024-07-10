using DVLD.Applications;
using DVLD.Applications.ApplicationTypes;
using DVLD.Applications.InternationalApplications;
using DVLD.DetainedLicenses;
using DVLD.Persons;
using DVLD.Tests;
using DVLD.Users;
using System;
using System.Windows.Forms;
using BusinessLayer;
using Users;

namespace DVLD
{

    public partial class fmMainForm : Form
    {
        public delegate void AfterLogOutDelegate();
        public AfterLogOutDelegate AfterLogOut;

        public fmMainForm()
        {
            InitializeComponent();
        }
        private void OnClick(object sender)
        {
            //((Form)sender).MdiParent = this;
            ((Form)sender).MinimizeBox = false;
            ((Form)sender).MaximizeBox = false;
            ((Form)sender).AutoSize = true;
            ((Form)sender).ShowDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            OnClick(new fmMangePeople());

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            OnClick(new fmMangeUsers());

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
             OnClick(new fmChangeUserPassword(clsCurrentUser.CurrentUser.UserID));
            clsCurrentUser.CurrentUser = clsUser.FindUserByUserID(clsCurrentUser.CurrentUser.UserID);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

            OnClick(new fmUpdateUserInformation(clsCurrentUser.CurrentUser.PersonID, clsCurrentUser.CurrentUser.UserID));
            clsCurrentUser.CurrentUser=clsUser.FindUserByUserID(clsCurrentUser.CurrentUser.UserID);


        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnClick(new fmAddNewUser());
        }

        private void addNewPeopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnClick(new fmAddUpdatePerson(-1));
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsCurrentUser.CurrentUser=null;
            AfterLogOut?.Invoke();
        }

        private void applicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            OnClick(new fmManageApplicationTypes());
        }

   

        private void testTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnClick(new fmManageTestTypes());
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // there is some thing wrong
            OnClick(new fmCurrentUserInfo(clsCurrentUser.CurrentUser.UserID));
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnClick(new fmAddNewLocalDrivingLicenseApplication());
        }

        private void manageLocalDrivingLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnClick(new fmManageLocalDrivingLicense());
        }

        private void addNewLocalDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnClick(new fmAddNewLocalDrivingLicenseApplication());
        }

        private void issueNewInternationalDrivingLiceseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnClick(new fmIssueInternationalLicense());
        }

        private void tsRenewLocalDrivingLicense_Click(object sender, EventArgs e)
        {
            OnClick(new fmRenewDrivingLicense());
        }

        private void replacementForDamageOrLostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnClick(new fmReplacementForDamage_Lost());
        }

        private void tsManageDetainedLicenses_Click(object sender, EventArgs e)
        {
            OnClick(new fmMangeDetainedLicense());
        }

        private void tsDetainLicense_Click(object sender, EventArgs e)
        {
            OnClick(new fmRelease_DetainLicense(fmRelease_DetainLicense.enMode.Detain));
        }

        private void tsReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            OnClick(new fmRelease_DetainLicense(fmRelease_DetainLicense.enMode.Release));

        }
    }
    
    
}
