using System;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.Applications
{
    public partial class fmIssueNewLocalDrivingLicense : Form
    {
        private long _LDLAID;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication=new clsLocalDrivingLicenseApplication();
        public fmIssueNewLocalDrivingLicense(long LDLAID)
        {
            this._LDLAID = LDLAID;
            InitializeComponent();
            ctrlLocalDrivingLicenseApplicationInfo1.LoadLDLInfo(LDLAID);
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IssueLocalDrivingLicense();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool _CheckConstrains()
        {
            if (ctrlLocalDrivingLicenseApplicationInfo1.LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Check Local Driving License Application ID");
                this.Close();
                return false;

            }
            if (ctrlLocalDrivingLicenseApplicationInfo1.LocalDrivingLicenseApplication.NoOfPassedTests < 3)
            {
                MessageBox.Show("The person doesn't passed all exams");
                this.Close();

                return false;
            }
            if (clsLocalDrivingLicense.IsPersonHasLicenseWithSameClass(ctrlLocalDrivingLicenseApplicationInfo1.LocalDrivingLicenseApplication.PersonID
                , ctrlLocalDrivingLicenseApplicationInfo1.LocalDrivingLicenseApplication.LocalDrivingLicenseClass.ID))
            {
                MessageBox.Show("This Person Has This License Before");
                this.Close();

                return false; 
            }
           

           
            return true;
        }

        public void IssueLocalDrivingLicense()
        {
            long LicenseNumber = _IssueLocalDrivingLicense();
            if (LicenseNumber>0)
            {
                MessageBox.Show($"The license Has been Issued \n LicenseNumber Is {LicenseNumber}");
                return;
            }
          
            
            MessageBox.Show("Error!");
            return ;
        }

        private long _IssueLocalDrivingLicense()
        {
            _LocalDrivingLicenseApplication=clsLocalDrivingLicenseApplication.Find(_LDLAID);
            if (_LocalDrivingLicenseApplication == null)
                     return -1;
                return _LocalDrivingLicenseApplication.IssueLocalDrivingLicense(clsCurrentUser.CurrentUser.UserID,
                    txtNotes.Text);
        }

        private void ctrlLocalDrivingLicenseApplicationInfo1_Load(object sender, EventArgs e)
        {
            _CheckConstrains();
        }
    }
}
