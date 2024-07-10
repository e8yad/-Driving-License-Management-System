using System;
using System.Data;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.Persons
{
    public partial class ctrlMangePeople : UserControl
    {
        private DataTable dtPersons;

        public ctrlMangePeople()
        {
            InitializeComponent();
            dtPersons= clsPerson.GetAllPersons();
            cmbFilterBy.SelectedIndex = 0;
            txtFilterBy.Visible= false; 
            LoadPersonsInformation();
        }


        public void LoadPersonsInformation()
        {
            dtPersons = clsPerson.GetAllPersons();
            DataView FullView= dtPersons.DefaultView;
            dgManegePeoble.DataSource = FullView;
            lbCount.Text= FullView.Count.ToString();
        }
     
        private void Filter(string FilterBy,string Value)
        {
            DataView PersonsFilterByFirstName = dtPersons.DefaultView;
            if (FilterBy == "NationalID")
                // to avoid numerical error
                PersonsFilterByFirstName.RowFilter = "Convert( NationalID , 'System.String')"+ " like '" + Value + "%'";
            else
                PersonsFilterByFirstName.RowFilter = FilterBy + " like '" + Value + "%'";
            
            dgManegePeoble.DataSource = PersonsFilterByFirstName;
            lbCount.Text = PersonsFilterByFirstName.Count.ToString();
        }
      

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilterBy.Visible = !(cmbFilterBy.SelectedIndex == 0);
            if (cmbFilterBy.SelectedIndex == 6)
                txtFilterBy.MaxLength = 1;
            else
                txtFilterBy.MaxLength = 50;



        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (cmbFilterBy.SelectedItem.ToString() == null)
                return;
            Filter(cmbFilterBy.SelectedItem.ToString(), txtFilterBy.Text);
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilterBy.SelectedIndex > 1 && cmbFilterBy.SelectedIndex <=6)
            {
                if ((!char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Space) && (e.KeyChar != (char)Keys.Back))
                {
                    // If not, prevent the input and play a beep sound
                    e.Handled = true;
                    System.Media.SystemSounds.Hand.Play();
              
                }return;
            }
            

            if(cmbFilterBy.SelectedIndex==1)
            {
                if ((char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Space) && (e.KeyChar != (char)Keys.Back))
                {
                    // If not, prevent the input and play a beep sound
                    e.Handled = true;
                    System.Media.SystemSounds.Hand.Play();
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            fmPersonInformation fmPersonInformation = new fmPersonInformation((long)dgManegePeoble.CurrentRow.Cells[1].Value);
            fmPersonInformation.ShowDialog();
            LoadPersonsInformation();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            fmAddUpdatePerson fmUpdatePerson = new fmAddUpdatePerson((long)dgManegePeoble.CurrentRow.Cells[1].Value);
            fmUpdatePerson.ShowDialog();
            LoadPersonsInformation();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            fmAddUpdatePerson fmAdd = new fmAddUpdatePerson(-1);
            fmAdd.ShowDialog();
            LoadPersonsInformation();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            // check first person is not linked with other user
            if(!clsPerson.DeletePerson((long)dgManegePeoble.CurrentRow.Cells[0].Value))
             {
                MessageBox.Show("You Cannot Delete this Person as he connected to a user");
                return;
            }
            LoadPersonsInformation();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(dgManegePeoble.CurrentRow.Selected)
                Clipboard.SetText(string.Format("NationalID:{0} PhoneNumber:{1}",dgManegePeoble.CurrentRow.Cells[1].Value,dgManegePeoble.CurrentRow.Cells[8].Value));
            if (dgManegePeoble.CurrentCell != null)
                Clipboard.SetText(dgManegePeoble.CurrentCell.Value.ToString());
        }
    }
}
