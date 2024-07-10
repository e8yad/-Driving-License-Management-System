using System;
using System.Data.SqlClient;
using ConnectionString;
using DataAccessLayer;

namespace ApplicationsData
{

    public static  class clsApplicationsData
    {
    

        public static bool  AddNewApplication(ref long ApplicationID,long PersonID,int ApplicationTypeId,DateTime CreationDate, int statusID,Decimal Fees,long UserID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"INSERT INTO dbo.Applications (PersonID, ApplicationTypeID, CreationDate, StatusID, TotalFees, PaymentID, UserID) 
                                    VALUES (@PersonID, @ApplicationTypeId, @CreationDate, @statusID, @Fees, @PaymentID, @UserID);
                                      select Scope_Identity();";

            SqlCommand command= new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeId", ApplicationTypeId);
            command.Parameters.AddWithValue("@CreationDate", CreationDate);
            command.Parameters.AddWithValue("@statusID", statusID);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@PaymentID", DBNull.Value);

            try
            {
                connection.Open();
                object obj=command.ExecuteScalar();
                if (obj != null&& long.TryParse(obj.ToString(),out ApplicationID)) 
                {
                    return true;
                }
            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return false;

        }
        public static bool UpdateStatus(long ApplicationID, int statusID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"update Applications
                                            set StatusID=@statusID
                                            where 
                                            ApplicationID=@ApplicationID";
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@StatusID", statusID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
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

        public static bool DeleteApplication(long ApplicationID)
        {
            SqlConnection connection= new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "Delete From Applications where ApplicationID=@ApplicationID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            bool Result = false;
            try
            {
                connection.Open();

                Result=command.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {

               clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return Result;


        }
        


    }
}
