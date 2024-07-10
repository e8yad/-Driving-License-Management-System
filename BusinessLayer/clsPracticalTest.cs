
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsPracticalTest:clsTests
    {

        public clsPracticalTest(long LDLAID, long PersonID,DateTime TestDate,long UserID, long RetakeTestAppID) : base(3)
        {

            this.TestID = -1;
            this.IsLocked = false;
            this.LDLAID = LDLAID;
            this.Notes = null;
            this.PersonID = PersonID;
            this.TestDate = TestDate;
            this.UserID = UserID;
            this.RetakeTestApplicationId = RetakeTestAppID;
            this.PersonInfo=clsPerson.FindByPersonID(this.PersonID);


        }
        public bool AddNewPracticalTest()
        {
            return base.AddNewTest();
        }

         
    }
}
