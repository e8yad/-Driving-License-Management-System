using System;
using System.Windows.Forms;
using BusinessLayer;


namespace DVLD.Persons
{
    public partial class ctrlFindPerson : UserControl
    {
        public delegate void FindPerson(bool Result, long NationalID, long PersonID);
        public event FindPerson OnFindPerson;
        public clsPerson SelectedPerson
        {
            get
            {
                return ctrlPersonInformation1.SelectedPerson;
            }
        }
        public ctrlFindPerson()
        {
            InitializeComponent();
            cmbFIlterBy.SelectedIndex = 0;
            ctrlPersonInformation1.Visible = false;
        }
        private void _AddNewPerson()
        {
            fmAddUpdatePerson fm = new fmAddUpdatePerson(-1);
            fm.getNationalID += GetNationID;
            fm.ShowDialog();
            ctrlPersonInformation1.LoadPerson(long.Parse(txtInput.Text));
        }

        private void GetNationID(bool Result, long NationalID)
        {
            if (!Result)
            {
                MessageBox.Show("Error!");
                OnFindPerson?.Invoke(false, -1,-1);
                return;
                

            }
            txtInput.Text = NationalID.ToString();
            ctrlPersonInformation1.LoadPerson(NationalID);
            OnFindPerson?.Invoke(true, NationalID, ctrlPersonInformation1.PersonID);

        }


        private void _FindPerson()
        {
            if (txtInput.Text == string.Empty)
            { errorProvider1.SetError(txtInput, "National ID Can Not Be Empty"); return; }
            errorProvider1.SetError(txtInput, null);
            bool result = long.TryParse(txtInput.Text, out long NationalID);
            if (!result)
            {
                OnFindPerson?.Invoke(false, -1,-1);
                return;
            }

            if (clsPerson.IsPersonExist(NationalID))
            {
                ctrlPersonInformation1.LoadPerson(Convert.ToInt64(txtInput.Text));
                ctrlPersonInformation1.Visible = true;
               
                OnFindPerson?.Invoke(true, NationalID, ctrlPersonInformation1.PersonID);
            }
            else
            {
                if (MessageBox.Show("Person Not Found Do You Want To Add New person?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _AddNewPerson();
                }
            }
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!long.TryParse(e.KeyChar.ToString(), out _))

            {
                if((Keys)e.KeyChar==Keys.Enter)
                    btnFind.PerformClick();
            
                if ((Keys)e.KeyChar == Keys.Back)
                    return;
                e.Handled = true;
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            //if ((Keys)e.KeyChar == Keys.Enter)
            //{
            //    _FindPerson();
            //}
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            _FindPerson();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }

    }
}
