using System;
using System.Data.SqlClient;
using PersonsData;
using System.Data;


using ConnectionString;
using DataAccessLayer;

namespace LocalDrivingLicenseData
{
    public static class clsLocalDrivingLicenseApplicationData
    {
        public static bool AddNewLocalDrivingLicense(ref long ID,int ClassID,long ApplicationID)
        {
            SqlConnection connection= new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "insert into LocalLicenseApplications(ApplicationID,ClassID) values(@ApplicationID,@ClassID);select SCOPE_IDENTITY();";
            SqlCommand command= new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ClassID", ClassID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                connection.Open();
                object obj= command.ExecuteScalar();
                if(obj != null  &&  long.TryParse(obj.ToString(),out ID )) 
                    return true;

            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }
            return false;
        }
        
        public static bool ISApplicationIsExistAndNotCancelled(long PersonID,short ClassID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "select x = 1 from LocalDrvingLicenseCheck where PersonID = @PersonID and ClassID = @ClassID";
            SqlCommand command=new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@ClassID", ClassID);
            bool result=false;
            try
            {
                connection.Open();
                SqlDataReader reader= command.ExecuteReader();
                result = reader.HasRows;
            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return result;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "Select * From ManageLocalDrivingLicenseApplications;";
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

        public static int NoOfTestsPassed(long LocalDrivingLicenseApplicationID)
        {
            SqlConnection connection= new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "select Count(R1.TestID) from(select TestID from Tests where Tests.LocalDrivingLicenseApplicationID=@LDLAPPID and Result=1)R1";
            SqlCommand command =new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLAPPID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                if (int.TryParse(command.ExecuteScalar().ToString(), out int Result))
                     return Result;
            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return 0;

        }

        public static bool UpdateTestPassed(long LocalDrivingLicenseApplicationID)
        {
            SqlConnection connection = new SqlConnection( clsConnectionString.ConnectionString);
            string Query = @"update LocalLicenseApplications
                                                        set TestsPassed= 
                                                        (
                                                        select Count(R1.TestID) 
                                                         from
                                                        (
                                                        select TestID
                                                        from Tests
                                                        where Tests.LocalDrivingLicenseApplicationID=@LDLAPPID and Result=1
                                                        )R1
                                                        )
                                                        where LocalLicenseApplications.ID=@LDLAPPID";

            SqlCommand command=new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLAPPID", LocalDrivingLicenseApplicationID);

            bool result = false;
            try
            {
                connection.Open();
                result =command.ExecuteNonQuery()>0;

            }
            catch (Exception e)
            {
                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return result;
        }

        public static bool FindByLDLApplicationID(long LocalDrivingLicenseApplicationID,ref short ClassID,ref long ApplicationID, ref short statusID, ref long PersonID
            ,ref DateTime CreationDate,ref long UserID,ref decimal Fees)
        {

            SqlConnection connection= new SqlConnection( clsConnectionString.ConnectionString);
            string Query = @"select *
                                    from LocalLicenseApplications
                                    join Applications on Applications.ApplicationID=LocalLicenseApplications.ApplicationID Where 
                                            ID=@LDLAID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLAID", LocalDrivingLicenseApplicationID);
            bool IsFound=false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    ClassID=(short)((int)reader["ClassID"]);
                    ApplicationID = (long)reader["ApplicationID"];
                    statusID = (short)((int)reader["StatusID"]);
                    PersonID = (long)reader["PersonID"];
                    CreationDate = (DateTime)reader["CreationDate"];
                    UserID = (long)reader["UserID"];
                    Fees = (decimal)reader["TotalFees"];

                    IsFound = true;
                    reader.Close();
                }

            }
            catch (Exception e)
            {
                clsLogger.LogErrors(e);

            }
            finally { connection.Close(); }
            return IsFound;
        }

        public static  bool  UpdateNoPassedTests(long LDLID)
        {
            SqlConnection connection= new SqlConnection( clsConnectionString.ConnectionString);
            string Query = "update LocalLicenseApplications set TestsPassed=TestsPassed+1 where ID=@LDLID";
            SqlCommand command= new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLID", LDLID);
            bool Result=false;
            try
            {
                connection.Open();
                Result=command.ExecuteNonQuery()>0;
            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return Result;
        }

        public static bool Delete(long lDLAID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "Delete from LocalLicenseApplications where ID=@LDLID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLID", lDLAID);
            bool Result = false;
            try
            {
                connection.Open();
                Result = command.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return Result;
        }

        public static bool IsRelatedToTest(long LDLAID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "select x=1 from tests where Tests.LocalDrivingLicenseApplicationID=@LDLAID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLAID", LDLAID);

            bool isFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
            }
            catch (Exception e)
            {
                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }

            return isFound;
        }

        public  static  bool UpdateStatus(long LDLAID, int statusID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"update Applications
                                            set StatusID=@statusID
                                            where 
                                            ApplicationID=(select LocalLicenseApplications.ApplicationID
                                            from LocalLicenseApplications where ID=@LDLAID)";
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@StatusID", statusID);
            command.Parameters.AddWithValue("@LDLAID", LDLAID);
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

       
    }
}
    