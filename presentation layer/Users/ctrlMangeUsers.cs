using System;
using System.Data;
using System.Windows.Forms;
using BusinessLayer;
using Users;

namespace DVLD.Users
{
    public partial class ctrlMangeUsers : UserControl
    {
        private DataTable _Users;
        public ctrlMangeUsers()
        {
            InitializeComponent();
            LoadUsers();
            cmbFilterBy.SelectedIndex = 0;
            cmActiveStatus.Visible = false;
        }
        public void LoadUsers()
        {
            _Users=clsUser.GetAllUsers();
            dgUsers.DataSource = _Users;
           
        }

        private void FilterBy(string FilterBy,string Value)
        {
            DataView filterUser = _Users.DefaultView;

            filterUser.RowFilter= $"Convert( {FilterBy},'System.String')" + " like '" + Value + "%'";
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterBy.SelectedIndex == 0)
            {LoadUsers(); }
            txtFilterValue.Visible = (cmbFilterBy.SelectedIndex != 0 && cmbFilterBy.SelectedIndex != 4);
            cmActiveStatus.Visible = (cmbFilterBy.SelectedIndex == 4);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            FilterBy(cmbFilterBy.SelectedItem.ToString(), txtFilterValue.Text);
        }

        private void cmActiveStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
           DataView view= _Users.DefaultView;
            view.RowFilter = $"IsActive={cmActiveStatus.SelectedIndex}";
            
            
        }
        private void txtFilterValue_KeyDown(object sender, KeyEventArgs e)
        {
        
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((cmbFilterBy.SelectedIndex == 3) && (!char.IsLetter((char)e.KeyChar))&&!((Keys)e.KeyChar==Keys.Back))
            //{
            //    e.Handled = true;
            //    System.Media.SystemSounds.Hand.Play();

            //}


            if((cmbFilterBy.SelectedIndex==1|| cmbFilterBy.SelectedIndex==2)&&!(int.TryParse(e.KeyChar.ToString(),out _)))
            {
                if (((Keys)e.KeyChar == Keys.Back))
                    return;
                e.Handled = true;
                System.Media.SystemSounds.Hand.Play();
            }

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmUpdateUserInformation fm = new fmUpdateUserInformation((long)dgUsers.CurrentRow.Cells[1].Value, (long)dgUsers.CurrentRow.Cells[0].Value);
            fm.ShowDialog();
            LoadUsers();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            fmAddNewUser fmAddNewUser = new fmAddNewUser();
               fmAddNewUser.ShowDialog();
               LoadUsers();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmAddNewUser fmAddNewUser1 = new fmAddNewUser(); 
            fmAddNewUser1.ShowDialog();
            LoadUsers();
        }

        private void changeUserPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmChangeUserPassword fm=new fmChangeUserPassword((long)dgUsers.CurrentRow.Cells[0].Value);
            fm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure You Want To Delete This User ?","?",MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                if(clsUser.DeleteUser((long)dgUsers.CurrentRow.Cells[0].Value))
                {
                MessageBox.Show("User Deleted Successfully", "?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                }  
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgUsers.CurrentRow.Selected)
                return;
            if (dgUsers.CurrentCell != null)
                Clipboard.SetText(dgUsers.CurrentCell.Value.ToString());
        }
    }
}
