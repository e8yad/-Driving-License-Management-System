using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ConnectionString;
using System.Data;
using DataAccessLayer;


namespace InternationalDrivingLicenseApplicationData
{
    public static class clsInternationalDrivingLicenseApplicationsData
    {

        public static bool AddNewInternationalDrivingLicense(ref long ILN,long ApplicationID , long LLN,DateTime IssueDate, DateTime ExpirationDate, bool IsActive)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
                            string Query = @"
                                    update InternationalDrivingLicenses
                                        set IsActive=0 where InternationalDrivingLicenses.LocalLicenseNumber=@LLN;
                                            INSERT INTO InternationalDrivingLicenses
                                         	(LocalLicenseNumber, ApplicationID, IssueDate, ExpirationDate, IsActive)
                                         VALUES
                                         	(@LLN, @ApplicationID, @IssueDate, @ExpirationDate, @IsActive);
                                         select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LLN", LLN);
            command.Parameters.AddWithValue("@ApplicationID",ApplicationID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);          ;
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive" ,IsActive);
       
            try
            {
                connection.Open();
                object obj = command.ExecuteScalar();
                if (obj != null && long.TryParse(obj.ToString(), out ILN))
                    return true;

            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return false;
        }

        public static bool IsAnActiveInternationalLicenseNumber(long LLN)
        {
            SqlConnection connection =new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"select x=1
                                from InternationalDrivingLicenses where InternationalDrivingLicenses.LocalLicenseNumber=@LLN and InternationalDrivingLicenses.IsActive=1;";
            SqlCommand command=new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LLN", LLN);
            bool result=false;
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



        //Move To Anoter class 
        //public static DataTable GetAllInternationalDrivingLicensesApplications()
        //{
        //    SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
        //    string Query = "Select * From InternationalDrivingLicenses;";
        //    SqlCommand command = new SqlCommand(Query, connection);
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        dt.Load(reader);
        //        reader.Close();

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally { connection.Close(); }

        //    return dt;
        //}
        //public static bool FindByLicenseNumber(long ILN, ref long LLN,ref long ApplicationID ,ref DateTime IssueDate, ref DateTime ExpirationDate,
        //    ref bool IsActive)
        //{
        //    SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
        //    string Query = @"SELECT *
        //                         FROM
        //                         	 InternationalDrivingLicenses
        //                         WHERE
        //                         	InternationalDrivingLicenses.IntLicenseNumber = @IntLicenseNumber";
        //    SqlCommand command = new SqlCommand(Query, connection);
        //    command.Parameters.AddWithValue("@IntLicenseNumber", ILN);

        //    bool Result = false;
        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            ILN = (long)reader["IntLicenseNumber"];
        //            LLN = (long)reader["IntLicenseNumber"];
        //            ApplicationID = (long)reader["ApplicationID"];
        //            IssueDate = (DateTime)reader["IssueDate"];
        //            ExpirationDate = (DateTime)reader["ExpirationDate"];
        //            IsActive = (bool)reader["IsActive"];
                 

        //        }
        //        reader.Close();
        //    }
        //    catch (Exception)
        //    {


        //    }
        //    finally { connection.Close(); }
        //    return Result;




        //}


        //public static bool FindByPersonNationalID(long NationalID, long ILN, ref long LLN, ref long ApplicationID, ref DateTime IssueDate, ref DateTime ExpirationDate,
        //     ref bool IsActive)
        //{
        //    SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
        //    string Query = @"select top 1 
        //                                    InternationalDrivingLicenses.*
        //                                    from InternationalDrivingLicenses
        //                                    join Applications on Applications.ApplicationID=InternationalDrivingLicenses.ApplicationID
        //                                    join PersonsData on PersonsData.PersonID=Applications.PersonID
        //                                    where PersonsData.NationalID=@NationalID
        //                                    order by IssueDate Desc;";
                                            

        //    SqlCommand command = new SqlCommand(Query, connection);
        //    command.Parameters.AddWithValue("@NationalID", NationalID);
        //    bool Result = false;
        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            Result = true;

        //            ILN = (long)reader["IntLicenseNumber"];
        //            LLN = (long)reader["IntLicenseNumber"];
        //            ApplicationID = (long)reader["ApplicationID"];
        //            IssueDate = (DateTime)reader["IssueDate"];
        //            ExpirationDate = (DateTime)reader["ExpirationDate"];
        //            IsActive = (bool)reader["IsActive"];
                

        //        }
        //        reader.Close();
        //    }
        //    catch (Exception)
        //    {


        //    }
        //    finally { connection.Close(); }
        //    return Result;
        //}


    }
}
