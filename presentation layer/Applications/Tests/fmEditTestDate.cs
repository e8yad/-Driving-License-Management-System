using System;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.Applications.Tests
{
    public partial class fmEditTestDate : Form
    {
        private long _TestID;
        public fmEditTestDate(long TestID,clsTests.TestType testType)
        {
            this._TestID = TestID;
            InitializeComponent();
            ctrlTestInfo1.LoadTestInfo(TestID);
            ctrlTestInfo1.TestType = testType;
            ctrlTestInfo1.OnSaveFinish += UpdateResult;

        }

        private void UpdateResult(bool Result, long TestID)
        {
           if (!Result)
           {
                MessageBox.Show("Failed To Update");
                return;
           }
            MessageBox.Show("Test Date Update Successfully");
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ctrlTestInfo1.EditTestDate(_TestID);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
