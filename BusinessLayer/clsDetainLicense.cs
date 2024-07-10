using System;
using DetainLicensesData;
using System.Data;

namespace BusinessLayer
{
    public class clsDetainedLicense
    {

        public long     DetainID { get; set; }
        public long     LicenseNumber { get; set; }

        public decimal  Fine { get; set; }
        public DateTime DetainDate { get; set; }
        public string   DetainReason { get; set; }




        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicensesData.GetAllDetainedLicenses();

        }

        public  clsDetainedLicense( long licenseNumber, decimal fine, string detainReason)
        {
            LicenseNumber = licenseNumber;
            Fine = fine;
            DetainDate = DateTime.Now;
            DetainReason = detainReason;
        }
        private clsDetainedLicense(long licenseNumber, long ID, DateTime DetainDate , decimal fine, string detainReason)
        {
            this.LicenseNumber = licenseNumber;
            Fine = fine;
            this.DetainDate = DetainDate;
            this.DetainReason = detainReason;
            this.DetainID = ID;
        }

        private bool _DetainNewLicense()
        {
            long DetainedID = default;
            if (IsLicenseDetained(LicenseNumber))
                    return false;

            bool result = clsDetainedLicensesData.DetainLicense(ref DetainedID, LicenseNumber, Fine, DetainDate, DetainReason);
                if (result)
                this.DetainID = DetainedID;
           return result;
        }

        public bool DetainLicense()
        {
        
            return _DetainNewLicense();
        }

        public static bool IsLicenseDetained(long LicenseNumber)
        {
            return clsDetainedLicensesData.IsLicenseDetained(LicenseNumber);
        }

        public static  bool ReleaseDetainedLicense(long LicenseNumber,long ReleaseApplicationID)
        {
            return clsDetainedLicensesData.ReleaseDetainedLicense(LicenseNumber, ReleaseApplicationID);
        }
        public static clsDetainedLicense Find(long LicenseNumber)
        {

            long DetainID =default;


            decimal Fine = default;
            DateTime DetainDate = default;
            string DetainReason = default;

            if (clsDetainedLicensesData.FindByLicenseNumber(LicenseNumber, ref DetainID, ref DetainDate, ref DetainReason, ref Fine))
                return new clsDetainedLicense(LicenseNumber, DetainID, DetainDate, Fine, DetainReason);
            else
                return null;
        }

    }
}
