using System;

using System.Data.SqlClient;
using System.Data;
using ConnectionString;
using DataAccessLayer;

namespace LocalDrivingLicenseData
{
    public static class clsLocalDrivingLicenseClassesData
    {
        public static bool Find(int ClassID,ref string ClassName,ref int MinimumAge,ref int Validity,ref decimal Fees)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "select * from LocalDrivingLicenseClasses  where ID=@ClassID";
            SqlCommand command=new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ClassID", ClassID);
            bool IsFound=false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    IsFound = true;
                    ClassName = (string)reader["ClassName"];
                    MinimumAge = (short)reader["MinimumAge"];
                    Validity = (short)reader["Validity"];
                    Fees = (decimal)reader["Fees"];
                }
                reader.Close();
            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return IsFound; 
        }

        public static DataTable GetAllClassesName()
        {
            SqlConnection connection=new SqlConnection(clsConnectionString.ConnectionString);
           string Query = "select ClassName from LocalDrivingLicenseClasses";
            SqlCommand command = new SqlCommand(Query, connection);
            DataTable dt = new DataTable();
            try
            {
                 connection.Open();
                dt.Load(command.ExecuteReader());
            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return dt;
        }

        //update age
        //update fees






    }
}
