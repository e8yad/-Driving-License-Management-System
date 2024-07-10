using System;
using System.Collections.Generic;
using System.Data;
using PersonsData;
using Users;

namespace BusinessLayer
{
    public class clsPerson
    {
 
        enum en_Mode { AddNew, Update }
        private en_Mode _Mode;
        public long PersonID { get; private set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public long NationalId { get; set; }
        public char Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public ushort CountryId { set; get; }
        public string FullName { get { return string.Format($"{FirstName} {SecondName} {ThirdName} {LastName}"); } }
        public string CountryName { 
            get
            { 
               return clsPersonsData.FindCountryName(CountryId);
            } 
        
        }

        // mapping for mode to call best method for it
        Dictionary<en_Mode, PersonOperationDelegate> _ModeHandler;
        public clsPerson()
        {
            _Mode = en_Mode.AddNew;
            PersonID = -1;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            NationalId = default(long);
            Gender = default;
            PhoneNumber = default(string);
            Email = default(string);
            Address = default(string);
            ImagePath = default(string);
            DateOfBirth = default(DateTime);
            CountryId = default(int);
            this. _ModeHandler = new Dictionary<en_Mode, PersonOperationDelegate>
            {
            {en_Mode.Update,_UpdatePerson},
            {en_Mode.AddNew,_AddNewPerson }
            };


        }

        public clsPerson(long PersonID, string FirstName, string SecondName, string ThirdName, string LastName, long NationalID, Char Gender, DateTime DateOfBirth, String PhoneNumber, string Email, String Address, String ImagePath, ushort CountryID)
        { _Mode = en_Mode.Update;

            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.LastName = LastName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.NationalId = NationalID;
            this.Gender = Gender;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.Address = Address;
            this.ImagePath = ImagePath;
            this.DateOfBirth = DateOfBirth;
            this.CountryId = CountryID;
            this._ModeHandler = new Dictionary<en_Mode, PersonOperationDelegate>
            {
            {en_Mode.Update,_UpdatePerson},
            {en_Mode.AddNew,_AddNewPerson }
            };
        }


        public static clsPerson FindByNationalID(long NationalID)
        {
            long PersonID = default;
            string FirstName = string.Empty;
            string SecondName = string.Empty;
            string ThirdName = string.Empty;
            string LastName = string.Empty;
            char Gender = default;
            string PhoneNumber = default(string);
            string Email = default(string);
            string Address = default(string);
            string ImagePath = default(string);
            DateTime DateOfBirth = default(DateTime);
            ushort CountryID = default;
            if (clsPersonsData.FindByNationalID(NationalID, ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref Gender, ref LastName, ref DateOfBirth, ref PhoneNumber, ref CountryID, ref Email, ref ImagePath, ref Address))
            {
                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName, NationalID, Gender, DateOfBirth, PhoneNumber, Email, Address, ImagePath, CountryID);
            }
            return null;
        }
        public static clsPerson FindByPersonID(long PersonID)
        {
            long NationalID = default;
            string FirstName = string.Empty;
            string SecondName = string.Empty;
            string ThirdName = string.Empty;
            string LastName = string.Empty;
            char Gender = default;
            string PhoneNumber = default(string);
            string Email = default(string);
            string Address = default(string);
            string ImagePath = default(string);
            DateTime DateOfBirth = default(DateTime);
            ushort CountryID = default;
            if (clsPersonsData.FindByPersonID(PersonID, ref NationalID , ref FirstName, ref SecondName, ref ThirdName, ref Gender, ref LastName, ref DateOfBirth, 
                ref PhoneNumber, ref CountryID, ref Email, ref ImagePath, ref Address))
            {
                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName, NationalID, Gender, DateOfBirth, PhoneNumber, Email, Address, ImagePath, CountryID);
            }
            return null;
        }

        public static bool IsPersonExists(long NationalID)
        {
            return clsPersonsData.IsPersonExist(NationalID);
        }

        public static bool DeletePerson(long PersonId)
        {
            if(!clsUser.IsUserExist(PersonId)) 
            {
                return false;
            }
            return clsPersonsData.DeletePerson(PersonId);
        }

 
        // this is very dynamic way of save 
        // using delegate 
        // save function is very extendable 
        private delegate bool PersonOperationDelegate();
        public bool SavePerson()
        {
            // in Add new mode if save is success you can access Person LDLApplicationID 
            //else Person not saved
           if(_ModeHandler.ContainsKey(_Mode))
                return _ModeHandler[_Mode]();
           else return false;
        }

        private  bool _UpdatePerson()
        {
            return clsPersonsData.UpdatePerson(PersonID, NationalId, FirstName, SecondName,ThirdName, Gender, LastName, DateOfBirth, PhoneNumber, CountryId, Email, ImagePath, Address);
        }

        private  bool _AddNewPerson()
        {
            long PersonID = default;
             clsPersonsData.AddNewPerson(ref PersonID, NationalId, FirstName, SecondName, ThirdName, Gender, LastName, DateOfBirth, PhoneNumber, CountryId, Email, ImagePath, Address);
            this.PersonID= PersonID; 
            return PersonID != -1;

        }

        public static  DataTable GetAllPersons()
        {
            return clsPersonsData.GetAllPersons();
        }
        public static DataTable GetAllCountries()
        {
            return clsPersonsData.GetAllCountryName();
        }
      public static bool IsPersonExist(long NatinalID)
      {
            return clsPersonsData.IsPersonExist(NatinalID);
      }
        public static bool IsNameExist(string FirstName, string SecondName, string ThirdName, string lastName)
        {
            return clsPersonsData.ISFullNameExists(FirstName, SecondName, ThirdName, lastName);
        }

        public static DateTime PersonDateOfBirth(long PersonID)
        {
            return clsPersonsData.GetDateOfBirth(PersonID);
        }

    }
}
