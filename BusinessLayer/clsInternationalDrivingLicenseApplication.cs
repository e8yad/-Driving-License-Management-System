using ApplicationsBusiness;
using System;
using InternationalDrivingLicenseApplicationData;
using LocalDrivingLicense;

namespace BusinessLayer
{
    public class clsInternationalDrivingLicenseApplication:clsApplications
    {
        // international license No
        public long ILN {  get; set; }
        // Local license No
        public long LLN {  get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime IssueDate { get; set; }
        public bool IsActive {  get; set; }

        public event Action<bool,long> OnSaveFinish;





        public clsInternationalDrivingLicenseApplication(): base(6)
        {
            ILN = default;
            LLN = default;
            ExpirationDate = default;
            IssueDate = default;
            IsActive = false;
        }

       
        private bool _AddNewIDL()
        {
            long ILN = default;
            if (!clsLocalDrivingLicense.IsPersonHasLicenseWithSameClass(PersonID, clsLocalDrivingLicense.enClassID.Class3))
            {
                OnSaveFinish?.Invoke(false, -111);
                return false;
            }
           
           if (base.Save())
            {
                 clsInternationalDrivingLicenseApplicationsData.AddNewInternationalDrivingLicense(ref ILN, this.ApplicationID,LLN,IssueDate,ExpirationDate,IsActive);
                this.ILN = ILN;
                clsApplications.UpdateStatusByApplicationID(this.ApplicationID,enStatusID.Completed);
                OnSaveFinish?.Invoke(true, ILN);
                return ILN > 0;

            }
            OnSaveFinish?.Invoke(false, -1);
            return false;
        }

        public bool IssueNewInternationalDrivingLicense()
        {

            return _AddNewIDL();


        }

        public static bool IsAnActiveInternationalLicenseNumber(long LLN)
        {
            return clsInternationalDrivingLicenseApplicationsData.IsAnActiveInternationalLicenseNumber(LLN);
        }







    }
}
