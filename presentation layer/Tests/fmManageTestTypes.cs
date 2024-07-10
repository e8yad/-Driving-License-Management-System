using ApplicationsBusiness;
using DVLD.Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestBusiness;

namespace DVLD.Tests
{
    public partial class fmManageTestTypes : Form
    {
        public fmManageTestTypes()
        {
            InitializeComponent();
            _Load();
        }



        DataTable dt = default;
     
        private void _Load()
        {
            dt = clsTestType.GetAllTypes();
            dgMangeApplicationTypes.DataSource = dt;
        }

        private void updateApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmUpdateTestType fm = new fmUpdateTestType((int)dgMangeApplicationTypes.CurrentRow.Cells[0].Value);
            fm.ShowDialog();
            _Load();

        }
    }
}
