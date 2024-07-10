using ApplicationsBusiness;
using System;
using System.Data;
using InternationalDrivingLicenseData;



namespace BusinessLayer
{
    public class clsInternationalDrivingLicense
    {
        public long ILN{ set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public long ApplicationId {private set; get; }

        public long LLN {  set; get; }

        public bool IsActive {  set; get; }



        public static DataTable GetAllIDLRelatedToPersonByNationalID(long NationalID)
        {
            return clsInternationalDrivingLicenseData.GetAllIDLRelatedToPersonByNationalID(NationalID);
        }



        public clsInternationalDrivingLicense()
        {

            ILN = -1;
            IssueDate = default;
            ExpirationDate = default;
            ApplicationId = -1;
            IsActive = false;
            LLN = -1;

        }

       





    }
}
