using System;
using System.Windows.Forms;
using BusinessLayer;


namespace DVLD.Applications.Tests
{
    public partial class fmTakeTest : Form
    {
        long _TestID;
        long _LDLID;
        public fmTakeTest(long TestId,long LDLID)
        {
            InitializeComponent();
            _TestID = TestId;
            _LDLID = LDLID;
        }


        private void _SetTestResult()   
        {
            

            if (!_IsOneChecked())
            {
                MessageBox.Show("You Must Select Result  First");
                return;
            }
            clsTests.UpdateTestResult(rdPass.Checked, _TestID, txtNotes.Text);
            clsLocalDrivingLicenseApplication.UpdateTestsPassed(_LDLID);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool _IsOneChecked()
        {
            if(!rdPass.Checked&&!rdFail.Checked)
                return false;
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _SetTestResult();
            this.Close();
        }
    }
}
