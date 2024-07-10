using PersonsData;
using System;
using System.Data.SqlClient;
using System.Data;
using ConnectionString;
using DataAccessLayer;
namespace TestsData
{
    public static class clsTestTypesData
    {
        public static DataTable GetAllTestTypes()
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "Select * From TestTypes;";
            SqlCommand command = new SqlCommand(Query, connection);
            DataTable dt = new DataTable();
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

        public static bool UpdateTypes(int TestTypeID, string TestTitle, float Fees,string Description)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"Update TestTypes
                                            set Fees=@Fees,Title=@TestTitle ,Description=@Description Where ID=@TestTypeID;";
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@TestTitle", TestTitle);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            if(string.IsNullOrEmpty(Description))
            {
                command.Parameters.AddWithValue("@Description", DBNull.Value);
            }
            else
            command.Parameters.AddWithValue("@Description", Description);

            bool result = false;
            try
            {
                connection.Open();
                result = command.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return result;
        }

        public static bool Find(int TestTypeID, ref string TestTitle, ref decimal Fees,ref string Description)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "Select * From TestTypes Where ID=@TestTypeID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("TestTypeID", TestTypeID);
            bool result = false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    TestTitle = (string)reader["Title"];
                    Fees = (decimal)reader["Fees"];
                    if(reader["Description"]==DBNull.Value)
                        Description=string.Empty;
                    else
                    Description = (string)reader["Description"];
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
