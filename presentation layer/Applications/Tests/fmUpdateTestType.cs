using System;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.Tests
{
    public partial class fmUpdateTestType : Form
    {
        private clsTestType _TestType;
        public fmUpdateTestType(int ID)
        {
            InitializeComponent();
            _TestType = clsTestType.Find(ID);
            txtFees.Text = _TestType.Fees.ToString();
            txtTitle.Text = _TestType.Title;
            lbID.Text = _TestType.ID.ToString();
            txtDescription.Text = _TestType.Description;
        }

        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter((char)e.KeyChar))
            {
                if ((Keys)e.KeyChar == Keys.Escape || (Keys)e.KeyChar == Keys.Back || (Keys)e.KeyChar == Keys.Space)
                    return;
                e.Handled = true;
                System.Media.SystemSounds.Asterisk.Play();
            }
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!long.TryParse(e.KeyChar.ToString(), out _))
            {
                if ((Keys)e.KeyChar == Keys.Escape || (Keys)e.KeyChar == Keys.Back || (Keys)e.KeyChar == Keys.Decimal || e.KeyChar == '.')
                    return;
                e.Handled = true;
                System.Media.SystemSounds.Asterisk.Play();
            }
        }

        private bool _CheckInput()
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                errorProvider1.SetError(txtTitle, "This Can Not Be Empty");
                return false;
            }
            else if (!float.TryParse(txtFees.Text, out _))
            {
                errorProvider1.SetError(txtFees, "This Must Be Numbers Only");
                return false;
            }
            return true;


        }
        private void _Save()
        {
            if (!_CheckInput())
                return;

            _TestType.Title = txtTitle.Text;
            _TestType.Fees = Convert.ToSingle(txtFees.Text);
            if (string.IsNullOrEmpty(txtDescription.Text))
                _TestType.Description = null;
            else
            _TestType.Description = txtDescription.Text;
            if (_TestType.Save())
            {
                MessageBox.Show("New Information Saved Successfully");

            }
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }
    }
}
