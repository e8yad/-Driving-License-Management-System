using DVLD.Applications.Tests;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.Applications
{

    public partial class ctrlTestAppointment : UserControl
    {
        private delegate void ctrlBehaviorDelegate();
        public long LDLAID { get; set; }
        //public long TestID { get;  set; } 
        public event Action<bool, short> State;
        public clsTests.TestType TestType { get; set; }
        public ctrlTestAppointment()
        {

            InitializeComponent();

        }

        // load depend of id type 

        public void LoadInfo()
        {

            ctrlLocalDrivingLicenseApplicationInfo1.LoadLDLInfo(LDLAID);
            _LoadAppointments();

        }
        // to fill data 
        private void _LoadAppointments()
        {
            label2.Text = clsTests.TotalTrialsPerTest(LDLAID, (int)TestType).ToString();
            dgAppointments.DataSource = clsTests.FindRelatedTests(LDLAID, (int)TestType);
        }
        // your problem here you seperate tests in 3 Forms

        void _ScheduleTest()
        {
            _onNewTestClicked(new fmTests(TestType, LDLAID, dgAppointments.Rows.Count > 0));
            _LoadAppointments();
        }
    

        private void _onNewTestClicked(object sender)
        {
            if(clsTests.IsTestExistsAndNotLocked(LDLAID,(int)TestType))
            {
                //means there is an open test
                State?.Invoke(false,-11);
                return;
            }

            if (clsTests.IsPassed(LDLAID, (int)TestType))
            {
                //means Person Passed in This Test
                State?.Invoke(false, -111);
                return;
            }
            // using upcasting 
            ((Form)sender).ShowDialog();

        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            _ScheduleTest();
        }
        private void tsEditTestDate_Click(object sender, EventArgs e)
        {
            fmEditTestDate fm =new fmEditTestDate((long)dgAppointments.CurrentRow.Cells[0].Value, TestType);
            fm.ShowDialog();
            _LoadAppointments();
        }

        private void tsTakeTest_Click(object sender, EventArgs e)
        {
            if(TestType==clsTests.TestType.Written)
            {
                fmWrittenTest fm = new fmWrittenTest((long)dgAppointments.CurrentRow.Cells[0].Value);
                fm.ShowDialog();
            }
            else
            {
                fmTakeTest fm = new fmTakeTest((long)dgAppointments.CurrentRow.Cells[0].Value, (long)dgAppointments.CurrentRow.Cells[1].Value);
                fm.ShowDialog();
            }
          
            _LoadAppointments();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgAppointments.Rows.Count == 0)
            {
                tsEditTestDate.Enabled = false;
                tsTakeTest.Enabled = false;
                return;
            }
                
            bool IsLocked = (bool)dgAppointments.CurrentRow.Cells[4].Value;


                tsEditTestDate.Enabled=!IsLocked;    
                tsTakeTest.Enabled=!IsLocked;
        }
    }
}
