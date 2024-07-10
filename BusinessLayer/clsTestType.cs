using System.Data;
using TestsData;

namespace BusinessLayer
{
    public class clsTestType
    {

        public string Title { get; set; }
        public float Fees { get; set; }
        public int ID { private set; get; }
        public string Description { get; set; }
        //it is better to be test type enum better than a table in database

        private clsTestType(string title, float fees, int iD,string description)
        {
            Title = title;
            Fees = fees;
            ID = iD;
            Description = description;
        }

        public static DataTable GetAllTypes()
        {
            return clsTestTypesData.GetAllTestTypes();
        }

        private bool _UpdateApplicationType()
        {
            return clsTestTypesData.UpdateTypes(ID, Title, Fees,Description);
        }

        public bool Save()
        {
            return _UpdateApplicationType();
        }


        public static clsTestType Find(int ID)
        {
            string title = default; decimal fees = default;string description = default;  

            if (clsTestTypesData.Find(ID, ref title, ref fees, ref description))
                return new clsTestType(title, (float)fees, ID, description);
            else
                return null;
        }


    }
}
