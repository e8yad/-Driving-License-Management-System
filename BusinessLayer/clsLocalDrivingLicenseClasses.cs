using LocalDrivingLicenseData;
using System.Data;


namespace BusinessLayer
{
    public class clsLocalDrivingLicenseClasses
    {
        public int ID { get; private set; }
        public string ClassName { get; private set; }
        public int Validity { get; private set; }
        public int MinimumAge { get; private set; }
        public decimal Fees { get; private set; }

        private clsLocalDrivingLicenseClasses(int id,string ClassName,int Validity,int MinimumAge,decimal Fees)
        {
            ID = id;
            this.ClassName = ClassName;
            this.Validity = Validity;
            this.MinimumAge = MinimumAge;
            this.Fees = Fees;
        }

        public clsLocalDrivingLicenseClasses() 
        {

        }

        public static clsLocalDrivingLicenseClasses Find(int ID)
        {

            string ClassName = default; int Validity = default; int MinimumAge = default; decimal Fees = default;

            if(clsLocalDrivingLicenseClassesData.Find(ID,ref ClassName,ref MinimumAge,ref Validity,ref Fees))
            {
                return new clsLocalDrivingLicenseClasses(ID,ClassName,Validity,MinimumAge,Fees);
            }
            else
                return null;

        }

        public static DataTable GetAllClassesName()
        {
            return clsLocalDrivingLicenseClassesData.GetAllClassesName();
        }


    }
}
