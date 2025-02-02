﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalDrivingLicense;
using InternationalDrivingLicense;
namespace DVLD.Applications
{
    public partial class fmDrivingLicenseHistory : Form
    {
        public fmDrivingLicenseHistory(long NationalID)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            ctrlPersonInformation1.LoadPerson(NationalID);
            dgLDL.DataSource=clsLocalDrivingLicense.GetAllLocalDrivingLicensesRelatedToPersonByNationalID(NationalID);
            dgIDL.DataSource=clsInternationalDrivingLicense.GetAllIDLRelatedToPersonByNationalID(NationalID);
         
        }

        public fmDrivingLicenseHistory(long PersonID,bool x=true)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            tabPage2.Hide();
           
            ctrlPersonInformation1.LoadPersonByPersonID(PersonID);
            dgLDL.DataSource = clsLocalDrivingLicense.GetAllLocalDrivingLicensesRelatedToPersonByPersonID(PersonID);
            // dgIDL.DataSource = clsInternationalDrivingLicense.GetAllIDLRelatedToPersonByPersonID(PersonID);

        }
    }
}
