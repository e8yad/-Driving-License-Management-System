using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using ConnectionString;
using System.Data;
using DataAccessLayer;
namespace DetainLicensesData
{
    public static class clsDetainedLicensesData
    {
        public static DataTable GetAllDetainedLicenses()
        {

            SqlConnection connection=new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"select * from ManageDetainedLicenses";
            SqlCommand command=new SqlCommand(Query, connection); 
            DataTable dt=new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
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

        public static bool DetainLicense(ref long DetainID,long LicenseNumber,decimal Fines,DateTime DetainedDate,string DetainedReason)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"update LocalDrivingLicenses
                                set IsDetained=1 ,IsActive=0 where LicenseNumber=@LicenseNumber
                                insert into DetainedLicenses(LicenseNumber,Fines,DetainedDate,DetainedReason,IsDetained)
                                values(@LicenseNumber,@Fines,@DetainedDate,@DetainedReason,1)
                                select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseNumber", LicenseNumber);
            command.Parameters.AddWithValue("@Fines", Fines);
            command.Parameters.AddWithValue("@DetainedDate", DetainedDate);
            if(string.IsNullOrEmpty(DetainedReason))
                command.Parameters.AddWithValue("@DetainedReason", DBNull.Value);
            else
                command.Parameters.AddWithValue("@DetainedReason", DetainedReason);
            bool result = false;
            try
            {
                connection.Open();
                Object obj = command.ExecuteScalar();

                if(obj != null&& long.TryParse(obj.ToString(),out DetainID))
                    result=true;

            }
            catch (Exception e)
            {
                clsLogger.LogErrors(e);

            }
            finally { connection.Close(); }
            return result;
        }

        public static bool IsLicenseDetained(long LicenseNumber)
        {

            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"select x=1 
                                        from DetainedLicenses
                                        where IsDetained=1 and LicenseNumber=@LicenseNumber";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseNumber", LicenseNumber);

            bool result = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                result=reader.HasRows;
              

            }
            catch (Exception e)
            {
                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return result;

        }

        public static bool ReleaseDetainedLicense(long LicenseNumber,long ReleaseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"Update DetainedLicenses
                                set ReleaseDate =GETDATE(),IsDetained=0,ReleaseDetainedAppID=@ReleaseApplicationID
                                where LicenseNumber=@LicenseNumber and IsDetained=1
                                update LocalDrivingLicenses
                                set IsDetained=0 ,IsActive=1 where LicenseNumber=@LicenseNumber";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseNumber", LicenseNumber);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            bool result = false;
            try
            {
                connection.Open();
                int obj = command.ExecuteNonQuery();
                result = obj>0;

            }
            catch (Exception  e)
            {
                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return result;

        }

        public static bool FindByLicenseNumber(long LicenseNumber,ref long DetainedID,ref DateTime DetainedDate,ref string DetainedReason,
            ref decimal Fines)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"SELECT top 1  DetainedLicenses.*
                                        FROM         DetainedLicenses 
						 where LicenseNumber = @LicenseNumber and IsDetained=1";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseNumber", LicenseNumber);
            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    IsFound = true;
                    DetainedID = (long)reader["ID"];
                    DetainedDate = (DateTime)reader["DetainedDate"];
                    Fines = (decimal)reader["Fines"];
                    if(reader["DetainedReason"]==DBNull.Value)
                        DetainedReason=string.Empty;
                    else
                     DetainedReason = (string)reader["DetainedReason"];
                  


                }
            

            }
            catch(Exception e)
            {
                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return IsFound;
        }









    }
}
