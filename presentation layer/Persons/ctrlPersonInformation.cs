using System.Windows.Forms;
using BusinessLayer;

namespace DVLD
{
    public partial class ctrlPersonInformation : UserControl
    {
      
        private clsPerson _Person;
        public clsPerson SelectedPerson
        { 
            get { return _Person; }
        }
        public bool IsSuccessfullyLoad { set; get; }
        private void ImageBoxes()
        {
            picName.Image = PersonInformationImageList.Images[0];
            PicNationalID.Image = PersonInformationImageList.Images[1];
            PicGender.Image = PersonInformationImageList.Images[2];
            picDateofBirth.Image = PersonInformationImageList.Images[3];
            PicPhone.Image = PersonInformationImageList.Images[4];
            PicEmail.Image = PersonInformationImageList.Images[5];
            PicAddrress.Image = PersonInformationImageList.Images[6];
            PicCountryName.Image = PersonInformationImageList.Images[7];
            picPersonImage.Image=Properties.Resources.Male128;
        }
        public long PersonID;
        public ctrlPersonInformation()
        {
            InitializeComponent();
            ImageBoxes();
        }
        private void _ChaneImageBasedOnPersonGender()
        {
            if(char.ToUpper(_Person.Gender)=='M')
            {
                PicGender.Image = PersonInformationImageList.Images[10];
                picPersonImage.Image=Properties.Resources.Male128;
                return;
            }
            PicGender.Image = PersonInformationImageList.Images[2];
            picPersonImage.Image = Properties.Resources.woman128;

        }
        private void _FillPersonData()
        {
            lbPersonID.Text = _Person.PersonID.ToString();
            lbNationalID.Text = _Person.NationalId.ToString();
            lbPersonName.Text = _Person.FullName;
            lbPhoneNuber.Text = _Person.PhoneNumber;
            lbDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lbEmail.Text = _Person.Email;
            lbGender.Text = _Person.Gender.ToString();
            lbCountryNamee.Text = _Person.CountryName;
            lbAddress.Text = _Person.Address;
            _ChaneImageBasedOnPersonGender();
            if (_Person.ImagePath != null)
                picPersonImage.ImageLocation=_Person.ImagePath;
            
        }
        public bool LoadPerson(long NationalID)
        {

            _Person = clsPerson.FindByNationalID( NationalID);
             if(_Person==null)
                return IsSuccessfullyLoad=false;
            _FillPersonData();
            PersonID = _Person.PersonID;
            return IsSuccessfullyLoad = true;
        }
        public void LoadPersonByPersonID(long PersonID)
        {
            _Person = clsPerson.FindByPersonID(PersonID);
                if (_Person == null) return;
            _FillPersonData();
            this.PersonID = _Person.PersonID;
        }

       

        private void _UpdateInformationAfterUpdate(bool result,long LoadPerson)
        {
            if(result)
            {
                this.LoadPerson(LoadPerson);
              
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            fmAddUpdatePerson fmAddUpdate = new fmAddUpdatePerson(_Person.NationalId);
            fmAddUpdate.getNationalID += _UpdateInformationAfterUpdate;
            fmAddUpdate.ShowDialog();
            fmAddUpdate.getNationalID -= _UpdateInformationAfterUpdate;


        }
    }
}
