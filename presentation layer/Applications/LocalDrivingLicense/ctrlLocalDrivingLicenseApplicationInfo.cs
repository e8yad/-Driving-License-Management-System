using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalDrivingLicense;
using BusinessLayer;

namespace DVLD.Applications
{
    public partial class ctrlLocalDrivingLicenseApplicationInfo : UserControl
    {
        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication;
        public ctrlLocalDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private string ConvertStatusToString(short StatusID)
        {
            switch (StatusID)
            {
                case 1:
                    return "New";
                case 2: return "Completed";
                case 3: return "Canceled";
                default:
                    return "UnKnown";
            }
        }
        public void LoadLDLInfo(long LDLID)
        {
            LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(LDLID);
            if (LocalDrivingLicenseApplication == null)
                return;
            FillForm();


        }
        public void LoadLDLInfo(clsLocalDrivingLicenseApplication LocalDrivingLicense)
        {
            this.LocalDrivingLicenseApplication = LocalDrivingLicense;
            if (LocalDrivingLicense == null)
                return;
            FillForm();
        }


        private void FillForm()
        {
            lbApplicant.Text = clsPerson.FindByPersonID(LocalDrivingLicenseApplication.PersonID).FullName;
            lbApplicationID.Text = LocalDrivingLicenseApplication.ApplicationID.ToString();
            lbClass.Text = LocalDrivingLicenseApplication.LocalDrivingLicenseClass.ClassName;
            lbDate.Text = LocalDrivingLicenseApplication.CreationDate.ToShortDateString();
            lbLDLID.Text = LocalDrivingLicenseApplication.LDLApplicationID.ToString();
            lbNPassedTest.Text = LocalDrivingLicenseApplication.NoOfPassedTests.ToString();
            lbStatus.Text = LocalDrivingLicenseApplication.statusID.ToString();
            lbTotalFees.Text = LocalDrivingLicenseApplication.ApplicationFees.ToString();
            lbType.Text = LocalDrivingLicenseApplication.ApplicationType.Title;
            lbUserID.Text = LocalDrivingLicenseApplication.UserID.ToString();
        }





      
    }
}
