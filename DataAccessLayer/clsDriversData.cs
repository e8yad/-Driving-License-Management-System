using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ConnectionString;
using System.Data;
using DataAccessLayer;
namespace DriversData

{
    public class clsDriversData
    {
        public static bool AddNewDriver(ref long DriverID,long PersonID)
        {
            SqlConnection connection=new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"if exists(select x=1 from drivers Where drivers.PersonID=@PersonID)
                                                select DriverID from drivers Where PersonID=@PersonID
                                                else
                                                   insert into drivers
                                                    values (@PersonID)
                                                    select SCOPE_IDENTITY();";
            SqlCommand command =new  SqlCommand (Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            bool Result = false;
            try
            {
                connection.Open();
                object obj=command.ExecuteScalar();
                if(obj != null && long.TryParse(obj.ToString(),out DriverID))
                {
                    Result = true;
                }

            }
            catch (Exception e)
            {
                clsLogger.LogErrors(e);

            }
            finally
            {
                connection.Close();
            }
            return Result;
        }

        public static DataTable GetAllLocalLicenseRelatedToDriver( long DriverID) 
        {
            SqlConnection connection=new SqlConnection (clsConnectionString.ConnectionString);
            string Query= @"SELECT LocalDrivingLicenses.LicenseNumber, LocalDrivingLicenses.IssueDate, LocalDrivingLicenses.ExpirationDate, LocalDrivingLicenses.Fees, LocalDrivingLicenses.Notes, LicenseStatus.StatuesName, LocalDrivingLicenses.IsActive, 
                  LocalDrivingLicenseClasses.ClassName
              FROM     LocalDrivingLicenseClasses INNER JOIN
                  LocalDrivingLicenses ON LocalDrivingLicenseClasses.ID = LocalDrivingLicenses.ClassID INNER JOIN
                  LicenseStatus ON LocalDrivingLicenses.StatusID = LicenseStatus.StatusID
				  where DriverID=@DriverID";
            SqlCommand command=new SqlCommand (Query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            DataTable dt=new DataTable();

            try
            {
                connection.Open();
                SqlDataReader reader=command.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);

                }
            }
            catch (Exception e)
            {
                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return dt;
        }

        public static bool Find(long DriverID,ref long PersonID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "select * from Drivers Where DriverID=@DriverID";
            SqlCommand cmd=new SqlCommand (Query, connection);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            bool IsFound=false;
            try
            {
                connection.Open();
                SqlDataReader reader=cmd.ExecuteReader();
                if (reader.Read())
                {
                     IsFound = true;
                    PersonID = (long)reader["PersonID"];
                }
            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return IsFound;
        }


    }
}
