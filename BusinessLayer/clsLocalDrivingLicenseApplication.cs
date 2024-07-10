using LocalDrivingLicenseData;
using System;
using System.Data;


namespace BusinessLayer
{
    public class clsLocalDrivingLicenseApplication : clsApplications
    {
        public event Action<bool, long> OnSaveFinish;

        private clsLocalDrivingLicenseApplication(long lDLApplicationID, short ClassID, long ApplicationID, enStatusID statusID, long PersonID, DateTime CreationDate, long UserID, decimal Fees) : base(1)
        {

            this.LDLApplicationID = lDLApplicationID;
            LocalDrivingLicenseClass = clsLocalDrivingLicenseClasses.Find(ClassID);
            base.ApplicationID = ApplicationID;
            base.statusID = statusID;
            base.PersonID = PersonID;
            base.CreationDate = CreationDate;
            base.UserID = UserID;
            base.ApplicationFees = Fees;


        }

        public clsLocalDrivingLicenseApplication() : base(1)
        {
            this.LDLApplicationID = default;
            LocalDrivingLicenseClass = null;
            statusID = enStatusID.New;
            ApplicationType = clsApplicationType.Find(1);
        }


        public clsLocalDrivingLicenseClasses LocalDrivingLicenseClass { get; set; }
        public long LDLApplicationID { get; private set; }
        public short NoOfPassedTests
        {
            get
            {
                return (short)clsLocalDrivingLicenseApplicationData.NoOfTestsPassed(LDLApplicationID);
            }
        }

        private bool _CheckConstrains()
        {
            if (IsApplicationExistsAndNotCancelled())
            {
                // -11 means there is an exist application
                ApplicationID = -11;
                OnSaveFinish?.Invoke(false, -11);
                return false;
            }
            TimeSpan span = DateTime.Now - clsPerson.PersonDateOfBirth(PersonID);
            if ((int)(span.TotalDays / 365.25) < LocalDrivingLicenseClass.MinimumAge)
            {
                // -111 Age Prblem
                ApplicationID = -111;
                OnSaveFinish?.Invoke(false, -111);
                return false;
            }
            return true;
        }
        private bool _AddNewLocalDrivingLicense()
        {
            long ID = default;

            if (clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicense(ref ID, LocalDrivingLicenseClass.ID, base.ApplicationID))
            {
                this.LDLApplicationID = ID;
                OnSaveFinish?.Invoke(true, ID);
                return true;
            }
            return false;
        }
        public override bool IsApplicationExistsAndNotCancelled()
        {
            return clsLocalDrivingLicenseApplicationData.ISApplicationIsExistAndNotCancelled(PersonID, (short)LocalDrivingLicenseClass.ID);
        }
        public bool save()
        {
            if (!_CheckConstrains())
            { return false; }
            return (base.Save() && _AddNewLocalDrivingLicense());

        }

        public static DataTable GetAllLocalDrivingLicense()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }
        public static bool UpdateTestsPassed(long LDLID)
        {
            return clsLocalDrivingLicenseApplicationData.UpdateTestPassed(LDLID);
        }


        public static clsLocalDrivingLicenseApplication Find(long LDLAID)
        {

            long lDLApplicationID = LDLAID;
            short ClassID = default;
            long ApplicationID = default;
            short statusID = default;
            long PersonID = default;
            DateTime CreationDate = default;
            long UserID = default;
            decimal Fees = default;
            if (clsLocalDrivingLicenseApplicationData.FindByLDLApplicationID(lDLApplicationID, ref ClassID, ref ApplicationID, ref statusID, ref PersonID, ref CreationDate, ref UserID, ref Fees))
                return new clsLocalDrivingLicenseApplication(lDLApplicationID, ClassID, ApplicationID, (enStatusID)statusID, PersonID, CreationDate, UserID, Fees);
            else
                return null;
        }

        public static bool Delete(long LDLAID)
        {
            long ApplicationID = clsLocalDrivingLicenseApplication.Find(LDLAID).ApplicationID;

            return (clsLocalDrivingLicenseApplicationData.Delete(LDLAID) && DeleteApplication(ApplicationID));

        }
        public static bool IsRelatedToTest(long LDLAID)
        {
            return clsLocalDrivingLicenseApplicationData.IsRelatedToTest(LDLAID);
        }
        public static bool UpdateStatus(long LDLAID, enStatusID StatusID)
        {
            if (StatusID == enStatusID.Canceled && IsRelatedToTest(LDLAID))
            {

                return false;
            }
            return clsLocalDrivingLicenseApplicationData.UpdateStatus(LDLAID, (int)StatusID);
        }

        public long IssueLocalDrivingLicense(long CreatedByUserID, string Notes)
        {
            clsLocalDrivingLicense drivingLicense = new clsLocalDrivingLicense(LDLApplicationID);
            drivingLicense.PersonID = this.PersonID;
            drivingLicense.StatusID = clsLocalDrivingLicense.enLicenseStatus.New;
            drivingLicense.IssueDate = DateTime.Now;
            drivingLicense.ExpirationDate = drivingLicense.IssueDate.AddYears(LocalDrivingLicenseClass.Validity);
            drivingLicense.Fees = LocalDrivingLicenseClass.Fees;
            drivingLicense.Notes = Notes;
            drivingLicense.UserID = CreatedByUserID;
            drivingLicense.ClassID = LocalDrivingLicenseClass.ID;
            if (drivingLicense.Save())
            {
                clsLocalDrivingLicenseApplication.UpdateStatus(LDLApplicationID, clsLocalDrivingLicenseApplication.enStatusID.Completed);
                return drivingLicense.LicenseNumber;


            }
            else
                return -1;

        }


    }
}
