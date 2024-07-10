using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationsBusiness;
namespace BusinessLayer
{
    public class clsRetakeTestApplication:clsApplications
    {

        public clsRetakeTestApplication(DateTime CreationDate,long UserID,long PersonID):base(7)
        {
            this.CreationDate = CreationDate;
            this.ApplicationFees =(decimal)ApplicationType.Fees;
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.ApplicationID = -1;
            this.statusID = enStatusID.Completed;

        }
        public bool RetakeTestApplicationSave()
        {
            return base.Save();
        }

       


    }
}
