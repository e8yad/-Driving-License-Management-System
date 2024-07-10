using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DetainedLicense;
using LocalDrivingLicense;

namespace BusinessLayer
{
    public class clsReleaseDetainedLicenseApplications : clsApplications
    {
        private long LicenseNumber;
        public  static event Action<bool,short> OnReleaseFinish;

        public clsReleaseDetainedLicenseApplications(long LicenseNumber,decimal Fine,long PersonID,long UserID) : base(5)
        {
            this.LicenseNumber=LicenseNumber;
            this.ApplicationFees = Fine + (decimal)this.ApplicationType.Fees;
            this.CreationDate= DateTime.Now;
            this.PersonID = PersonID;
            this.UserID = UserID;
        }
        private bool _ReleaseDetainedLicense()
        {
            bool Result = false;
            if(!clsDetainedLicense.IsLicenseDetained(LicenseNumber))
            {
                //-11-> not detained
                OnReleaseFinish?.Invoke(false, -11);
                return false;
            }

            if (base.Save())
            {

                Result = clsDetainedLicense.ReleaseDetainedLicense(LicenseNumber,this.ApplicationID);
                if(Result) { UpdateStatusByApplicationID(this.ApplicationID, enStatusID.Completed); }
            }
            OnReleaseFinish?.Invoke(Result,1);
            return Result;
        }

        public bool ReleaseLicense() {
            return _ReleaseDetainedLicense();



        }



    }
}
