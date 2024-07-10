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
    public partial class fmCurrentUserInfo : Form
    {
        public fmCurrentUserInfo(long UserID)
        {
            InitializeComponent();
            ctrlShowUserInformation1.LoadUserInformation(UserID);
        }
    }
}
