
using BusinessLayer;
using System;
using System.Data;
using System.Threading.Tasks;
using TestBusiness;
using TestsData;


namespace BusinessLayer
{
    public  class clsTests
    {
        public  event Action<bool, long> OnSaveFinish;
        public static event Action<bool> OnUpdateFinish;
        public clsTestType TestTypeInfo { get; private set; }
       public  long TestID { set; get; }
       public  bool Result {  set; get; }
       public  bool IsLocked {  set; get; }
         //  local Driving license application ID
        public  long LDLAID { set; get; }
        public string Notes { set; get; }

        public long PersonID { protected set; get; }
        public enum TestType {Vision=1,Written=2,Practical=3 }
        public clsPerson PersonInfo { protected set; get; }
        public decimal Fees { set; get; }
        public long RetakeTestApplicationId { set; get; }




        public DateTime TestDate { set; get; }

        public long UserID;

        protected clsTests(int TestTypeID)
        {
            TestTypeInfo = clsTestType.Find(TestTypeID);
            TestID = -1;
            this.Fees = (decimal)TestTypeInfo.Fees;
            this.RetakeTestApplicationId = default;

        }

          protected bool  AddNewTest()
        {
            long TestID = 0;
            if (clsTestsData.AddNewTest(ref TestID, LDLAID, TestTypeInfo.ID, TestDate, PersonID,UserID,Fees,RetakeTestApplicationId))
            {
                this.TestID = TestID;
                OnSaveFinish?.Invoke(true, TestID);
                return true;
            }
            // if -1 that means test faild to save 

            OnSaveFinish?.Invoke(false, -1);
            return false;

        }

        public static bool UpdateTestResult(bool Result,long TestID,string Notes)
        {
            if(clsTestsData.UpdateResult(Result, TestID, Notes))
            {
                OnUpdateFinish?.Invoke(true);
                return true;

            }
            OnUpdateFinish?.Invoke(false);
            return false;
        }

        public static bool UpdateTestDate(DateTime TestDate, long TestID)
        {
            if (clsTestsData.UpdateTestDate(TestDate, TestID))
            {
                OnUpdateFinish?.Invoke(true);
                return true;

            }
            OnUpdateFinish?.Invoke(false);
            return false;
        }

        
        public static DataTable FindRelatedTests(long LDLAPPlicatonID,int TestType)
        {
            return clsTestsData.FindRelatedTests(LDLAPPlicatonID, TestType);
        }

        public static bool IsFailBefore(long LDLApplicationID, int TestTypeID)
        {
            return clsTestsData.IsFailBefore(LDLApplicationID, TestTypeID);
        }


        // this is Important if you want to do more thane one thing after finish
        //protected virtual void RaiseSaveFinishEvent(bool success, long recordId)
        //{
        //    OnReleaseFinish?.Invoke(success, recordId); // Raise the event with arguments
        //}

        public static bool IsTestExistsAndNotLocked(long LDLApplicationID, int TestTypeID)
        {
           return clsTestsData.IsTestExistAndNotLocked(LDLApplicationID, TestTypeID);
        }
        public static bool IsPassed(long LDLApplicationID, int TestTypeID)
        {
            return clsTestsData.IsPassed(LDLApplicationID,TestTypeID);
        }

        public static clsTests Find(long TestID)
        {
          short TestTypeID = default;
          bool Result =default;
            bool IsLocke=default;   
            long LDLAID =default;
            string Notes = default;
             //long  applicationID
            long PersonID=default;
            long UserID = default; DateTime TestDate = default;
            decimal Fees=default;
            if (clsTestsData.Find(TestID,ref LDLAID,ref Result,ref IsLocke,ref Notes,ref PersonID,ref TestTypeID,ref UserID,ref TestDate,ref Fees))
                    return new clsTests(TestID, LDLAID, Result, IsLocke, Notes, PersonID,TestTypeID, UserID, TestDate,Fees);
            else
                return null;

        }

      public static byte TotalTrialsPerTest(long LDLAID, int TestTypeID)
        {
            return clsTestsData.TotalTrialsPerTest(LDLAID, TestTypeID);
        }

        private  clsTests(long testID, long lDLAID, bool result, bool isLocke, string notes, long personID,short TestTypeID,long UserID,DateTime TestDate, Decimal Fees )
        {
            this.TestID = testID;
            this.LDLAID = lDLAID;
            this.Notes = notes;
            this.PersonID = personID;
            this.Result= result;
            this.IsLocked = isLocke;
            this.TestTypeInfo =clsTestType.Find(TestTypeID);
            this.TestDate=TestDate;
            this.UserID=UserID;
            this.Fees=Fees; 
            //this.ApplicationID=ApplicationID
        }
    }
}
