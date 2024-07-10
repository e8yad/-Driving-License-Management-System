using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ApplicationsData;
namespace ApplicationsBusiness

{
    public class clsApplicationTypes
    {
        public string Title { get; set; }
        public float Fees { get; set; }
        public int ID { private set; get; }
        private clsApplicationTypes(string title, float fees, int iD)
        {
            Title = title;
            Fees = fees;
            ID = iD;
        }

        public static DataTable GetAllTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }

        private bool _UpdateApplicationType()
        {
            return clsApplicationTypesData.UpdateTypes(ID,Title, Fees);
        }

        public bool Save()
        {
            return _UpdateApplicationType();
        }


        public static clsApplicationTypes Find(int ID )
        {
            string title = default; decimal fees=default;

            if (clsApplicationTypesData.Find(ID, ref title, ref fees))
                return new clsApplicationTypes(title, (float)fees,ID);
            else
                return null;
        }

        

    }
}
