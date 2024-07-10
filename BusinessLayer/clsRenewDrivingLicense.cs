using ApplicationsBusiness;
using System;
using LocalDrivingLicense;

namespace BusinessLayer
{
    public class clsRenewDrivingLicense : clsApplications
    {
        public clsLocalDrivingLicense NewLocalDrivingLicense;
        private long _oldLicenseNumber;
        public static event Action<bool> OnSaveFinish;

        public clsRenewDrivingLicense(clsLocalDrivingLicense OldDrivingLicense,long CurrentUserID) :base(2)
        {
            _oldLicenseNumber=OldDrivingLicense.LicenseNumber;
            this.CreationDate = DateTime.Now;
            this.statusID = enStatusID.New;
            this.UserID = CurrentUserID;
            NewLocalDrivingLicense=  new clsLocalDrivingLicense(OldDrivingLicense.LocalDrivingLicenseApplicationID);
            NewLocalDrivingLicense.ClassID =OldDrivingLicense.ClassID;
            NewLocalDrivingLicense.PersonID = this.PersonID = OldDrivingLicense.DriverInfo.PersonID;
            NewLocalDrivingLicense.DriverInfo = OldDrivingLicense.DriverInfo;
            NewLocalDrivingLicense.Notes = OldDrivingLicense.Notes;
            NewLocalDrivingLicense.Fees =OldDrivingLicense.DriverClassesInfo.Fees;
            NewLocalDrivingLicense.IssueDate= DateTime.Now;
            NewLocalDrivingLicense.ExpirationDate= DateTime.Now.AddYears(OldDrivingLicense.DriverClassesInfo.Validity);
            NewLocalDrivingLicense.StatusID = clsLocalDrivingLicense.enLicenseStatus.Renew;
            //renew  
            NewLocalDrivingLicense.UserID= CurrentUserID;
            NewLocalDrivingLicense.IsActive = true;
            NewLocalDrivingLicense.IsDetained=false;
        }
        private  bool _AddNew()
        {

            bool Result = false;
            if(!clsLocalDrivingLicense.IsLicenseExpiredAndActive(_oldLicenseNumber))
            {
                OnSaveFinish?.Invoke(Result);
                return Result;
            }

            if (base.Save())
            {

                Result = NewLocalDrivingLicense.Save();
                clsLocalDrivingLicense.DeactivateLicense(_oldLicenseNumber);
                if (Result) 
                    UpdateStatusByApplicationID(this.ApplicationID, enStatusID.Completed);
            }
            OnSaveFinish?.Invoke(Result);
            return Result;

        }
        
        public bool RenewDrivingLicense()
        {
            return _AddNew();
        }



    }
}
