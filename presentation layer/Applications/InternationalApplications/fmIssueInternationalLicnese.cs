using System;
using System.Windows.Forms;
using BusinessLayer;


namespace DVLD.Applications.InternationalApplications
{
    public partial class fmIssueInternationalLicense : Form
    {
        // International Application
        private clsInternationalDrivingLicenseApplication _IApplication =new clsInternationalDrivingLicenseApplication();
        ~fmIssueInternationalLicense()
        {
            _IApplication.OnSaveFinish -= AfterSaveFinish;
            _IApplication =null;

        }
        public fmIssueInternationalLicense()
        {
            InitializeComponent();

            cmFilterBY.SelectedItem = 0;
            btnIssue.Enabled= false;
            llbShowLicenseInfo.Enabled= false;
            llbShowLicenseHistory.Enabled= false;
            _IApplication.OnSaveFinish += AfterSaveFinish;
            _FillBasicApplicationInformation();
        }

        private void AfterSaveFinish(bool result, long ILN)
        {
            if (result)
            {
                MessageBox.Show($"International License Issued Successfully With No:{_IApplication.ILN}");
                btnIssue.Enabled= false;
                llbShowLicenseInfo.Enabled= true;
                lbApplicationID.Text=_IApplication.ApplicationID.ToString();
                label.Text=_IApplication.ILN.ToString();
            }
        }

        private void _FindLicense()
        {
             if (!_CheckTxtPerson_LLN())
             {
                MessageBox.Show("NationalId or License Number Class 3 are not correct");
                return;
             }
            if (cmFilterBY.SelectedIndex==0)
                ctrlLocalDrivingLicenseInfo1.LoadDrivingLicenseInfoByNationalID(Convert.ToInt64(txtPerson_LLN.Text));
            else
                ctrlLocalDrivingLicenseInfo1.LoadDrivingLicenseInfoByLicenseNo(Convert.ToInt64(txtPerson_LLN.Text));
            llbShowLicenseHistory.Enabled=true;
        }
     
        private bool _CheckTxtPerson_LLN()
        {
            return long.TryParse(txtPerson_LLN.Text,out _);
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtPerson_LLN.Text))
            {
                MessageBox.Show("Please Enter NationalId or License Number Class 3");
                return;
            }
            _FindLicense();
            if (ctrlLocalDrivingLicenseInfo1.localDrivingLicense == null)
            {
                MessageBox.Show("Can not find  A License Class 3  for This Person");
                return;
            }
             btnIssue.Enabled = true;
            _IApplication.LLN = ctrlLocalDrivingLicenseInfo1.localDrivingLicense.LicenseNumber;
            _IApplication.PersonID = ctrlLocalDrivingLicenseInfo1.localDrivingLicense.DriverInfo.PersonID;
            lbLLN.Text = _IApplication.LLN.ToString();
        }

        private void _FillBasicApplicationInformation()
        {
            _IApplication.CreationDate = DateTime.Now;
            _IApplication.ApplicationFees = (decimal)_IApplication.ApplicationType.Fees;
            _IApplication.UserID = clsCurrentUser.CurrentUser.UserID;
            _IApplication.IssueDate = DateTime.Now;
            // hard code it not latter you can edit it 
            _IApplication.ExpirationDate = DateTime.Now.AddYears(1);
            _IApplication.statusID =  BusinessLayer.clsApplications.enStatusID.New;
            _IApplication.IsActive = true;


            lbApplicationDate.Text = _IApplication.CreationDate.ToShortDateString();
            lbIssueDate.Text = _IApplication.IssueDate.ToShortDateString();
            lbExpirationDate.Text= _IApplication.ExpirationDate.ToShortDateString();
            lbFees.Text=_IApplication.ApplicationFees.ToString();
            lbUserName.Text = clsCurrentUser.CurrentUser.UserName;
        }

        private void _IssueIDL()
        {
            if(!ctrlLocalDrivingLicenseInfo1.localDrivingLicense.IsActive)
            {
                MessageBox.Show($"License With Number {_IApplication.LLN} Is Not Active");
                return;  
            }

            if (clsInternationalDrivingLicenseApplication.IsAnActiveInternationalLicenseNumber(_IApplication.LLN))
            {
                if(MessageBox.Show("This Person Has olready An Active International License \n Do You Want To Add New One","?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    btnIssue.Enabled = false;
                    return;
                }
            }



            _IApplication.IssueNewInternationalDrivingLicense();



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _IssueIDL();
        }

        private void llbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmDrivingLicenseHistory fm= new fmDrivingLicenseHistory(_IApplication.PersonID);
            fm.ShowDialog();
        }
    }
}
