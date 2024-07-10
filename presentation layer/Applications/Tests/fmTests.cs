using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BusinessLayer;

using static TestsBusiness.clsTests;

namespace DVLD.Applications.Tests
{
    public partial class fmTests : Form
    {
        public fmTests(clsTests.TestType TestType ,long LDLAID, bool IsFailBefore)
        {
            InitializeComponent();
           ctrlTestInfo1.AddNewTest(TestType,-1,LDLAID,IsFailBefore);

        }

        private void onSaveFinish(bool Result, long TestID)
        {
            if (Result)
            {
                MessageBox.Show("Saved!");

            }
            else
            {
                MessageBox.Show("NotSaved!");
            }
            ctrlTestInfo1.OnSaveFinish -= onSaveFinish;
            this.Close();
        }


        private void _Save()
        {
            ctrlTestInfo1.OnSaveFinish += onSaveFinish;
            ctrlTestInfo1.Save();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }
    }
}
