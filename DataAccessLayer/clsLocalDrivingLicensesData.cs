using System;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ConnectionString;


namespace LocalDrivingLicenseData
{
    public class clsLocalDrivingLicensesData
    {
        // only i need is 
        // add 
        // get will be with join in main table 
        // update (status)  status 1 new 2 completed 3 canceled on main table 


        public static long AddNewLocalDrivingLicense(long ApplicationID,int ClassID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"Insert Into LocalLicenseApplications values(@ApplicationID,@ClassID);select scope_identity();";
            SqlCommand command=new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ClassID", ClassID);
            long ID=default;
            try
            {
                connection.Open();
                object obj= command.ExecuteScalar();
                if (!(obj != null && long.TryParse(obj.ToString(), out ID)))
                    return ID;
                    
 
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }
            return -1;
            
            


        }

    }
}
