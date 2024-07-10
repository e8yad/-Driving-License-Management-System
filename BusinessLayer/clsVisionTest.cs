
using BusinessLayer;
using System;

namespace BusinessLayer
{
    public class clsVisionTest:clsTests
    {

       public clsVisionTest(long LDLAID,long PersonID, DateTime TestDate, long UserID, long RetakeTestAppID) :base(1)
       {
            this.IsLocked = false;
            this.LDLAID = LDLAID;
            this.Notes = null;
            this.PersonID = PersonID;
            this.TestDate = TestDate;
            this.UserID = UserID;
            this.RetakeTestApplicationId = RetakeTestAppID;
            this.PersonInfo = clsPerson.FindByPersonID(this.PersonID);

        }


        public bool AddNewVisionTest()
        {
            return base.AddNewTest();
        }
    }
}
