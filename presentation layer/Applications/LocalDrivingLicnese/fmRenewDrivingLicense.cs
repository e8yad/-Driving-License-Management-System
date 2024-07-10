using System;
using System.Windows.Forms;
using DVLD.Applications;
using BusinessLayer;

namespace DVLD
{
    public partial class fmRenewDrivingLicense : Form
    {
        private clsRenewDrivingLicense _NewLocalLicense;
        public fmRenewDrivingLicense()
        {
            InitializeComponent();
            btnRenewlicense.Enabled = false;
            llbShowLicenseHistory.Enabled = false;
        }

        private void SaveResult(bool obj)
        {
            if (obj)
            {
                MessageBox.Show($"License Issued Successfully With No:{_NewLocalLicense.NewLocalDrivingLicense.LicenseNumber}");
                btnRenewlicense.Enabled = false;
                lbApplicationID.Text = _NewLocalLicense.ApplicationID.ToString();
                lbLLN.Text = _NewLocalLicense.NewLocalDrivingLicense.LicenseNumber.ToString();
            }
            else
            {
                MessageBox.Show($"This License Is Not Active Or Not Expired:");
            }

            clsRenewDrivingLicense.OnSaveFinish -= SaveResult;


        }

        private void btnFind_Click(object sender, System.EventArgs e)
        {
            _FindLicense();
        }

        private void _FindLicense()
        {
            if (!_CheckTxtPerson_LLN())
            {
                MessageBox.Show("License Number is not correct");
                btnRenewlicense.Enabled = true;

                return;
            }
                ctrlLocalDrivingLicenseInfo1.LoadDrivingLicenseInfoByLicenseNo(Convert.ToInt64(txtPerson_LLN.Text));
            if(ctrlLocalDrivingLicenseInfo1.localDrivingLicense==null)
            {
                MessageBox.Show("License Number is not correct");
                btnRenewlicense.Enabled = false;

                return;
            }
            llbShowLicenseHistory.Enabled = true ;
            _FillApplicationData();

            if(ctrlLocalDrivingLicenseInfo1.localDrivingLicense.ExpirationDate>DateTime.Now|| !ctrlLocalDrivingLicenseInfo1.localDrivingLicense.IsActive)
            {
                MessageBox.Show("The license You Entered Is Not Expired or Not Active", "Not Expired", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewlicense.Enabled = false;

                return;
            }
            btnRenewlicense.Enabled=true;
        }

        private bool _CheckTxtPerson_LLN()
        {
            return long.TryParse(txtPerson_LLN.Text, out _);
        }
        private void _FillApplicationData()
        {
            lbApplicationDate.Text = DateTime.Now.ToShortDateString();
            lbIssueDate.Text = DateTime.Now.ToShortDateString();
            lbExpirationDate.Text = DateTime.Now.AddYears(ctrlLocalDrivingLicenseInfo1.localDrivingLicense.DriverClassesInfo.Validity).ToShortDateString();
            lbApplicationFees.Text = clsApplicationType.Find((int)clsApplicationType.enApplicationTypes.Renew).Fees.ToString();
            lbLicenseFees.Text = ctrlLocalDrivingLicenseInfo1.localDrivingLicense.DriverClassesInfo.Fees.ToString();
            lbTotalFees.Text = (Convert.ToDecimal(lbApplicationFees.Text) + Convert.ToDecimal(lbLicenseFees.Text)).ToString();
           lbUserName.Text = clsCurrentUser.CurrentUser.UserName;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _Renew()
        {
            clsRenewDrivingLicense.OnSaveFinish += SaveResult;
             _NewLocalLicense =ctrlLocalDrivingLicenseInfo1.localDrivingLicense.RenewLicense(clsCurrentUser.CurrentUser.UserID);
            //SaveResult(_NewLocalLicense != null);


        }

        private void llbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmDrivingLicenseHistory fm = new fmDrivingLicenseHistory(
               ctrlLocalDrivingLicenseInfo1.localDrivingLicense.DriverID, ctrlLocalDrivingLicenseInfo1.localDrivingLicense.DriverInfo.PersonID);
            fm.ShowDialog();
        }

        private void btnRenewlicense_Click(object sender, EventArgs e)
        {
            _Renew();
            
        }
    }
}
