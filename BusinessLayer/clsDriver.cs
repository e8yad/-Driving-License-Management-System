
using System.Data;

using DriversData;

namespace BusinessLayer
{
    public class clsDriver
    {

        protected clsDriver()
        {
            DriverID = -1;
        }

        public long DriverID { set; get; }
        // it is better to has separate PersonID not Property in personInfo
        public long PersonID { set; get; }

        public clsPerson PersonInfo { set; get; }
        public static long AddNewDriver(long PersonID)
        {
            long DriverID = default(long);
            clsDriversData.AddNewDriver(ref DriverID, PersonID);
            return DriverID;
        }
        public static DataTable GetAllLocalLicenseRelatedToDriver(long DriverID)
        {
            return clsDriversData.GetAllLocalLicenseRelatedToDriver(DriverID);

        }

        private clsDriver(long driverID, long personID)
        {
            DriverID = driverID;
            PersonID = personID;
            PersonInfo = clsPerson.FindByPersonID(personID);
        }

        public static clsDriver Find(long DriverID)
        {
            long personID = default;
            if (clsDriversData.Find(DriverID, ref personID))
                return new clsDriver(DriverID, personID);
            else
                return null;

        }

    }
}
