using PersonsData;
using System;
using System.Data;
using System.Data.SqlClient;
using ConnectionString;
using System.ComponentModel;
using DataAccessLayer;
namespace LocalDrivingLicenseData
{
    public class clsLocalDrivingLicenseData
    {

        public static DataTable GetAllLocalDrivingLicensesRelatedToPersonByPersonID(long PersonID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"SELECT      LocalDrivingLicenses.LicenseNumber, LocalDrivingLicenses.IssueDate, LocalDrivingLicenses.ExpirationDate,
                                            LicenseStatus.StatuesName, LocalDrivingLicenses.ClassID,LocalDrivingLicenses.IsActive
                                                        FROM            Drivers INNER JOIN
                         LocalDrivingLicenses ON Drivers.DriverID = LocalDrivingLicenses.DriverID 
                        INNER JOIN
                         LicenseStatus ON LocalDrivingLicenses.StatusID = LicenseStatus.StatusID
						 where Drivers.PersonID=@personID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@personID", PersonID);
            return _FillTable(connection,command);
        }

        public static DataTable GetAllLocalDrivingLicensesRelatedToPersonByNationalID(long NationalID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"SELECT        LocalDrivingLicenses.LicenseNumber, LocalDrivingLicenses.IssueDate, LocalDrivingLicenses.ExpirationDate,
                                                LicenseStatus.StatuesName, LocalDrivingLicenses.ClassID,LocalDrivingLicenses.IsActive
                                                        FROM            Drivers INNER JOIN
                         LocalDrivingLicenses ON Drivers.DriverID = LocalDrivingLicenses.DriverID INNER JOIN
                         Persons ON Drivers.PersonID = Persons.PersonID INNER JOIN
                         LicenseStatus ON LocalDrivingLicenses.StatusID = LicenseStatus.StatusID
						 where Persons.NationalID=@NationalID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalID", NationalID);
            return _FillTable(connection, command);
        }




        static DataTable _FillTable(SqlConnection connection, SqlCommand command)
        {

            DataTable LicenseTable = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    LicenseTable.Load(reader);
                }
                reader.Close();

            }
            catch (Exception e)
            {
                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return LicenseTable;
        }




        public static bool FindByLicenseNumber(long LicenseNumber,ref long LDLAID,ref DateTime IssueDate,ref DateTime ExpirationDate,ref decimal Fees,ref string Notes,
        ref int StatusID,ref long UserID,ref long PersonID,ref int ClassID,ref bool IsActive,ref bool IsDetained,ref long DriverID)
        {
            SqlConnection connection=new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"SELECT        LocalDrivingLicenses.*, Drivers.PersonID
                                FROM            Drivers INNER JOIN
                         LocalDrivingLicenses ON Drivers.DriverID = LocalDrivingLicenses.DriverID
                                 WHERE
                                 	LocalDrivingLicenses.LicenseNumber = @LicenseNumber";
            SqlCommand command =new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseNumber", LicenseNumber);

            bool Result = false;
            try
            {
                connection.Open();
                SqlDataReader reader= command.ExecuteReader();
                if (reader.Read())
                {
                    Result=true;
                    LDLAID = (long)reader["LDLA"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Fees = (decimal)reader["Fees"];
                    StatusID = (int)reader["StatusID"];
                    UserID = (long)reader["UserID"];
                    PersonID = (long)reader["PersonID"];
                    ClassID = (int)reader["ClassID"];
                    IsActive = (bool)reader["IsActive"];
                    DriverID = (long)reader["DriverID"];
                    IsDetained = (bool)reader["IsDetained"];
                    if (reader["Notes"]==DBNull.Value)
                        Notes=string.Empty;
                    else    
                     Notes = (string)reader["Notes"];

                }
                reader.Close();
            }
            catch (Exception e)
            {
                clsLogger.LogErrors(e);

            }
            finally { connection.Close(); }
            return Result;
            



        }


        public static bool FindByPersonNationalID(long NationalID,ref long LDLAID,ref long LicenseNumber, ref DateTime IssueDate, ref DateTime ExpirationDate, ref decimal Fees, ref string Notes,
        ref int StatusID, ref long UserID, ref long PersonID,ref int ClassID,ref bool IsActive, ref bool IsDetained, ref long DriverID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"SELECT        LocalDrivingLicenses.*, Drivers.PersonID
                                        FROM            Drivers INNER JOIN
                         LocalDrivingLicenses ON Drivers.DriverID = LocalDrivingLicenses.DriverID INNER JOIN
                         Persons ON Drivers.PersonID = Persons.PersonID
                                                        where Persons.NationalID=@NationalID";
            
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalID", NationalID);
            bool Result = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Result = true;
                    LDLAID = (long)reader["LDLA"];
                    LicenseNumber = (long)reader["LicenseNumber"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Fees = (decimal)reader["Fees"];
                    StatusID = (int)reader["StatusID"];
                    UserID = (long)reader["UserID"];
                    PersonID = (long)reader["PersonID"];
                    ClassID = (int)reader["ClassID"];
                    IsActive = (bool)reader["IsActive"];
                    IsDetained = (bool)reader["IsDetained"];
                    DriverID = (long)reader["DriverID"];
                    if (reader["Notes"] == DBNull.Value)
                        Notes = string.Empty;
                    else
                        Notes = (string)reader["Notes"];

                }
                reader.Close();
            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return Result;
        }

        // find by local  driving license application ID
        public static bool FindByLDLAID(  long LDLAID,ref long LicenseNumber, ref DateTime IssueDate, ref DateTime ExpirationDate, ref decimal Fees, ref string Notes,
        ref int StatusID, ref long UserID, ref long PersonID, ref int ClassID, ref bool IsActive, ref bool IsDetained, ref long DriverID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"SELECT        LocalDrivingLicenses.*, Drivers.PersonID
                                        FROM  Drivers INNER JOIN
                         LocalDrivingLicenses ON Drivers.DriverID = LocalDrivingLicenses.DriverID
                                                where LDLA=@LDLID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLID", LDLAID);

            bool Result = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Result = true;
                    LDLAID = (long)reader["LDLA"];
                    LicenseNumber = (long)reader["LicenseNumber"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Fees = (decimal)reader["Fees"];
                    StatusID = (int)reader["StatusID"];
                    UserID = (long)reader["UserID"];
                    PersonID = (long)reader["PersonID"];
                    ClassID = (int)reader["ClassID"];
                    IsDetained = (bool)reader["IsDetained"];
                    IsActive = (bool)reader["IsActive"];
                    DriverID = (long)reader["DriverID"];
                    if (reader["Notes"] == DBNull.Value)
                        Notes = string.Empty;
                    else
                        Notes = (string)reader["Notes"];

                }
                reader.Close();
            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return Result;




        }


        public static bool AddNewLocalDrivingLicense(ref long LicenseNumber,long LDLAID,DateTime IssueDate,DateTime ExpirationDate,decimal Fees,string Notes,
            int StatusID,long UserID,int ClassID,bool IsActive, bool IsDetained, long DriverID)
        {
            SqlConnection connection=new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"INSERT INTO MyDVLD.dbo.LocalDrivingLicenses
	                                (LDLA, IssueDate, ExpirationDate, Fees, Notes, StatusID, UserID,ClassID,IsActive,IsDetained,DriverID)
                            VALUES
	                    (@LDLAID, @IssueDate, @ExpirationDate, @Fees,@Notes, @StatusID, @UserID,@ClassID,@IsActive,@IsDetained,@DriverID);
                                                  select Scope_Identity();";


            SqlCommand command= new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LDLAID", LDLAID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@StatusID", StatusID);
            command.Parameters.AddWithValue("@ClassID", ClassID);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IsDetained", IsDetained);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            if(string.IsNullOrEmpty(Notes))
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);
            bool Result=false;
            try
            {
                connection.Open();
                object obj=command.ExecuteScalar();
                if (obj != null && long.TryParse(obj.ToString(), out LicenseNumber))
                    Result = true;
                else
                    LicenseNumber = -1;


            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }


            return Result;
            
        }


        public static bool UpdateDrivingLicenseStatus(long LicenseNumber,int StatusID)
        {
            SqlConnection connection=new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"UPDATE
                    	MyDVLD.dbo.LocalDrivingLicenses
                    SET
                    	StatusID = @StatusID
                    WHERE
	                LicenseNumber = @LicenseNumber";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseNumber", LicenseNumber);
            command.Parameters.AddWithValue("@StatusID", StatusID);

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

        public static bool IsPersonHasLicenseBefore(long PersonID,int ClassID)
        {
            SqlConnection Connection=new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"select X=1
                                    from LocalDrivingLicenses
                                    join Drivers on Drivers.DriverID=LocalDrivingLicenses.DriverID
                                    where Drivers.PersonID=@PersonID and ClassID=@ClassID";

            SqlCommand command =new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@ClassID", ClassID);
            bool Result=false;  
            try
            {
                Connection.Open();
                SqlDataReader reader=command.ExecuteReader();
                Result=reader.HasRows;
                reader.Close();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            { Connection.Close(); }
            return Result ;
        }

        public static bool IsLicenseExpiredAndActive(long LicenseNO)
        {
            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"select x=1
                                    from LocalDrivingLicenses 
                                    where LicenseNumber=@LicenseNO and GETDATE()>ExpirationDate and IsActive=1 ";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@LicenseNO", LicenseNO);
            bool Result = false;
            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Result = reader.HasRows;
                reader.Close();

            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally
            { Connection.Close(); }
            return Result;
        }


        public static bool DeactivateLicense(long LicenseNumber)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"update LocalDrivingLicenses
                            set IsActive = 0 where LicenseNumber =@LicenseNumber";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseNumber", LicenseNumber);
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
       public static bool IsLicenseNotExpiredAndActive(long LicenseNumber)
        {
            SqlConnection connection = new SqlConnection( clsConnectionString.ConnectionString);
            string Query = @"select x=1 
                        from LocalDrivingLicenses
                        where ExpirationDate>GETDATE() and IsActive=1 and LicenseNumber=@LicenseNO;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseNO", LicenseNumber);
            bool Result = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Result = reader.HasRows;
                reader.Close();

            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally
            { connection.Close(); }
            return Result;
        }

        // renew 





    }
}
