using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationsData;
using LocalDrivingLicenseData;

namespace ApplicationsBusiness
{
    public class clsLocalDrivingLicenses
    {
        public static long  AddNewLocalDrivingLicense(long ApplicationID, int ClassID)
        {
            return clsLocalDrivingLicensesData.AddNewLocalDrivingLicense(ApplicationID, ClassID);
        }

    }
}
