
using System.Windows.Forms;
using BusinessLayer;
namespace DVLD.Applications
{
    public partial class ctrlLocalDrivingLicenseInfo : UserControl
    {
        public clsLocalDrivingLicense localDrivingLicense { get; private set; }
        public ctrlLocalDrivingLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadDrivingLicenseInfoByNationalID(long NationalID)
        {
             localDrivingLicense = clsLocalDrivingLicense.FindByNationalID(NationalID);
            if (localDrivingLicense == null)
            {
                MessageBox.Show("No License");
                return;
            }
            _FillData(localDrivingLicense);
        }

        public void LoadDrivingLicenseInfoByLicenseNo(long LocalDrivingLicenseNo)
        {
             localDrivingLicense=clsLocalDrivingLicense.FindByLicenseNumber(LocalDrivingLicenseNo);
            if (localDrivingLicense == null)
            {
                MessageBox.Show("No License");
                return;

            }
            _FillData(localDrivingLicense);
        }
        public void LoadDrivingLicenseInfoLDLAID(long LDLAID)
        {
            localDrivingLicense = clsLocalDrivingLicense.FindByLDLID(LDLAID);
            if (localDrivingLicense == null)
            {
                MessageBox.Show("No License");
                return;

            }
            _FillData(localDrivingLicense);
        }

        private void _FillData(clsLocalDrivingLicense localDrivingLicense)
        {
           // clsPerson person = clsPerson.FindByPersonID(localDrivingLicenseApplication.PersonInfo.PersonID);
            lbName.Text = localDrivingLicense.DriverInfo.PersonInfo.FullName;
            lbLicenseNo.Text = localDrivingLicense.LicenseNumber.ToString();
            // you can make Commposation
            lbClassName.Text = localDrivingLicense.DriverClassesInfo.ClassName;
            lbDriverID.Text = localDrivingLicense.DriverID.ToString();
            lbGender.Text = localDrivingLicense.DriverInfo.PersonInfo.Gender.ToString();
            lbIssueDate.Text = localDrivingLicense.IssueDate.ToShortDateString();
            lbExpirationDate.Text = localDrivingLicense.ExpirationDate.ToShortDateString();
            lbDateOfBirth.Text = localDrivingLicense.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lbIsActive.Text = (localDrivingLicense.IsActive) ? "Yes" : "No";
            lbIsDetained.Text = (localDrivingLicense.IsDetained) ? "Yes" : "No";
            lbIssueStatus.Text = localDrivingLicense.StatusID.ToString();
            lbNotes.Text = localDrivingLicense.Notes;

            if (localDrivingLicense.DriverInfo.PersonInfo.ImagePath != null)
            {
                pcPersonImage.ImageLocation= localDrivingLicense.DriverInfo.PersonInfo.ImagePath;
            }

            else
            {
                if (char.ToUpper(localDrivingLicense.DriverInfo.PersonInfo.Gender) == 'M')
                    pcPersonImage.Image = Properties.Resources.Male128;
                else
                    pcPersonImage.Image = Properties.Resources.woman128;

            }
        }
    }
}
