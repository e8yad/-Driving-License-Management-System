using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DVLD.Applications;
using BusinessLayer;

namespace DVLD.DetainedLicenses
{
    public partial class fmMangeDetainedLicense : Form
    {
        private DataTable DetainedLicensesInfo=null;
        public fmMangeDetainedLicense()
        {
            InitializeComponent();
            LoadDetainedLicensesInfo();
        }

        private void LoadDetainedLicensesInfo()
        {
            DetainedLicensesInfo=clsDetainedLicense.GetAllDetainedLicenses();
            dgManageDetainedLicenses.DataSource= DetainedLicensesInfo;
        }
        private void Filter()
        {
            if (DetainedLicensesInfo.Rows.Count == 0)
                return;
   
            DataView dv= DetainedLicensesInfo.DefaultView;
            dv.RowFilter = $"Convert(LicenseNumber, System.String)LIKE '" +$"{txtFilterBY.Text}%'";

        }

        private void txtFilterBY_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void txtFilterBY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar))
            {
                if((Keys)e.KeyChar==Keys.Back)
                { return; }
                e.Handled = true;
                System.Media.SystemSounds.Hand.Play();
            
            }
           
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            fmRelease_DetainLicense fm = new fmRelease_DetainLicense(fmRelease_DetainLicense.enMode.Release);
            fm.ShowDialog();
            LoadDetainedLicensesInfo();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {


            fmRelease_DetainLicense fm = new fmRelease_DetainLicense(fmRelease_DetainLicense.enMode.Detain);
            fm.ShowDialog();
            LoadDetainedLicensesInfo();
            
        }
        private void _onContextClick(object sender)
        {
            ((Form)(sender)).ShowDialog();
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgManageDetainedLicenses.Rows.Count == 0)
            {
                tsReleaseLicesne.Enabled = tsShowLicense.Enabled = false;
                return;
            }

            tsReleaseLicesne.Enabled = (bool)dgManageDetainedLicenses.CurrentRow.Cells[6].Value;



        }

        private void tsShowLicense_Click(object sender, EventArgs e)
        {
            _onContextClick(new fmLocalDrivingLicenseInfo((long)dgManageDetainedLicenses.CurrentRow.Cells[1].Value, true));
        }

        private void tsReleaseLicesne_Click(object sender, EventArgs e)
        {
            _onContextClick(new fmRelease_DetainLicense(fmRelease_DetainLicense.enMode.Release,
                (long)dgManageDetainedLicenses.CurrentRow.Cells[1].Value));
        }
    }
}
