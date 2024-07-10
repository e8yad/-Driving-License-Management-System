using ApplicationsBusiness;
using LocalDrivingLicense;
using System;
using System.Diagnostics.SymbolStore;

namespace BusinessLayer
{
    public class clsReplacementForDamage_Lost: clsApplications
    {
        public clsLocalDrivingLicense NewLocalDrivingLicense { get; private set; }
        private long _oldLicenseNumber;
        public enum enReplacementFor { Lost=3,Damage=4}
        public enReplacementFor ReplacementFor;
        public static event Action<bool> OnSaveFinish;
        public clsReplacementForDamage_Lost(enReplacementFor ReplacementFor, clsLocalDrivingLicense OldDrivingLicense, long CurrentUserID) :base((int)ReplacementFor)
        {
            this.ReplacementFor = ReplacementFor;
            _oldLicenseNumber = OldDrivingLicense.LicenseNumber;
            this.CreationDate = DateTime.Now;
            this.statusID = enStatusID.New;
            this.UserID = CurrentUserID;
            NewLocalDrivingLicense = new clsLocalDrivingLicense(OldDrivingLicense.LocalDrivingLicenseApplicationID);
            NewLocalDrivingLicense.ClassID = OldDrivingLicense.ClassID;
            NewLocalDrivingLicense.DriverID = OldDrivingLicense.DriverID;
            NewLocalDrivingLicense.PersonID = this.PersonID=OldDrivingLicense.PersonID;
            NewLocalDrivingLicense.Notes = OldDrivingLicense.Notes;
            NewLocalDrivingLicense.Fees = OldDrivingLicense.DriverClassesInfo.Fees;
            NewLocalDrivingLicense.IssueDate = DateTime.Now;
            NewLocalDrivingLicense.ExpirationDate = DateTime.Now.AddYears(OldDrivingLicense.DriverClassesInfo.Validity);
            NewLocalDrivingLicense.StatusID = (ReplacementFor==enReplacementFor.Damage)? clsLocalDrivingLicense.enLicenseStatus.ReplacementForDamage:
             clsLocalDrivingLicense.enLicenseStatus.ReplacementForLost;
            NewLocalDrivingLicense.UserID = CurrentUserID;
            NewLocalDrivingLicense.IsActive = true;
            NewLocalDrivingLicense.IsDetained = false;

        }


        private bool _Replace()
        {

            bool Result = false;
            // to check is active or not
            if (!clsLocalDrivingLicense.IsLicenseNotExpiredAndActive(_oldLicenseNumber))
            {
                OnSaveFinish?.Invoke(Result);
                return Result;
            }

            if (base.Save())
            {

                Result = NewLocalDrivingLicense.Save();
                
                if (Result)
                {
                    clsLocalDrivingLicense.DeactivateLicense(_oldLicenseNumber);
                    UpdateStatusByApplicationID(this.ApplicationID, enStatusID.Completed);
                }
                    
            }
       
            return Result;

        }

        public bool Replace()
        {
            bool result = _Replace();
            OnSaveFinish?.Invoke(result);
            return result;
        }


    }
}
