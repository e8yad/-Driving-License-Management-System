using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Persons
{
    public partial class fmMangePeople : Form
    {
        public fmMangePeople()
        {
            InitializeComponent();
        }

    

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            fmAddUpdatePerson fmAdd = new fmAddUpdatePerson(-1);
            fmAdd.ShowDialog();
            ctrlMangePeople1.LoadPersonsInformation();
        }
    }
}
