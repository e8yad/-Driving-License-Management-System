using System;
using System.Data;
using System.Data.SqlClient;

using ConnectionString;
using DataAccessLayer;

namespace PersonsData
{
    public static class clsUsersData
    {
        public static DataTable GerAllUsers()
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "Select UserId,PersonID,UserName,IsActive from users";
            SqlCommand command = new SqlCommand(Query, connection);
            DataTable UsersTable = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    UsersTable.Load(reader);
                }
                reader.Close();

            }
            catch (Exception e)
            {
                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return UsersTable;
        }

        public static bool AddNewUser(ref long UserID ,string username, string password,bool IsActive,long PersonID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string Query = @"INSERT INTO 
                                         dbo.Users 
                                         ( 
                                             UserName, 
                                             Password, 
                                             IsActive, 
                                             Permissions, 
                                             PersonID 
                                         ) 
                                         VALUES 
                                         ( @UserName, @Password, @IsActive,@Permissions, @PersonID); select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName", username);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Permissions", DBNull.Value);
            

            try
            {
                connection.Open();
                object obj = command.ExecuteScalar();
                if (obj != null && long.TryParse(obj.ToString(), out long result))
                {
                    UserID = result;
                    return result > 0;
                }

            }
            catch (SqlException e)
            {
                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            UserID = -1;
            return false;
        }
        public static bool DeleteUser(long UserID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"delete from Users
                              where UserID=@UserID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID",UserID);
            int result = default;
            try
            {
                connection.Open();
                result = command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                // try to make events here 
                // if there is an error
                clsLogger.LogErrors(e);

            }
            finally { connection.Close(); }
            return result > 0;
        }
        public static bool FindUserByUserID(long UserID,ref string UserName,ref string Password,ref long PersonId,ref bool IsActive,ref int Permissions)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "Select * From Users Where UserID=@UserID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.Read())
                {
                    IsFound = true;
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    PersonId = (long)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];
                    Permissions = 0;
                    reader.Close();
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }
            return IsFound;
        }
        public static bool FindUserByUserName_Password(ref long UserID,string UserName, string Password, ref bool IsActive, ref long PersonId, ref int Permissions)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "Select * From Users Where UserName=@UserName and Password=@Password;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    UserID= (long)reader["UserID"];
                    PersonId = (long)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];
                    Permissions = 0;
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
        // is user exists by long PersonID
        public static bool IsUserExist(long PersonID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "SELECT x=1\r\nfrom Users where PersonID=@PersonID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
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
        
        public static bool UpdateUser(long UserID,string NewPassword, int isActive)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "update Users set Password=@Password,IsActive=@IsActive where UserId=@UserID;"; 
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Password", NewPassword);
            command.Parameters.AddWithValue("@IsActive", isActive);
        
            int result = 0;
            try
            {
                connection.Open();
                result=command.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return result > 0;
        }

         public static bool IsPersonRelatedToUser(long PersonID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "select x=1 From Users where PersonID=@PersonID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            bool result=false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                result = reader.HasRows;
            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }

            return result;

        }
        public static bool IsUserNameExist(string UserName)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "select x=1 From Users where UserName=@UserName";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            bool result = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                result = reader.HasRows;
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
