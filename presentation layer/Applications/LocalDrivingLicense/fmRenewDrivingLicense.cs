using System;
using System.Web.Compilation;
using System.Windows.Forms;
using DVLD.Applications;
using RenewDrivingLicense;
using static System.Net.Mime.MediaTypeNames;
namespace DVLD
{
    public partial class fmRenewDrivingLicense : Form
    {
        private clsRenewDrivingLicense RenewDriving;
        ~fmRenewDrivingLicense()
        {
            clsRenewDrivingLicense.OnSaveFinish -= SaveResult;
        }
        public fmRenewDrivingLicense()
        {
            InitializeComponent();
            btnRenewlicense.Enabled = false;
            llbShowLicenseHistory.Enabled = false;
            clsRenewDrivingLicense.OnSaveFinish += SaveResult;

        }

        private void SaveResult(bool obj)
        {
            if (obj)
            {
                MessageBox.Show($"International License Issued Successfully With No:{RenewDriving.NewLocalDrivingLicense.LicenseNumber}");
                btnRenewlicense.Enabled = false;
                lbApplicationID.Text = RenewDriving.ApplicationID.ToString();
                lbLLN.Text = RenewDriving.NewLocalDrivingLicense.LicenseNumber.ToString();
            }
            else
            {
                MessageBox.Show($"This License Is Not Active Or Not Expired:");
            }
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
                return;
            }
                ctrlLocalDrivingLicenseInfo1.LoadDrivingLicenseInfoByLicenseNo(Convert.ToInt64(txtPerson_LLN.Text));
            if(ctrlLocalDrivingLicenseInfo1.localDrivingLicense==null)
            {
                MessageBox.Show("License Number is not correct");
                return;
            }
            llbShowLicenseHistory.Enabled = true ;
            _FillApplicationData();

            if(ctrlLocalDrivingLicenseInfo1.localDrivingLicense.ExpirationDate>DateTime.Now|| !ctrlLocalDrivingLicenseInfo1.localDrivingLicense.IsActive)
            {
                MessageBox.Show("The license You Entered Is Not Expired or Not Active", "Not Expired", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ctrlLocalDrivingLicenseInfo1.localDrivingLicense.Notes= txtNotes.Text;
            RenewDriving =new clsRenewDrivingLicense(ctrlLocalDrivingLicenseInfo1.localDrivingLicense,clsCurrentUser.CurrentUser.UserID);

            lbApplicationDate.Text = RenewDriving.CreationDate.ToShortDateString();
            lbIssueDate.Text = RenewDriving.NewLocalDrivingLicense.IssueDate.ToShortDateString();
            lbExpirationDate.Text =  RenewDriving.NewLocalDrivingLicense.ExpirationDate.ToShortDateString();
            lbApplicationFees.Text = RenewDriving.ApplicationFees.ToString();
            lbLicenseFees.Text = RenewDriving.NewLocalDrivingLicense.Fees.ToString();
            lbTotalFees.Text = ((decimal)RenewDriving.ApplicationType.Fees + RenewDriving.ApplicationFees).ToString();
           lbUserName.Text = clsCurrentUser.CurrentUser.UserName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _Renew()
        {
            RenewDriving.RenewDrivingLicense();
        }

        private void llbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmDrivingLicenseHistory fm = new fmDrivingLicenseHistory(ctrlLocalDrivingLicenseInfo1.localDrivingLicense.PersonID, true);
            fm.ShowDialog();
        }

        private void btnRenewlicense_Click(object sender, EventArgs e)
        {
            _Renew();
        }
    }
}
