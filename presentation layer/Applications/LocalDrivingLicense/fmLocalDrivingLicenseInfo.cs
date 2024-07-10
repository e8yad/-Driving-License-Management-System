using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class fmLocalDrivingLicenseInfo : Form
    {
        public fmLocalDrivingLicenseInfo(long LDLAID)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false; 
            ctrlLocalDrivingLicenseInfo1.LoadDrivingLicenseInfoLDLAID(LDLAID);
        }
        public fmLocalDrivingLicenseInfo(long LicenseNumber,bool x)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            ctrlLocalDrivingLicenseInfo1.LoadDrivingLicenseInfoByLicenseNo(LicenseNumber);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
