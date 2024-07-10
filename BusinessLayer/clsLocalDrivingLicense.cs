using LocalDrivingLicenseData;
using System;
using System.Data;

namespace BusinessLayer
{
    public class clsLocalDrivingLicense
    {
        public enum enLicenseStatus { New=1 ,Renew=2 , ReplacementForDamage=3, ReplacementForLost=4 }
        public long LicenseNumber { set; get; }
        public long LocalDrivingLicenseApplicationID { get;  set; }
        public DateTime IssueDate { get;  set; }
        public DateTime ExpirationDate { get;  set; }
        public Decimal Fees {  get;  set; }
        //public long PaymentID{set;get;}
        public string Notes {  get; set; }

        public enLicenseStatus StatusID {  get;  set; }

        
        public enum enClassID { Class1=1, Class2 ,Class3,Class4,Class5,Class6,Class7}

        public long UserID { get; set; }
        public int ClassID {  get; set; }
        public bool IsActive { get; set; }

        public bool IsDetained {  get; set; }

        public long DriverID {  get; set; }

        public long PersonID { get; set; }

        public clsDriver DriverInfo { get; set; }


        public clsLocalDrivingLicenseClasses DriverClassesInfo { get; set; }

        public clsDetainedLicense DetainedLicenseInfo { get; private set; }

        public clsLocalDrivingLicense(long LDLID)
        {
            this.LicenseNumber = -1;
            PersonID = default;
            LocalDrivingLicenseApplicationID = LDLID;
            IssueDate = default;
            ExpirationDate = default;
            Fees = default;
            Notes = null;
            StatusID = default;
            UserID = default;
            ClassID = default;
            IsActive = true;
            IsDetained = false;
            DriverInfo = null;
        }
      
        private clsLocalDrivingLicense(long LicenseNumber,long LDLAID, DateTime issueDate, DateTime expirationDate, decimal fees, string notes, enLicenseStatus statusID,
            long userID, long personID,int ClassID,bool IsActive,bool IsDetained,long DriverID)
        {
            this.LicenseNumber = LicenseNumber;
            LocalDrivingLicenseApplicationID = LDLAID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Fees = fees;
            Notes = notes;
            StatusID = statusID;
            UserID = userID;
            this.ClassID = ClassID;
            this.IsActive = IsActive;
            this.IsDetained = IsDetained;
            this.DriverID = DriverID;
            DriverInfo =clsDriver.Find(DriverID);
            this.PersonID=DriverInfo.PersonID;
            DriverClassesInfo = clsLocalDrivingLicenseClasses.Find(ClassID);
            DetainedLicenseInfo=clsDetainedLicense.Find(LicenseNumber);
            //PyamentID=paymentID
        }

        public static DataTable GetAllLocalDrivingLicensesRelatedToPersonByPersonID(long PersonID)
        {
            return clsLocalDrivingLicenseData.GetAllLocalDrivingLicensesRelatedToPersonByPersonID(PersonID);
        }
        public static DataTable GetAllLocalDrivingLicensesRelatedToPersonByNationalID(long NationalID)
        {
            return clsLocalDrivingLicenseData.GetAllLocalDrivingLicensesRelatedToPersonByNationalID(NationalID);
        }

        public static bool UpdateLicenseStatus(long LicenseNumber,int StatusID)
        {
            return clsLocalDrivingLicenseData.UpdateDrivingLicenseStatus(LicenseNumber, StatusID);
        }
        public static clsLocalDrivingLicense FindByLicenseNumber(long LicenseNumber)
        {
            long LDLAID = default; DateTime issueDate = default; DateTime expirationDate = default; decimal fees = default; string notes = default;
            int statusID = default; long userID = default; long personID = default;
            int ClassID = default;
            bool IsActive = default;
            bool IsDetained = default;
            long DriverID = default;


            if (clsLocalDrivingLicenseData.FindByLicenseNumber(LicenseNumber,ref LDLAID,ref issueDate,ref expirationDate, ref fees,ref notes,ref statusID,ref userID,
                ref personID,ref ClassID, ref IsActive, ref IsDetained, ref DriverID))
                return new clsLocalDrivingLicense(LicenseNumber, LDLAID, issueDate, expirationDate, fees, notes, (enLicenseStatus)statusID, userID, personID,
                    ClassID, IsActive, IsDetained, DriverID );
            else return null;
        }
        public static clsLocalDrivingLicense FindByNationalID(long NationalID)
        {
            long LicenseNumber=default;
            long LDLAID = default; DateTime issueDate = default; DateTime expirationDate = default; decimal fees = default; string notes = default;
            int statusID = default; long userID = default; long personID = default;
            int ClassID=default;
            bool IsActive  = default;
            bool IsDetained = default;
            long DriverID=default;


            //statusID i send to database id but in class it is converted to enstatus


            if (clsLocalDrivingLicenseData.FindByPersonNationalID(NationalID, ref LicenseNumber, ref LDLAID, ref issueDate, ref expirationDate, ref fees, ref notes,
                ref statusID, ref userID, ref personID, ref ClassID,ref IsActive,ref IsDetained,ref DriverID)) 
                return new clsLocalDrivingLicense(LicenseNumber, LDLAID, issueDate, expirationDate, fees, notes, (enLicenseStatus)statusID, userID, personID,
                    ClassID, IsActive, IsDetained, DriverID);

            else return null;
        }

        // find by local Driving license Application ID
        public static clsLocalDrivingLicense FindByLDLID(long LDLAID)
        {

            long LicenseNumber = default;
           DateTime issueDate = default; DateTime expirationDate = default; decimal fees = default; string notes = default;
            int statusID = default; long userID = default; long personID = default;
            int ClassID = default;
            bool IsActive = default;
            bool IsDetained = default;
            long DriverID = default;

            //statusID i send to database id but in class it is converted to enstatus


            if (clsLocalDrivingLicenseData.FindByLDLAID ( LDLAID, ref LicenseNumber, ref issueDate, ref expirationDate, ref fees, ref notes,
                ref statusID, ref userID, ref personID, ref ClassID, ref IsActive, ref IsDetained, ref DriverID))
                return new clsLocalDrivingLicense(LicenseNumber, LDLAID, issueDate, expirationDate, fees, notes, (enLicenseStatus)statusID, userID, personID,
                    ClassID, IsActive, IsDetained, DriverID);

            else return null;
        }
        private bool _AddNewLocalDrivingLicense()
        {
            DriverID = clsDriver.AddNewDriver(this.PersonID);
           if (DriverID <= 0)
                return false;
            long licenseNumber=default;
             clsLocalDrivingLicenseData.AddNewLocalDrivingLicense(ref licenseNumber, LocalDrivingLicenseApplicationID, IssueDate, ExpirationDate, Fees, Notes,(int)StatusID, UserID, 
                ClassID,IsActive,IsDetained,DriverID);
            this.LicenseNumber = licenseNumber;
            return licenseNumber > 0;

        }

        public bool Save()
        {
            return _AddNewLocalDrivingLicense();
        }

        public static bool IsPersonHasLicenseWithSameClass(long PersonID, enClassID ClassId)
        {
            return clsLocalDrivingLicenseData.IsPersonHasLicenseBefore(PersonID, (int)ClassId);
        }
        public static bool IsPersonHasLicenseWithSameClass(long PersonID, int ClassId)
        {
            return clsLocalDrivingLicenseData.IsPersonHasLicenseBefore(PersonID, (int)ClassId);
        }
        // save call addNew 



        public static bool IsLicenseExpiredAndActive(long LicenseNO)
        {
            return clsLocalDrivingLicenseData.IsLicenseExpiredAndActive(LicenseNO);
        }

        public static bool IsLicenseNotExpiredAndActive(long LicenseNO)
        {
            return clsLocalDrivingLicenseData.IsLicenseNotExpiredAndActive(LicenseNO);
        }
        

        public static bool DeactivateLicense(long LicenseNumber)
        {
            return clsLocalDrivingLicenseData.DeactivateLicense(LicenseNumber);
        }

        // it is better to link detain and renew here 
        // public void DetainLicense()
        //public  void Renew()
        // it is better than create new class if no new information you don't want to add


        // link is very good  
        // so if you have old license you can renew very easily
        public clsRenewDrivingLicense RenewLicense(long CurrentUserID)
        {
            clsRenewDrivingLicense renew = new clsRenewDrivingLicense(this, CurrentUserID);
          bool result= renew.RenewDrivingLicense();

            if (result)
                return renew;
            else return null;
            
        }

        public clsReplacementForDamage_Lost ReplaceLicense(clsReplacementForDamage_Lost.enReplacementFor ReplacementFor, long CurrentUserID)
        {
            clsReplacementForDamage_Lost Replace = new clsReplacementForDamage_Lost(ReplacementFor, this, CurrentUserID);
            bool result = Replace.Replace();
            if (result)
                  return Replace;


            else return null;
            
        }

        public long DetainLicense(decimal Fine,string Reson)
        {
            clsDetainedLicense  detainedLicense=new clsDetainedLicense(this.LicenseNumber, Fine, Reson);    
             bool resutl=detainedLicense.DetainLicense();
            return detainedLicense.DetainID;
        }

        public long ReleaseLicense(decimal TotalFees,long CurrentUser)
        {
            if (DetainedLicenseInfo == null)
                return -1;
            clsReleaseDetainedLicenseApplications Release = new clsReleaseDetainedLicenseApplications(this.LicenseNumber, TotalFees,this.PersonID, CurrentUser);
            bool result= Release.ReleaseLicense();
            if(result)
                return Release.ApplicationID;
            else
            {
                return -1;
            }
        }


    }
}
