using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationsData;

namespace BusinessLayer
{
    public abstract class clsApplications
    {
        private Decimal _Fees;
        public long PersonID { get; set; }
        public clsApplicationType ApplicationType { get; set; }
        public long ApplicationID { get;internal set; }
        public DateTime CreationDate { get; set; }
        public enum enStatusID { New = 1, Completed = 2, Canceled = 3 }
        public enStatusID statusID { get; set; }
        public Decimal ApplicationFees
        {
            get { return _Fees; }

            set {
                _Fees = value; 

            }

        }
        public long UserID { get; set; }
        public clsPerson PersonInfo { private set; get; }
      

         public clsApplications(int ApplicationTypeID)
        {
            this.ApplicationType = clsApplicationType.Find(ApplicationTypeID);
           this.ApplicationID = ApplicationID;
            this.statusID = enStatusID.New;
           this.PersonID =default;
           this.CreationDate = default;
           this.UserID=default;
            this.ApplicationFees = (decimal)ApplicationType.Fees;

        }
        private clsApplications(long PersonID,long ApplicationID, int ApplicationTypeID, DateTime CreationDate, enStatusID statusID, Decimal Fees, long UserID)
        {
            this.PersonID = PersonID;  
            this.ApplicationID=ApplicationID;
            this.ApplicationType = null;
            this.CreationDate = CreationDate;
            this.statusID = statusID;
            this.ApplicationFees = Fees;
            this.UserID = UserID;
            this.PersonInfo=clsPerson.FindByPersonID(PersonID);
        }


        // Add new 

        // update status and fees only 
     
        //public static bool  UpdateStatus(long ApplicationID, enStatusID StatusID)
        //{
        //    return clsApplicationsData.UpdateStatus(ApplicationID, (int)StatusID);
        //}

        // if only change from object is fees 

        private bool _AddNewApplication()
        {
            long ApplicationID = default;
            if(clsApplicationsData.AddNewApplication(ref ApplicationID, PersonID, ApplicationType.ID, CreationDate, (int)statusID, ApplicationFees, UserID))
            {
                this.ApplicationID= ApplicationID;
                return true;
            }
            return false;
        } 

       protected  bool Save()
        {
            return _AddNewApplication();
           
        }

        public virtual bool IsApplicationExistsAndNotCancelled()
        {
            // check LDLApplicationID&& status
           throw new NotImplementedException();
        }
        public static bool UpdateStatusByApplicationID(long ApplicationID, enStatusID StatusID)
        {
            return clsApplicationsData.UpdateStatus(ApplicationID, (int)StatusID);
        }
        public  static bool DeleteApplication(long ApplicationID)
        {
            return clsApplicationsData.DeleteApplication(ApplicationID); 
        }
      

        // this is better as you use cancel very much 
        public static bool Cancel(long ApplicationID)
        {
            return UpdateStatusByApplicationID(ApplicationID,enStatusID.Canceled);
        }


    }
}
