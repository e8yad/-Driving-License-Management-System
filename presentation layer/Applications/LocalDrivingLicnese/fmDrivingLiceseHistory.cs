using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.Applications
{
    public partial class fmDrivingLicenseHistory : Form
    {
        public fmDrivingLicenseHistory(long PersonID)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            ctrlPersonInformation1.LoadPersonByPersonID(PersonID);

            dgLDL.DataSource = clsLocalDrivingLicense.GetAllLocalDrivingLicensesRelatedToPersonByPersonID(PersonID);

        }

        public fmDrivingLicenseHistory(long DriverID,long PersonID)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            tabPage2.Hide();
           
            ctrlPersonInformation1.LoadPersonByPersonID(PersonID);
            dgLDL.DataSource = clsDriver.GetAllLocalLicenseRelatedToDriver(DriverID);
            // dgIDL.DataSource = clsInternationalDrivingLicense.GetAllIDLRelatedToPersonByPersonID(PersonID);

        }
    }
}
