using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD.Applications
{
    public partial class fmManageApplicationTypes : Form
    {
        DataTable dt= default;
        public fmManageApplicationTypes()
        {
            InitializeComponent();
            _Load();
        }

        private void _Load()
        {
            dt = clsApplicationType.GetAllTypes();
            dgMangeApplicationTypes.DataSource = dt;
        }

        private void updateApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmUpdateApplicationTypes fm = new fmUpdateApplicationTypes((int)dgMangeApplicationTypes.CurrentRow.Cells[0].Value);
            fm.ShowDialog();
            _Load();

        }
    }
}
