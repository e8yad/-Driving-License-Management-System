using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class fmUserInformation : Form
    {
        public fmUserInformation(long UserID)
        {
            InitializeComponent();
           ctrlShowUserInformation1.LoadUserInformation(14);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
