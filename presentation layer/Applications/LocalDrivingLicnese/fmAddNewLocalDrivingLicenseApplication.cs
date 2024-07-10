using System;
using System.Data;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.Applications
{
    public partial class fmAddNewLocalDrivingLicenseApplication : Form
    {
        // i  able to make public Property in ctrlFindPerson and i will save time for event  

        clsLocalDrivingLicenseApplication localDrivingLicense;
    
        public fmAddNewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            localDrivingLicense = new clsLocalDrivingLicenseApplication();
            localDrivingLicense.UserID = clsCurrentUser.CurrentUser.UserID;
            _loadCm();
            
           
        }
        // to get person info after find person
        private void _FillLDLApplication()
        {
            localDrivingLicense.PersonID = ctrlFindPerson1.SelectedPerson.PersonID;
            localDrivingLicense.CreationDate = DateTime.Now;


        }
        // to load ApplicationInfoTab
        private void _LoadApplicationInfoTab()
        {
            cmbLicenseClass.SelectedIndex = 2;
            lbUserName.Text=clsCurrentUser.CurrentUser.UserName;
            lbDate.Text=localDrivingLicense.CreationDate.ToShortDateString();

        }
       private void _UpdateFees()
        {
            decimal ApplicationFees= (decimal)localDrivingLicense.ApplicationType.Fees;
            lbClassFees.Text = localDrivingLicense.LocalDrivingLicenseClass.Fees.ToString();
            lbApplicationFees.Text = ApplicationFees.ToString();
            localDrivingLicense.ApplicationFees = ApplicationFees;
        }
        private void _SaveResult(bool Result,long ApplicationID)
        {
            if(!Result && ApplicationID==-11)
            {
                MessageBox.Show("Person  Already Has a License With The Same Applied Driving Class");
                return; 
            }
            if(!Result && ApplicationID==-111) { 
                MessageBox.Show($"Age Must Be More Then {localDrivingLicense.LocalDrivingLicenseClass.MinimumAge}");
                return; 
            }
            MessageBox.Show("Application Saved Successfully");
            lbApplicationID.Text = localDrivingLicense.ApplicationID.ToString();
        }
       private void _Save()
       {
            _FillLDLApplication();
            bool result = localDrivingLicense.save();
            _SaveResult(result,localDrivingLicense.ApplicationID);
       }

        private void cmbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            localDrivingLicense.LocalDrivingLicenseClass= clsLocalDrivingLicenseClasses.Find(cmbLicenseClass.SelectedIndex+1);
            _UpdateFees();
        }

        private void _loadCm()
        {
            DataTable dt= clsLocalDrivingLicenseClasses.GetAllClassesName();
            foreach(DataRow row in dt.Rows)
            {
                cmbLicenseClass.Items.Add(row[0].ToString());
            }
        }
        private void _NextTab()
        {
            if (ctrlFindPerson1.SelectedPerson == null)
            {
                tabControl1.SelectedIndex = 0;
                MessageBox.Show("Check Person National ID!");
                return;
            }
            _LoadApplicationInfoTab();
            tabControl1.SelectedIndex = 1;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _NextTab();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                return;
            _NextTab();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
