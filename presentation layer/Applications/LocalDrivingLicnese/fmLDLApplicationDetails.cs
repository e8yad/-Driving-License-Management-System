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
    public partial class fmLDLApplicationDetails : Form
    {
        public fmLDLApplicationDetails(long LDLID)
        {
            InitializeComponent();
            ctrlLocalDrivingLicenseApplicationInfo1.LoadLDLInfo(LDLID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
