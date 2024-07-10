using System;
using System.Windows.Forms;
using System.IO;
using BusinessLayer;
using Utility;
namespace DVLD.Persons
{

    public partial class ctrlUpdate_AddPerson : UserControl
    {
        private string _oldImage = null;
        public long PersonID;
        private enum enMode { Update, AddNew};
        private enMode _mode {  set; get; }
        public delegate void SaveFinished(bool result,long NatioinalID,string OldImagePath);
        public event SaveFinished onSaveFinished;
        clsPerson _person;



        public ctrlUpdate_AddPerson()
        {
            InitializeComponent();
            ImageBoxes();
            _LoadCountry();
            cmbCountry.SelectedIndex = 50;
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
        }
        

        private void ImageBoxes()
        {
            picName.Image = PersonInformationImageList.Images[0];
            PicNationalID.Image = PersonInformationImageList.Images[1];
            PicGender.Image = PersonInformationImageList.Images[9];
            picDateofBirth.Image = PersonInformationImageList.Images[3];
            PicPhone.Image = PersonInformationImageList.Images[4];
            PicEmail.Image = PersonInformationImageList.Images[5];
            PicAddrress.Image = PersonInformationImageList.Images[6];
            PicCountryName.Image = PersonInformationImageList.Images[7];
            picPersonPicture.Image =  (rdFemale.Checked) ? Properties.Resources.woman128 : Properties.Resources.Male128; ;
            picPersonPicture.Tag = "Default";
        }

        private bool _HandelImage()
        {
            if (_person.ImagePath != picPersonPicture.ImageLocation)
            {
                // update remove for Picture  
                if (!string.IsNullOrEmpty(_person.ImagePath))
                {
                    try
                    {
                        File.Delete(_person.ImagePath);

                    }
                    catch (Exception)
                    {

                        throw;
                 
             
                    }

                }


            }

            if(picPersonPicture.ImageLocation!=null)
            {
                string NewImageLocation = picPersonPicture.ImageLocation;
                if (clsUtil.CopyImageToFileAndNameWithGuid(ref NewImageLocation))
                {
                    _person.ImagePath = NewImageLocation;
                }
                else
                    return false;
            }
            return true;
        }


            // NationalID   PersonID
        public void AddUpdatePerson(long NationalID)
        {
            rdMale.Checked = true;
            llbRemoveImage.Visible = false;
            if (NationalID != -1)
                _mode=enMode.Update;
            else
            _mode=enMode.AddNew;
            
            if (_mode==enMode.AddNew)
            {
                groupBox1.Text = "Add New Person";
                
                _person = new clsPerson();
                
                return;
            }
           _person = clsPerson.FindByNationalID(NationalID);
            if( _person == null )
            {
   
                return;
            }
            _Load(_person);
        }
        public void UpdatePerson(long PersonID)
        {
            if (_person != null)
            {

                return;
            }
            _person =clsPerson.FindByPersonID(PersonID);
            _Load(_person);
        }
        private void _Load(clsPerson _Person)
        {
            if (_person == null)
                return;
            groupBox1.Text = "Update Person";
            lbPersonIDValue.Text = _person.PersonID.ToString();
            txtNationalID.Text = _person.NationalId.ToString();
            txtFirstName.Text = _person.FirstName;
            txtSecondName.Text = _person.SecondName;
            txtThirdName.Text = _person.ThirdName;
            txtLastName.Text = _person.LastName;
            txtEmail.Text = _person.Email;
            txtPhoneNumber.Text = _person.PhoneNumber;
            txtAddress.Text = _person.Address;
            cmbCountry.SelectedIndex = (int)_person.CountryId - 1;
            dtpDateOfBirth.Value = _person.DateOfBirth;
            if (char.ToUpper(_person.Gender) == 'M')
                rdMale.Checked = true;
            else
                rdFemale.Checked = true;

            if (_person.ImagePath != null) { picPersonPicture.ImageLocation=_person.ImagePath; llbRemoveImage.Visible = true; }
            PersonID = _person.PersonID;
        }

        public bool Save()
        {
            // you must write easeast first
           if(!_CheckInputData())
                return false;

            if (_mode == enMode.AddNew&&clsPerson.IsNameExist(txtFirstName.Text, txtSecondName.Text, txtThirdName.Text, txtLastName.Text))
                return false;

            _person.NationalId = Convert.ToInt64(txtNationalID.Text);
            _person.FirstName = txtFirstName.Text;
            _person.SecondName = txtSecondName.Text;
            _person.ThirdName=txtThirdName.Text;
            _person.LastName = txtLastName.Text;
            _person.Email = txtEmail.Text;
            _person.PhoneNumber = txtPhoneNumber.Text;
            _person.Address = txtAddress.Text;
            _person.DateOfBirth = dtpDateOfBirth.Value;
            _person.CountryId = (ushort)(cmbCountry.SelectedIndex+1);
            _person.Gender = (rdMale.Checked) ? 'M' : 'F';
            if (!_HandelImage())
                return false;
            bool result= _person.SavePerson();
            if (result)
            {
                lbPersonIDValue.Text = _person.PersonID.ToString();
            }
                onSaveFinished?.Invoke(result, _person.NationalId,_oldImage);
            
            return result; 

        }

      
        private void llbAddImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (picPersonPicture.ImageLocation != null)
                { _oldImage = picPersonPicture.ImageLocation; _person.ImagePath = null;}
                string SelectedFile = openFileDialog1.FileName;
                picPersonPicture.ImageLocation=SelectedFile;
                picPersonPicture.Tag = "Update";
                llbRemoveImage.Visible = true;
                 

            }
        }

        private void llbRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            picPersonPicture.Image.Dispose();
            picPersonPicture.Tag = "Remove";
            picPersonPicture.Image = rdFemale.Checked? Properties.Resources.woman128: Properties.Resources.Male128;
            llbRemoveImage.Visible = false;
            _oldImage = _person.ImagePath;
            _person.ImagePath = null;
            GC.Collect();

        }

        private void _LoadCountry()
        {

            cmbCountry.DisplayMember = "CountryName";
            cmbCountry.DataSource = clsPerson.GetAllCountries();
        }

        private void txtNationalID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
          if(!long.TryParse(txtNationalID.Text, out _))
          {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalID, "National ID Must Be A Number");
                return;
          }
            
            if(_mode==enMode.AddNew&&clsPerson.IsPersonExist(Convert.ToInt64(txtNationalID.Text))) 
            {
                e.Cancel=true;
                errorProvider1.SetError(txtNationalID, "This National Id Is Exist");
                return ;
            }

            errorProvider1.SetError(txtNationalID, null);
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
                return;
            
            if(txtEmail.Text.IndexOf(".com")==-1|| txtEmail.Text.IndexOf("@")==-1)
            {
                e.Cancel = true ;
                errorProvider1.SetError(txtEmail, "Please Enter A Correct Email");
                return;

            }
            errorProvider1.SetError(txtEmail, null) ;
        }

        private void rdFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdFemale.Checked)
            { PicGender.Image = PersonInformationImageList.Images[2];
  
            }
            else
            PicGender.Image = PersonInformationImageList.Images[9];

            if(_person.ImagePath==null)
                picPersonPicture.Image = (rdFemale.Checked)? Properties.Resources.woman128 : Properties.Resources.Male128;

           
        }

        private void txtNationalID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar))
            {
                if ((Keys)e.KeyChar == Keys.Back)
                    return;
                e.Handled = true ;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void _HandelNamePress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                if ((Keys)e.KeyChar == Keys.Back)
                    return;
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }


        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            _HandelNamePress(sender, e);
        }

        private void txtSecondName_KeyPress(object sender, KeyPressEventArgs e)
        {
            _HandelNamePress(sender, e);
        }

        private void txtThirdName_KeyPress(object sender, KeyPressEventArgs e)
        {
            _HandelNamePress(sender, e);
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            _HandelNamePress(sender, e);
        }

        private bool _CheckInputData()
        {
            if(string .IsNullOrEmpty(txtNationalID.Text))
            {
                errorProvider1.SetError(txtNationalID, "You Must Enter National ID");
                return false;
            }
            errorProvider1.SetError(txtNationalID, null);
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                errorProvider1.SetError(txtFirstName, "You Must Enter First Name ");
                return false;
            }
            errorProvider1.SetError(txtFirstName, null);
            if (string.IsNullOrEmpty(txtSecondName.Text))
            {
                errorProvider1.SetError(txtSecondName, "You Must Enter Second Name");
                return false;
            }
            errorProvider1.SetError(txtSecondName, null);

            if (string.IsNullOrEmpty(txtThirdName.Text))
            {
                errorProvider1.SetError(txtThirdName, "You Must Enter Third Name ");
                return false;
            }
            errorProvider1.SetError(txtThirdName, null);

            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                errorProvider1.SetError(txtLastName, "You Must Enter Last Name ");
                return false;
            }
            errorProvider1.SetError(txtLastName, null);

            return true;

        }


    }
}
