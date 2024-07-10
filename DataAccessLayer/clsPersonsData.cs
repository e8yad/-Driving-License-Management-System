using System;
using System.Data.SqlClient;
using System.Data;
using ConnectionString;
using DataAccessLayer;


namespace PersonsData
{
    public static class clsPersonsData
    {
        public  delegate void onExceptionHappens();
        public static onExceptionHappens onException;
        public static bool FindByNationalID(long NationalID, ref long PersonID,ref string FirstName, ref string SecondName, ref string ThirdName, ref char Gender,ref string LastName,
            ref DateTime DateOfBirth, ref string PhoneNumber, ref ushort CountryID, ref string Email, ref string ImagePath,ref string Address)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "Select * From Persons Where NationalID=@NationalID;";
            SqlCommand command=new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalID", NationalID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    PersonID = (long)reader["PersonID"];
                    FirstName=(string)reader["FirstName"];
                    SecondName=(string)reader["SecondName"];
                    ThirdName=(string)reader["ThirdName"];
                    LastName=(string)reader["LastName"];
                   DateOfBirth =(DateTime)reader["DateOfBirth"];
                   PhoneNumber=(string)reader["PhoneNumber"];
                   CountryID=(ushort)((int)reader["CountryID"]);
                    Address = (string)reader["address"];
                    Gender = Convert.ToChar(((string)reader["Gender"]));
                    if (reader["Email"] == DBNull.Value)
                        Email = default;
                    else
                        Email = (string)reader["Email"];
              
                 if (reader["ImagePath"] == DBNull.Value)
                        ImagePath = default;
                 else
                    ImagePath =(string)reader["ImagePath"];
                    reader.Close();
                }
                else
                {
                    PersonID = -1;
                }

            }

            catch (Exception e)
            {
                PersonID = -1;
                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return PersonID > 0;

        }

        public static bool FindByPersonID(long PersonID ,ref long  NationalID , ref string FirstName, ref string SecondName, ref string ThirdName, ref char Gender, ref string LastName,
           ref DateTime DateOfBirth, ref string PhoneNumber, ref ushort CountryID, ref string Email, ref string ImagePath, ref string Address)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "Select * From Persons Where PersonID=@PersonID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    NationalID = (long)reader["NationalID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    CountryID = (ushort)((int)reader["CountryID"]);
                    Address = (string)reader["address"];
                    Gender = Convert.ToChar(((string)reader["Gender"]));
                    if (reader["Email"] == DBNull.Value)
                        Email = default;
                    else
                        Email = (string)reader["Email"];

                    if (reader["ImagePath"] == DBNull.Value)
                        ImagePath = default;
                    else
                        ImagePath = (string)reader["ImagePath"];
                    reader.Close();
                }
                else
                {
                    PersonID = -1;
                }

            }

            catch (Exception e)
            {
                PersonID = -1;
                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return PersonID > 0;

        }



        // Delete Person using ID 
        public static bool DeletePerson(long PersonID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"delete from Persons
                              where PersonID=@PersonID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            int result = default;
            try
            {
               connection.Open();
               result =command.ExecuteNonQuery();
                
            }
            catch (Exception  e)
            {
                // try to make events here 
                // if there is an error
                clsLogger.LogErrors(e);
            }
            finally { connection.Close() ; }
            return result > 0;
        }



        public static bool UpdatePerson(long PersonID, long NationalID,  string FirstName,  string SecondName,  string ThirdName, char Gender, string LastName,
            DateTime DateOfBirth,  string PhoneNumber,  ushort CountryID,  string Email,  string ImagePath,string Address)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"Update Persons
                            set 
                               NationalID=@NationalID,FirstName=@FirstName,SecondName=@SecondName,ThirdName=@ThirdName, LastName=@LastName,DateOfBirth=@DateOfBirth,PhoneNumber=@PhoneNumber,
                                CountryID=@CountryID,Email=@Email,ImagePath=@ImagePath,Address=@Address,Gender=@Gender where PersonID=@PersonID;";
            

            SqlCommand command= new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalID", NationalID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@CountryID", (int)CountryID);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            if(string.IsNullOrEmpty(Email))
                 command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
            command.Parameters.AddWithValue("@Email", Email);

            if (string.IsNullOrEmpty(ImagePath))
                 command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
            command.Parameters.AddWithValue("@ImagePath", ImagePath);
        
            int result = default;
            try
            {
                connection.Open();
                result= command.ExecuteNonQuery();      
            }
            catch (Exception e)
            {
                // try to make event
                clsLogger.LogErrors(e);
            }
            finally { connection.Close() ; }
            return result > 0;
        }

        public static bool  AddNewPerson(ref long PersonID, long NationalID, string FirstName, string SecondName, string ThirdName, char Gender, string LastName,
            DateTime DateOfBirth, string PhoneNumber, ushort CountryID, string Email, string ImagePath, string Address)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string Query = @"INSERT INTO 
                                   Persons 
                                    ( 
                                        NationalID, 
                                        Gender, 
                                        FirstName, 
                                        SecondName, 
                                        ThirdName, 
                                        LastName, 
                                        DateOfBirth, 
                                        PhoneNumber, 
                                        Address, 
                                        CountryID, 
                                        Email, 
                                        ImagePath 
                                    ) 
                                    VALUES 
                                    ( 
                                      @NationalID, 
                                      @Gender, 
                                      @FirstName, 
                                      @SecondName, 
                                      @ThirdName, 
                                      @LastName, 
                                      @DateOfBirth, 
                                      @PhoneNumber, 
                                      @Address, 
                                      @CountryID, 
                                      @Email, 
                                      @ImagePath);
                                    select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalID", NationalID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@CountryID", (int)CountryID);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Gender", Gender);

            if (string.IsNullOrEmpty(Email))
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);

            if (string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                connection.Open();
                object obj = command.ExecuteScalar();
                if (obj != null&& long.TryParse(obj.ToString(),out long result)) 
                {
                    PersonID = result;
                    return result>0; 
                }

            }
            catch (SqlException e)
            {
                clsLogger.LogErrors(e);
                //try to add exception event 
            }
            finally { connection.Close(); }
            PersonID = -1;
            return  false;
        }

        public static bool IsPersonExist(long NationalID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = " SELECT x=1\r\nfrom Persons where NationalID=@NationalID;"; 
            SqlCommand command=new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("NationalID", NationalID);
            bool isFound= false; 
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows ;
            }
            catch (Exception)
            {
            }
            finally { connection.Close(); }
          
            return isFound;

        }
        public static bool ISFullNameExists(string FirstName,string SecondName,string ThirdName,string lastName)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "select x =1\r\nfrom Persons\r\nwhere (firstName=@FirstName and secondName=@SecondName and ThirdName=@ThirdName and lastName=@lastName)";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", lastName);
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
        public static DataTable GetAllPersons() 
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = " \r\nSELECT Persons.PersonID, Persons.NationalID, Persons.Gender, Persons.FirstName, Persons.SecondName, Persons.ThirdName, Persons.LastName, Persons.DateOfBirth, Persons.PhoneNumber, Persons.Address, " +
                "\r\n  Countries.CountryName as Country, Persons.Email\r\nFROM Persons INNER JOIN\r\n  Countries ON Persons.CountryID = Countries.CountryID";
            SqlCommand command = new SqlCommand(Query, connection);
            DataTable PersonsTable=new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
              if(reader.HasRows)
              {
                    PersonsTable.Load(reader);
              }
              reader.Close();

            }
            catch (Exception e)
            {
                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return  PersonsTable;
        }

        public static DataTable GetAllCountryName()
        {
            SqlConnection connection=new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "select Countries.CountryName\r\nfrom Countries";
            SqlCommand sqlCommand = new SqlCommand(Query, connection);
            DataTable dataTable = new DataTable(); 
            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
               dataTable.Load(reader);
                reader.Close();
            }
            catch (Exception e)
            {
                clsLogger.LogErrors(e);
            }
            finally 
               {  connection.Close();}

              return dataTable;
        }

        public static string FindCountryName(int CountryId)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "select CountryName from Countries where CountryID=@CountryID";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@CountryID", CountryId);
            object CountryName=null;
            try
            {
                connection.Open();
                 CountryName=sqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
          return CountryName.ToString();
        }
        public static DateTime GetDateOfBirth(long PersonID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string Query = "select Persons.DateOfBirth from Persons where PersonID=@PersonID";
            SqlCommand command = new SqlCommand( Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                object obj=command.ExecuteScalar();
                if (obj != null && DateTime.TryParse(obj.ToString(), out DateTime DateOfBirth))
                    return DateOfBirth;

            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return DateTime.Now ;
        }


        //public static  DataTable GetAllPersonsFilterBy(string FilterBy,string value)
        //{
        //    SqlConnection connection = new SqlConnection(clsConnectionString.PersonsData);
        //    string Query = $" SELECT * from PersonsData where {FilterBy} like '' + @value + '%'";
        //    SqlCommand command = new SqlCommand(Query, connection);
        //    command.Parameters.AddWithValue("@value", value);
          
        //    DataTable PersonsTable = new DataTable();
        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            PersonsTable.Load(reader);
        //        }
        //        reader.Close();

        //    }
        //    catch (Exception)
        //    {

        //    }
        //    finally { connection.Close(); }
        //    return PersonsTable;
        //}



    }
}
