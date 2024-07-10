using System;
using System.ComponentModel;
using System.Data;
using BusinessLayer;

using System.Windows.Forms;
using DVLD.Applications.Tests;

namespace DVLD.Applications
{
    public partial class fmManageLocalDrivingLicense : Form
    {
        DataTable LocalDrivingLicenses;
        
        public fmManageLocalDrivingLicense()
        {
            InitializeComponent();
            _LoadLocalDrivingLicenses();
            cmFilterBy.SelectedIndex = 0;
            _loadCm();


        }
        private void _loadCm()
        {
            DataTable dt = clsLocalDrivingLicenseClasses.GetAllClassesName();
            foreach (DataRow row in dt.Rows)
            {
                cmLicenseClasses.Items.Add(row[0].ToString());
            }
          
        }
        private void _LoadLocalDrivingLicenses()
        {
            LocalDrivingLicenses=clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicense();
            dgLocalDrivingLicenses.DataSource= LocalDrivingLicenses;

            if (dgLocalDrivingLicenses.Rows.Count == 0)
                return;

            dgLocalDrivingLicenses.Columns[0].Width = 130;
            dgLocalDrivingLicenses.Columns[0].HeaderText = "LDLA.ID";
            dgLocalDrivingLicenses.Columns[1].Width = 120;
            dgLocalDrivingLicenses.Columns[2].Width = 300;
            dgLocalDrivingLicenses.Columns[3].Width = 130;
            dgLocalDrivingLicenses.Columns[4].Width = 130;
            dgLocalDrivingLicenses.Columns[5].Width = 150;
            dgLocalDrivingLicenses.Columns[6].Width = 200;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            fmAddNewLocalDrivingLicenseApplication fm=new fmAddNewLocalDrivingLicenseApplication();
            fm.ShowDialog();
            _LoadLocalDrivingLicenses();
        }

        private void _FilterBy(string FilterBy,string Value)
        {
            DataView dvLocalDrivingLicenses = LocalDrivingLicenses.DefaultView;
            dvLocalDrivingLicenses.RowFilter = $"Convert( {FilterBy},'System.String')" + " like '" + Value + "%'";

        }

        private void _FilterLicenseClass( string Value)
        {
            DataView dvLocalDrivingLicenses = LocalDrivingLicenses.DefaultView;
            dvLocalDrivingLicenses.RowFilter = $"Class like'Class{Value}'";
        }


        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            _FilterBy(cmFilterBy.SelectedItem.ToString(),txtInput.Text);

        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!short.TryParse(e.KeyChar.ToString(),out _) && (Keys)e.KeyChar!=  Keys.Back)
            {
                e.Handled = true;
                System.Media.SystemSounds.Asterisk.Play();

            }
        }

        private void cmFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmFilterBy.SelectedIndex == 0)
               dgLocalDrivingLicenses.DataSource= LocalDrivingLicenses.DefaultView;

                txtInput.Visible = (cmFilterBy.SelectedIndex != 3&& cmFilterBy.SelectedIndex!=0);
                cmLicenseClasses.Visible = (cmFilterBy.SelectedIndex == 3 && cmFilterBy.SelectedIndex != 0);
                


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterLicenseClass(cmLicenseClasses.SelectedItem.ToString());
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (_CheckIsCanceled()|| dgLocalDrivingLicenses.Rows.Count==0)
            {
                tsScheduleTest.Enabled =false;
                tsCancel.Enabled = false;
                tsIssueLocalDrivingLicense.Enabled = false;
                tsShowLicenseInfo.Enabled = false;
                return;
            }


            tsScheduleTest.Enabled = !(Convert.ToInt16(dgLocalDrivingLicenses.CurrentRow.Cells[8].Value) == 3);
            tsVision.Enabled = (Convert.ToInt16(dgLocalDrivingLicenses.CurrentRow.Cells[8].Value) == 0);
            tsWritten.Enabled = (Convert.ToInt16(dgLocalDrivingLicenses.CurrentRow.Cells[8].Value) == 1);
            tsPractical.Enabled = (Convert.ToInt16(dgLocalDrivingLicenses.CurrentRow.Cells[8].Value) == 2);
            tsShowLicenseInfo.Enabled = (Convert.ToInt16(dgLocalDrivingLicenses.CurrentRow.Cells[8].Value) == 3) && ( (string)dgLocalDrivingLicenses.CurrentRow.Cells[4].Value=="Completed");
            tsIssueLocalDrivingLicense.Enabled = (Convert.ToInt16(dgLocalDrivingLicenses.CurrentRow.Cells[8].Value) == 3) && ((string)dgLocalDrivingLicenses.CurrentRow.Cells[4].Value != "Completed");

        }

       private void onScheduleClick(long LDLID, clsTests.TestType TestType)
       {
            fmTestAppointment fm=new fmTestAppointment(LDLID,TestType);
            fm.ShowDialog();
            _LoadLocalDrivingLicenses();
       }

        private void tsVision_Click(object sender, EventArgs e)
        {
            onScheduleClick((long)dgLocalDrivingLicenses.CurrentRow.Cells[0].Value, clsTests.TestType.Vision);
        }

        private void tsWritten_Click(object sender, EventArgs e)
        {
            onScheduleClick((long)dgLocalDrivingLicenses.CurrentRow.Cells[0].Value, clsTests.TestType.Written);
        }

        private void tsPractical_Click(object sender, EventArgs e)
        {
            onScheduleClick((long)dgLocalDrivingLicenses.CurrentRow.Cells[0].Value, clsTests.TestType.Practical);
        }

        private void tsApplicationDetails_Click(object sender, EventArgs e)
        {
            fmLDLApplicationDetails fm = new fmLDLApplicationDetails((long)dgLocalDrivingLicenses.CurrentRow.Cells[0].Value);
            fm.ShowDialog();
        }

        private void tsDeleteApplication_Click(object sender, EventArgs e)
        {

            if(clsLocalDrivingLicenseApplication.IsRelatedToTest((long)dgLocalDrivingLicenses.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("You Can't Delete This Application");
                return;
            }

            clsLocalDrivingLicenseApplication.Delete((long)dgLocalDrivingLicenses.CurrentRow.Cells[0].Value);
            _LoadLocalDrivingLicenses();
        }

        private void tsCancel_Click(object sender, EventArgs e)
        {
            long ApplicationID = clsLocalDrivingLicenseApplication.Find((long)dgLocalDrivingLicenses.CurrentRow.Cells[0].Value).ApplicationID;
            clsApplications.Cancel(ApplicationID);
            _LoadLocalDrivingLicenses();
        }

        bool _CheckIsCanceled()
        {
            string status = (string)dgLocalDrivingLicenses.CurrentRow.Cells[4].Value;
            if (status== "Canceled")
            {
                return true;
            }
            return false;
        }

        private void tsIssueLocalDrivingLicense_Click(object sender, EventArgs e)
        {
            fmIssueNewLocalDrivingLicense fm = new fmIssueNewLocalDrivingLicense((long)dgLocalDrivingLicenses.CurrentRow.Cells[0].Value);
            fm.ShowDialog();
            _LoadLocalDrivingLicenses();
        }

        private void tsShowLicenseInfo_Click(object sender, EventArgs e)
        {
            fmLocalDrivingLicenseInfo fm = new fmLocalDrivingLicenseInfo((long)dgLocalDrivingLicenses.CurrentRow.Cells[0].Value);
            fm.ShowDialog();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            long PerosnID = clsLocalDrivingLicenseApplication.Find((long)dgLocalDrivingLicenses.CurrentRow.Cells[0].Value).PersonID;
            fmDrivingLicenseHistory fm = new fmDrivingLicenseHistory(PerosnID);



            fm.ShowDialog();
        }
    }
}
