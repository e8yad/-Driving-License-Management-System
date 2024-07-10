using System;
using System.IO.Pipes;
using System.Windows.Forms;
using LocalDrivingLicense;
namespace DVLD.Applications
{
    public partial class fmIssueNewLocalDrivingLicense : Form
    {
        private long _LDLAID;
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
                return false;

            }
            if (ctrlLocalDrivingLicenseApplicationInfo1.LocalDrivingLicenseApplication.NoOfPassedTests < 3)
            {
                MessageBox.Show("The person doesn't passed all exams");
                return false;
            }
            if (clsLocalDrivingLicense.IsPersonHasLicenseWithSameClass(ctrlLocalDrivingLicenseApplicationInfo1.LocalDrivingLicenseApplication.PersonID
                , ctrlLocalDrivingLicenseApplicationInfo1.LocalDrivingLicenseApplication.LocalDrivingLicenseClass.ID))
            {
                MessageBox.Show("This Person Has This License Before");
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
                clsLocalDrivingLicenseApplication.UpdateStatus(_LDLAID, clsLocalDrivingLicenseApplication.enStatusID.Completed);
                return;
            }
          
            
            MessageBox.Show("Error!");
            return ;
                
            
            
        }

        private long _IssueLocalDrivingLicense()
        {
            if (!_CheckConstrains())
                return  -1;
            clsLocalDrivingLicense drivingLicense=new clsLocalDrivingLicense(_LDLAID);
            drivingLicense.StatusID = clsLocalDrivingLicense.enLicenseStatus.New;
            drivingLicense.IssueDate=DateTime.Now;
            drivingLicense.ExpirationDate= drivingLicense.IssueDate.AddYears(ctrlLocalDrivingLicenseApplicationInfo1.LocalDrivingLicenseApplication.LocalDrivingLicenseClass.Validity);
             drivingLicense.Fees=ctrlLocalDrivingLicenseApplicationInfo1.LocalDrivingLicenseApplication.ApplicationFees;
            drivingLicense.Notes=txtNotes.Text;
            drivingLicense.PersonID = ctrlLocalDrivingLicenseApplicationInfo1.LocalDrivingLicenseApplication.PersonID;
            drivingLicense.UserID = clsCurrentUser.CurrentUser.UserID;
            drivingLicense.ClassID=ctrlLocalDrivingLicenseApplicationInfo1.LocalDrivingLicenseApplication.LocalDrivingLicenseClass.ID;
             drivingLicense.Save();

            return drivingLicense.LicenseNumber;





        }
    }
}
