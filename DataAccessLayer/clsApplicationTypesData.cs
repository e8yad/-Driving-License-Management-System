using System;
using System.Data;
using System.Data.SqlClient;
using ConnectionString;
using DataAccessLayer;
namespace ApplicationsData
{
    public static  class clsApplicationTypesData
    {
        public static DataTable GetAllApplicationTypes()
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "Select * From ApplicationTypes;";
            SqlCommand command=new SqlCommand(Query, connection);
            DataTable dt=new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                 dt.Load(reader);
                reader.Close();

            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }

            return dt;
        }

        public static bool UpdateTypes(int ApplicationTypeID, string ApplicationTitle,float Fees)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"Update ApplicationTypes
                                            set Fees=@Fees,Title=@ApplicationTitle Where ID=@ApplicationTypeID;";
            SqlCommand command= new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@ApplicationTitle", ApplicationTitle);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            bool result=false;
            try
            {
               connection.Open();  
               result= command.ExecuteNonQuery()>0;
            }
            catch (Exception e)
            {
                clsLogger.LogErrors(e);

            }
            finally { connection.Close(); }
            return result; 
        }

        public static bool Find(int ApplicationTypeID, ref string  ApplicationTitle, ref decimal Fees)
        {
            SqlConnection connection = new SqlConnection( clsConnectionString.ConnectionString);
            string Query = "Select * From ApplicationTypes Where ID=@ApplicationTypeID";
            SqlCommand command=new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);
            bool result=false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    result=true;
                    ApplicationTitle = (string)reader["Title"];
                    Fees = (decimal)reader["Fees"];
                }
                reader.Close();

            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return result;

        }



    }
}
