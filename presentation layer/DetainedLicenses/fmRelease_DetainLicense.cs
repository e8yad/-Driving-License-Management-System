using BusinessLayer;
using DVLD.Applications;
using System;
using System.Windows.Forms;

namespace DVLD.DetainedLicenses
{
    public partial class fmRelease_DetainLicense : Form
    {
        private clsApplicationType _ApplicationType;

        private long _DetainID;
        private long _ReleaseID;
        public enum enMode { Release=1, Detain }
        private enMode _Mode;
        private long _LicenseNumber;
        public fmRelease_DetainLicense(enMode Mode,long LicenseNumber=-11)
        {
            InitializeComponent();
            this._LicenseNumber = LicenseNumber;
            this._Mode = Mode;  
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            _InitializeForm();
        }

        private void OnReleaseFinish(bool arg1, long  _ReleaseID)
        {
          
            MessageBox.Show($"The License Released Successfully With ApplicationId {_ReleaseID}");
            btnDo.Enabled = false;
            lbApplicationID.Text = _ReleaseID.ToString();

        }

        private void _InitializeForm()
        {
            llbShowLicenseHistory.Enabled = false;
            btnDo.Enabled=false;
            if(_Mode == enMode.Release)
            {
                label1.Text = "Release Detained Driving License";
                this.Text = "Release Detained Driving License";
                btnDo.Text="Release";
                txtFineAmount.ReadOnly= true;
                txtDetainReason.ReadOnly= true;
               

            }
            else
            {
                label1.Text = "Detain Detained Driving License";
                this.Text = "Detain Detained Driving License";
                btnDo.Text="Detain";
                lbDetaindDate.Text=DateTime.Now.ToShortDateString();
                lbApplicationID.Hide();
                lbTotalFees.Hide();
                lbApplicationFees.Hide();
                label10.Hide();
                label3.Hide();
                label11.Hide();

            }
            if(_LicenseNumber==-11)
                groupBox1.Enabled= true;
            else
            {
                groupBox1.Enabled = false;
                txtPerson_LLN.Text= _LicenseNumber.ToString();
                _FindLicense();
            }
            lbUserName.Text = clsCurrentUser.CurrentUser.UserName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _FindLicense()
        {
            if (!_CheckTxtPerson_LLN())
            {
                MessageBox.Show("License Number is not correct");
                return;
            }
            ctrlLocalDrivingLicenseInfo1.LoadDrivingLicenseInfoByLicenseNo(Convert.ToInt64(txtPerson_LLN.Text));
            if (ctrlLocalDrivingLicenseInfo1.localDrivingLicense == null)
            {
                MessageBox.Show("License Number is not correct");
                return;
            }
        
            llbShowLicenseHistory.Enabled = true;
            btnDo.Enabled=true;
            llbShowLicenseHistory.Enabled = true;
   
            if (enMode.Detain==_Mode)
            {
                if (ctrlLocalDrivingLicenseInfo1.localDrivingLicense.IsDetained)
                {
                    MessageBox.Show("This License Is Olready Detained");
                }
                else if (!ctrlLocalDrivingLicenseInfo1.localDrivingLicense.IsDetained && !ctrlLocalDrivingLicenseInfo1.localDrivingLicense.IsActive)
                {
                    MessageBox.Show("This License Is Not Active");

                }
                else
                    return;
                btnDo.Enabled = false;

            }
            else
            {
                _ApplicationType = clsApplicationType.Find(5);
                if(!ctrlLocalDrivingLicenseInfo1.localDrivingLicense.IsDetained)
                {
                    MessageBox.Show("This License Is Not Detained");
                    btnDo.Enabled = false;
                    return;
                }    
                _FillDetainedInformation();
            }

        }
        private void _FillDetainedInformation()
        {
           
            txtFineAmount.Text = ctrlLocalDrivingLicenseInfo1.localDrivingLicense.DetainedLicenseInfo.Fine.ToString();
            txtDetainReason.Text = ctrlLocalDrivingLicenseInfo1.localDrivingLicense.DetainedLicenseInfo.DetainReason;
            lbDetaindDate.Text= ctrlLocalDrivingLicenseInfo1.localDrivingLicense.DetainedLicenseInfo.DetainDate.ToShortDateString();         
            lbDetainID.Text=ctrlLocalDrivingLicenseInfo1.localDrivingLicense.DetainedLicenseInfo.DetainID.ToString();
            lbApplicationFees.Text = _ApplicationType.Fees.ToString();
            lbTotalFees.Text = (decimal.Parse(txtFineAmount.Text) + (decimal)_ApplicationType.Fees).ToString();
        }
        private bool _CheckTxtPerson_LLN()
        {
            return long.TryParse(txtPerson_LLN.Text, out _);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            _FindLicense();
        }

        private bool _checkFine()
        {
            if(string.IsNullOrEmpty(txtFineAmount.Text))
            {
                errorProvider1.SetError(txtFineAmount, "You Must Enter Fine Amount");
                return false;
            }
            return true;
        }

        private void _DoDependOnMode()
        {
            if(_Mode==enMode.Detain)
            {
                if (!_checkFine())
                    return;
                _DetainID=ctrlLocalDrivingLicenseInfo1.localDrivingLicense.DetainLicense(decimal.Parse(txtFineAmount.Text),txtDetainReason.Text);
                if(_DetainID>0)
                {
                    lbDetainID.Text= _DetainID.ToString();
                    MessageBox.Show($"The License is  Detained With ID {_DetainID}");
                    btnDo.Enabled = false;
                }
                else
                {
                    MessageBox.Show($"Error In Detain License");
                }
            }
            else
            {
                if (ctrlLocalDrivingLicenseInfo1.localDrivingLicense.DetainedLicenseInfo == null)
                    return;
                decimal totalFees=ctrlLocalDrivingLicenseInfo1.localDrivingLicense.DetainedLicenseInfo.Fine+(decimal)_ApplicationType.Fees;

            
                _ReleaseID=ctrlLocalDrivingLicenseInfo1.localDrivingLicense.ReleaseLicense(totalFees,clsCurrentUser.CurrentUser.UserID);
                OnReleaseFinish(_ReleaseID > 0, _ReleaseID);
            }

        }

        private void txtFineAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar))
            {
                if ((Keys)e.KeyChar == Keys.Back || (Keys)e.KeyChar == Keys.Decimal)
                    return;
                e.Handled = true;
                System.Media.SystemSounds.Hand.Play();
            }
        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            _DoDependOnMode();
        }

        private void llbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmDrivingLicenseHistory fm = new fmDrivingLicenseHistory(ctrlLocalDrivingLicenseInfo1.localDrivingLicense.DriverID
                , ctrlLocalDrivingLicenseInfo1.localDrivingLicense.DriverInfo.PersonID);
            fm.ShowDialog();
        }
    }
}
