using System;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.Applications.Tests
{
    public partial class fmTestAppointment : Form
    {
        public fmTestAppointment(long LDLID, clsTests.TestType TestType)
        {
            InitializeComponent();

          //  ctrlTestAppointment1.TestID = TestID;
            ctrlTestAppointment1.TestType = TestType;
            ctrlTestAppointment1.LDLAID = LDLID;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            ctrlTestAppointment1.LoadInfo();
            ctrlTestAppointment1.State += onAddButtonErrorHappend;
        }

        private void onAddButtonErrorHappend(bool Result, short code)
        {
            if(!Result&&code==-11)
            {
                MessageBox.Show("This Person Has olready and open exam");
            }
            if (!Result && code == -111)
            {
                MessageBox.Show("This Person Has olready Passed");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        fmTestAppointment()
        {
            ctrlTestAppointment1.State -= onAddButtonErrorHappend;
        }
    }
}
