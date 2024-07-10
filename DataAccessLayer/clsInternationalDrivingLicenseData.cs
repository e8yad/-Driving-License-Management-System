using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectionString;
using DataAccessLayer;
namespace InternationalDrivingLicenseData
{
    public class clsInternationalDrivingLicenseData
    {

        public static DataTable GetAllIDLRelatedToPersonByNationalID(long NationalID)
        {
            SqlConnection connection=new SqlConnection(clsConnectionString.ConnectionString);
            string Query = @"SELECT        InternationalDrivingLicenses.IntLicenseNumber, InternationalDrivingLicenses.IssueDate, InternationalDrivingLicenses.ExpirationDate, InternationalDrivingLicenses.IsActive
FROM            InternationalDrivingLicenses INNER JOIN
                         Applications ON InternationalDrivingLicenses.ApplicationID = Applications.ApplicationID INNER JOIN
                         Persons ON Applications.PersonID = Persons.PersonID
						 where Persons.NationalID=@NationalID";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("NationalID", NationalID);
            DataTable dt= new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception e)
            {

                clsLogger.LogErrors(e);
            }
            return dt;

        }



    }
}
