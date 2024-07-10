using DVLD.Persons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class fmAddUpdatePerson : Form
    {
        bool _SaveResult=false;
        public delegate void GetNationalID(bool Result,long NationalID);
        public GetNationalID getNationalID;
        // you can make to constructor it is better than sent -1    
        public fmAddUpdatePerson(long NationalID)
        {
            InitializeComponent();
            //-1 if add new
            if (NationalID == -1) { this.Text = "Add New Person"; }
            this.Text = "Update Person Information";
            ctrlUpdate_AddPerson1.AddUpdatePerson(NationalID);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ctrlUpdate_AddPerson1.Save();
            if (_SaveResult)
            {
                MessageBox.Show("The Information have been saved successfully");
                btnOK.Enabled = false;
            }
            else
                MessageBox.Show("Check Person Data");
        }


        private void ctrlUpdate_AddPerson1_onSaveFinished(bool result, long NationalID,string oldImagePath)
        {
            _SaveResult = result;
            getNationalID?.Invoke(result,NationalID);
        }
    }
}
