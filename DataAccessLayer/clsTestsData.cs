using System;
using System.Data;
using System.Data.SqlClient;
using ConnectionString;
using DataAccessLayer;
namespace TestsData
{
    public static class clsTestsData
    {
        public static bool AddNewTest(ref long TestID ,long LDLAID,int TestTypeID,DateTime TestDate,long PersonID,long UserID,decimal Fees,long RetakeTestApplicationID)
        {
            SqlConnection connection=new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"INSERT INTO dbo.Tests (TestTypeID, TestDate, isLocked, LocalDrivingLicenseApplicationID,PersonID,UserID,Fees,RetakeTestApplicationID) VALUES 
                                        (@TestTypeID, @TestDate,0, @LDLAID,@personID,@UserID,@Fees,@RetakeTestApplicationID);
                                                                                select Scope_Identity();";
            SqlCommand command=new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@TestDate", TestDate);
            command.Parameters.AddWithValue("@LDLAID", LDLAID);
            //command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Fees", Fees);
            if(RetakeTestApplicationID==default)
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            bool IsSaved =false;
            try
            {
                connection.Open();
                object obj = command.ExecuteScalar();
                if (long.TryParse(obj.ToString(), out TestID))
                    IsSaved = true;
            }
            catch (Exception e)
            {
                clsLogger.LogErrors(e);
            }
            finally
            {
                connection.Close();
            }
            return IsSaved;

        }


        //update date 
        /// update result 
        /// 

        public static bool UpdateResult(bool Result,long TestID,string Notes)
        {
            
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "Update Tests set Result=@Result,IsLocked=1,Notes=@Notes where TestID=@TestID";
            SqlCommand command=new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Result", Result);
            command.Parameters.AddWithValue("@TestID", TestID);
            if(string.IsNullOrEmpty(Notes))
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
            command.Parameters.AddWithValue("@Notes", Notes);
            return Update(ref command, ref connection);
        }
        public static bool UpdateTestDate(DateTime TestDate, long TestID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "Update Tests set TestDate=@TestDate where TestID=@TestID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestDate", TestDate);
            command.Parameters.AddWithValue("@TestID", TestID);
            return Update(ref command, ref connection);
        }

        public static bool Update(ref SqlCommand command,ref SqlConnection connection)
        {
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

        // to get test that  related to application and same type 
        public static DataTable FindRelatedTests(long LDLApplicationID,int TestTypeID)
        {
            SqlConnection connection=new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"select TestID,LocalDrivingLicenseApplicationID as LDLID,TestDate ,
                                                        case 
                                                        when Result=1 then 'Passed'
                                                        when Result=0 then 'Failed'
                                                        else
                                                        'No Result Yet' end as Result ,Islocked
                                                    from Tests where Tests.LocalDrivingLicenseApplicationID=@LDLApplicationID and TestTypeID=@TestTypeID;";
            SqlCommand command =new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            DataTable dt = new DataTable() ;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                   


                    reader.Close();
                
                }
            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e); 
            }
            finally { connection.Close(); }
            

            return dt;
        }

        private static  DataTable DeclareDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TestID", typeof(long));
            dt.Columns.Add("LDLID", typeof(long));
            dt.Columns.Add("Result",typeof(string));
            dt.Columns.Add("TestDate", typeof(DateTime));
            dt.Columns.Add("IsLocked", typeof(bool));
            return dt;
        }

        public static bool IsPassed(long LDLApplicationID, int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"select x=1
                                                    from Tests where Tests.LocalDrivingLicenseApplicationID=@LDLApplicationID and TestTypeID=@TestTypeID and Result=1;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            return HasRowsFromSqlCommand(ref command, ref connection);
        }


        public static bool IsTestExistAndNotLocked(long LDLApplicationID, int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"select x=1
                                                    from Tests where Tests.LocalDrivingLicenseApplicationID=@LDLApplicationID and TestTypeID=@TestTypeID and IsLocked=0;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            return HasRowsFromSqlCommand(ref command, ref connection);
        }
        public static bool IsFailBefore(long LDLApplicationID, int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"x=1
                                                    from Tests where Tests.LocalDrivingLicenseApplicationID=@LDLApplicationID and TestTypeID=@TestTypeID and Result=0;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            return HasRowsFromSqlCommand(ref command, ref connection);
        }
        //public static bool IsPassedInTest(long LDLApplicationID, int TestTypeID)
        //{
        //    SqlConnection connection = new SqlConnection(clsConnectionString.PersonsData);
        //    string Query = @"x=1
        //                                            from Tests where Tests.LocalDrivingLicenseApplicationID=@LDLApplicationID and TestTypeID=@TestTypeID and Result=1;";
        //    SqlCommand command = new SqlCommand(Query, connection);
        //    command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
        //    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
        //    return HasRowsFromSqlCommand(ref command, ref connection);
        //}

        public static bool HasRowsFromSqlCommand(ref SqlCommand command,ref SqlConnection connection)
        {
            bool result=false;
            try
            {
                connection.Open();
                result = command.ExecuteReader().HasRows;
            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        // if you want test application you can join by Person id and then choose is exists
        public static bool Find(long TestID, ref long lDLAID, ref bool result,ref bool isLocke, ref string notes, ref long personID,ref short TestTypeID, ref long UserID,ref  DateTime TestDate,ref decimal Fees)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            
            string Query = "Select * From Tests Where  TestId=@TestID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);
            bool IsFound=false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    IsFound = true;
                    lDLAID = (long)reader["LocalDrivingLicenseApplicationID"];
                    isLocke = (bool)reader["isLocked"];
                    if(reader["Notes"]==DBNull.Value)
                        notes=string.Empty;
                    else
                    notes = (string)reader["Notes"];
                    personID = (long)reader["PersonID"];
                    TestTypeID = ((short)(int)reader["TestTypeID"]);
                    UserID = (long)reader["UserID"];
                    TestDate = (DateTime)reader["TestDate"];
                    //PaymentID = (long)reader["PaymentID"];
                    Fees = (decimal)reader["Fees"];
                    
                    if (reader["Result"] == DBNull.Value)
                        result = default;
                    else
                        result = (bool)reader["Result"];
                    
                }
                reader.Close();

            }
            catch (Exception  e)
            {
                clsLogger.LogErrors(e);

            }
            finally { connection.Close();}
            return IsFound;

        }
        public static byte TotalTrialsPerTest(long LDLAID, int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"select COUNT(*) from Tests
                                where Tests.LocalDrivingLicenseApplicationID=@LDLAID and TestTypeID=@TestTypeID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLAID", LDLAID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            byte result = 0;

            try
            {
                connection.Open();
                object obj = command.ExecuteScalar();
                if (obj != null && byte.TryParse(obj.ToString(), out byte result1))
                    result = result1;

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
