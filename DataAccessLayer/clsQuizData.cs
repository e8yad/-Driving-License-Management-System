using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ConnectionString;
using DataAccessLayer;
namespace QuizData
{
    public class clsQuizData
    {
       public static DataTable GetAllChoicesByQuetionID(long quetionID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string SQL = "SP_GetChoicesByQuetionID";  
            SqlCommand command=new SqlCommand(SQL, connection);
            command.CommandType=CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@QuetionID", quetionID);
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader=command.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception e) 
            {
                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return dt;
        }

       public static DataTable GetAllQustionByQuizID(int QuizID)
        {
            SqlConnection connection=new SqlConnection(clsConnectionString.ConnectionString);
            string SQL = "SP_GetQuizQutionsByQuizID";
            SqlCommand cmd=new  SqlCommand(@SQL, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QuizID", QuizID);
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader=cmd.ExecuteReader();
                if(reader.HasRows) { 
                    dt.Load(reader);
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }
            return dt;
        }

       public static long SaveExameResult(long ID,long PersonID,int QuizID,short Grade,DateTime StartDate, TimeSpan endTime,long TestId)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string SQL = "SP_AddExamResult";
            SqlCommand cmd= new SqlCommand(@SQL, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@QuizID", QuizID);
            cmd.Parameters.AddWithValue("@Grade", Grade);
            cmd.Parameters.AddWithValue("@ExamDate", StartDate);
            cmd.Parameters.AddWithValue("@endTime", endTime);
            cmd.Parameters.AddWithValue("@TestID", TestId);

            SqlParameter param;
            param = cmd.Parameters.AddWithValue("@ID", ID);
            param.Direction= ParameterDirection.Output;

            try
            {
                connection.Open();
                cmd.ExecuteScalar();
                if (PersonID != 0)
                    return ID;

            }
            catch (Exception e)
            {
                clsLogger.LogErrors(e);
            }
            finally { connection.Close(); }
            return -1;





        }

        

       


    }
}
