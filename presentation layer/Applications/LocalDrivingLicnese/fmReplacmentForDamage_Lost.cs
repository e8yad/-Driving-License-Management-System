
using System;
using System.Windows.Forms;
using BusinessLayer;


namespace DVLD.Applications.ApplicationTypes
{
    public partial class fmReplacementForDamage_Lost : Form
    {
        private clsReplacementForDamage_Lost _Replacement;
        private clsApplicationType _ApplicationType;
        private enum enMode { Damage=4,Lost=3}
        private enMode _Mode;

        public fmReplacementForDamage_Lost()
        {
            InitializeComponent();
            
            llbShowLicenseHistory.Enabled = false;
            btnReplace.Enabled = false;
            rdDamage.Checked= true;
        }

        private void OnSaveFinish(bool obj)
        {
            if (obj)
            {
              //  MessageBox.Show($"License Issued Successfully With No:{_Replacement.NewLocalDrivingLicense.LicenseNumber}");
                btnReplace.Enabled = false;
              //  lbApplicationID.Text = _Replacement.ApplicationID.ToString();
               //lbLLN.Text = _Replacement.NewLocalDrivingLicense.LicenseNumber.ToString();
            }
            else
            {
                MessageBox.Show($"This License Is Not Active:");
            }
            clsReplacementForDamage_Lost.OnSaveFinish -= OnSaveFinish;

        }

        private void _FindLicense()
        {
            if (!_CheckTxtPerson_LLN())
            {
                MessageBox.Show("License Number is not correct");
                btnClose.Enabled = false;
                return;
            }
            ctrlLocalDrivingLicenseInfo1.LoadDrivingLicenseInfoByLicenseNo(Convert.ToInt64(txtPerson_LLN.Text));
            if (ctrlLocalDrivingLicenseInfo1.localDrivingLicense == null)
            {
                MessageBox.Show("License Number is not correct");
                btnClose.Enabled = false;
                return;
            }

            llbShowLicenseHistory.Enabled = true;
            _FillApplicationData();
            _UpdateDependOnMode();
            if (ctrlLocalDrivingLicenseInfo1.localDrivingLicense.ExpirationDate < DateTime.Now || !ctrlLocalDrivingLicenseInfo1.localDrivingLicense.IsActive)
            {
                MessageBox.Show("The license You Entered Is  Expired or Not Active", "Not Expired", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnReplace.Enabled = true;
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
            lbLicenseFees.Text = ctrlLocalDrivingLicenseInfo1.localDrivingLicense.DriverClassesInfo.Fees.ToString();
            lbUserName.Text = clsCurrentUser.CurrentUser.UserName;
        }
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();   
        }
        private void _UpdateDependOnMode()
        {
            if(rdDamage.Checked)
            {
                _Mode = enMode.Damage;
                label1.Text = "Replacement For Damage License";
            }
               

            else
            {
                label1.Text = "Replacement For Lost License";
                _Mode = enMode.Lost;

            }

            _ApplicationType = clsApplicationType.Find((int)_Mode);
            lbApplicationFees.Text = _ApplicationType.Fees.ToString();
            if(ctrlLocalDrivingLicenseInfo1.localDrivingLicense!=null)
             lbTotalFees.Text = ((decimal)_ApplicationType.Fees + ctrlLocalDrivingLicenseInfo1.localDrivingLicense.Fees).ToString();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            _Replace();
        }

        private void rdDamage_CheckedChanged(object sender, EventArgs e)
        {
            _UpdateDependOnMode();
        }

        private void _Replace()
        {
            clsReplacementForDamage_Lost.OnSaveFinish += OnSaveFinish;
            _Replacement = (rdDamage.Checked) ? ctrlLocalDrivingLicenseInfo1.localDrivingLicense.ReplaceLicense(clsReplacementForDamage_Lost.enReplacementFor.Damage, clsCurrentUser.CurrentUser.UserID) :
                ctrlLocalDrivingLicenseInfo1.localDrivingLicense.ReplaceLicense(clsReplacementForDamage_Lost.enReplacementFor.Lost, clsCurrentUser.CurrentUser.UserID);
            // just solution util you study events 
            if(_Replacement!=null)
            {
                MessageBox.Show($"License Issued Successfully With No:{_Replacement.NewLocalDrivingLicense.LicenseNumber}");
                lbApplicationID.Text = _Replacement.ApplicationID.ToString();
                lbLLN.Text = _Replacement.NewLocalDrivingLicense.LicenseNumber.ToString();
            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            _FindLicense();
        }

        private void llbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmDrivingLicenseHistory fm = new fmDrivingLicenseHistory(ctrlLocalDrivingLicenseInfo1.localDrivingLicense.DriverID
                ,ctrlLocalDrivingLicenseInfo1.localDrivingLicense.DriverInfo.PersonID);
            fm.ShowDialog();
        }
    }
}
