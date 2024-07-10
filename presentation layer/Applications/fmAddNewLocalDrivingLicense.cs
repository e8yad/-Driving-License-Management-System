using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationsBusiness;
using DVLD.Persons;
using LocalDrivingLicense;
namespace DVLD.Applications
{
    public partial class fmAddNewLocalDrivingLicense : Form
    {
        private bool _IsFoundPerson=false;
        clsLocalDrivingLicense localDrivingLicense; 
  
        public fmAddNewLocalDrivingLicense()
        {
            InitializeComponent();
            localDrivingLicense = new clsLocalDrivingLicense();
            ctrlFindPerson1.OnFindPerson += _AfterSelectPerson;
            localDrivingLicense.UserID = clsCurrentUser.CurrentUser.UserID;
            _loadCm();
        }
        
        // to get person info after find person
        private void _AfterSelectPerson(bool result ,long NationalID,long PersonID)
        {
            if (!result)
                return;
            _IsFoundPerson=true;
            localDrivingLicense.PersonID = PersonID;
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
            decimal TotalFees= localDrivingLicense.LocalDrivingLicenseClass.Fees + (decimal)localDrivingLicense.ApplicationType.Fees;
            lbClassFees.Text = localDrivingLicense.LocalDrivingLicenseClass.Fees.ToString();
            lbTotalFees.Text = TotalFees.ToString();
            localDrivingLicense.Fees = TotalFees;
        }
        private void _SaveResult(bool Result,long ApplicationID)
        {
            if(!Result && ApplicationID==-11)
            {
                MessageBox.Show("This Person Already has an Open Application at Same Class");
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
            localDrivingLicense.OnSaveFinish += _SaveResult;
            localDrivingLicense.save();
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
            if (!_IsFoundPerson)
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
